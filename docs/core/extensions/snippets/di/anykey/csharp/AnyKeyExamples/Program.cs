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

    var provider = services.BuildServiceProvider();

    // Requesting with "premium" key returns PremiumCache.
    var premiumCache = provider.GetKeyedService<ICache>("premium");
    Console.WriteLine($"Premium key: {premiumCache}");

    // Requesting with any other key uses the AnyKey fallback.
    var basicCache = provider.GetKeyedService<ICache>("basic");
    Console.WriteLine($"Basic key: {basicCache}");

    var standardCache = provider.GetKeyedService<ICache>("standard");
    Console.WriteLine($"Standard key: {standardCache}");
    // </FallbackRegistration>
}
