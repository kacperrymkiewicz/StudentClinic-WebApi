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
            var visit = _mapper.Map<Visit>(newVisit);
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Visits.Select(v => _mapper.Map<GetVisitDto>(v)).ToListAsync();
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

        public Task<ServiceResponse<GetVisitDto>> GetVisitById(int id)
        {
        throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetVisitDto>> UpdateVisit(int id, UpdateVisitDto updatedVisit)
        {
        throw new NotImplementedException();
        }
    }
}