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
            CreateMap<User, UserDto>();
            CreateMap<User, UserResponseDto>();
            CreateMap<User, AddressDto>();
            CreateMap<User, AuthenticationDto>();
            CreateMap<Log, LogDto>();
        }
    }
}