using ManateeBackend.Application.Common.Interfaces;
using ManateeBackend.Data;
using ManateeBackend.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ManateeBackend.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Registers infrastructure-layer services (persistence, external clients, etc.).
    /// </summary>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDataServices();

        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
        services.AddSingleton<IAccountService, AccountService>();

        return services;
    }
}
