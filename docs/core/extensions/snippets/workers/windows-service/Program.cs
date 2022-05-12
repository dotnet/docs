using App.WindowsService;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET Joke Service";
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<JokeService>();
        services.AddHostedService<WindowsBackgroundService>();
    })
    .Build();

await host.RunAsync();
