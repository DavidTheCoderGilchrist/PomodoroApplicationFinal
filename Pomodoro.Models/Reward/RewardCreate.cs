using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Models.Reward
{
    public class RewardCreate
    {
        public int RewardId { get; set; }
        [DisplayName("Reward")]
        public string RewardName { get; set; }
        public string Description { get; set; }
        [DisplayName("Point Cost")]
        public int PointCost { get; set; }
    }
}
