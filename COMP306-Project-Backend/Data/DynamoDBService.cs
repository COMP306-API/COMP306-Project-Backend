using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using COMP306_Project_Backend.Models;
using COMP306_Project_Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Data
{
    public class DynamoDBService
    {
        IAmazonDynamoDB dynamoDBClient { get; set; }
        AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast2);
        DynamoDBContext context;

        public DynamoDBService()
        {

        }
        public DynamoDBService(IAmazonDynamoDB dynamoDBClient)
        {
            this.dynamoDBClient = dynamoDBClient;
        }
    }
}
