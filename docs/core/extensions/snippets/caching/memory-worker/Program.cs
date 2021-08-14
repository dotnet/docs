using System.Collections.Generic;
using CachingExamples.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMemoryCache();
        services.AddHttpClient<CacheWorker>();
        services.AddHostedService<CacheWorker>();
        services.AddScoped<PhotoService>();
        services.AddSingleton(typeof(CacheSignal<>));
    })
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

        IAsyncEnumerable<Photo> photos = service.GetPhotosAsync(p => p.AlbumId == id);
        await foreach (Photo photo in photos)
        {
            logger.LogInformation(photo.ToString());
        }

        logger.LogInformation("");
    }
}
