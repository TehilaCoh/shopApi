using Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using DTO;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _map;

        private readonly IUserService  userServices;

        private readonly ILogger _logger;

        public UserController(IUserService _userServices, IMapper map, ILogger<UserController> logger)
        {
            userServices = _userServices;
            _map = map;
          _logger = logger;
        }
        [Route("login")]
        // GET api/<RegisterAndLogin>/5
        [HttpPost]
        public async Task< ActionResult<User>> Get([FromBody] UserLoginDto loginDto)                           
        {
            var userName = loginDto.Email;
            var password = loginDto.Password;
            User user = await userServices.GetUserByUserNameAndPassword(userName, password);
           _logger.LogInformation("Login attempted with User Name , {userName} and password {password}", userName, password);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        // POST api/<RegisterAndLogin>
        [HttpPost]
        public async Task< CreatedAtActionResult> Post([FromBody] UserDto userDto)
        {           
                User user = _map.Map<UserDto, User>(userDto);
                await userServices.Post(user);
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // PUT api/<RegisterAndLogin>/5
        [HttpPut("{id}")]
        public async Task<User> Put(int id, [FromBody] User userToUpdate)
        {
            return await userServices.UpdateUser(id, userToUpdate);
        }

        [HttpPost("check")]
        public async Task<int> Check([FromBody] string password)
        {
            if (password != "")
            {
                return await userServices.check(password);
            }
            return -1;


        }
        // DELETE api/<RegisterAndLogin>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
