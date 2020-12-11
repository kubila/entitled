using AutoMapper;
using Entitled.Data;
using Entitled.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entitled.Mappings
{
    public class MapsThings : Profile // Profile is AutoMapper
    {
        public MapsThings()
        {

            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();            
            CreateMap<LeaveHistory, LeaveHistoryViewModel>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveType, DetailsLeaveTypeViewModel>().ReverseMap();
            
        }
    }
}
