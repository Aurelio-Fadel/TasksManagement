using Microsoft.AspNetCore.Mvc;
using TaskManagement.Management.Applications;
using TaskManagement.Management.Applications.Src;
using TaskManagement.Management.Dtos;
using Tasks.Management.Exceptions;

namespace TasksManagement.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonApplication PersonApplication;

        public PersonController(IPersonApplication personApplication)
        {
            PersonApplication = personApplication;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            try
            {
                var data = PersonApplication.GetPeople();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreatePerson(
            [FromBody] PersonDto person
        )
        {
            try
            {
                PersonApplication.CreatePerson(person);

                return Created(
                    string.Empty,
                    new
                    {
                        Message = "Person created successfully."
                    });
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdatePerson(
            [FromBody] PersonDto person
        )
        {
            try
            {
                PersonApplication.UpdatePerson(person);

                return Ok(new
                {
                    Message = "Person updated successfully."
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{personId}")]
        public IActionResult DeletePerson(int personId)
        {
            try
            {
                PersonApplication.DeletePerson(personId);

                return Ok(new
                {
                    Message = "Person deleted successfully."
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BusinessException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

