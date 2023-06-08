using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.UserAuthorization;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, Patient patient, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePasswordDto userRequest);
        Task<bool> UserExists(string email);
    }
}