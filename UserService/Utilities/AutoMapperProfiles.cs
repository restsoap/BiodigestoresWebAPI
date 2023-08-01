using AutoMapper;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {
            //Mapear modelo usuario
            CreateMap<UserCreationDTOs, User>();

            CreateMap<User, UserCreationDTOs>().ReverseMap();

            CreateMap<User, UserDTO>();
        }
    }
}