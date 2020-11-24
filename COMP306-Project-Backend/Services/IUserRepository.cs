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
        Task<IEnumerable<UserResponseDto>> GetAllBusinesses();
        Task<bool> UpdateName(string email, string name);
        Task<bool> UpdateAddress(string email, AddressDto addressDto);
        Task<bool> UpdatePhoneNumber(string email, string phoneNumber);
        Task<bool> UpdatePassword(AuthenticationDto authenticationDto);
        Task<string> Save(UserDto userDto);
        Dictionary<string, string> StringToDictionary(string value);
    }
}
