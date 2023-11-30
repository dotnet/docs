using App.WindowsService;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET Joke Service";
    })
    .ConfigureServices((context, services) =>
    {
        LoggerProviderOptions.RegisterProviderOptions<
            EventLogSettings, EventLogLoggerProvider>(services);
    
        services.AddSingleton<JokeService>();
        services.AddHostedService<WindowsBackgroundService>();
    });

IHost host = builder.Build();
host.Run();
