using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
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

        public UserRepository(IAmazonDynamoDB dynamoDBClient)
        {
            this.dynamoDBClient = dynamoDBClient;
        }

        public Task<bool> Authenticate(AuthenticationDto authenticationDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> GetById(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistingUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> Save(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> UpdateAddress(AddressDto addressDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> UpdateName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePassword(AuthenticationDto authenticationDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> UpdatePhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
