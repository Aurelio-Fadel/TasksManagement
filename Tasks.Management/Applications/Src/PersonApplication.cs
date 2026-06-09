using TaskManagement.Management.Dtos;
using TaskManagement.Management.Repositories;
using TaskManagement.Management.Repositories.Src;
using Tasks.Management.Exceptions;

namespace TaskManagement.Management.Applications.Src
{
    public class PersonApplication : IPersonApplication
    {
        private readonly IPersonRepository PersonRepository;

        public PersonApplication(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public List<PersonDto> GetPeople()
        {
            return PersonRepository
                .GetPeople()
                .Select(x => x.ConvertToDto())
                .ToList();
        }

        public PersonDto GetPerson(int id)
        {
            var entity = PersonRepository.Find(id);

            return entity == null ? throw new NotFoundException($"User with id {id} not found.") : entity.ConvertToDto();
        }

        public void CreatePerson(PersonDto person)
        {
            var entity = person.ConvertToEntity();

            entity.Tasks.ForEach(x => x.SetCreate());

            if (!entity.IsValidEmail(person.Email))
            {
                throw new BusinessException("Email with invalid format.");
            }

            entity.SetCreate();

            PersonRepository.CreatePerson(entity);
        }

        public void UpdatePerson(PersonDto person)
        {
            var entity = PersonRepository.Find(person.Id) ?? throw new NotFoundException($"User with id {person.Id} not found.");

            if (!entity.IsValidEmail(person.Email))
            {
                throw new BusinessException("Email with invalid format.");
            }

            entity.SetUpdatePerson(person.ConvertToEntity());

            PersonRepository.UpdatePerson(entity);
        }

        public void DeletePerson(int personId)
        {
            var entity = PersonRepository.Find(personId) ?? throw new NotFoundException($"User with id {personId} not found.");
            if (entity.Tasks.Any())
            {
                throw new BusinessException(
                    "Cannot delete user with active tasks.");
            }

            entity.SetDelete();

            PersonRepository.UpdatePerson(entity);
        }
    }
}