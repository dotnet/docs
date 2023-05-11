using CachingExamples.Memory;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMemoryCache();
        services.AddHttpClient<CacheWorker>();
        services.AddHostedService<CacheWorker>();
        services.AddScoped<PhotoService>();
        services.AddSingleton(typeof(CacheSignal<>));
    })
    .UseConsoleLifetime()
    .Build();

await host.StartAsync();

ILoggerFactory loggerFactory =
    host.Services.GetRequiredService<ILoggerFactory>();
IServiceScopeFactory scopeFactory =
    host.Services.GetRequiredService<IServiceScopeFactory>();

for (int id = 1; id < 7; ++ id)
{
    using (IServiceScope scope = scopeFactory.CreateScope())
    {
        ILogger logger = loggerFactory.CreateLogger("Program");

        PhotoService service =
            scope.ServiceProvider.GetRequiredService<PhotoService>();
        
        await foreach (Photo photo in service.GetPhotosAsync(p => p.AlbumId == id))
        {
            logger.LogInformation("{PhotoDetails}", photo.ToString());
        }

        logger.LogInformation("");
    }
}
