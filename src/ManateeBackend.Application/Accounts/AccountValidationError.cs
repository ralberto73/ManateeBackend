namespace ManateeBackend.Application.Accounts;

/// <summary>
/// A single field-level validation failure, decoupled from any specific validation library.
/// </summary>
public record AccountValidationError(string PropertyName, string ErrorMessage);
