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
        List<PersonDto> GetPeople();
        PersonDto GetPerson(int id);
        void CreatePerson(PersonDto person);
        void UpdatePerson(PersonDto person);
        void DeletePerson(int personId);
    }
}