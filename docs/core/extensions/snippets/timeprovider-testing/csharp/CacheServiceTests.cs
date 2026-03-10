using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Time.Testing;
using Xunit;

// <CacheServiceTests>
public class CacheServiceTests
{
    [Fact]
    public void Cache_ExpiresAfterTimeout()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();

        var services = new ServiceCollection();
        services.AddSingleton<TimeProvider>(fakeTimeProvider);
        services.AddSingleton<CacheService>();

        ServiceProvider provider = services.BuildServiceProvider();
        CacheService cache = provider.GetRequiredService<CacheService>();

        // Act
        cache.Set("key", "value", TimeSpan.FromMinutes(10));

        // Assert - value is present
        Assert.True(cache.TryGet("key", out string? value));
        Assert.Equal("value", value);

        // Advance time beyond expiration
        fakeTimeProvider.Advance(TimeSpan.FromMinutes(11));

        // Value should be expired
        Assert.False(cache.TryGet("key", out _));
    }
}

public class CacheService(TimeProvider timeProvider)
{
    private readonly Dictionary<string, CacheEntry> _cache = [];

    public void Set(string key, string value, TimeSpan expiration)
    {
        DateTimeOffset expiresAt = timeProvider.GetUtcNow() + expiration;
        _cache[key] = new CacheEntry(value, expiresAt);
    }

    public bool TryGet(string key, out string? value)
    {
        if (_cache.TryGetValue(key, out CacheEntry? entry))
        {
            if (timeProvider.GetUtcNow() < entry.ExpiresAt)
            {
                value = entry.Value;
                return true;
            }

            // Entry expired, remove it
            _cache.Remove(key);
        }

        value = null;
        return false;
    }

    private record CacheEntry(string Value, DateTimeOffset ExpiresAt);
}
// </CacheServiceTests>
