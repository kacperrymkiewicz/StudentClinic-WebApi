using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Dtos.Visit
{
    public class GetVisitAvailableSlotsDto
    {
        public int DoctorId { get; set; }
        public DateOnly Date { get; set; }
    }
}