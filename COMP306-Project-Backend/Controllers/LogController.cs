using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using COMP306_Project_Backend.Models;
using COMP306_Project_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace COMP306_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private IAmazonDynamoDB dynamoDBClient;
        private AmazonDynamoDBClient client;
        private DynamoDBContext context;

        private readonly IMapper _mapper;
        private ILogRepository _logRepository;


        public LogController(ILogger<LogController> logger, ILogRepository logRepository, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _logRepository = logRepository;

        }

        [HttpDelete("/{id}")]
        public void Delete(string id)
        {

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<LogDto>))]
        public async Task<ActionResult<LogDto>> GetAllByBusiness(string email)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast2);
            context = new DynamoDBContext(client);
            // await TableOperations.CreateLogTable(client);
         

            var businesslogs = await _logRepository.GetAllByBusiness(email);
            var objDto = new List<LogDto>();
            foreach (var obj in businesslogs)
            {
                objDto.Add(_mapper.Map<LogDto>(obj));
            }
            return Ok(businesslogs);

        }

        [HttpGet("/{email}/customer")]
        public Task<ActionResult<LogDto>> GetAllByCustomer(string email)
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<LogDto>> Save([FromBody]LogDto logDto)
        {
        
            var logsObj = _mapper.Map<Log>(logDto);
            return  null;
    }
    }
}
