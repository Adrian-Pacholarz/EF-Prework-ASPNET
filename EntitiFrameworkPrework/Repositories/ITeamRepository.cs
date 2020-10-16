using EntitiFrameworkPrework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        IEnumerable<Team> GetTeamsContainingFC();

        IEnumerable<TeamGoalsViewModel> GetTeamsWithGoals();

        IEnumerable<TeamGoalsViewModel> GetTeamsPlayedMoreMatches();

        Team GetBestTeam();
    }
}
