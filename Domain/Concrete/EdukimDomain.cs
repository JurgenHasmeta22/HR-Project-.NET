using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EdukimDomain : DomainBase, IEdukimDomain

    {
        public EdukimDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IEdukimRepository EdukimRepository => _unitOfWork.GetRepository<IEdukimRepository>();

        public EdukimDTO AddEdukim(EdukimPostDTO edukim)
        {
            var edukimEntity = _mapper.Map<Edukim>(edukim);
            edukimEntity.EduId = Guid.NewGuid();
            var edukimFinal = EdukimRepository.Add(edukimEntity);
            var edukimToReturn = _mapper.Map<EdukimDTO>(edukimFinal);
            _unitOfWork.Save();
            return edukimToReturn;
        }

        public void DeleteEdukim(Guid EduId)
        {
            try
            {
                var edukim = EdukimRepository.GetById(EduId);
                if (edukim is null)
                    throw new Exception();
                EdukimRepository.Remove(EduId);
                _unitOfWork.Save();

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<EdukimDTO> getAllEdukim()
        {
            IEnumerable<Edukim> user = EdukimRepository.GetAll();

            var test = _mapper.Map<IList<EdukimDTO>>(user);
            return test;
        }

        public EdukimDTO GetEdukimById(Guid EduId)
        {
            var edukim = EdukimRepository.GetById(EduId);
            return _mapper.Map<EdukimDTO>(edukim);
        }

        public void PatchEdukim(Guid EduId, JsonPatchDocument patchDoc)
        {
            var edukim = EdukimRepository.GetById(EduId);
            if (edukim is null)
                throw new Exception();
            patchDoc.ApplyTo(edukim);
            _unitOfWork.Save();

        }

        public void PutEdukim(Guid EduId, EdukimPostDTO edukim)
        {
            var Edukimentity = EdukimRepository.GetById(EduId);

            if (Edukimentity is null)
                throw new Exception();
            Edukimentity = _mapper.Map<EdukimPostDTO, Edukim>(edukim, Edukimentity);

            EdukimRepository.Update(Edukimentity);
            _unitOfWork.Save();
        }
    }
}
