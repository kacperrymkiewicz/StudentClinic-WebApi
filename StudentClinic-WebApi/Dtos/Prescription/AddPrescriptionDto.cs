using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClinic_WebApi.Dtos.Prescription
{
    public class AddPrescriptionDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; } 
        public string Drug { get; set; }
        public string Dosage { get; set; }
        public string PrescriptionCode { get; set; }
        public string Recommendations { get; set; }
    }
}