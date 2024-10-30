using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; // Corrigido para usar o namespace do EF Core
using TaskManagement.Management.DataContext;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.Repositories.Src
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementContext TaskContext;

        public TaskRepository(TaskManagementContext taskContext)
        {
            TaskContext = taskContext;
        }

        public void CreateTask(AssignedTask task)
        {
            TaskContext.Tasks.Add(task);
            Save();
        }

        public void DeleteTask(AssignedTask task)
        {
            TaskContext.Tasks.Remove(task);
            Save();
        }

        public AssignedTask Find(int id)
        {
            return TaskContext.Tasks
                .FirstOrDefault(x => x.Id == id);
        }

        public List<AssignedTask> GetTasks()
        {
            return TaskContext.Tasks.ToList();
        }

        public AssignedTask UpdateTask(AssignedTask task)
        {
            TaskContext.Tasks.Update(task);
            Save();
            return task;
        }

        protected void Save()
        {
            TaskContext.SaveChanges();
        }
    }
}
