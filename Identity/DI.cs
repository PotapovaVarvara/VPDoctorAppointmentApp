using Microsoft.Extensions.DependencyInjection;

namespace Identity;

public static class DiRegistry
{
    public static IServiceCollection AddDiIdentity(this IServiceCollection services)
    {
        services.AddScoped<ICurrentContextSetup, CurrentContext>();
        services.AddScoped<ICurrentContext, CurrentContext>();
        
        return services;
    }
}
