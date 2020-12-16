using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entitled.Models
{
    public class CreateLeaveTypeViewModel
    {
        [Required]                
        public string Name { get; set; }

        
    }

    public class DetailsLeaveTypeViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
