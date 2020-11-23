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
    public class UserRepository : IUserRepository
    {
        IAmazonDynamoDB dynamoDBClient { get; set; }
        AmazonDynamoDBClient client;
        DynamoDBContext context;

        DynamoDBService _service = new DynamoDBService();
        public UserRepository(IAmazonDynamoDB dynamoDBClient)
        {
            this.dynamoDBClient = dynamoDBClient;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            return await  _service.GetUser(email,password);
          
        }
        //Get user by  email Id
        public async Task<User> GetById(string email)
        {
            return await _service.GetById(email);

        }

        public Task<bool> IsExistingUser(string email)
        {
            throw new NotImplementedException();
        }
        //Creating a new user 
        public async Task<User> Save(User user)
        {
            
            return await _service.RegisterVisitor(user);
            
        }

        public Task<User> UpdateAddress(AddressDto addressDto)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateName(string email, User user)
        {
            return await _service.UpdateUserName(email,user);
        }

        public Task<bool> UpdatePassword(AuthenticationDto authenticationDto)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
