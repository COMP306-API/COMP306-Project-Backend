using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{
    [DynamoDBTable("Address")]
    public class Address
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }

    }
}
