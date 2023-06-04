using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentClinic_WebApi.Data;
using StudentClinic_WebApi.Dtos.User;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepository.Register(
                new User { FirstName = request.FirstName, LastName = request.LastName, EmailAddress = request.EmailAddress }, 
                new Patient { Pesel = request.Pesel, PhoneNumber = request.PhoneNumber, City = request.City, PostalCode = request.PostalCode, StreetAddress = request.StreetAddress}, 
                request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authRepository.Login(request.EmailAddress, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}