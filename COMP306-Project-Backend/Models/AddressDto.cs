using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{
    public class AddressDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

        public AddressDto(
            string address,
            string city,
            string province,
            string postalCode
            )
        {
            Address = address;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }
    }
}
