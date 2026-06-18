namespace ManateeBackend.Models;

/// <summary>
/// Request contract for creating a new account.
/// </summary>
public class CreateAccountRequest
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
