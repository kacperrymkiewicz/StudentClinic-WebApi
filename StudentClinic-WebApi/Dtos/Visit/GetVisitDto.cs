using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.Doctor;
using StudentClinic_WebApi.Dtos.Patient;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Dtos.Visit
{
    public class GetVisitDto
    {
        public int Id { get; set; }
        public GetPatientDto? Patient { get; set; }
        public GetDoctorDto? Doctor { get; set; }
        public DateOnly Date { get; set; }
        public VisitSlot? Slot { get; set; }
        public VisitStatus Status { get; set; }
    }
}