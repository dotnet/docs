using Microsoft.Extensions.Logging;

internal sealed class JobRunner(ILogger<JobRunner> logger)
{
    public async Task RunAsync()
    {
        logger.LogInformation("Starting job...");

        // Simulate work
        await Task.Delay(1000);

        // Simulate failure
        // throw new InvalidOperationException("Something went wrong!");

        logger.LogInformation("Job completed successfully.");
    }
}
