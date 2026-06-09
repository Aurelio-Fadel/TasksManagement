using TaskManagement.Management.Dtos;
using TaskManagement.Management.Entities;
using TaskManagement.Management.Repositories;
using Tasks.Management.Exceptions;

namespace TaskManagement.Management.Applications.Src
{
    public class TaskApplication : ITaskApplication
    {
        private readonly ITaskRepository TaskRepository;
        private readonly IPersonApplication PersonApplication;

        public TaskApplication(
            ITaskRepository taskRepository,
            IPersonApplication personApplication)
        {
            TaskRepository = taskRepository;
            PersonApplication = personApplication;
        }

        public IEnumerable<TaskDto> GetTasks()
        {
            return TaskRepository
                .GetTasks()
                .ToList()
                .ConvertToDtos();
        }

        public void CreateTask(TaskDto task)
        {
            var entity = task.ConvertToEntity();

            entity.SetCreate();

            TaskRepository.CreateTask(entity);

            CheckStatusPerson(task.PersonId);
        }

        public void UpdateTask(TaskDto task)
        {
            var entity = TaskRepository.Find(task.Id)
                ?? throw new NotFoundException($"Task with id {task.Id} not found.");

            entity.SetUpdateTask(task.ConvertToEntity());

            TaskRepository.UpdateTask(entity);

            CheckStatusPerson(task.PersonId);
        }

        public void DeleteTask(int taskId)
        {
            var entity = TaskRepository.Find(taskId) 
                ?? throw new NotFoundException($"Task with id {taskId} not found.");

            var personId = entity.PersonId;

            TaskRepository.DeleteTask(entity);

            CheckStatusPerson(personId);
        }

        private void CheckStatusPerson(int personId)
        {
            var person = PersonApplication.GetPerson(personId);

            PersonApplication.UpdatePerson(person);
        }
    }
}