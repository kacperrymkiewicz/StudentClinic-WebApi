using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentClinic_WebApi.Dtos.Patient;
using StudentClinic_WebApi.Models;
using StudentClinic_WebApi.Services.PatientService;

namespace StudentClinic_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) 
        {
            _patientService = patientService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetPatientDto>>>> Get()
        {
            return Ok(await _patientService.GetAllPatients());
        }
    }
}