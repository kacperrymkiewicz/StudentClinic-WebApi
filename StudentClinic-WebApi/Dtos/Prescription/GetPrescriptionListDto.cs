using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.Doctor;

namespace StudentClinic_WebApi.Dtos.Prescription
{
    public class GetPrescriptionListDto
    {
        public int Id { get; set; }
        public GetDoctorDto Doctor { get; set; }
        public int DoctorId { get; set; } 
        public string Drug { get; set; }
        public string Dosage { get; set; }
        public string PrescriptionCode { get; set; }
        public string Recommendations { get; set; }
        public DateTime Date { get; set; }
    }
}