using LiveSim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSim.Core.Interfaces
{
    public interface IEntityLocationService
    {
        /// <summary>
        /// Gets the current locations for the given training.
        /// </summary>
        /// <param name="TrainingId">Given training</param>
        /// <returns>Current entity locations</returns>
        Task<IEnumerable<EntityLocation>> GetLiveLocationsAsync(int TrainingId);

        /// <summary>
        /// Gets the historical locations for the given training.
        /// </summary>
        /// <param name="TrainingId">Given training</param>
        /// <param name="atTimestamp">Point in time, when the locations were valid.</param>
        /// <returns>Historical entity locations</returns>
        Task<IEnumerable<EntityLocation>> GetHistoricalLocationsAtAsync(int TrainingId, DateTime atTimestamp);
    }
}
