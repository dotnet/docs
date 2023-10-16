using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var healthChecksBuilder = builder.Services
    .AddHealthChecks()
    .AddApplicationLifecycleHealthCheck();

var app = builder.Build();

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
var healthCheckService = app.Services.GetRequiredService<HealthCheckService>();

void ReportHealthCheck(string eventName)
{
    // ⚠️ Normally, you would await the result of CheckHealthAsync, but this
    // function is called in a synchronous context, so we block instead...
    var result = healthCheckService!.CheckHealthAsync().GetAwaiter().GetResult();

    Console.WriteLine($"{eventName}: {result.Status} {result.TotalDuration}");
}

lifetime.ApplicationStarted.Register(() => ReportHealthCheck("Started"));
lifetime.ApplicationStopping.Register(() => ReportHealthCheck("Stopping"));
lifetime.ApplicationStopped.Register(() => ReportHealthCheck("Stopped"));

app.Run();

// Sample output:
//   info: Microsoft.Hosting.Lifetime[0]
//         Application started. Press Ctrl+C to shut down.
//   info: Microsoft.Hosting.Lifetime[0]
//         Hosting environment: Production
//   info: Microsoft.Hosting.Lifetime[0]
//         Content root path: .\lifecycle-health-checks\bin\Debug\net8.0
//   Started: Healthy 00:00:00.0159571
//   info: Microsoft.Hosting.Lifetime[0]
//         Application is shutting down...
//   fail: Microsoft.Extensions.Diagnostics.HealthChecks.DefaultHealthCheckService[103]
//         Health check ApplicationLifecycle with status
//         Unhealthy completed after 0.0067ms with message 'Stopping'
//   Stopping: Unhealthy 00:00:00.0307552
//   fail: Microsoft.Extensions.Diagnostics.HealthChecks.DefaultHealthCheckService[103]
//         Health check ApplicationLifecycle with status
//         Unhealthy completed after 0.0052ms with message 'Stopping'
//   Stopped: Unhealthy 00:00:00.0015680
