namespace ManateeBackend.Domain.Entities;

/// <summary>
/// Represents an account.
/// </summary>
public class Account
{
    public Guid Account_Id { get; set; } = Guid.NewGuid();

    public string Account_Name { get; set; } = string.Empty;

    public string Account_Email { get; set; } = string.Empty;

    public bool Account_IsActive { get; set; } = true;

    public DateTime Account_CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
