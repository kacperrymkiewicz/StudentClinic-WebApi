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

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try {
                var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
                if(user is null)
                    throw new Exception($"Nie znaleziono użytkownika z ID: '{updatedUser.Id}'");

                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Login = updatedUser.Login;
                user.Password = updatedUser.Password;
                user.AccountType = updatedUser.AccountType;

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            } catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}