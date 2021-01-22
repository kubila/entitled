using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entitled.Models
{
    
    public class LeaveTypeViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Number Of Days")]
        [Range(1, 25, ErrorMessage = "Please enter a valid number, granted range is minimum 1 and maximum 25 respectively.")]
        public int DefaultDays { get; set; }

        [Display(Name = "Date Created")]
        
        public DateTime? DateCreated { get; set; }
    }
}
