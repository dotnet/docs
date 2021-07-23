using System;
using System.Collections.Generic;
using CachingExamples.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMemoryCache();
        services.AddHttpClient<CacheWorker>();
        services.AddHostedService<CacheWorker>();
        services.AddScoped<PhotoService>();
        services.AddSingleton<PhotoCacheSignal>();
    })
    .Build();

await host.StartAsync();

IServiceScopeFactory scopeFactory =
    host.Services.GetRequiredService<IServiceScopeFactory>();

for (int id = 1; id < 7; ++ id)
{
    using (IServiceScope scope = scopeFactory.CreateScope())
    {
        PhotoService service =
            scope.ServiceProvider.GetRequiredService<PhotoService>();

        Console.WriteLine($"Printing photos from album {id}");
        IAsyncEnumerable<Photo> photos = service.GetPhotosAsync(p => p.AlbumId == id);
        await foreach (Photo photo in photos)
        {
            Console.WriteLine(photo);
        }
        Console.WriteLine();
    }
}

host.Dispose();
