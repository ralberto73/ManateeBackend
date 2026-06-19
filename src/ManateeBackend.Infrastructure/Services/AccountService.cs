using FluentValidation;
using ManateeBackend.Application.Accounts;
using ManateeBackend.Application.Common.Interfaces;
using ManateeBackend.Domain.Entities;
using ManateeBackend.Models;

namespace ManateeBackend.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IValidator<CreateAccountRequest> _validator;
    private readonly IAccountRepository _accountRepository;

    public AccountService(IValidator<CreateAccountRequest> validator, IAccountRepository accountRepository)
    {
        _validator = validator;
        _accountRepository = accountRepository;
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

        _accountRepository.Add(account);

        return AccountCreationResult.Success(account);
    }
}
