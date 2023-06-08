using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.User;

namespace StudentClinic_WebApi.Dtos.Patient
{
    public class UpdatePatientDto
    {
        public int Id { get; set; }
        public GetUserDto? User { get; set; }
        public string? Pesel { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Allergies { get; set; }
        public string? MedicationsTaken { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? StreetAddress { get; set; }
    }
}