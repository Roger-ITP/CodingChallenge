using LiveSim.Core.Interfaces;
using LiveSim.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveSim.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LiveSimDatabase");
            services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddScoped<IEntityLocationRepository, EntityLocationRepository>();

            return services;
        }
    }
}
