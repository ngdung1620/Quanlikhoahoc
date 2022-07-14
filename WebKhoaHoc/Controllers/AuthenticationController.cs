using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Services;

namespace WebKhoaHoc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController: ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _userService.Login(request);
            return Ok(response);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
        {
            var response = await _userService.Registration(request);
            return Ok(response);
        }

        [HttpGet("get-user")]
        public IActionResult GetUser()
        {
            return Ok(_userService.GetListUser());
        }

        [HttpDelete("delete-user/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var isDeleted = _userService.DeleteUser(id);
            return Ok(isDeleted);
        }

        [HttpPost("edit-user")]
        public async Task<IActionResult> EditUser([FromBody] EditUserRequest request)
        {
           var  editUser = await _userService.EditUser(request);
            return Ok(editUser);
        }
        
    }
}