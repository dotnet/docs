using System.Runtime.CompilerServices;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

internal class ExampleLifecycle(
    HealthCheckService healthCheckService,
    ILogger<ExampleLifecycle> logger) : IHostedLifecycleService
{
    Task IHostedService.StartAsync(CancellationToken cancellationToken) =>
        CheckHealthAsync(cancellationToken: cancellationToken);

    Task IHostedLifecycleService.StartedAsync(CancellationToken cancellationToken) =>
        CheckHealthAsync(cancellationToken: cancellationToken);

    Task IHostedLifecycleService.StartingAsync(CancellationToken cancellationToken) =>
        CheckHealthAsync(cancellationToken: cancellationToken);

    Task IHostedService.StopAsync(CancellationToken cancellationToken) =>
        CheckHealthAsync(cancellationToken: cancellationToken);

    Task IHostedLifecycleService.StoppedAsync(CancellationToken cancellationToken) =>
        CheckHealthAsync(cancellationToken: cancellationToken);

    Task IHostedLifecycleService.StoppingAsync(CancellationToken cancellationToken) =>
        CheckHealthAsync(cancellationToken: cancellationToken);

    public Task PostStartedAndPreStoppingAsync() => CheckHealthAsync();

    private async Task CheckHealthAsync(
         [CallerMemberName] string eventName = "",
         CancellationToken cancellationToken = default)
    {
        var result =
            await healthCheckService.CheckHealthAsync(cancellationToken);

        logger.LogInformation(
            "{EventName}: {Status} {TotalDuration}",
            eventName, result.Status, result.TotalDuration);
    }
}
