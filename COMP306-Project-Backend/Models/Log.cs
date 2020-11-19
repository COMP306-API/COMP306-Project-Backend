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
        [Required]
        public string BusinessEmail { get; set; }
        [DynamoDBRangeKey]
        [Required]
        public string DateVisited { get; set; }
        [Required]
        public string TimeVisited { get; set; }
        [Required]
        public string ClientEmail { get; set; }
    }
}
