using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Models.Assignment
{
    public class AssignmentCreate
    {
        
        [DisplayName("Task")]
        [Required]
        public string AssignmentName { get; set; }

        public string Description { get; set; }

        public int Points { get; set; }
    }
}
