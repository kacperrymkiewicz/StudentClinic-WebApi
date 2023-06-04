using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentClinic_WebApi.Dtos.Visit;
using StudentClinic_WebApi.Models;
using StudentClinic_WebApi.Services.VisitService;

namespace StudentClinic_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitsController(IVisitService visitService) 
        {
            _visitService = visitService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetVisitDto>>>> Get()
        {
            return Ok(await _visitService.GetAllVisits());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetVisitDto>>>> AddVisit(AddVisitDto newVisit)
        {
            return Ok(await _visitService.AddVisit(newVisit));
        }

        [HttpPost]
        [Route("Slots")]
        public async Task<ActionResult<ServiceResponse<List<GetVisitDto>>>> GetSlots(GetVisitAvailableSlotsDto visitSlots)
        {
            return Ok(await _visitService.GetAvailableSlots(visitSlots));
        }
    }
}