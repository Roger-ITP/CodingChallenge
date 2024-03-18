using LiveSim.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSim.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // don't use in production (as it would be called by each db context)
            // this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityLocation>()
                .ToTable(name: "EntityLocation", t => t.IsTemporal())
                .ComplexProperty(el => el.Location);

        }

        public DbSet<EntityLocation> EntityLocations { get; set; }
    }
}
