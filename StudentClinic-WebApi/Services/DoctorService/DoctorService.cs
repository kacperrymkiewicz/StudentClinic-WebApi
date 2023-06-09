using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentClinic_WebApi.Data;
using StudentClinic_WebApi.Dtos.Doctor;
using StudentClinic_WebApi.Dtos.Prescription;
using StudentClinic_WebApi.Dtos.Visit;
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

        public async Task<ServiceResponse<GetPrescriptionDto>> AddPrescription(AddPrescriptionDto newPrescription)
        {
            var serviceResponse = new ServiceResponse<GetPrescriptionDto>();
            var prescription = _mapper.Map<Prescription>(newPrescription);
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetPrescriptionDto>(prescription);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVisitDto>>> GetAllVisits(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetVisitDto>>();

            try
            {
                var doctor = await _context.Doctors.Include(d => d.User).FirstOrDefaultAsync(d => d.Id == id);
                if (doctor is null)
                    throw new Exception($"Nie znaleziono doktora z ID: '{id}'");

                var visits = await _context.Visits
                    .Include(v => v.Slot)
                    .Include(v => v.Patient)
                    .Include(v => v.Patient!.User)
                    .Where(v => v.DoctorId == id)
                    .ToListAsync();
                visits.ForEach(v => {
                    if((v.Date.ToDateTime(v.Slot!.StartTime) < DateTime.Now) && v.Status != VisitStatus.Canceled) {
                        v.Status = VisitStatus.Finished;
                    }
                });

                serviceResponse.Data = visits.Select(v => _mapper.Map<GetVisitDto>(v)).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }
  }
}