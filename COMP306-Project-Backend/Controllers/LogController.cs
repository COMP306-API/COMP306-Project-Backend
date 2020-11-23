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
        private ILogRepository _logRepository;

        public LogController(ILogRepository logRepository)
        {
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
            var logs = await _logRepository.GetAllByBusiness(email);

            if (logs == null)
            {
                return BadRequest(new { message = "No business found with the given email." });
            }

            return Ok(logs);
        }

        [HttpGet("/{email}/customer")]
        public async Task<ActionResult<LogDto>> GetAllByCustomer(string email)
        {
            var logs = await _logRepository.GetAllByCustomer(email);

            if (logs == null)
            {
                return BadRequest(new { message = "No customer found with the given email." });
            }

            return Ok(logs);
        }

        [HttpPost("/create")]
        public async Task<ActionResult<LogDto>> Save(string businessEmail, string clientEmail)
        {

            return Ok(await _logRepository.Save(
                businessEmail,clientEmail));
        }
    }
}
