using Microsoft.Extensions.DependencyInjection;
using MW.SUNQU.UOM.Domain.Interfaces;
using MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Context;
using MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Repositories;

namespace MW.SUNQU.UOM.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddServices();
        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<UnitOfMeasureDbContext>();
        services.AddTransient<IUnitOfWorkUom, UnitOfWorkUom>();
    }
}