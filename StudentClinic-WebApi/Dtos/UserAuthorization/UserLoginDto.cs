using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Dtos.User
{
    public class UserLoginDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}