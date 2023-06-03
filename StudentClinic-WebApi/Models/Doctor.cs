using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}