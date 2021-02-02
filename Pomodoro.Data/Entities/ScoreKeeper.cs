using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Data.Entities
{
    public class ScoreKeeper
    {
        [Key, Column(Order=0)]
        [ForeignKey(nameof(Person))]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Reward))]
        public int RewardKeeperID { get; set; }
        public virtual Reward Reward { get; set; }


        //[Key, Column(Order = 2)]
        //[ForeignKey(nameof(Achievement))]
        //public int AchievementKeeperID { get; set; }
        //public virtual Achievement Achievement { get; set; }

        //[Key, Column(Order = 3)]
        //[ForeignKey(nameof(Assignment))]
        //public int AssignmentKeeperID { get; set; }
        //public virtual Assignment Assignment { get; set; }
    }
}
