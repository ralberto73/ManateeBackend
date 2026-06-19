using ManateeBackend.Application.Common.Interfaces;
using ManateeBackend.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ManateeBackend.Data;

public static class DependencyInjection
{
    /// <summary>
    /// Registers data-layer services (repositories, DbContext, etc.).
    /// </summary>
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddSingleton<IAccountRepository, AccountRepository>();

        return services;
    }
}
