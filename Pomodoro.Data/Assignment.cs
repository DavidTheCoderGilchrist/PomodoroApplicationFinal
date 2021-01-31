using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Data
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        public Guid OwnerId { get; set; }
        [DisplayName("Task")]
        public string AssignmentName { get; set; }
        public string Description { get; set; }
        public int Points{ get; set; }
                 
    }
}
