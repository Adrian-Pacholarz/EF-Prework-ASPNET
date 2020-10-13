using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Models
{
    public class TeamMatchViewModel
    {
        public IEnumerable<Team> teams { get; set; }
        public IEnumerable<Match> matches { get; set; }
    }
}
