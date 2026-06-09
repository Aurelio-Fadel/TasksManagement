using Microsoft.AspNetCore.Mvc;
using TaskManagement.Management.Applications;
using TaskManagement.Management.Dtos;
using Tasks.Management.Exceptions;

namespace TasksManagement.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskApplication TaskApplication;

        public TaskController(ITaskApplication taskApplication)
        {
            TaskApplication = taskApplication;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            try
            {
                return Ok(TaskApplication.GetTasks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDto task)
        {
            try
            {
                TaskApplication.CreateTask(task);

                return Created(string.Empty, new
                {
                    Message = "Task created successfully."
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
        public IActionResult UpdateTask([FromBody] TaskDto task)
        {
            try
            {
                TaskApplication.UpdateTask(task);

                return Ok(new
                {
                    Message = "Task updated successfully."
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

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            try
            {
                TaskApplication.DeleteTask(taskId);

                return Ok(new
                {
                    Message = "Task deleted successfully."
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