using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private UserRepository userRepository;

        public LogRepository(IAmazonDynamoDB dynamoDBClient, IMapper mapper)
        {
            this.dynamoDBClient = dynamoDBClient;
            client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast2);
            context = new DynamoDBContext(client);
            _mapper = mapper;
            this.userRepository = new UserRepository(dynamoDBClient, mapper);
        }

        public async Task<string> Delete(string id)
        {
            Log log = await context.LoadAsync<Log>(id, default);
            await context.DeleteAsync(log, default);

            return "Successfully deleted";
        }

        private async Task<bool> UserValidation(string email, string expectedType)
        {
            UserResponseDto user = await userRepository.GetById(email);

            if (user != null && user.Type.Equals(expectedType))
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<LogDto>> GetAllByBusiness(string email)
        {
            bool isValidated = await UserValidation(email, "business");

            if (!isValidated)
            {
                return null;
            }

            var businesslogs = await GetLogs(context, email, "BusinessEmail");

            var objDto = new List<LogDto>();

            foreach (var obj in businesslogs)
            {
                objDto.Add(_mapper.Map<LogDto>(obj));
            }

            return objDto;
        }

        public async Task<IEnumerable<LogDto>> GetAllByCustomer(string email)
        {
            bool isValidated = await UserValidation(email, "personal");

            if (!isValidated)
            {
                return null;
            }

            var clientlogs = await GetLogs(context, email, "ClientEmail");

            var objDto = new List<LogDto>();

            foreach (var obj in clientlogs)
            {
                objDto.Add(_mapper.Map<LogDto>(obj));
            }

            return objDto;
        }

        public async Task<LogDto> Save(string businessEmail, string clientEmail)
        {
            string Id = Guid.NewGuid().ToString();

            DateTime today = DateTime.Now;
            string date = today.ToString("yyyy-MM-dd");
            string time = today.ToString("HH:mm:ss");

            LogDto logDto = new LogDto(Id, businessEmail, clientEmail, date, time);

            var log = _mapper.Map<Log>(logDto);

            await context.SaveAsync(log, default);

            return logDto;
        }

        public async Task<List<Log>> GetLogs(DynamoDBContext context, string email, string condition)
        {
            var logsConditions = new List<ScanCondition>();
            logsConditions.Add(new ScanCondition(condition, ScanOperator.Equal, email));
            List<Log> logs = await context.ScanAsync<Log>(logsConditions).GetRemainingAsync();

            return logs;
        }
    }
}
