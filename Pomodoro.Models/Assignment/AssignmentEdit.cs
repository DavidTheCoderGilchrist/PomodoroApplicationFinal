﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Models.Assignment
{
    public class AssignmentEdit
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
    }
}
