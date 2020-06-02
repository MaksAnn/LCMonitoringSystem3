using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCMonitoringSystem3.Models
{
    public class IndicatorsDbContext: DbContext
    {
        public DbSet<IndicatorsModel> Indicators { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Year> Year { get; set; }
        public IndicatorsDbContext(DbContextOptions<IndicatorsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
