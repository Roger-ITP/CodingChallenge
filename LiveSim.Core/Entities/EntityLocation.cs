using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSim.Core.Entities
{
    public class EntityLocation
    {
        public EntityLocation() { }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; init; }
        public EntityType Type { get; set; }
        public GpsLocation Location { get; set; }

        public DateTime CreatedAt { get; set; }

        public int TrainingId { get; set; }

        public string ToString()
        {
            return $"EntityLocation(Id={Id}, Type={Type}, CreatedAt={CreatedAt:yyyy-MM-ddTHH:mm:ssZ}, GpsLocation(Latitude={Location.Latitude}, Longitude{Location.Longitude}), TrainingId={TrainingId})";
        }
    }
}
