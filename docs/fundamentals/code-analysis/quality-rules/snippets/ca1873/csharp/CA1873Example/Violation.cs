using Microsoft.Extensions.Logging;

// <ViolationExample>
class ViolationExample
{
    private readonly ILogger _logger;

    public ViolationExample(ILogger<ViolationExample> logger)
    {
        _logger = logger;
    }

    public void ProcessData(int[] data)
    {
        // Violation: expensive operation in logging argument.
        _logger.LogDebug($"Processing {string.Join(", ", data)} items");

        // Violation: object creation in logging argument.
        _logger.LogTrace("Data: {Data}", new { Count = data.Length, Items = data });
    }
}
// </ViolationExample>
