using Microsoft.EntityFrameworkCore;

namespace UrbanEnvi.Persistence;

public static class Config
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDefaultDbContext<ProjectsContext>(c => c
            .UseNpgsql(
                configuration.GetConnectionString(WellKnownServices.Postgis),
                o => o
                    .UseNodaTime()
                    .UseNetTopologySuite()
                    .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                    .MigrationsHistoryTable("__EFMigrationsHistory", "Projects")
            )
        );
}