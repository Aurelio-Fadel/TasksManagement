using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public PersonDto? Person { get; set; }

        public int PersonId { get; set; }
    }

    public static class TaskConverter
    {
        public static TaskDto ConvertToDto(this AssignedTask entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssignedTask, TaskDto>();
            });
            var mapper = config.CreateMapper();

            TaskDto dto = mapper.Map<TaskDto>(entity);

            return dto;
        }

        public static List<TaskDto> ConvertToDtos(this List<AssignedTask> entity)
        {
            List<TaskDto> tasks = new List<TaskDto>();
            foreach (var task in entity)
            {
                tasks.Add(ConvertToDto(task));
            }

            return tasks;

        }

        public static AssignedTask ConvertToEntity(this TaskDto entity)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskDto, AssignedTask>();
            });
            var mapper = config.CreateMapper();

            AssignedTask reason = mapper.Map<AssignedTask>(entity);

            return reason;
        }
    }
}

