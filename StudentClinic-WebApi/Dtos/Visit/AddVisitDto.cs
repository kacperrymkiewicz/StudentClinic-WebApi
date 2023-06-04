using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Dtos.Visit
{
    public class AddVisitDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public int SlotId { get; set; }
        public VisitStatus Status { get; set; }
    }
}