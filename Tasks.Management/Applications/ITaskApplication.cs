using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Management.Dtos;

namespace TaskManagement.Management.Applications
{
    public interface ITaskApplication
    {
        IEnumerable<TaskDto> GetTasks();
        void CreateTask(TaskDto task);
        void UpdateTask(TaskDto task);
        void DeleteTask(int taskId);
    }
}
