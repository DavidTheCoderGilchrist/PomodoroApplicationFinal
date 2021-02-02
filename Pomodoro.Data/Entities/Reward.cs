using Pomodoro.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Data
{
    public class Reward
    {
        [Key]
        public int RewardId { get; set; }
        public Guid OwnerId { get; set; }
        [DisplayName("Reward")]
        public string RewardName { get; set; }
        public string Description { get; set; }
        [DisplayName("Point Cost")]
        public int PointCost { get; set; }

        public virtual ICollection<ScoreKeeper> ScoreKeepers { get; set; } = new List<ScoreKeeper>();


    }
}
