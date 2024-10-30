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
        List<TaskDto> GetTasks();
        bool CreateTask(TaskDto task);
        bool UpdateTask(TaskDto task);
        bool DeleteTask(int taskId);
    }
}
