using LiveSim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSim.Core.Interfaces
{
    public interface IEntityLocationRepository
    {
        /// <summary>
        /// Gets the entity location for the given filters (params).
        /// </summary>
        /// <param name="trainingId">Filter by training</param>
        /// <param name="atTimestamp">Filter by timestamp</param>
        /// <param name="cancellationToken">Token to cancel request</param>
        /// <returns>Entity locations</returns>
        Task<IEnumerable<EntityLocation>> GetByFilterAsync(int? trainingId, DateTime? atTimestamp, CancellationToken cancellationToken = default);

        /// <summary>
        /// Saves given entity location. If the entity location exists, it is updated.
        /// </summary>
        /// <param name="entityLocation">Given entity location.</param>
        /// <param name="cancellationToken">Token to cancel request</param>
        /// <returns>Task</returns>
        Task SaveAsync(EntityLocation entityLocation, CancellationToken cancellationToken = default);
    }
}
