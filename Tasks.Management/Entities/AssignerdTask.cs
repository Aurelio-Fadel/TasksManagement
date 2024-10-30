using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Management.Entities
{
    public class AssignedTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public Person Person { get; set; }

        public int PersonId { get; set; }


        public void SetCreate()
        {
            this.CreationDate = DateTime.Now;
        }

        public void SetUpdateTask(AssignedTask NewEntity)
        {
            var newData = NewEntity;

            this.Id = NewEntity.Id;
            this.Title = NewEntity.Title;
            this.Description = NewEntity.Description;
            this.Status = NewEntity.Status;
            this.Person = NewEntity.Person;
            this.PersonId = NewEntity.PersonId;
        }
    }
}
