using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.User;

namespace StudentClinic_WebApi.Dtos.Doctor
{
    public class GetDoctorDto
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public GetUserDto? User { get; set; }
    }
}