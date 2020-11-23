using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using COMP306_Project_Backend.Data;
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

        public async Task <IEnumerable<Log>> GetAllByBusiness(string email)
        {
            DynamoDBService _service = new DynamoDBService();
            //AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast2);
           // context = new DynamoDBContext(client);
          // return (IEnumerable<Log>) await context.LoadAsync<Log>(email);

            return await _service.GetLogs() ;
            //throw new NotImplementedException();
        }

        public Task<IEnumerable<Log>> GetAllByCustomer(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Log> Save(Log logDto)
        {
            throw new NotImplementedException();
        }
    }
}
