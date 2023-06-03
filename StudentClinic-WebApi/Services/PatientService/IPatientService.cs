using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.Patient;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Services.PatientService
{
    public interface IPatientService
    {
        Task<ServiceResponse<List<GetPatientDto>>> GetAllPatients();
        Task<ServiceResponse<GetPatientDto>> GetPatientById(int id);
    }
}