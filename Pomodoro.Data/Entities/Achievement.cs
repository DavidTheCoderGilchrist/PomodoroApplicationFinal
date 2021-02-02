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
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }
        public Guid OwnerId { get; set; }
        [DisplayName("Achievement")]
        public string AchievementName { get; set; }
        public string Description { get; set; }
        [DisplayName("Total Completes")]
        public int TotalCompletes { get; set; }
        [DisplayName("Remaining Points")]
        public int PointsToUnlock { get; set; }
        public bool IsUnlocked { get; set; }
        public string Message { get; set; }

        //public virtual ICollection<ScoreKeeper> ScoreKeepers { get; set; } = new List<ScoreKeeper>();

    }
}
