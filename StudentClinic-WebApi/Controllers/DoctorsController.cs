using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentClinic_WebApi.Dtos.Doctor;
using StudentClinic_WebApi.Dtos.Prescription;
using StudentClinic_WebApi.Dtos.Visit;
using StudentClinic_WebApi.Models;
using StudentClinic_WebApi.Services.DoctorService;

namespace StudentClinic_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService) 
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetDoctorDto>>>> Get()
        {
            return Ok(await _doctorService.GetAllDoctors());
        }

        [HttpGet]
        [Route("{specialization}")]
        public async Task<ActionResult<ServiceResponse<List<GetDoctorDto>>>> GetBySpetialization(string specialization)
        {
            return Ok(await _doctorService.GetAllDoctorsBySpecialization(specialization));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ServiceResponse<GetDoctorDto>>> GetSingle(int id)
        {
            var response = await _doctorService.GetDoctor(id);
            if(response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Specializations")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetAllSpecializations()
        {
            return Ok(await _doctorService.GetAllSpecializations());
        }

        [HttpPost]
        [Route("Prescriptions")]
        public async Task<ActionResult<ServiceResponse<GetPrescriptionDto>>> AddPrescription(AddPrescriptionDto newPrescription)
        {
            return Ok(await _doctorService.AddPrescription(newPrescription));
        }

        [HttpGet]
        [Route("{id}/Visits")]
        public async Task<ActionResult<ServiceResponse<GetVisitDto>>> GetVisits(int id)
        {
            var response = await _doctorService.GetAllVisits(id);
            if(response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}