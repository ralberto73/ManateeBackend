namespace ManateeBackend.Domain.Entities;

/// <summary>
/// Represents an account.
/// </summary>
public class Account : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
