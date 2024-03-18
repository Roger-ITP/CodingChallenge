using LiveSim.Core.Entities;
using LiveSim.Core.Interfaces;
using LiveSim.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LiveSim.Data.Repositories
{
    internal class EntityLocationRepository : IEntityLocationRepository
    {
        private readonly DatabaseContext dbContext;

        public EntityLocationRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<EntityLocation>> GetByFilterAsync(int? trainingId, DateTime? atTimestamp, CancellationToken cancellationToken = default)
        {
            return await dbContext.EntityLocations
                .AddOptionalTimestampFilter(atTimestamp)
                .AsNoTracking()
                .AddOptionalTrainingFilter(trainingId)
                .ToListAsync(cancellationToken);

        }

        public async Task SaveAsync(EntityLocation entityLocation, CancellationToken cancellationToken = default)
        {
            var existingEntityLocation = await dbContext.EntityLocations.FirstOrDefaultAsync(el => el.Id == entityLocation.Id);
            if (existingEntityLocation is null)
            {
                dbContext.EntityLocations
                    .Add(entityLocation);
            }
            else
            {
                existingEntityLocation.Location = entityLocation.Location;
                existingEntityLocation.CreatedAt = entityLocation.CreatedAt;
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
