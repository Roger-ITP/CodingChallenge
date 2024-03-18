using LiveSim.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSim.Data.Extensions
{
    internal static class DbSetExtensions
    {

        internal static IQueryable<EntityLocation> AddOptionalTimestampFilter(this DbSet<EntityLocation> dbSet, DateTime? atTimestamp)
        {
            if (atTimestamp is null) return dbSet;

            return dbSet.TemporalAsOf(atTimestamp.Value);
        }

    }
}
