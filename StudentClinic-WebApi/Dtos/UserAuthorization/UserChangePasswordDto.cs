using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Dtos.UserAuthorization
{
    public class UserChangePasswordDto
    {
        public int Id { get; set; }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}