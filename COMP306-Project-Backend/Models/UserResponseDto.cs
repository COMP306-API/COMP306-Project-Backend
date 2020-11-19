using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{
    public class UserResponseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public UserResponseDto(
            string Email,
            string Name,
            string Address,
            string City,
            string Province,
            string PostalCode,
            string PhoneNumber
            )
        {
            this.Email = Email;
            this.Name = Name;
            this.Address = Address;
            this.City = City;
            this.Province = Province;
            this.PostalCode = PostalCode;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
