using FakeLocationProvider.Utils;
using LiveSim.Core.Entities;
using System.Net.Http.Json;

namespace FakeLocationProvider.Extensions
{
    internal static class EntityLocationExtensions
    {
        public static async Task PostAsJsonAsync(this IEnumerable<EntityLocation> soldiers, HttpClient httpClient, CancellationToken token)
        {
            var tasks = soldiers.Select(async s =>
            {
                if (token.IsCancellationRequested) return;

                // we set the timestamp before sending to simulate creation at different times
                s.CreatedAt = DateTime.UtcNow;

                HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/entitylocations", s, token);
                response.EnsureSuccessStatusCode();
            });

            await Task.WhenAll(tasks);
        }


        public static IEnumerable<EntityLocation> Transform(this IEnumerable<EntityLocation> soldiers, int direction, double step)
        {
            (var deltaLat, var deltaLng) = TransformUtils.GetDelta(direction, step);

            return soldiers.Select(s => s.Transform(deltaLat, deltaLng));
        }

        public static EntityLocation Transform(this EntityLocation entityLocation, double deltaLat, double deltaLng)
        {
            var tranformedLat = entityLocation.Location.Latitude + deltaLat;
            var tranformedLng = entityLocation.Location.Longitude + deltaLng;

            entityLocation.Location = new GpsLocation { Latitude = tranformedLat, Longitude = tranformedLng };
            return entityLocation;
        }


    }
}
