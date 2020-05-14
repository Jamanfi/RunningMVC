using RunningMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RunningMVC.Data
{
    public class RaceContext : IdentityDbContext<User>

    {
        public RaceContext(DbContextOptions<RaceContext> options) : base(options)
        {

        }
        public DbSet<Race> Races { get; set; }
        public DbSet<Runner> Runners { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
