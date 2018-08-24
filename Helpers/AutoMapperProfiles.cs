using AutoMapper;
using dotnetJwt.Dtos;
using dotnetJwt.Entities;

namespace TaskProject.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {

          CreateMap<TaskEntity, TaskDto>().ReverseMap();
        
        }
    }
}