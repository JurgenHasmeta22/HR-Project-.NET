using Domain.Concrete;
using Domain.Contracts;
using DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;

        public UserController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        //[Authorize (Roles = "HR Manager")]
        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var users = _userDomain.GetAllUsers();

                if (users != null)
                {
                    return Ok(users);
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


        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _userDomain.GetUserById(userId);

                if (user != null)
                    return Ok(user);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("{UserId}")]
        public IActionResult UpdateProject(Guid UserId, UserPostDTO user)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                var userupdated = _userDomain.PutUser(UserId, user);

                return Ok(userupdated);

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        [HttpPost]
        [Route("AssignProjectToUser/{UserId},{ProjektId}")]
        public IActionResult AssignProjectToUser([FromRoute] Guid UserId,[FromRoute] Guid ProjektId,[FromBody] UserProjektPostDTO userprojekt)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (userprojekt is null)
                    return BadRequest("UserProjektPostDTO object is null");

                 _userDomain.AddUserProject(UserId,ProjektId,userprojekt);
                return Ok();
                // return CreatedAtRoute("", new { id = createdProject.ProjektId,emri = createdProject.EmriProjekt,pershkrimi = createdProject.PershkrimProjekt }, createdProject);

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        [HttpDelete]
        [Route("DeleteMappedProjectToUser/{UserId},{ProjektId}")]
        public IActionResult DeleteMappedProjectToUser([FromRoute] Guid UserId, [FromRoute] Guid ProjektId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

               

                _userDomain.DeleteUserProject(UserId, ProjektId);
                return Ok();
                // return CreatedAtRoute("", new { id = createdProject.ProjektId,emri = createdProject.EmriProjekt,pershkrimi = createdProject.PershkrimProjekt }, createdProject);

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        [HttpPost]
        [Route("AssignLejeToUser/{UserId}")]

        public IActionResult CreateLeje([FromRoute] Guid UserId, [FromBody] LejePostDTO leje)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (leje is null)
                    return BadRequest("LejePostDTO object is null");

                _userDomain.KerkoLeje(UserId, leje);
                return Ok();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }


        [HttpDelete]
        [Route("DeleteLejeOfUser/{LejeId}")]
        public IActionResult DeleteLeje(Guid LejeId)
        {


            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _userDomain.DeleteLeje(LejeId);

                return NoContent();

            }

            catch (Exception ex)
            {
                return NotFound();
            }



        }

        [HttpPut]
        [Route("UpdateLeje/{LejeId}")]
        public IActionResult UpdateLeje(Guid LejeId, LejePostDTO leje)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                _userDomain.UpdateLeje(LejeId, leje);

                return NoContent();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost]
        [Route("ApproveLeje/{LejeId}")]

        public IActionResult ApproveLeje([FromRoute] Guid LejeId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

               

                _userDomain.ApproveLeje(LejeId);
                return Ok();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost]
        [Route("DisapproveLeje/{LejeId}")]

        public IActionResult DisapproveLeje([FromRoute] Guid LejeId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }



                _userDomain.DisapproveLeje(LejeId);
                return Ok();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        [HttpPut]
        [Route("UpdateBalance/{UserId}")]
        public IActionResult UpdateBalance(Guid UserId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                _userDomain.UpdateBalance(UserId);

                return NoContent();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }




    }

   
}

