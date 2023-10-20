using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var healthChecksBuilder = builder.Services
    .AddSingleton<ExampleLifecycle>()
    .AddHostedService<ExampleLifecycle>()
    .AddHealthChecks()
    .AddApplicationLifecycleHealthCheck();

// You could use the healthChecksBuilder instance to add more checks...

var app = builder.Build();

var example = app.Services.GetRequiredService<ExampleLifecycle>();

async Task DelayAndRepostAsync()
{
    // Ensure app started...
    await Task.Delay(500);
    await example.PostStartedAndPreStoppingAsync();
}

await Task.WhenAll(DelayAndRepostAsync(), app.RunAsync());
