using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Basic registration
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHybridCache();

// Configuration with options
var builderWithOptions = Host.CreateApplicationBuilder(args);
builderWithOptions.Services.AddHybridCache(options =>
{
    options.MaximumPayloadBytes = 1024 * 1024; // 1 MB
    options.MaximumKeyLength = 1024;
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(5),
        LocalCacheExpiration = TimeSpan.FromMinutes(2)
    };
});

// Basic GetOrCreateAsync usage
async Task<WeatherData> GetWeatherDataAsync(HybridCache cache, string city)
{
    return await cache.GetOrCreateAsync(
        $"weather:{city}",
        async cancellationToken =>
        {
            // Simulate fetching from an external API
            await Task.Delay(100, cancellationToken);
            return new WeatherData(city, 72, "Sunny");
        }
    );
}

// GetOrCreateAsync with entry options
async Task<WeatherData> GetWeatherWithOptionsAsync(HybridCache cache, string city)
{
    var entryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(10),
        LocalCacheExpiration = TimeSpan.FromMinutes(5)
    };

    return await cache.GetOrCreateAsync(
        $"weather:{city}",
        async cancellationToken => new WeatherData(city, 72, "Sunny"),
        entryOptions
    );
}

// Tag-based caching
async Task<CustomerData> GetCustomerAsync(HybridCache cache, int customerId)
{
    var tags = new[] { "customer", $"customer:{customerId}" };

    return await cache.GetOrCreateAsync(
        $"customer:{customerId}",
        async cancellationToken => new CustomerData(customerId, "John Doe", "john@example.com"),
        new HybridCacheEntryOptions { Expiration = TimeSpan.FromMinutes(30) },
        tags
    );
}

// Invalidate by tag
async Task InvalidateCustomerCacheAsync(HybridCache cache, int customerId)
{
    await cache.RemoveByTagAsync($"customer:{customerId}");
}

// Invalidate multiple tags
async Task InvalidateAllCustomersAsync(HybridCache cache)
{
    await cache.RemoveByTagAsync(new[] { "customer", "orders" });
}

// Remove specific entry
async Task RemoveWeatherDataAsync(HybridCache cache, string city)
{
    await cache.RemoveAsync($"weather:{city}");
}

// Invalidate all entries
async Task InvalidateAllCacheAsync(HybridCache cache)
{
    await cache.RemoveByTagAsync("*");
}

// Custom serialization example (conceptual - would need actual serializer implementation)
var builderWithSerializer = Host.CreateApplicationBuilder(args);
builderWithSerializer.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(10),
        LocalCacheExpiration = TimeSpan.FromMinutes(5)
    };
});
// .AddSerializer<WeatherData, CustomSerializer<WeatherData>>();

// Distributed cache with Redis example (conceptual)
var builderWithRedis = Host.CreateApplicationBuilder(args);
builderWithRedis.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});
builderWithRedis.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(30),
        LocalCacheExpiration = TimeSpan.FromMinutes(5)
    };
});

// Example data classes
file record WeatherData(string City, int Temperature, string Condition);
file record CustomerData(int Id, string Name, string Email);
