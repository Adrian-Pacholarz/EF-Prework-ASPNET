using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Models
{
    public class Match
    {
        public int id { get; set; }
        public DateTime date { get; set; }

        [ForeignKey("home_team_id")]
        public Team home_team { get; set; }

        [ForeignKey("away_team_id")]
        public Team away_team { get; set; }
        public int goals_home { get; set; }
        public int goals_away { get; set; }
    }
}
