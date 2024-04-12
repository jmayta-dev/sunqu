using Microsoft.Extensions.DependencyInjection;
using MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Context;

namespace MW.SUNQU.UOM.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddServices();
        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<UnitOfMeasureDbContext>();
    }
}