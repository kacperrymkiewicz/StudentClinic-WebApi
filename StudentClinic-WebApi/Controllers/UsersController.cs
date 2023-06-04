using Microsoft.AspNetCore.Mvc;
using StudentClinic_WebApi.Services.UserService;
using StudentClinic_WebApi.Models;
using StudentClinic_WebApi.Dtos.User;
using Microsoft.AspNetCore.Authorization;

namespace StudentClinic_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetSingle(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUser(AddUserDto newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> UpdateUser(UpdateUserDto updatedUser)
        {
            var response = await _userService.UpdateUser(updatedUser);
            if(response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Receptionist")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if(response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
