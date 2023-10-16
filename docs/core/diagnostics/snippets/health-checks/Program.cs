using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddResourceMonitoring();

var healthChecksBuilder = builder.Services
    .AddHealthChecks()
    .AddResourceUtilizationHealthCheck();

var app = builder.Build();

var healthCheckService = app.Services.GetRequiredService<HealthCheckService>();

var result = await healthCheckService.CheckHealthAsync();

Console.WriteLine($"{result.Status} {result.TotalDuration}");

app.Run();

// Sample output:
//   info: Microsoft.Extensions.Diagnostics.ResourceMonitoring.Internal.WindowsSnapshotProvider[3]
//         Resource Utilization is running outside of Job Object.
//         For more information about Job Objects see https://aka.ms/job-objects
//   Healthy 00:00:00.1019892
//   info: Microsoft.Hosting.Lifetime[0]
//         Application started. Press Ctrl+C to shut down.
//   info: Microsoft.Hosting.Lifetime[0]
//         Hosting environment: Production
//   info: Microsoft.Hosting.Lifetime[0]
//         Content root path: .\health-checks\bin\Debug\net8.0
