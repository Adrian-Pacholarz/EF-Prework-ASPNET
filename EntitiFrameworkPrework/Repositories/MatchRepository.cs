using EntitiFrameworkPrework.Models;
using EntitiFrameworkPrework.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MyAppContext myAppContext
        {
            get { return Context as MyAppContext; }
        }
        public MatchRepository(MyAppContext context)
            : base(context)
        {

        }

        public MatchViewModel GetMostGoalsMatch()
        {
            return myAppContext.Matches.Select(m => new MatchViewModel
            {
                id = m.id,
                date = m.date,
                home_name = m.home_team.name,
                goals_home = m.goals_home,
                goals_away = m.goals_away,
                away_name = m.away_team.name,
                goals_sum = m.goals_away + m.goals_home,
            })
             .OrderByDescending(m => m.goals_sum)
             .First();
        }

        public IEnumerable<Match> GetMatchesFromLastWeek()
        {
            return myAppContext.Matches.Where(m => m.date >= DateTime.Now.AddDays(-7))
                .Include(m => m.home_team)
                .Include(m => m.away_team)
                .ToList();
        }
    }
}
