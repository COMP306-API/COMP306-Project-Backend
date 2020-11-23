using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using COMP306_Project_Backend.Models;
using COMP306_Project_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace COMP306_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepo;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserRepository userRepo, IMapper mapper)
        {
            _logger = logger;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        //Authenticating user by Email ID and password
        [HttpPost("/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationDto authenticationDto)
        {
            var userAutheticated = await _userRepo.Authenticate(authenticationDto);

            if (userAutheticated == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(userAutheticated);
        }

        [HttpGet("/{email}")]
        public async Task<ActionResult<UserResponseDto>> GetById(string email)
        {
            var result = await _userRepo.GetById(email);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //creating user
        [HttpPost("/createUser")]
        public async Task<ActionResult<string>> Save([FromBody] UserDto userDto)
        {
            string result = await _userRepo.Save(userDto);

            if (result == null)
            {
                return BadRequest("Email already exist.");
            }

            return Ok(result);
        }

        [HttpPut("/address")]
        public async Task<ActionResult<bool>> UpdateAddress(string email, [FromBody] AddressDto addressDto)
        {
            bool result = await _userRepo.UpdateAddress(email, addressDto);
            if (!result)
            {
                return BadRequest("Email is not valid");
            }
            return Ok(result);
        }

        [HttpPut("/name/{name}")]
        public async Task<ActionResult<bool>> UpdateName(string emailId, string name)
        {
            bool result = await _userRepo.UpdateName(emailId, name);

            if (!result)
            {
                return BadRequest("Email is not valid");
            }

            return Ok(result);
        }

        [HttpPut("/password")]
        public Task<ActionResult<bool>> UpdatePassword(AuthenticationDto authenticationDto)
        {
            return null;
        }

        [HttpPut("/phone/{phoneNumber}")]
        public async Task<ActionResult<bool>> UpdatePhoneNumber(string emailId, string phoneNumber)
        {
            bool result = await _userRepo.UpdatePhoneNumber(emailId, phoneNumber);

            if (!result)
            {
                return BadRequest("Email is not valid");
            }

            return Ok(result);
        }
    }
}
