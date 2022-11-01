
   using  Domain.Concrete;
using Domain.Contracts;

using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EdukimController : ControllerBase
    {
        //private readonly IEdukimDomain edukimDomain;
        private readonly IEdukimDomain _EdukimDomain;


        public EdukimController(IEdukimDomain edukimDomain)
        {
            _EdukimDomain = edukimDomain;


        }


        [HttpGet]
        [Route("GetAllEdukim")]
        public IActionResult GetAllEdukim()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var edukim = _EdukimDomain.getAllEdukim();

                if (edukim != null)
                {
                    return Ok(edukim);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]

        public IActionResult CreateEdukim([FromBody]EdukimPostDTO edukim) 
        { 
        

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (edukim is null)
                    return BadRequest("edukimPostDTO object is null");

                var CreateEdukim = _EdukimDomain.AddEdukim(edukim);
                return Ok(CreateEdukim);









            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }




        [HttpGet]
       
        [Route("GetById/{EduId}")]
        public IActionResult GetEdukimById([FromRoute]Guid EduId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var Edukim = _EdukimDomain.GetEdukimById(EduId);

                if (Edukim != null)
                    return Ok(Edukim);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpDelete]
      
        [Route("Delete/{EduId}")]
        public IActionResult DeleteEdukim(Guid EduId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                _EdukimDomain.DeleteEdukim(EduId);
                return NoContent();


            }
            catch (Exception ex)
            {
                return NotFound();
            }




        }

        [HttpPut]
        [Route("Put/{EduId}")]
        public IActionResult UpdateEdukim(Guid EduId, EdukimPostDTO edukim)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                _EdukimDomain.PutEdukim(EduId, edukim);

                return NoContent();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPatch]
        [Route("{EduId}")]
        public IActionResult UpdateEdukim(Guid EduId, JsonPatchDocument patchDoc)
        { 

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                _EdukimDomain.PatchEdukim(EduId, patchDoc);

                return NoContent();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }




    }
}