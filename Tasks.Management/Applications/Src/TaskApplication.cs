using System.Threading.Tasks;
using TaskManagement.Management.Dtos;
using TaskManagement.Management.Entities;
using TaskManagement.Management.Repositories;
using TaskManagement.Management.Repositories.Src;

namespace TaskManagement.Management.Applications.Src
{
    public class TaskApplication : ITaskApplication
    {
        private ITaskRepository TaskRepository;
        private readonly IPersonApplication PersonApplication;

        public TaskApplication(ITaskRepository taskRepository, IPersonApplication personApplication)
        {
            TaskRepository = taskRepository;
            PersonApplication = personApplication;
        }

        public List<TaskDto> GetTasks()
        {
            return TaskRepository.GetTasks().ConvertToDtos();

        }
        public bool CreateTask(TaskDto task)
        {
            try
            {
                var entity = task.ConvertToEntity();
                entity.SetCreate();
                TaskRepository.CreateTask(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateTask(TaskDto task)
        {
            try
            {
                var entity = TaskRepository.Find(task.Id);
                if (entity == null)
                {
                    throw new ArgumentException("Não foi possível encontrar essa tarefa");
                }
                entity.SetUpdateTask(task.ConvertToEntity());
                TaskRepository.UpdateTask(entity);
                CheckStatusPerson(task.PersonId);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        private void CheckStatusPerson(int personId)
        {
            Person person = PersonApplication.GetPerson(personId).ConvertToEntity();
            if (person.Tasks.Count < 1)
            {
                person.IsDisponible = true;
            }
            else
            {
                person.IsDisponible = false;
            }

            PersonApplication.UpdatePerson(person.ConvertToDto());
        }

        public bool DeleteTask(int taskId)
        {
            try
            {
                var entity = TaskRepository.Find(taskId);
                if (entity == null)
                {
                    throw new ArgumentException("Não foi possível encontrar essa tarefa");
                }
                TaskRepository.DeleteTask(entity);
                CheckStatusPerson(entity.PersonId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}