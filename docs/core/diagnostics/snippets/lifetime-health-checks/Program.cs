using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var healthChecksBuilder = builder.Services
    .AddHostedService<ExampleLifecycle>()
    .AddHealthChecks()
    .AddApplicationLifecycleHealthCheck();

// You could use the healthChecksBuilder instance to add more checks...

var app = builder.Build();

var services = app.Services.GetRequiredService<IEnumerable<IHostedService>>();

await Task.WhenAll(DelayAndReportAsync(services), app.RunAsync());

static async Task DelayAndReportAsync(IEnumerable<IHostedService> services)
{
    // Ensure app started...
    await Task.Delay(500);

    var service = services.FirstOrDefault(static s => s is ExampleLifecycle);
    if (service is ExampleLifecycle example)
    {
        await example.ReadyAsync();
    }
}
