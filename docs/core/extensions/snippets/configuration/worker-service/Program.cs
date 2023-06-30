using WorkerService.Example;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();

using IHost host = builder.Build();

await host.RunAsync();
