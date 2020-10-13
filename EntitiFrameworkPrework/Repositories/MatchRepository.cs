using EntitiFrameworkPrework.Models;
using EntitiFrameworkPrework.ORM;
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
    }
}
