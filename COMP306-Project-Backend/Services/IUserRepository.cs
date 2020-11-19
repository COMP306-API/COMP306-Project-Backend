using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Services
{
    interface IUserRepository
    {
        Task<bool> Authenticate(AuthenticationDto authenticationDto);
        Task<bool> IsExistingUser(string email);
        Task<UserResponseDto> GetById(string email);
        Task<UserResponseDto> UpdateName(string name);
        Task<UserResponseDto> UpdateAddress(AddressDto addressDto);
        Task<UserResponseDto> UpdatePhoneNumber(string phoneNumber);
        Task<bool> UpdatePassword(AuthenticationDto authenticationDto);
        Task<UserResponseDto> Save(UserDto userDto);
    }
}
