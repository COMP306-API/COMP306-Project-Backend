using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Services
{
    public class LogRepository : ILogRepository
    {
        IAmazonDynamoDB dynamoDBClient { get; set; }
        AmazonDynamoDBClient client;
        DynamoDBContext context;

        public LogRepository(IAmazonDynamoDB dynamoDBClient)
        {
            this.dynamoDBClient = dynamoDBClient;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LogDto>> GetAllByBusiness(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LogDto>> GetAllByCustomer(string email)
        {
            throw new NotImplementedException();
        }

        public Task<LogDto> Save(LogDto logDto)
        {
            throw new NotImplementedException();
        }
    }
}
