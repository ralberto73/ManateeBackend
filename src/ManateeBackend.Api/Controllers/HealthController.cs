using ManateeBackend.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManateeBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public HealthController(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "Healthy",
            TimestampUtc = _dateTimeProvider.UtcNow
        });
    }
}
