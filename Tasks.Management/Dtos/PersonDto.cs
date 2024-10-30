using AutoMapper;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Birth { get; set; }
        public List<TaskDto>? Tasks { get; set; }
    }

    public static class PersonConverter
    {
        public static PersonDto ConvertToDto(this Person entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>();
            });
            var mapper = config.CreateMapper();

            PersonDto dto = mapper.Map<PersonDto>(entity);

            return dto;
        }

        public static List<PersonDto> ConvertToDtos(this List<Person> entity)
        {
            List<PersonDto> reasons = new List<PersonDto>();
            foreach (var reason in entity)
            {
                reasons.Add(ConvertToDto(reason));
            }

            return reasons;

        }

        public static Person ConvertToEntity(this PersonDto entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDto, Person>();
            });
            var mapper = config.CreateMapper();

            Person reason = mapper.Map<Person>(entity);

            return reason;
        }
    }
}
