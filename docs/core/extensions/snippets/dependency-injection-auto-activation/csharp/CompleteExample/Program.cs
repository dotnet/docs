using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// <snippet>
// Register service with auto-activation
builder.Services.AddActivatedSingleton<CacheWarmer>();
// </snippet>

var host = builder.Build();

// CacheWarmer is already instantiated and initialized at this point
await host.RunAsync();

// <CacheWarmer>
public class CacheWarmer
{
    public CacheWarmer()
    {
        Console.WriteLine("Warming up cache at startup...");
        // Perform expensive initialization
        WarmUpCache();
    }

    private void WarmUpCache()
    {
        // Cache warming logic here
        Console.WriteLine("Cache warmed up successfully!");
    }
}
// </CacheWarmer>
