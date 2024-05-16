using App.TimerHostedService;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<TimerService>();

IHost host = builder.Build();
host.Run();
