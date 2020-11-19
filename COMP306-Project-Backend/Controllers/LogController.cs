using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private ILogRepository logRepository;
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpDelete("/{id}")]
        public void Delete(string id)
        {

        }

        [HttpGet("/{email}/business")]
        public Task<ActionResult<LogDto>> GetAllByBusiness(string email)
        {
            return null;
        }

        [HttpGet("/{email}/customer")]
        public Task<ActionResult<LogDto>> GetAllByCustomer(string email)
        {
            return null;
        }

        [HttpPost]
        public Task<ActionResult<LogDto>> Save(LogDto logDto)
        {
            return null;
        }
    }
}
