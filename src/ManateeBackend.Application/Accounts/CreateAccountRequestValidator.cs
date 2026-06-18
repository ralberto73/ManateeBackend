using FluentValidation;
using ManateeBackend.Models;

namespace ManateeBackend.Application.Accounts;

/// <summary>
/// Validation rules for <see cref="CreateAccountRequest"/>.
/// </summary>
public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256);
    }
}
