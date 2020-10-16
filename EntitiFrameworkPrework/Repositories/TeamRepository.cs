using EntitiFrameworkPrework.Models;
using EntitiFrameworkPrework.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public MyAppContext myAppContext
        {
            get { return Context as MyAppContext; }
        }
        public TeamRepository(MyAppContext context)
            :base(context)
        {

        }
        public IEnumerable<Team> GetTeamsContainingFC()
        {
            return myAppContext.Teams.Where(t => t.name.Contains("FC")).ToList();
        }

        public IEnumerable<TeamGoalsViewModel> GetTeamsWithHomeGoals()
        {
            return myAppContext.Teams
                .Join(
                myAppContext.Matches,
                team => team.id,
                match_home => match_home.home_team.id,
                (team, match_home) => new TeamGoalsViewModel { id = team.id, name = team.name, home_goals = match_home.goals_home })
                .GroupBy(
                team => team.name,
                team => team.home_goals,
                (key, g) => new TeamGoalsViewModel { name = key, home_goals = g.Sum(g => g)})
                .ToList();
        }

        public IEnumerable<TeamGoalsViewModel> GetTeamsWithAwayGoals()
        {
            return myAppContext.Teams
                .Join(
                myAppContext.Matches,
                team => team.id,
                match_away => match_away.away_team.id,
                (team, match_away) => new TeamGoalsViewModel { id = team.id, name = team.name, away_goals = match_away.goals_away })
                .GroupBy(
                team => team.name,
                team => team.away_goals,
                (key, g) => new TeamGoalsViewModel { name = key, away_goals = g.Sum(g => g) })
                .ToList();
        }

        public IEnumerable<TeamGoalsViewModel> GetTeamsWithGoals()
        {
            List<TeamGoalsViewModel> teamsgoals = new List<TeamGoalsViewModel>();

            var awayGoals = GetTeamsWithAwayGoals();
            var homeGoals = GetTeamsWithHomeGoals();

            foreach (var awayTeams in awayGoals)
            {
                foreach (var homeTeams in homeGoals)
                {
                    if (awayTeams.name == homeTeams.name)
                    {
                        teamsgoals.Add(new TeamGoalsViewModel { name = awayTeams.name, away_goals = awayTeams.away_goals, home_goals = homeTeams.home_goals, all_goals = awayTeams.away_goals +  homeTeams.home_goals });
                    }
                }
            }

            return teamsgoals;
        }
    }
}
