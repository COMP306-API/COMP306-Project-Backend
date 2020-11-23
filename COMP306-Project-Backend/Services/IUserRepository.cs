using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Services
{
    public interface IUserRepository
    {
        Task <User> Authenticate(string email, string password);
        Task<bool> IsExistingUser(string email);
        Task<User> GetById(string email);
        Task<User> UpdateName(string name, User user);
        Task<User> UpdateAddress(AddressDto addressDto);
        Task<User> UpdatePhoneNumber(string phoneNumber);
        Task<bool> UpdatePassword(AuthenticationDto authenticationDto);
        Task<User> Save(User userDto);
    }
}
