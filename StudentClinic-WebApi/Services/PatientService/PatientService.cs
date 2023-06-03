using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentClinic_WebApi.Data;
using StudentClinic_WebApi.Dtos.Patient;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Services.PatientService
{
  public class PatientService : IPatientService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public PatientService(IMapper mapper, DataContext context)
    {
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

    public Task<ServiceResponse<GetPatientDto>> GetPatientById(int id)
    {
      throw new NotImplementedException();
    }
  }
}