using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ManateeBackend.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Registers application-layer services (use cases, validators, mappers, etc.).
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection), lifetime: ServiceLifetime.Singleton);

        return services;
    }
}
