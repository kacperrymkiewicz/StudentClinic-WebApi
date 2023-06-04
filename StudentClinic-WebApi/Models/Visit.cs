using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }
        public Doctor? Doctor { get; set; }
        public int DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public VisitSlot? Slot { get; set; }
        public int SlotId { get; set; }
        public VisitStatus Status { get; set; }
    }
}