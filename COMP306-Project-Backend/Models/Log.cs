using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;


namespace COMP306_Project_Backend.Models
{
    [DynamoDBTable("Log")]
    public class Log
    {
        [DynamoDBHashKey]
        public string LogID { get; set; }
        [Required]
        public string DateTimeVisited { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
