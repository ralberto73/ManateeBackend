namespace ManateeBackend.Application.Common.Interfaces;

/// <summary>
/// Abstraction over the current time so application logic stays testable.
/// </summary>
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
