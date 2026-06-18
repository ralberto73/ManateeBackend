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
    [EndpointSummary("Returns API health status.")]
    [EndpointDescription("Returns the current health status and UTC timestamp of the API.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "Healthy",
            TimestampUtc = _dateTimeProvider.UtcNow
        });
    }
}
