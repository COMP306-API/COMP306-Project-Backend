using AutoMapper;
using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<User, AddressDto>().ReverseMap();
            CreateMap<User, AuthenticationDto>().ReverseMap();
            CreateMap<Log, LogDto>().ReverseMap();
         
        }
    }
}