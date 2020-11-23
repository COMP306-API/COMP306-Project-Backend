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
        private ILogRepository _logRepository;

        public LogController(ILogger<LogController> logger, ILogRepository logRepository, IMapper mapper)
        {
            _logger = logger;
            _logRepository = logRepository;
        }

        [HttpDelete("/{id}")]
        public async Task<string> Delete(string id)
        {
          return await  _logRepository.Delete(id);
        }

        [HttpGet("/{email}/business")]
        [ProducesResponseType(200, Type = typeof(List<LogDto>))]
        public async Task<ActionResult<LogDto>> GetAllByBusiness(string email)
        {
            return Ok(await _logRepository.GetAllByBusiness(email));
        }

        [HttpGet("/{email}/customer")]
        public async Task<ActionResult<LogDto>> GetAllByCustomer(string email)
        {
            return Ok(await _logRepository.GetAllByCustomer(email));
        }


        [HttpPost("/create")]
        public async Task<ActionResult<LogDto>> Save(string businessEmail, string clientEmail)
        {

            return Ok(await _logRepository.Save(
                businessEmail,clientEmail));
        }
    }
}
