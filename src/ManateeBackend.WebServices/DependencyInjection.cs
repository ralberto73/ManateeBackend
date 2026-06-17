using Microsoft.Extensions.DependencyInjection;

namespace ManateeBackend.WebServices;

public static class DependencyInjection
{
    /// <summary>
    /// Registers web service client implementations against the interfaces defined in
    /// ManateeBackend.WebServices.Interfaces.
    /// </summary>
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        return services;
    }
}
