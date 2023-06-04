using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentClinic_WebApi.Data;
using StudentClinic_WebApi.Dtos.Doctor;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DoctorService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctors()
        {
            var serviceResponse = new ServiceResponse<List<GetDoctorDto>>();
            var doctors = await _context.Doctors.Include(d => d.User).ToListAsync();
            serviceResponse.Data = doctors.Select(d => _mapper.Map<GetDoctorDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDoctorDto>>> GetAllDoctorsBySpecialization(string specialization)
        {
            var serviceResponse = new ServiceResponse<List<GetDoctorDto>>();
            var doctors = await _context.Doctors.Include(d => d.User).Where(d => d.Specialization.ToLower() == specialization.ToLower()).ToListAsync();
            serviceResponse.Data = doctors.Select(d => _mapper.Map<GetDoctorDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDoctorDto>> GetDoctor(int id)
        {
            var serviceResponse = new ServiceResponse<GetDoctorDto>();

            try
            {
                var doctor = await _context.Doctors.Include(d => d.User).FirstOrDefaultAsync(d => d.Id == id);
                if (doctor is null)
                    throw new Exception($"Nie znaleziono doktora z ID: '{id}'");

                serviceResponse.Data = _mapper.Map<GetDoctorDto>(doctor);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<string>>> GetAllSpecializations()
        {
            var serviceResponse = new ServiceResponse<List<string>>();
            var doctors = await _context.Doctors.ToListAsync();

            serviceResponse.Data = doctors.Select(v => v.Specialization).Distinct().ToList();

            return serviceResponse;
        }
    }
}