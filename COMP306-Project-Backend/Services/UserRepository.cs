using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
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
        private readonly IMapper _mapper;

        DynamoDBService _service = new DynamoDBService();
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
