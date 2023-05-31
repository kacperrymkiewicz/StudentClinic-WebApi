using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentClinic_WebApi.Dtos.User;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User> 
        {
            new User(),
            new User { Id = 1, FirstName = "Bartosz" }
        };
        private readonly IMapper _mapper;

        public UserService(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var user = _mapper.Map<User>(newUser);
            user.Id = users.Max(u => u.Id) + 1;
            users.Add(user);
            serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = users.FirstOrDefault(u => u.Id == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }
    }
}