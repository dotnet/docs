---
title: "Breaking change: BackgroundService runs all of ExecuteAsync as a Task"
description: "Learn about the breaking change in .NET 10 where BackgroundService now runs the entirety of ExecuteAsync on a background thread instead of running the synchronous portion on the main thread."
ms.date: 10/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/runtime/issues/116181
---

# BackgroundService runs all of ExecuteAsync as a Task

<xref:Microsoft.Extensions.Hosting.BackgroundService> now runs the entirety of <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A> on a background thread. Previously, the synchronous portion of `ExecuteAsync` (before the first `await`) ran on the main thread during service startup, blocking other services from starting. Only code after the first `await` ran on a background thread.

## Version introduced

.NET 10 Preview 1

## Previous behavior

Previously, the synchronous portion of `ExecuteAsync` ran on the main thread and blocked other services from starting. For example:

```csharp
public class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // This code ran on the main thread and blocked other services
        DoSomeSynchronousWork();
        
        // Only after this first await did the code run on a background thread
        await Task.Delay(1000, stoppingToken);
        
        // This code ran on a background thread
        while (!stoppingToken.IsCancellationRequested)
        {
            await DoWorkAsync(stoppingToken);
        }
    }
}
```

This behavior allowed implementers to partition synchronous work before the first `await` and asynchronous work after. However, most implementers didn't understand or expect this nuance.

## New behavior

Starting in .NET 10, all of `ExecuteAsync` runs on a background thread, and no part of it blocks other services from starting:

```csharp
public class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // All of this code now runs on a background thread
        DoSomeSynchronousWork();
        
        await Task.Delay(1000, stoppingToken);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await DoWorkAsync(stoppingToken);
        }
    }
}
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was a common pitfall that didn't meet user expectations. Most implementers of `BackgroundService` didn't understand that the synchronous portion before the first `await` would block other services from starting during application startup.

## Recommended action

If you require any part of your `BackgroundService.ExecuteAsync` to run earlier during startup (synchronously and blocking other services), you can do any one of the following:

1. Place that code in the constructor, and it executes as part of the service construction.
2. Override `StartAsync` and do some work before calling `base.StartAsync`. `StartAsync` retains the behavior that its synchronous portion runs synchronously during startup and blocks other services from starting.
3. Implement <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService?displayProperty=fullName> on your `BackgroundService` if you want to run code at a more specific time during service startup.
4. Forgo `BackgroundService` entirely and implement your own <xref:Microsoft.Extensions.Hosting.IHostedService?displayProperty=fullName>.

## Affected APIs

- <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A?displayProperty=fullName>
- <xref:Microsoft.Extensions.Hosting.BackgroundService?displayProperty=fullName>
