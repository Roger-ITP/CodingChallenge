using LiveSim.Core.Entities;
using LiveSim.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveSim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityLocationsController : ControllerBase
    {
        private readonly IEntityLocationRepository repository;

        public EntityLocationsController(IEntityLocationRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/EntityLocations>
        [HttpGet]
        public async Task<IEnumerable<EntityLocation>> Get(int? trainingId, DateTime? atTimestamp, CancellationToken cancellationToken)
        {
            return await repository.GetByFilterAsync(trainingId, atTimestamp, cancellationToken);
        }

        // POST api/EntityLocations
        [HttpPost]
        public async Task Post([FromBody] EntityLocation entityLocation)
        {
            // TODO: get the trainingId by Id & Type
            entityLocation.TrainingId = 12345;

            await repository.SaveAsync(entityLocation);
        }

    }
}
