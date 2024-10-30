using Microsoft.AspNetCore.Mvc;
using TaskManagement.Management.Applications;
using TaskManagement.Management.Dtos;

namespace TasksManagement.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskApplication TaskApplication;

        public TaskController(ITaskApplication taskApplication)
        {
            TaskApplication = taskApplication;
        }

        [HttpGet("getTasks")]
        public IActionResult GetTasks()
        {
            try
            {
                var data = TaskApplication.GetTasks();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("createTask")]
        public IActionResult CreateTask(TaskDto task)
        {
            try
            {
                var data = TaskApplication.CreateTask(task);
                if (data)
                {
                    return Ok("Tarefa criada com sucesso");
                }
                return BadRequest("Falha ao criar tarefa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updateTask")]
        public IActionResult UpdateTask(TaskDto task)
        {
            try
            {
                var data = TaskApplication.UpdateTask(task);
                if (data)
                    return Ok("Tarefa atualizada com sucesso");
                return BadRequest("Falha na atualização da tarefa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("deleteTask")]
        public IActionResult DeleteTask(int taskId)
        {
            try
            {
                var data = TaskApplication.DeleteTask(taskId);
                if (data)
                    return Ok("Tarefa excluida com sucesso");
                return BadRequest("Erro na exclusão da tarefa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
