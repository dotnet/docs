---
title: Testing with FakeTimeProvider
description: Learn how to test time-dependent code using FakeTimeProvider from Microsoft.Extensions.TimeProvider.Testing in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 10/20/2025
ms.topic: concept-article
ai-usage: ai-assisted
---

# Testing with FakeTimeProvider

The [`Microsoft.Extensions.TimeProvider.Testing`](https://www.nuget.org/packages/Microsoft.Extensions.TimeProvider.Testing) NuGet package provides a `FakeTimeProvider` class that enables deterministic testing of code that depends on time. This fake implementation allows you to control the system time within your tests, ensuring predictable and repeatable results.

## Why use FakeTimeProvider

Testing code that depends on the current time or uses timers can be challenging:

- **Non-deterministic tests**: Tests that depend on real time can produce inconsistent results.
- **Slow tests**: Tests that need to wait for actual time to pass can significantly slow down test execution.
- **Race conditions**: Time-dependent logic can introduce race conditions that are hard to reproduce.
- **Edge cases**: Testing time-based logic at specific times (such as midnight or month boundaries) is difficult with real time.

The `FakeTimeProvider` addresses these challenges by:

- Providing complete control over the current time.
- Allowing you to advance time instantly without waiting.
- Enabling deterministic testing of time-based behavior.
- Making it easy to test edge cases and boundary conditions.

## Get started

To get started with `FakeTimeProvider`, install the [`Microsoft.Extensions.TimeProvider.Testing`](https://www.nuget.org/packages/Microsoft.Extensions.TimeProvider.Testing) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.TimeProvider.Testing
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.TimeProvider.Testing" Version="9.10.0" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Basic usage

The `FakeTimeProvider` extends <xref:System.TimeProvider> to provide controllable time for testing:

```csharp
using Microsoft.Extensions.Time.Testing;

var fakeTimeProvider = new FakeTimeProvider();

// Get the current time
var now = fakeTimeProvider.GetUtcNow();
Console.WriteLine($"Current time: {now}");

// Advance time by 1 hour
fakeTimeProvider.Advance(TimeSpan.FromHours(1));

var later = fakeTimeProvider.GetUtcNow();
Console.WriteLine($"Time after advance: {later}");
```

## Initialize with specific time

You can initialize `FakeTimeProvider` with a specific starting time:

```csharp
using Microsoft.Extensions.Time.Testing;

var startTime = new DateTimeOffset(2025, 10, 20, 12, 0, 0, TimeSpan.Zero);
var fakeTimeProvider = new FakeTimeProvider(startTime);

Console.WriteLine($"Started at: {fakeTimeProvider.GetUtcNow()}");
```

## Set time explicitly

Use the `SetUtcNow` method to set the time to a specific value:

```csharp
using Microsoft.Extensions.Time.Testing;

var fakeTimeProvider = new FakeTimeProvider();

// Set to a specific date and time
var specificTime = new DateTimeOffset(2025, 12, 31, 23, 59, 59, TimeSpan.Zero);
fakeTimeProvider.SetUtcNow(specificTime);

Console.WriteLine($"Time set to: {fakeTimeProvider.GetUtcNow()}");
```

## Advance time

The `Advance` method moves time forward by a specified duration:

```csharp
using Microsoft.Extensions.Time.Testing;

var fakeTimeProvider = new FakeTimeProvider();
var startTime = fakeTimeProvider.GetUtcNow();

// Advance by 30 minutes
fakeTimeProvider.Advance(TimeSpan.FromMinutes(30));

var elapsed = fakeTimeProvider.GetUtcNow() - startTime;
Console.WriteLine($"Time advanced by: {elapsed.TotalMinutes} minutes");
```

## Configure time zone

Set the local time zone for the fake time provider:

```csharp
using Microsoft.Extensions.Time.Testing;

var fakeTimeProvider = new FakeTimeProvider();

// Set to Pacific Standard Time
var pacificTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
fakeTimeProvider.SetLocalTimeZone(pacificTimeZone);

var localTime = fakeTimeProvider.GetLocalNow();
Console.WriteLine($"Local time: {localTime}");
```

## Test delayed operations

`FakeTimeProvider` is particularly useful for testing operations that involve delays:

```csharp
using Microsoft.Extensions.Time.Testing;
using Xunit;

public class DelayedOperationTests
{
    [Fact]
    public async Task DelayedOperation_CompletesAfterDelay()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();
        var operation = new DelayedOperation(fakeTimeProvider);
        
        // Act
        var task = operation.ExecuteAsync(TimeSpan.FromMinutes(5));
        
        // Assert - operation should not be complete yet
        Assert.False(task.IsCompleted);
        
        // Advance time by 5 minutes
        fakeTimeProvider.Advance(TimeSpan.FromMinutes(5));
        
        // Wait for the task to complete
        await task;
        
        // Operation should now be complete
        Assert.True(task.IsCompleted);
    }
}

public class DelayedOperation
{
    private readonly TimeProvider _timeProvider;

    public DelayedOperation(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public async Task ExecuteAsync(TimeSpan delay)
    {
        await Task.Delay(delay, _timeProvider);
    }
}
```

## Test periodic operations

Test operations that execute periodically using timers:

```csharp
using Microsoft.Extensions.Time.Testing;
using Xunit;

public class PeriodicOperationTests
{
    [Fact]
    public void PeriodicOperation_ExecutesAtIntervals()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();
        var counter = new PeriodicCounter(fakeTimeProvider);
        counter.Start(TimeSpan.FromSeconds(10));
        
        // Act & Assert
        Assert.Equal(0, counter.Count);
        
        // Advance by 10 seconds
        fakeTimeProvider.Advance(TimeSpan.FromSeconds(10));
        Assert.Equal(1, counter.Count);
        
        // Advance by 20 more seconds
        fakeTimeProvider.Advance(TimeSpan.FromSeconds(20));
        Assert.Equal(3, counter.Count);
        
        // Clean up
        counter.Stop();
    }
}

public class PeriodicCounter
{
    private readonly TimeProvider _timeProvider;
    private ITimer? _timer;
    
    public int Count { get; private set; }

    public PeriodicCounter(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public void Start(TimeSpan interval)
    {
        _timer = _timeProvider.CreateTimer(
            callback: _ => Count++,
            state: null,
            dueTime: interval,
            period: interval);
    }

    public void Stop()
    {
        _timer?.Dispose();
    }
}
```

## Test time-based business logic

Test business logic that depends on specific times or dates:

```csharp
using Microsoft.Extensions.Time.Testing;
using Xunit;

public class SubscriptionTests
{
    [Fact]
    public void Subscription_ExpiresAfterOneYear()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();
        var startDate = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);
        fakeTimeProvider.SetUtcNow(startDate);
        
        var subscription = new Subscription(fakeTimeProvider);
        subscription.Activate();
        
        // Assert - subscription is active
        Assert.True(subscription.IsActive);
        
        // Act - advance time by 11 months
        fakeTimeProvider.Advance(TimeSpan.FromDays(30 * 11));
        Assert.True(subscription.IsActive);
        
        // Advance time by 2 more months
        fakeTimeProvider.Advance(TimeSpan.FromDays(60));
        Assert.False(subscription.IsActive);
    }
}

public class Subscription
{
    private readonly TimeProvider _timeProvider;
    private DateTimeOffset _activationDate;

    public Subscription(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public void Activate()
    {
        _activationDate = _timeProvider.GetUtcNow();
    }

    public bool IsActive
    {
        get
        {
            var currentTime = _timeProvider.GetUtcNow();
            var expirationDate = _activationDate.AddYears(1);
            return currentTime < expirationDate;
        }
    }
}
```

## Integration with dependency injection

Use `FakeTimeProvider` in tests for services registered with dependency injection:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Time.Testing;
using Xunit;

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
        
        var provider = services.BuildServiceProvider();
        var cache = provider.GetRequiredService<CacheService>();
        
        // Act
        cache.Set("key", "value", TimeSpan.FromMinutes(10));
        
        // Assert - value is present
        Assert.True(cache.TryGet("key", out var value));
        Assert.Equal("value", value);
        
        // Advance time beyond expiration
        fakeTimeProvider.Advance(TimeSpan.FromMinutes(11));
        
        // Value should be expired
        Assert.False(cache.TryGet("key", out _));
    }
}

public class CacheService
{
    private readonly TimeProvider _timeProvider;
    private readonly Dictionary<string, CacheEntry> _cache = new();

    public CacheService(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public void Set(string key, string value, TimeSpan expiration)
    {
        var expiresAt = _timeProvider.GetUtcNow() + expiration;
        _cache[key] = new CacheEntry(value, expiresAt);
    }

    public bool TryGet(string key, out string? value)
    {
        if (_cache.TryGetValue(key, out var entry))
        {
            if (_timeProvider.GetUtcNow() < entry.ExpiresAt)
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
```

## Best practices

When using `FakeTimeProvider`, consider the following best practices:

- **Inject TimeProvider**: Always inject `TimeProvider` as a dependency rather than using <xref:System.DateTime> or <xref:System.DateTimeOffset> directly. This makes your code testable.
- **Use UTC time**: Work with UTC time in your business logic and convert to local time only when needed for display.
- **Test edge cases**: Use `FakeTimeProvider` to test edge cases like midnight, month boundaries, daylight saving time transitions, and leap years.
- **Clean up timers**: Dispose of timers created with `CreateTimer` to avoid resource leaks in your tests.
- **Advance time deliberately**: Advance time explicitly in your tests to make the test behavior clear and predictable.
- **Avoid mixing real and fake time**: Don't mix real `TimeProvider.System` with `FakeTimeProvider` in the same test, as this can lead to unpredictable behavior.

## See also

- <xref:System.TimeProvider>
- [Unit testing in .NET](../testing/index.md)
- [Dependency injection in .NET](dependency-injection.md)
