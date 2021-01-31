using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Models.Assignment
{
    public class AssignmentListItem
    {
        public int AssignmentId { get; set; }
        public string Description { get; set; }
           
        [DisplayName("Task")]
        public string AssignmentName { get; set; }
        public int Points { get; set; }
    }
}
