using AnyKeyExamples;
using Microsoft.Extensions.DependencyInjection;
FallbackExample();

static void FallbackExample()
{
    // <FallbackRegistration>
    var services = new ServiceCollection();

    // Register a fallback cache for any key.
    services.AddKeyedSingleton<ICache>(KeyedService.AnyKey, (sp, key) =>
    {
        // Create a cache instance based on the key.
        return new DefaultCache(key?.ToString() ?? "unknown");
    });

    // Register a specific cache for the "premium" key.
    services.AddKeyedSingleton<ICache>("premium", new PremiumCache());

    ServiceProvider provider = services.BuildServiceProvider();

    // Requesting with "premium" key returns PremiumCache.
    ICache? premiumCache = provider.GetKeyedService<ICache>("premium");
    Console.WriteLine($"Premium key: {premiumCache}");

    // Requesting with any other key uses the AnyKey fallback.
    ICache? basicCache = provider.GetKeyedService<ICache>("basic");
    Console.WriteLine($"Basic key: {basicCache}");

    ICache? standardCache = provider.GetKeyedService<ICache>("standard");
    Console.WriteLine($"Standard key: {standardCache}");

    /* This example outputs:
     * 
     * Premium key: Premium cache
     * Basic key: basic cache
     * Standard key: standard cache
    */
    // </FallbackRegistration>

    // <AnyKeyQuery>
    IEnumerable<ICache>? keyedCaches = provider.GetKeyedServices<ICache>(KeyedService.AnyKey);
    foreach (ICache cache in keyedCaches)
    {
        Console.WriteLine($"AnyKey registered cache: {cache}");
    }

    /* This example outputs:
     * 
     * AnyKey registered cache: Premium cache
    */
    // </AnyKeyQuery>
}
