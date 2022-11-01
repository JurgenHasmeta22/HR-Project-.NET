using DTO.UserDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserDomain
    {
        IList<UserDTO1> GetAllUsers();
     
        UserDTO GetUserById(Guid id);
        UserDTO PutUser(Guid UserId, UserPostDTO user);
        void AddUserProject(Guid UserId, Guid ProjektId, UserProjektPostDTO userprojekt);
        void DeleteUserProject(Guid UserId, Guid ProjektId);
        bool KerkoLeje(Guid UserId, LejePostDTO leje);
        void DeleteLeje(Guid UserId);
        void UpdateLeje(Guid UserId, LejePostDTO leje);
        public void UpdateBalance(Guid userId);
        public int KontrolloLejen(Leje leje);
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru);
        void ApproveLeje(Guid LejeId);
        void DisapproveLeje(Guid LejeId);
       
        // IList<UserDTO1> GetAllUsers1();


    }
}
