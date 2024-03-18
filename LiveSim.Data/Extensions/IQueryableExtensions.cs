using LiveSim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSim.Data.Extensions
{
    internal static class IQueryableExtensions
    {
        internal static IQueryable<EntityLocation> AddOptionalTrainingFilter(this IQueryable<EntityLocation> queryable, int? trainingId)
        {
            if (trainingId is null) return queryable;

            return queryable.Where(x => x.TrainingId == trainingId);
        }
    }
}
