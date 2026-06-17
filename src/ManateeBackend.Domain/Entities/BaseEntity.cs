namespace ManateeBackend.Domain.Entities;

/// <summary>
/// Base class for all domain entities, providing identity and audit fields.
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
