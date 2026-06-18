using ManateeBackend.Domain.Entities;

namespace ManateeBackend.Application.Accounts;

/// <summary>
/// Outcome of the account-creation use case: either the created account, or the
/// validation errors that prevented it from being created.
/// </summary>
public class AccountCreationResult
{
    public bool IsValid { get; private init; }

    public Account? Account { get; private init; }

    public IReadOnlyCollection<AccountValidationError> Errors { get; private init; } = [];

    public static AccountCreationResult Success(Account account) =>
        new() { IsValid = true, Account = account };

    public static AccountCreationResult Failure(IEnumerable<AccountValidationError> errors) =>
        new() { IsValid = false, Errors = errors.ToList() };
}
