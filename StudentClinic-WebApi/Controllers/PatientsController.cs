using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentClinic_WebApi.Dtos.Patient;
using StudentClinic_WebApi.Dtos.User;
using StudentClinic_WebApi.Models;
using StudentClinic_WebApi.Services.PatientService;

namespace StudentClinic_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService) 
        {
            _patientService = patientService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> Get()
        {
            return Ok(await _patientService.GetAllPatients());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPatientDto>>> GetSingle(int id)
        {
            var response = await _patientService.GetPatientById(id);
            if(response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> UpdatePatient(UpdatePatientDto updatedPatient)
        {
            var response = await _patientService.UpdatePatient(updatedPatient);
            if(response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}