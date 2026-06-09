using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<AssignedTask> GetTasks();
        void CreateTask(AssignedTask task);
        AssignedTask UpdateTask(AssignedTask task);
        void DeleteTask(AssignedTask task);
        AssignedTask Find(int id);
    }
}