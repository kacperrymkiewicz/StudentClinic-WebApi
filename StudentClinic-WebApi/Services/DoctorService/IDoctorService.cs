using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.Doctor;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<ServiceResponse<GetDoctorDto>> GetDoctor(int id);
        Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctors();
        Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctorsBySpecialization(string specialization);
        Task<ServiceResponse<List<string>>> GetAllSpecializations();
    }
}