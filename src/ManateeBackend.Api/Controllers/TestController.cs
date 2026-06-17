using Microsoft.AspNetCore.Mvc;

namespace ManateeBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Message = "Test endpoint is working"
        });
    }
}
