using App.ScopedService;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ScopedBackgroundService>();
builder.Services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();

IHost host = builder.Build();
host.Run();
