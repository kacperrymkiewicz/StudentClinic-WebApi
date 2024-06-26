using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Dtos.User
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
    }
}