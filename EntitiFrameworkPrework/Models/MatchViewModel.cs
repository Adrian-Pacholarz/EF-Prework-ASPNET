using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Models
{
    public class MatchViewModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string home_name { get; set; }
        public int goals_home { get; set; }
        public int goals_away { get; set; }
        public string away_name { get; set; }
        public int goals_sum { get; set; }
    }
}
