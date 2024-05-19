using WorkerServiceOptions.Example;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<PriorityQueue>();

using IHost host = builder.Build();

host.Run();
