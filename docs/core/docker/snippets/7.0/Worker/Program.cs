using DotNet.ContainerImage;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

using IHost host = builder.Build();

host.Run();
