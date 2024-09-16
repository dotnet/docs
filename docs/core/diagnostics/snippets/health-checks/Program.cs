using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHealthChecks()
    .AddResourceUtilizationHealthCheck();

var app = builder.Build();

var healthCheckService = app.Services.GetRequiredService<HealthCheckService>();

var result = await healthCheckService.CheckHealthAsync();

Console.WriteLine($"{result.Status} {result.TotalDuration}");

app.Run();
