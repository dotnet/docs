using WorkerScope.Example;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IObjectIdProvider, AutoIncrementingIdProvider>();
builder.Services.AddScoped<IObjectRelay, ObjectWorkerService>();
builder.Services.AddScoped<IObjectStore, ObjectWorkerService>();
builder.Services.AddScoped<IObjectProcessor, ObjectWorkerService>();

using IHost host = builder.Build();

await host.RunAsync();
