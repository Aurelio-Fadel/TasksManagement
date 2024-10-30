using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.Repositories
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
        void CreatePerson(Person person);
        Person UpdatePerson(Person person);
        Person DeletePerson(Person person);
        Person Find(int id);
    }
}
