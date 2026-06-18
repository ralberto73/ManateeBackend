using System.Collections.Concurrent;
using FluentValidation;
using ManateeBackend.Application.Accounts;
using ManateeBackend.Application.Common.Interfaces;
using ManateeBackend.Domain.Entities;
using ManateeBackend.Models;

namespace ManateeBackend.Infrastructure.Services;

/// <summary>
/// In-memory implementation of <see cref="IAccountService"/>. Serves as a placeholder
/// until a persistent store (e.g. EF Core + a database) is introduced.
/// </summary>
public class AccountService : IAccountService
{
    private readonly ConcurrentDictionary<Guid, Account> _accounts = new();
    private readonly IValidator<CreateAccountRequest> _validator;

    public AccountService(IValidator<CreateAccountRequest> validator)
    {
        _validator = validator;
    }

    public async Task<AccountCreationResult> CreateAsync(CreateAccountRequest request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => new AccountValidationError(e.PropertyName, e.ErrorMessage));

            return AccountCreationResult.Failure(errors);
        }

        var account = new Account
        {
            Account_Name = request.Name,
            Account_Email = request.Email,
            Account_IsActive = request.IsActive
        };

        _accounts[account.Account_Id] = account;

        return AccountCreationResult.Success(account);
    }
}
