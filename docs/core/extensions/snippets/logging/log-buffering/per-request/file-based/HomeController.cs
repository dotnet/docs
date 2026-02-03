using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.Buffering;
using Microsoft.Extensions.Logging;

namespace PerRequestLogBufferingFileBased;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly PerRequestLogBuffer _buffer;

    public HomeController(ILogger<HomeController> logger, PerRequestLogBuffer buffer)
    {
        _logger = logger;
        _buffer = buffer;
    }

    [HttpGet("index/{id}")]
    public IActionResult Index(int id)
    {
        try
        {
            _logger.RequestStarted(id);

            // Simulate exception every 10th request
            if (id % 10 == 0)
            {
                throw new Exception("Simulated exception in controller");
            }

            _logger.RequestEnded(id);

            return Ok();
        }
        catch
        {
            _logger.ErrorMessage(id);
            _buffer.Flush();

            _logger.ExceptionHandlingFinished(id);

            return StatusCode(500, "An error occurred.");
        }
    }
}
