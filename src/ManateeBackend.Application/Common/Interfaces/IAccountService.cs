using ManateeBackend.Application.Accounts;
using ManateeBackend.Models;

namespace ManateeBackend.Application.Common.Interfaces;

/// <summary>
/// Orchestrates account use cases (creation, lookup, etc.), including request validation.
/// </summary>
public interface IAccountService
{
    Task<AccountCreationResult> CreateAsync(CreateAccountRequest request, CancellationToken cancellationToken = default);
}
