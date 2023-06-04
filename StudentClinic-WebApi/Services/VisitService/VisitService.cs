using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentClinic_WebApi.Data;
using StudentClinic_WebApi.Dtos.Visit;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Services.VisitService
{
    public class VisitService : IVisitService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VisitService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetVisitDto>>> AddVisit(AddVisitDto newVisit)
        {
            var serviceResponse = new ServiceResponse<List<GetVisitDto>>();
            try
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == newVisit.PatientId);
                if (patient is null)
                    throw new Exception("Podany pacjent nie istnieje.");

                var visit = _mapper.Map<Visit>(newVisit);
                _context.Visits.Add(visit);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Visits.Select(v => _mapper.Map<GetVisitDto>(v)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVisitDto>>> GetAllVisits()
        {
            var serviceResponse = new ServiceResponse<List<GetVisitDto>>();
            var visits = await _context.Visits
                .Include(v => v.Slot)
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .Include(v => v.Patient!.User)
                .Include(v => v.Doctor!.User)
                .ToListAsync();
            serviceResponse.Data = visits.Select(v => _mapper.Map<GetVisitDto>(v)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVisitDto>> GetVisitById(int id)
        {
                var serviceResponse = new ServiceResponse<GetVisitDto>();
                try
                {
                    var visit = await _context.Visits
                        .Include(v => v.Slot)
                        .Include(v => v.Patient)
                        .Include(v => v.Doctor)
                        .Include(v => v.Patient!.User)
                        .Include(v => v.Doctor!.User)
                        .FirstOrDefaultAsync(v => v.Id == id);

                    if(visit is null)
                        throw new Exception($"Nie znaleziono wizyty z ID: '{id}'");

                    serviceResponse.Data = _mapper.Map<GetVisitDto>(visit);
                }
                catch(Exception ex)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = ex.Message;
                }

                return serviceResponse;
        }

        public Task<ServiceResponse<GetVisitDto>> UpdateVisit(int id, UpdateVisitDto updatedVisit)
        {
        throw new NotImplementedException();
        }
        
        public async Task<ServiceResponse<List<VisitSlot>>> GetAvailableSlots(GetVisitAvailableSlotsDto visitSlots)
        {
            var serviceResponse = new ServiceResponse<List<VisitSlot>>();
            var visits = await _context.Visits.Where(v => v.Date == visitSlots.Date && v.DoctorId == visitSlots.DoctorId).ToListAsync();
            var slots = await _context.VisitSlots.ToListAsync();
            
            foreach(var visit in visits)
            {
                slots.RemoveAll(s => s.Id == visit.SlotId);
            }

            serviceResponse.Data = slots;
            return serviceResponse;
        }
    }
}