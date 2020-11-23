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

        //creating new user
        public async Task<User> RegisterVisitor(User visitor)
        {
            context = new DynamoDBContext(client);
            await context.SaveAsync(visitor, default(System.Threading.CancellationToken));
            User newVisitor = await context.LoadAsync<User>(visitor.Email, visitor.Password="", default(System.Threading.CancellationToken));
            return newVisitor;
        }
        //getting user by Id (email)
        public async Task<User> GetById(string emailId)
        {
            context = new DynamoDBContext(client);
            var user = await context.LoadAsync<User>(emailId, default(System.Threading.CancellationToken));
            return user;
        }
        //Authenticating user by email Id and password
        public async Task<User> GetUser(string email, string password)
        {
            context = new DynamoDBContext(dynamoDBClient);
            User newUser = await context.LoadAsync<User>(email, password, default(System.Threading.CancellationToken));
            return newUser;
        }

        //Update user name
        public async Task <User>UpdateUserName(string emailId, User _user)
        {
            context = new DynamoDBContext(dynamoDBClient);
            User user = context.LoadAsync<User>(emailId, default(System.Threading.CancellationToken)).Result;
            user.Name = _user.Name;
            await context.SaveAsync<User>(user);
            return await GetById(user.Email);
        }
   
    }
}
