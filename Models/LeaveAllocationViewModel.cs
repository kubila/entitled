﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Entitled.Models
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        public DateTime DateCreated { get; set; }

        
        public EmployeeViewModel Employee { get; set; }

        public string EmployeeId { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; }


        public LeaveTypeViewModel LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}