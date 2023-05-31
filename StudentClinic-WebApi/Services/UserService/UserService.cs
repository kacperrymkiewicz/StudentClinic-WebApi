using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ServiceResponse<List<User>>> AddUser(User newUser)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            users.Add(newUser);
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            var user = users.FirstOrDefault(u => u.Id == id);
            serviceResponse.Data = user;
            return serviceResponse;
        }
    }
}