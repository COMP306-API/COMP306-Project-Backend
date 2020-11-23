using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{

    [DynamoDBTable("User")]
    public class User
    {
        [DynamoDBHashKey]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DynamoDBProperty]
        public string Name { get; set; }
        [Required]
        [DynamoDBProperty]
        public string Type { get; set; }
        [Required]
        [DynamoDBProperty]
        public string Address { get; set; }
        [Required]
        [DynamoDBProperty]
        public string City { get; set; }
        [Required]
        [DynamoDBProperty]
        public string Province { get; set; }
        [Required]
        [DynamoDBProperty]
        public string PostalCode { get; set; }
        [Required]
        [DynamoDBProperty]
        public string PhoneNumber { get; set; }
        [Required]
        [DynamoDBProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
