using CachingExamples.Memory;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<CacheWorker>();
builder.Services.AddHostedService<CacheWorker>();
builder.Services.AddScoped<PhotoService>();
builder.Services.AddSingleton(typeof(CacheSignal<>));

using IHost host = builder.Build();

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
