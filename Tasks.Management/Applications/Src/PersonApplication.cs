using TaskManagement.Management.Dtos;
using TaskManagement.Management.Repositories;

namespace TaskManagement.Management.Applications.Src
{
    public class PersonApplication : IPersonApplication
    {
        private IPersonRepository PersonRepository;
        public PersonApplication(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }
        public PeopleDto GetPeople()
        {
            var personsDto = new PeopleDto();
            personsDto.Peoples = PersonRepository.GetPeople().ConvertToDtos();

            return personsDto;

        }
        public PersonDto GetPerson(int id)
        {
            return PersonRepository.Find(id).ConvertToDto();
        }

        public bool CreatePerson(PersonDto person)
        {
            try
            {
                var entity = person.ConvertToEntity();
                if (!entity.IsValidEmail(person.Email))
                {
                    throw new ArgumentException("Email com formato inválido");
                }

                entity.SetCreate();
                PersonRepository.CreatePerson(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool UpdatePerson(PersonDto person)
        {
            try
            {
                var entity = PersonRepository.Find(person.Id);
                if (entity == null)
                {
                    throw new ArgumentException("Não foi possível encontrar essa pessoa");
                }
                entity.SetUpdatePerson(person.ConvertToEntity());
                PersonRepository.UpdatePerson(entity);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public bool DeletePerson(int personId)
        {
            try
            {
                var entity = PersonRepository.Find(personId);
                if (entity == null)
                {
                    throw new ArgumentException("Não foi possível encontrar essa pessoa");
                }

                if (entity.Tasks.Count > 0)
                {
                    throw new ArgumentException("Não é permitido excluir uma pessoa que possui tarefas ativas.");
                }
                entity.SetDelete();
                PersonRepository.UpdatePerson(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}