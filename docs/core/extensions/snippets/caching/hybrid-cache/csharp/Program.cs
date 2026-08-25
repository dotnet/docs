using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// <BasicRegistration>
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHybridCache();
// </BasicRegistration>

// <ConfigurationWithOptions>
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
// </ConfigurationWithOptions>

// <BasicGetOrCreateAsync>
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
// </BasicGetOrCreateAsync>

// <GetOrCreateAsyncWithOptions>
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
// </GetOrCreateAsyncWithOptions>

// <TagBasedCaching>
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
// </TagBasedCaching>

// <InvalidateByTag>
async Task InvalidateCustomerCacheAsync(HybridCache cache, int customerId)
{
    await cache.RemoveByTagAsync($"customer:{customerId}");
}
// </InvalidateByTag>

// <InvalidateMultipleTags>
async Task InvalidateAllCustomersAsync(HybridCache cache)
{
    await cache.RemoveByTagAsync(new[] { "customer", "orders" });
}
// </InvalidateMultipleTags>

// <RemoveEntry>
async Task RemoveWeatherDataAsync(HybridCache cache, string city)
{
    await cache.RemoveAsync($"weather:{city}");
}
// </RemoveEntry>

// <InvalidateAll>
async Task InvalidateAllCacheAsync(HybridCache cache)
{
    await cache.RemoveByTagAsync("*");
}
// </InvalidateAll>

// <CustomSerialization>
// Custom serialization example
// Note: This requires implementing a custom IHybridCacheSerializer<T>
var builderWithSerializer = Host.CreateApplicationBuilder(args);
builderWithSerializer.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(10),
        LocalCacheExpiration = TimeSpan.FromMinutes(5)
    };
});
// To add a custom serializer, uncomment and provide your implementation:
// .AddSerializer<WeatherData, CustomWeatherDataSerializer>();
// </CustomSerialization>

// <RedisConfiguration>
// Distributed cache with Redis
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
// </RedisConfiguration>

// Example data classes
file record WeatherData(string City, int Temperature, string Condition);
file record CustomerData(int Id, string Name, string Email);
