using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskManagement.Management.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Birth { get; set; }
        public List<AssignedTask> Tasks { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Deleted { get; set; }
        public bool IsDisponible { get; set; }
        public bool IsActive { get; set; }

        public void SetCreate()
        {
            IsDisponible = true;
            Created = DateTime.Now;
            IsActive = true;
        }

        public void SetUpdatePerson(Person NewEntity)
        {
            var newData = NewEntity;

            this.Id = NewEntity.Id;
            this.Email = NewEntity.Email;
            this.Name = NewEntity.Name;
            this.Birth = NewEntity.Birth;
            UpdateTasks(newData.Tasks.ToList());
        }

        public void SetDelete()
        {
            Deleted = DateTime.Now;
            IsDisponible = false;
            IsActive = false;
        }

        public void UpdateTasks(List<AssignedTask> tasks)
        {
            foreach (var ca in tasks)
            {
                if (!this.Tasks.Exists(a => a.Id == ca.Id))
                    this.Tasks.Add(ca);
            }

            foreach (var task in this.Tasks.ToList())
            {
                if (!tasks.Exists(ca => task.Id == ca.Id))
                    this.Tasks.Remove(task);
            }
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

    }
}