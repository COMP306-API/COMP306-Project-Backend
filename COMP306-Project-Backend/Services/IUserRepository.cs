using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Services
{
    public interface IUserRepository
    {
        Task <UserResponseDto> Authenticate(AuthenticationDto authDto);
        Task<bool> IsExistingUser(string email);
        Task<UserResponseDto> GetById(string email);
        Task<User> UpdateName(string name, User user);
        Task<User> UpdateAddress(AddressDto addressDto);
        Task<User> UpdatePhoneNumber(string phoneNumber);
        Task<bool> UpdatePassword(AuthenticationDto authenticationDto);
        Task<User> Save(User userDto);
    }
}
