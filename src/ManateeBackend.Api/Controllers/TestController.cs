using Microsoft.AspNetCore.Mvc;

namespace ManateeBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Test endpoint.")]
    [EndpointDescription("Simple endpoint to verify the API is reachable.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        return Ok(new
        {
            Message = "Test endpoint is working"
        });
    }
}
