using EntitiFrameworkPrework.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppContext _context;
        public ITeamRepository Teams { get; }

        public IMatchRepository Matches { get; }

        public UnitOfWork(MyAppContext context)
        {
            this._context = context;
            Teams = new TeamRepository(_context);
            Matches = new MatchRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
