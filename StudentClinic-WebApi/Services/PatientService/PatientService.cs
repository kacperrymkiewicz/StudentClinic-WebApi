using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentClinic_WebApi.Data;
using StudentClinic_WebApi.Dtos.Patient;
using StudentClinic_WebApi.Dtos.User;
using StudentClinic_WebApi.Dtos.Visit;
using StudentClinic_WebApi.Models;
using StudentClinic_WebApi.Services.UserService;

namespace StudentClinic_WebApi.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public PatientService(IMapper mapper, DataContext context, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetPatientDto>>> GetAllPatients()
        {
            var serviceResponse = new ServiceResponse<List<GetPatientDto>>();
            var patients = await _context.Patients.Include(p => p.User).ToListAsync();
            serviceResponse.Data = patients.Select(p => _mapper.Map<GetPatientDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVisitDto>>> GetAllVisits(int id)
        {
                var serviceResponse = new ServiceResponse<List<GetVisitDto>>();

                try
                {
                    var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
                    if (patient is null)
                        throw new Exception($"Nie znaleziono pacjenta z ID: '{id}'");

                    var visits = await _context.Visits.
                        Include(v => v.Doctor).
                        Include(v => v.Doctor!.User).
                        Include(v => v.Slot).
                        Where(v => v.PatientId == patient.Id).
                        ToListAsync();
                    serviceResponse.Data = visits.Select(v => _mapper.Map<GetVisitDto>(v)).ToList();
                }
                catch(Exception ex)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = ex.Message;
                }
                
                return serviceResponse;
        }

        public async Task<ServiceResponse<GetPatientDto>> GetPatientById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPatientDto>();

            try
            {
                var patient = await _context.Patients.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
                if (patient is null)
                    throw new Exception($"Nie znaleziono pacjenta z ID: '{id}'");

                serviceResponse.Data = _mapper.Map<GetPatientDto>(patient);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPatientDto>> UpdatePatient(UpdatePatientDto updatedPatient)
        {
            var serviceResponse = new ServiceResponse<GetPatientDto>();

            try
            {
                var patient = await _context.Patients.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == updatedPatient.Id);
                if (patient is null)
                    throw new Exception($"Nie znaleziono pacjenta z ID: '{updatedPatient.Id}'");

                patient.Pesel = updatedPatient.Pesel;
                patient.PhoneNumber = updatedPatient.PhoneNumber;
                patient.Allergies = updatedPatient.Allergies;
                patient.User!.FirstName = updatedPatient.User!.FirstName;
                patient.User!.LastName = updatedPatient.User!.LastName;
                patient.User!.EmailAddress = updatedPatient.User!.EmailAddress;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetPatientDto>(patient);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}