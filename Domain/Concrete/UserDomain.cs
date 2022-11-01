using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class UserDomain : DomainBase, IUserDomain
    {
        public UserDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IUserRepository userRepository => _unitOfWork.GetRepository<IUserRepository>();
       private IProjektRepository projektRepository => _unitOfWork.GetRepository<IProjektRepository>();
        private ILejeRepository lejeRepository => _unitOfWork.GetRepository<ILejeRepository>();
        private IDetajeUserRepository detajeUserRepository => _unitOfWork.GetRepository<IDetajeUserRepository>();
        private IPushimetZyrtareRepository pushimeRepository => _unitOfWork.GetRepository<IPushimetZyrtareRepository>();

        
        
        public IList<UserDTO1> GetAllUsers()
        {
            IEnumerable<AppUser> user = userRepository.GetAll();
           
            var test = _mapper.Map<IList<UserDTO1>>(user);
            return test;
        }

        public IList<UserDTO1> GetAllUsers1()
        {
            IEnumerable<AppUser> user = userRepository.getAllusers();
            var test = _mapper.Map<IList<UserDTO1>>(user);
                return test;
           

        }
        
        
        public UserDTO GetUserById(Guid id)
        {
            AppUser user = userRepository.GetById(id);

            return _mapper.Map<UserDTO>(user);
        }
        public UserDTO PutUser(Guid UserId, UserPostDTO user)
        {
            var userentity = userRepository.GetById(UserId);

            if (userentity is null)
                throw new Exception();
            userentity = _mapper.Map<UserPostDTO, AppUser>(user, userentity);

            userRepository.Update(userentity);
            _unitOfWork.Save();
            return _mapper.Map<UserDTO>(userentity);
        }
        public void AddUserProject(Guid UserId,Guid ProjektId,UserProjektPostDTO userprojekt)
        {
            var user = userRepository.GetById(UserId);
            if (user == null)
                throw new ArgumentException("User does not exist");

            if (user.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (projektRepository.GetById(ProjektId) == null)
                throw new ArgumentException("Project does not exist");

            var userprojektentity = _mapper.Map<UserProjekt>(userprojekt);
            userprojektentity.UserId = UserId;
            userprojektentity.ProjektId = ProjektId;


            if (user.UserProjekts.Contains(userprojektentity) == true)
                throw new ArgumentException("User already has project");

            user.UserProjekts.Add(userprojektentity);
            _unitOfWork.Save();
        }
        public void DeleteUserProject(Guid UserId, Guid ProjektId)
        {
            var user = userRepository.GetById(UserId);
            var userprojects = user.UserProjekts;
            foreach(var userproject in userprojects)
            {
                if (userproject.UserId == UserId && userproject.ProjektId == ProjektId)
                    userprojects.Remove(userproject);

            }
            _unitOfWork.Save();
        }

        public bool KerkoLeje(Guid UserId,LejePostDTO leje)
        {
            //UpdateBalance(UserId);
            int diteLeje = KontrolloLejen(_mapper.Map<Leje>(leje));
            //int diteLeje = (int)(leje.DataMbarim - leje.DataFillim).TotalDays;
            int balanca = userRepository.GetById1(UserId).BalancaLeje;

            if (diteLeje <= balanca)
            {
                var lejeEntity = _mapper.Map<Leje>(leje);
                lejeEntity.LejeId = Guid.NewGuid();
                lejeEntity.UserId = UserId;
                lejeEntity.Aprovuar = 2;
                //lejeEntity.DokumentLeje = _photoDomain.AddPhoto(leje.DokumentLeje);

                var lejeFinal = lejeRepository.Add(lejeEntity);

                
                _unitOfWork.Save();
                return true;
            }
            else return false;
        }
        public void DeleteLeje(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            if (leje is null)
                throw new Exception();

            lejeRepository.Remove(LejeId);

            _unitOfWork.Save();
        }
        public void UpdateLeje(Guid LejeId, LejePostDTO leje)
        {
            var lejeEntity = lejeRepository.GetById(LejeId);

            if (lejeEntity is null)
                throw new Exception();
            lejeEntity = _mapper.Map<LejePostDTO, Leje>(leje, lejeEntity);

            lejeRepository.Update(lejeEntity);
            _unitOfWork.Save();
        }
        public void UpdateBalance(Guid userId)
        {
            var user = userRepository.GetById(userId);
            IEnumerable<Leje> lejet = user.Lejes;

            var detajet = user.DetajeUsers.First();
            int count = 0;

            foreach (var x in lejet)
            {
                if (x.Aprovuar == 1 && x.TipiLeje == "Pushime")
                {
                    count += KontrolloLejen(x);
                    //count = count + (int)(x.DataMbarim - x.DataFillim).TotalDays;
                }
            }
            if (detajet != null)
            {
                double months = Math.Abs((detajet.DataFillim.Month - DateTime.Now.Month) + 12 * (detajet.DataFillim.Year - DateTime.Now.Year));
                int shtimiBalances = (int)Math.Round(months * 1.7);
                user.BalancaLeje = 0;
                user.BalancaLeje += shtimiBalances;
                user.BalancaLeje -= count;
                userRepository.Update(user);
                _unitOfWork.Save();
            }
           

        }
        public int KontrolloLejen(Leje leje)
        {
            int count = 0;
            foreach(DateTime day in EachDay(leje.DataFillim, leje.DataMbarim))
            {
                if (pushimeRepository.GetByDate(day)==null)
                {
                    if ((day.DayOfWeek == DayOfWeek.Saturday) || (day.DayOfWeek == DayOfWeek.Sunday))
                        continue;
                    else
                        ++count;
                }
               
                else
                {
                    
                }
            }
            return count;
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        public void ApproveLeje(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            leje.Aprovuar = 1;
            UpdateBalance(leje.UserId);
            lejeRepository.Update(leje);
            _unitOfWork.Save();
        }
        public void DisapproveLeje(Guid LejeId)
        {
            var leje = lejeRepository.GetById(LejeId);
            leje.Aprovuar = 0;
            //UpdateBalance(leje.UserId);
            lejeRepository.Update(leje);
            _unitOfWork.Save();
        }
    }
}
