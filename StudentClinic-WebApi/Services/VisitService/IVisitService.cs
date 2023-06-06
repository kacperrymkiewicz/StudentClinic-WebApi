using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentClinic_WebApi.Dtos.Visit;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Services.VisitService
{
    public interface IVisitService
    {
        Task<ServiceResponse<List<GetVisitDto>>> GetAllVisits();
        Task<ServiceResponse<GetVisitDto>> GetVisitById(int id);
        Task<ServiceResponse<List<GetVisitDto>>> AddVisit(AddVisitDto newVisit);
        Task<ServiceResponse<GetVisitDto>> UpdateVisit(int id, UpdateVisitDto updatedVisit);
        Task<ServiceResponse<List<GetVisitSlotStatusDto>>> GetAvailableSlots(GetVisitAvailableSlotsDto visitSlots);
        Task<ServiceResponse<GetVisitDto>> CancelVisit(int id);
        Task<ServiceResponse<GetVisitDto>> ConfirmVisit(int id);
    }
}