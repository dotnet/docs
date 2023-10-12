using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddResourceMonitoring();

var healthChecksBuilder = builder.Services.AddHealthChecks()    
    .AddResourceUtilizationHealthCheck();

var app = builder.Build();

var healthCheckService = app.Services.GetRequiredService<HealthCheckService>();

var result = await healthCheckService.CheckHealthAsync();

_ = result;

app.Run();
