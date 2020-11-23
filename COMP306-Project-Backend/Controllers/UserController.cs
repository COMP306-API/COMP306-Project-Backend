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
            var userAutheticated = await _userRepo.Authenticate(authenticationDto.Email, authenticationDto.Password);
            if (userAutheticated == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(userAutheticated);
        }

        [HttpGet("/{email}")]
        public async Task<ActionResult<UserResponseDto>> GetById(string email)
        {
            // await TableOperations.CreateVisitorTable(client);

            var userById = await _userRepo.GetById(email);
            if (userById == null)
            {
                return NotFound();
            }
            var userObj = _mapper.Map<UserDto>(userById);
            return Ok(userObj);

        }

        [HttpGet("/{email}/existingUser")]
        public Task<bool> IsExistingUser(string email)
        {

            var userExistsAlready = _userRepo.IsExistingUser(email);
            return userExistsAlready;
        }

        //creating user
        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Save([FromBody] UserDto userDto)
        {
            var mapUser = _mapper.Map<User>(userDto);

            User user = await _userRepo.Save(mapUser);
            var userdto = _mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(GetById),
                new {
                    emailId = userDto.Email
                },
               userDto);

        }

        [HttpPut("/address")]
        public Task<ActionResult<UserResponseDto>> UpdateAddress(AddressDto addressDto)
        {
            return null;
        }

        [HttpPut("/name/{name}")]
        public async Task<ActionResult<User>> UpdateName(string emailId, [FromBody] UserDto userDto)
        {
            var mapUser = _mapper.Map<User>(userDto);
            var userName = await _userRepo.UpdateName(emailId, mapUser);
            var mapuserDto = _mapper.Map<UserDto>(userName);
            return CreatedAtAction(nameof(GetById), new
            {
                emailId = mapuserDto.Email,
                userDto
            });

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
