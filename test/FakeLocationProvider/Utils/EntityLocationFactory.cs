using LiveSim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeLocationProvider.Utils
{
    internal class EntityLocationFactory
    {
        private readonly GpsLocation initalLocation;
        private readonly double DISTANCE = 0.000001;

        public EntityLocationFactory(GpsLocation initalLocation)
        {
            this.initalLocation = initalLocation;
        }

        public IEnumerable<EntityLocation> Create(EntityType entityType, int row, int col)
        {
            var id = 1;
            List<EntityLocation> soldiers = new();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    // arrange the entities in row and colums
                    var position = new GpsLocation { Latitude = initalLocation.Latitude + row * DISTANCE, Longitude = initalLocation.Longitude + col * DISTANCE };
                    var soldier = new EntityLocation { Id = id++, Location = position, Type = entityType };
                    soldiers.Add(soldier);
                }
            }

            return soldiers;
        }
    }
}
