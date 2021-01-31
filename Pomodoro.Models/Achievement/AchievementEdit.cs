using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Models.Achievement
{
    public class AchievementEdit
    {
        public int AchievementId { get; set; }
        [DisplayName("Achievement")]
        public string AchievementName { get; set; }
        public string Description { get; set; }
        [DisplayName("Total Completes")]
        public int TotalCompletes { get; set; }
        [DisplayName("Remaining Points")]
        public int PointsToUnlock { get; set; }
        public bool IsUnlocked { get; set; }
        public string Message { get; set; }
    }
}
