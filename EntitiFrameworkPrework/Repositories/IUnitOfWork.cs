using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFrameworkPrework.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITeamRepository Teams { get; }
        IMatchRepository Matches { get; }
    }
}
