using Microsoft.AspNetCore.Mvc;
using StudentClinic_WebApi.Services.UserService;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetSingle(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<User>>>> AddUser(User newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }
    }
}
