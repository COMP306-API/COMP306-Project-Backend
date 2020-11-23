using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserRepository(IAmazonDynamoDB dynamoDBClient, IMapper mapper)
        {
            this.dynamoDBClient = dynamoDBClient;
            _mapper = mapper;
            client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast2);
            context = new DynamoDBContext(client);
        }

        public async Task<UserResponseDto> Authenticate(AuthenticationDto authDto)
        {
            User user = await context.LoadAsync<User>(authDto.Email, default(System.Threading.CancellationToken));

            if (user != null && !user.Password.Equals(authDto.Password))
            {
                return null;
            }

            return MapToUserResponseDto(user);
        }

        //Get user by  email Id
        public async Task<UserResponseDto> GetById(string email)
        {
            User user = await context.LoadAsync<User>(email, default(System.Threading.CancellationToken));

            return MapToUserResponseDto(user);
        }

        public async Task<bool> IsExistingUser(string email)
        {
            if (await GetById(email) != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateName(string email, string name)
        {
            bool isExist = await IsExistingUser(email);

            if (!isExist)
            {
                return false;
            }

            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                { "Email", new AttributeValue { S = email} }
            };

            Dictionary<string, AttributeValueUpdate> update = new Dictionary<string, AttributeValueUpdate>();
            update["Name"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.PUT,
                Value = new AttributeValue { S = name }
            };

            UpdateItemRequest request = new UpdateItemRequest
            {
                TableName = "User",
                Key = key,
                AttributeUpdates = update
            };

            await client.UpdateItemAsync(request);

            return true;
        }

        public async Task<bool> UpdateAddress(string email, AddressDto addressDto)
        {
            bool isExist = await IsExistingUser(email);

            if (!isExist)
            {
                return false;
            }

            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                { "Email", new AttributeValue { S = email} }
            };

            Dictionary<string, AttributeValueUpdate> update = new Dictionary<string, AttributeValueUpdate>();
            update["Address"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.PUT,
                Value = new AttributeValue { S = addressDto.Address }
            };

            update["City"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.PUT,
                Value = new AttributeValue { S = addressDto.City }
            };

            update["Province"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.PUT,
                Value = new AttributeValue { S = addressDto.Province }
            };

            update["PostalCode"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.PUT,
                Value = new AttributeValue { S = addressDto.PostalCode }
            };

            UpdateItemRequest request = new UpdateItemRequest
            {
                TableName = "User",
                Key = key,
                AttributeUpdates = update
            };

            await client.UpdateItemAsync(request);

            return true;
        }

        public async Task<bool> UpdatePhoneNumber(string email, string phoneNumber)
        {

            bool isExist = await IsExistingUser(email);

            if (!isExist)
            {
                return false;
            }

            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                { "Email", new AttributeValue { S = email} }
            };

            Dictionary<string, AttributeValueUpdate> update = new Dictionary<string, AttributeValueUpdate>();
            update["PhoneNumber"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.PUT,
                Value = new AttributeValue { S = phoneNumber }
            };

            UpdateItemRequest request = new UpdateItemRequest
            {
                TableName = "User",
                Key = key,
                AttributeUpdates = update
            };

            await client.UpdateItemAsync(request);

            return true;
        }

        public async Task<bool> UpdatePassword(AuthenticationDto authenticationDto)
        {

            bool isExist = await IsExistingUser(authenticationDto.Email);

            if (!isExist)
            {
                return false;
            }

            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                { "Email", new AttributeValue { S = authenticationDto.Email} }
            };

            Dictionary<string, AttributeValueUpdate> update = new Dictionary<string, AttributeValueUpdate>();
            update["Password"] = new AttributeValueUpdate()
            {
                Action = AttributeAction.PUT,
                Value = new AttributeValue { S = authenticationDto.Password }
            };

            UpdateItemRequest request = new UpdateItemRequest
            {
                TableName = "User",
                Key = key,
                AttributeUpdates = update
            };

            await client.UpdateItemAsync(request);

            return true;
        }

        public async Task<string> Save(UserDto userDto)
        {
            bool isExisting = await IsExistingUser(userDto.Email);

            if (isExisting)
            {
                return null;
            }

            var user = _mapper.Map<User>(userDto);
            await context.SaveAsync(user, default(System.Threading.CancellationToken));
            return "Successfully saved.";
        }

        private UserResponseDto MapToUserResponseDto(User user)
        {
            UserResponseDto result = null;
            if (user != null)
            {
                result = _mapper.Map<UserResponseDto>(user);
            }
            return result;
        }

    }
}
