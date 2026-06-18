using ManateeBackend.Application.Common.Interfaces;
using ManateeBackend.Domain.Entities;
using ManateeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManateeBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [EndpointSummary("Creates a new account.")]
    [EndpointDescription("Validates the request and creates a new account. Returns the created account on success, or validation errors if the request is invalid.")]
    [ProducesResponseType<Account>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Account>> Post(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var result = await _accountService.CreateAsync(request, cancellationToken);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return ValidationProblem(ModelState);
        }

        return Created($"/api/account/{result.Account!.Account_Id}", result.Account);
    }
}
