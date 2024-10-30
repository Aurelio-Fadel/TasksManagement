using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Management.Dtos;

namespace TaskManagement.Management.Applications
{
    public interface IPersonApplication
    {
        PeopleDto GetPeople();
        PersonDto GetPerson(int personId);
        bool CreatePerson(PersonDto person);
        bool UpdatePerson(PersonDto person);
        bool DeletePerson(int personId);
    }
}