using LiveSim.Core.Entities;
using LiveSim.Core.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace LiveSim.Wpf.Simple.Services
{
    public class EntityLocationService : IEntityLocationService
    {
        const string API_BASEADDRESS = "https://localhost:7205";
        private readonly string END_POINT = "api/entitylocations";
        private readonly HttpClient httpClient;
        public EntityLocationService(IHttpClientFactory factory)
        {
            this.httpClient = factory.CreateClient();
            this.httpClient.BaseAddress = new Uri(API_BASEADDRESS);
        }

        public async Task<IEnumerable<EntityLocation>> GetHistoricalLocationsAtAsync(int trainingId, DateTime atTimestamp)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<EntityLocation>>($"{END_POINT}?trainingId={trainingId}&atTimestamp={atTimestamp}");
        }

        public async Task<IEnumerable<EntityLocation>> GetLiveLocationsAsync(int trainingId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<EntityLocation>>($"{END_POINT}?trainingId={trainingId}");
        }
    }
}
