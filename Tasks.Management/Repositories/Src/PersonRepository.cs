using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Management.DataContext;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.Repositories.Src
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TaskManagementContext TaskContext;

        public PersonRepository(TaskManagementContext taskContext)
        {
            TaskContext = taskContext;
        }

        public void CreatePerson(Person person)
        {
            TaskContext.Persons.Add(person);
            Save();
        }

        public Person DeletePerson(Person person)
        {
            UpdatePerson(person);
            Save();
            return person;
        }

        public Person Find(int id)
        {
            return TaskContext.Persons
                .Include(x => x.Tasks)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Person> GetPeople()
        {
            return TaskContext.Persons
                .Include(x => x.Tasks)
                .Where(x => x.IsActive)
                .ToList();
        }

        public Person UpdatePerson(Person person)
        {
            TaskContext.Persons.Update(person);
            Save();
            return person;
        }

        protected void Save()
        {
            TaskContext.SaveChanges();
        }
    }
}
