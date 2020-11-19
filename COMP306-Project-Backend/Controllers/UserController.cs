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
    public class UserController : ControllerBase
    {
        private IUserRepository repository;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/authenticate")]
        public Task<bool> Authenticate(AuthenticationDto authenticationDto)
        {
            return null;
        }

        [HttpGet("/{email}")]
        public Task<UserResponseDto> GetById(string email)
        {
            return null;
        }

        [HttpGet("/{email}/existingUser")]
        public Task<bool> IsExistingUser(string email)
        {
            return null;
        }

        [HttpPost]
        public Task<ActionResult<UserResponseDto>> Save(UserDto userDto)
        {
            return null;
        }

        [HttpPut("/address")]
        public Task<ActionResult<UserResponseDto>> UpdateAddress(AddressDto addressDto)
        {
            return null;
        }

        [HttpPut("/name/{name}")]
        public Task<ActionResult<UserResponseDto>> UpdateName(string name)
        {
            return null;
        }

        [HttpPut("/password")]
        public Task<ActionResult<bool>> UpdatePassword(AuthenticationDto authenticationDto)
        {
            return null;
        }

        [HttpPut("/phone/{phoneNumber}")]
        public Task<ActionResult<UserResponseDto>> UpdatePhoneNumber(string phoneNumber)
        {
            return null;
        }
    }
}
