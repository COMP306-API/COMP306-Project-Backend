using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{
    public class AuthenticationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthenticationDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
