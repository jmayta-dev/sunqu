using Microsoft.Extensions.DependencyInjection;

namespace MW.SUNQU.UOM.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));

        return services;
    }
}