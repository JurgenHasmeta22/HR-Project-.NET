using AutoMapper;
using DTO.AccountDTO;
using DTO.PervojePuneDTO;
using DTO.RoleDTO;
using DTO.UserDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        #region User
        public GeneralProfile()
        {
            #region userDTO
            CreateMap<AppUser, UserDTO>().ReverseMap();
            #endregion
            CreateMap<Projekt, ProjektDTO>().ReverseMap();
            CreateMap<ProjektPostDTO, Projekt>().ReverseMap();
            CreateMap<UserProjekt, UserProjektDTO>().ReverseMap();
            CreateMap<UserProjekt, UserProjektPostDTO>().ReverseMap();
            CreateMap<Edukim, EdukimDTO>().ReverseMap();
            CreateMap<EdukimPostDTO, Edukim>().ReverseMap();
            CreateMap<Certifikate, CertifikateDTO>().ReverseMap();
            CreateMap<CertifikatePostDTO, Certifikate>().ReverseMap();
            CreateMap<Roli, RoleDTO>().ReverseMap();
            CreateMap<PervojePune, PervojePuneDTO>().ReverseMap();
            CreateMap<UserPervojePune, UserPPDTO>().ReverseMap();
            CreateMap<PushimetZyrtare, PushimeDTO>().ReverseMap();
            CreateMap<PushimetZyrtare, PushimePostDTO>().ReverseMap();
            CreateMap<Leje, LejeDTO>().ReverseMap();
            CreateMap<Leje, LejePostDTO>().ReverseMap();
            CreateMap<UserRoli, UserRoliDTO>().ReverseMap();
            CreateMap<AppUser, UserPostDTO>().ReverseMap();
            CreateMap<Roli, RoliDTO>().ReverseMap();
            CreateMap<Projekt, Projekt1DTO>().ReverseMap();

            CreateMap<Aftesi, AftesiDTO>().ReverseMap();
            CreateMap<UserProjekt, UserProjekt1DTO>().ReverseMap();
            CreateMap<UserEdukim, UserEdukimDTO>().ReverseMap();
            CreateMap<UserAftesi, UserAftesiDTO>().ReverseMap();
            CreateMap<UserCertifikate, UserCertifikateDTO>().ReverseMap();
            CreateMap<UserPervojePune, UserPervojePuneDTO>().ReverseMap();
            CreateMap<DetajeUser, DetajeUserDTO>().ReverseMap();
            CreateMap<DokumentaDetajeUser, DokumentaDetajeUserDTO>().ReverseMap();
            CreateMap<PervojePune, PervojePuneDTO1>().ReverseMap();
            CreateMap<AppUser, UserDTO1>().ReverseMap();
            
            CreateMap<Leje, LejeDTOwithUser>().ReverseMap();




            CreateMap<UserRoli, UserRoleDTO>().ReverseMap();
            CreateMap<RegisterDTO, AppUser>().ReverseMap();
            CreateMap<PostPutPPDTO, PervojePune>().ReverseMap();
            CreateMap<PostPutRoleDTO, Roli>().ReverseMap();

            CreateMap<AppUser, TokenDTO>().ReverseMap();
        }

        #endregion


    }
}
