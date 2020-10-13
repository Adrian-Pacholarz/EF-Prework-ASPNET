using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntitiFrameworkPrework.Models;

namespace EntitiFrameworkPrework.ORM
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
               
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
