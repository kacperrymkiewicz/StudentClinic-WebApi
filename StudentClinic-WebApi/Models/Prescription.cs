using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; } 
        public string Drug { get; set; }
        public string Dosage { get; set; }
        public string PrescriptionCode { get; set; }
        public string Recommendations { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}