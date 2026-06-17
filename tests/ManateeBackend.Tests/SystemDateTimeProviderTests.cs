using ManateeBackend.Infrastructure.Services;

namespace ManateeBackend.Tests;

public class SystemDateTimeProviderTests
{
    [Fact]
    public void UtcNow_ReturnsCurrentTime()
    {
        var provider = new SystemDateTimeProvider();
        var before = DateTime.UtcNow;

        var result = provider.UtcNow;

        var after = DateTime.UtcNow;
        Assert.InRange(result, before.AddSeconds(-1), after.AddSeconds(1));
    }
}
