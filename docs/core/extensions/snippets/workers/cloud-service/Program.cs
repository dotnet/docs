using App.CloudService;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

IHost host = builder.Build();
host.Run();
