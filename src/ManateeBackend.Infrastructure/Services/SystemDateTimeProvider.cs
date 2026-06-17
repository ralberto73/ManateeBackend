using ManateeBackend.Application.Common.Interfaces;

namespace ManateeBackend.Infrastructure.Services;

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
