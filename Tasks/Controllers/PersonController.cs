using Microsoft.AspNetCore.Mvc;
using TaskManagement.Management.Applications;
using TaskManagement.Management.Dtos;

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

        [HttpGet("getPeople")]
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

        [HttpPost("createPeople")]
        public IActionResult CreatePeople(PersonDto person)
        {
            try
            {
                var data = PersonApplication.CreatePerson(person);
                if (data)
                {
                    return Ok("Pessoa criada com sucesso");
                }
                return BadRequest("Falha ao criar pessoa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updatePeople")]
        public IActionResult UpdatePeople(PersonDto person)
        {
            try
            {
                var data = PersonApplication.UpdatePerson(person);
                if (data)
                    return Ok("Informações atualizadas com sucesso");
                return BadRequest("Falha na atualização das informações");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("deletePeople")]
        public IActionResult UpdatePeople(int personId)
        {
            try
            {
                var data = PersonApplication.DeletePerson(personId);
                if (data)
                    return Ok("Pessoa excluida com sucesso");
                return BadRequest("Erro na exclusão da pessoa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

