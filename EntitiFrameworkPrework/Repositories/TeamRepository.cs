using EntitiFrameworkPrework.Models;
using EntitiFrameworkPrework.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return myAppContext.Teams.ToList();
        }

    }
}
