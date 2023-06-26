using DependencyInjection.Example;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IMessageWriter, MessageWriter>();

using IHost host = builder.Build();

host.Run();
