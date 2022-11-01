using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public  interface IEdukimDomain
    {
        EdukimDTO AddEdukim(EdukimPostDTO edukim);
        IList<EdukimDTO> getAllEdukim();
        EdukimDTO GetEdukimById(Guid EduId);

        void PutEdukim(Guid EduId, EdukimPostDTO edukim);
        void DeleteEdukim(Guid EduId);
        void PatchEdukim(Guid EduId, JsonPatchDocument patchDoc);

    }
}
