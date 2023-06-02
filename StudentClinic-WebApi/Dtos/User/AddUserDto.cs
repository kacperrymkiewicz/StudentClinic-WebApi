using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Dtos.User
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get;set; }
        public AccountType AccountType { get; set; } = AccountType.Patient;
    }
}