using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Data.Entities
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Points { get; set; }

        public virtual ICollection<ScoreKeeper> ScoreKeepers { get; set; } = new List<ScoreKeeper>();
    }
}
