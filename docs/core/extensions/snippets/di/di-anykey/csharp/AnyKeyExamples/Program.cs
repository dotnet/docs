using AnyKeyExamples;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("KeyedService.AnyKey Examples\n");

// Example 1: Fallback registration with AnyKey
Console.WriteLine("Example 1: Fallback registration with AnyKey");
Console.WriteLine("===========================================");
FallbackExample();
Console.WriteLine();

// Example 2: Query all keyed services with AnyKey
Console.WriteLine("Example 2: Query all keyed services with AnyKey");
Console.WriteLine("================================================");
QueryExample();
Console.WriteLine();

static void FallbackExample()
{
    // <FallbackRegistration>
    var services = new ServiceCollection();
    
    // Register a fallback cache for any key
    services.AddKeyedSingleton<ICache>(KeyedService.AnyKey, (sp, key) => 
    {
        // Create a cache instance based on the key
        return new DefaultCache(key?.ToString() ?? "unknown");
    });

    // Register a specific cache for the "premium" key
    services.AddKeyedSingleton<ICache>("premium", new PremiumCache());

    var provider = services.BuildServiceProvider();

    // Requesting with "premium" key returns PremiumCache
    var premiumCache = provider.GetKeyedService<ICache>("premium");
    Console.WriteLine($"Premium key: {premiumCache}");

    // Requesting with any other key uses the AnyKey fallback
    var basicCache = provider.GetKeyedService<ICache>("basic");
    Console.WriteLine($"Basic key: {basicCache}");

    var standardCache = provider.GetKeyedService<ICache>("standard");
    Console.WriteLine($"Standard key: {standardCache}");
    // </FallbackRegistration>
}

static void QueryExample()
{
    // <QueryAllKeyed>
    var services = new ServiceCollection();
    
    services.AddKeyedSingleton<INotificationService, EmailService>("email");
    services.AddKeyedSingleton<INotificationService, SmsService>("sms");
    services.AddKeyedSingleton<INotificationService, PushService>("push");
    services.AddSingleton<INotificationService, LoggingService>(); // Unkeyed

    var provider = services.BuildServiceProvider();

    // Get all keyed notification services
    var allKeyedServices = provider.GetKeyedServices<INotificationService>(KeyedService.AnyKey);
    
    Console.WriteLine("All keyed services:");
    foreach (var service in allKeyedServices)
    {
        Console.WriteLine($"  - {service.GetType().Name}");
    }
    // Returns: EmailService, SmsService, and PushService (but not LoggingService)

    Console.WriteLine("\nAll unkeyed services:");
    var unkeyedServices = provider.GetServices<INotificationService>();
    foreach (var service in unkeyedServices)
    {
        Console.WriteLine($"  - {service.GetType().Name}");
    }
    // Returns: LoggingService only
    // </QueryAllKeyed>
}
