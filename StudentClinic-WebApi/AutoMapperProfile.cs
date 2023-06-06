using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentClinic_WebApi.Dtos.Doctor;
using StudentClinic_WebApi.Dtos.Patient;
using StudentClinic_WebApi.Dtos.User;
using StudentClinic_WebApi.Dtos.Visit;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<Patient, GetPatientDto>();
            CreateMap<Visit, GetVisitDto>();
            CreateMap<Doctor, GetDoctorDto>();
            CreateMap<AddVisitDto, Visit>();
            CreateMap<VisitSlot, GetVisitSlotStatusDto>();
        }
    }
}