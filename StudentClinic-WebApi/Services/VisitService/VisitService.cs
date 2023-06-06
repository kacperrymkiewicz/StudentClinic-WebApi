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
        
        public async Task<ServiceResponse<List<GetVisitSlotStatusDto>>> GetAvailableSlots(GetVisitAvailableSlotsDto visitSlots)
        {
            var serviceResponse = new ServiceResponse<List<GetVisitSlotStatusDto>>();
            var visits = await _context.Visits.Where(v => v.Date == visitSlots.Date && v.DoctorId == visitSlots.DoctorId).ToListAsync();
            var slots = await _context.VisitSlots.Select(s => _mapper.Map<GetVisitSlotStatusDto>(s)).ToListAsync();
            
            foreach(var visit in visits)
            {
                slots.Find(s => s.Id == visit.SlotId)!.Status = false;
            }

            if(visitSlots.Date == DateOnly.FromDateTime(DateTime.Now))
            {
                slots.FindAll(s => s.StartTime < TimeOnly.FromDateTime(DateTime.Now)).ForEach(s => s.Status = false);
            }

            if(visitSlots.Date < DateOnly.FromDateTime(DateTime.Now))
            {
                slots.ForEach(s => s.Status = false);
            }

            serviceResponse.Data = slots;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVisitDto>> CancelVisit(int id)
        {
            var serviceResponse = new ServiceResponse<GetVisitDto>();

            try
            {
                var visit = await _context.Visits.FirstOrDefaultAsync(v => v.Id == id);
                if(visit is null)
                    throw new Exception($"Nie znaleziono wizyty z ID: '{id}'");
                
                visit.Status = VisitStatus.Canceled;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetVisitDto>(visit);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVisitDto>> ConfirmVisit(int id)
        {
            var serviceResponse = new ServiceResponse<GetVisitDto>();

            try
            {
                var visit = await _context.Visits.FirstOrDefaultAsync(v => v.Id == id);
                if(visit is null)
                    throw new Exception($"Nie znaleziono wizyty z ID: '{id}'");
                
                visit.Status = VisitStatus.Confirmed;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetVisitDto>(visit);
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