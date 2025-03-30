---
title: Activation collection
description: Learn about activation collection in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
ms.service: orleans
zone_pivot_groups: orleans-version
---

# Activation collection

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->
This article applies to: ✔️ Orleans 7.x and later versions
:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->
This article applies to: ✔️ Orleans 3.x and earlier versions
:::zone-end

A *grain activation* is an in-memory instance of a grain class that the Orleans runtime automatically creates on an as-needed basis as a temporary physical embodiment of a grain.

Activation collection is the process of removing unused grain activations from memory. It's conceptually similar to how garbage collection works in .NET. However, activation collection only considers how long a particular grain activation has been idle. Memory usage isn't used as a factor.

## How activation collection works

The general process of activation collection involves the Orleans runtime in a silo periodically scanning for grain activations that haven't been used for the configured period (Collection Age Limit). Once a grain activation has been idle for that long, it gets deactivated. The deactivation process begins with the runtime calling the grain's <xref:Orleans.Grain.OnDeactivateAsync> method and completes by removing references to the grain activation object from all silo data structures, allowing the .NET GC to reclaim the memory.

As a result, without burdening your application code, only recently used grain activations stay in memory. Activations no longer in use are automatically removed, and the runtime reclaims the system resources they used.

**What counts as "being active" for grain activation collection:**

- Receiving a method call.
- Receiving a reminder.
- Receiving an event via streaming.

**What does NOT count as "being active" for grain activation collection:**

- Performing a call (to another grain or an Orleans client).
- Timer events.
- Arbitrary I/O operations or external calls not involving the Orleans framework.

**Collection age limit**

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->
The time after which an idle grain activation becomes subject to collection is called the Collection Age Limit. The default Collection Age Limit is 15 minutes, but you can change it globally or for individual grain classes.
:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->
The time after which an idle grain activation becomes subject to collection is called the Collection Age Limit. The default Collection Age Limit is 2 hours, but you can change it globally or for individual grain classes.
:::zone-end

## Explicit control of activation collection

### Delay activation collection

A grain activation can delay its collection by calling the <xref:Orleans.Grain.DelayDeactivation%2A> method:

```csharp
protected void DelayDeactivation(TimeSpan timeSpan)
```

This call ensures this activation isn't deactivated for at least the specified time duration. It takes priority over activation collection settings specified in the configuration but doesn't cancel them. Therefore, this call provides another hook to **delay deactivation beyond what's specified in the activation collection settings**. You can't use this call to expedite activation collection.

A positive `timeSpan` value means "prevent collection of this activation for that time."

A negative `timeSpan` value means "cancel the previous setting of the `DelayDeactivation` call and make this activation behave based on the regular activation collection settings."

**Scenarios:**

1.  Activation collection settings specify an age limit of 10 minutes, and the grain calls `DelayDeactivation(TimeSpan.FromMinutes(20))`. This causes the activation not to be collected for at least 20 minutes.

2.  Activation collection settings specify an age limit of 10 minutes, and the grain calls `DelayDeactivation(TimeSpan.FromMinutes(5))`. The activation will be collected after 10 minutes if no further calls are made.

3.  Activation collection settings specify an age limit of 10 minutes, and the grain calls `DelayDeactivation(TimeSpan.FromMinutes(5))`. After 7 minutes, another call arrives for this grain. The activation will be collected after 17 minutes from time zero if no further calls are made.

4.  Activation collection settings specify an age limit of 10 minutes, and the grain calls `DelayDeactivation(TimeSpan.FromMinutes(20))`. After 7 minutes, another call arrives for this grain. The activation will be collected after 20 minutes from time zero if no further calls are made.

`DelayDeactivation` doesn't 100% guarantee the grain activation won't be deactivated before the specified time expires. Certain failure cases might cause 'premature' deactivation of grains. This means `DelayDeactivation` **cannot be used as a means to 'pin' a grain activation in memory forever or to a specific silo**. `DelayDeactivation` is merely an optimization mechanism that can help reduce the aggregate cost of a grain being deactivated and reactivated over time. In most cases, you shouldn't need to use `DelayDeactivation` at all.

### Expedite activation collection

A grain activation can also instruct the runtime to deactivate it the next time it becomes idle by calling the <xref:Orleans.Grain.DeactivateOnIdle> method:

```csharp
protected void DeactivateOnIdle()
```

A grain activation is considered idle if it isn't processing any messages at the moment. If you call `DeactivateOnIdle` while a grain is processing a message, it deactivates as soon as the processing of the current message finishes. If any requests are queued for the grain, they'll be forwarded to the next activation.

`DeactivateOnIdle` takes priority over any activation collection settings specified in the configuration or `DelayDeactivation`.

> [!NOTE]
> This setting only applies to the specific grain activation from which it was called; it doesn't apply to other activations of this grain type.

## Configuration

Configure activation collection using <xref:Orleans.Configuration.GrainCollectionOptions>:

```csharp
mySiloHostBuilder.Configure<GrainCollectionOptions>(options =>
{
    // Set the value of CollectionAge to 10 minutes for all grain
    options.CollectionAge = TimeSpan.FromMinutes(10);

    // Override the value of CollectionAge to 5 minutes for MyGrainImplementation
    options.ClassSpecificCollectionAge[typeof(MyGrainImplementation).FullName] =
        TimeSpan.FromMinutes(5);
})
```

## Keep alive

To keep a grain alive indefinitely, apply the <xref:Orleans.KeepAliveAttribute?displayProperty=fullName> to the grain implementation. The `KeepAlive` attribute instructs the Orleans runtime to avoid collecting the grain by the idle activation collector. Avoiding collection is useful for grains used infrequently but that you want to keep alive to avoid potential creation overhead upon the next invocation.

```csharp
public interface IPlayerGrain : IGrainWithGuidKey
{
    Task<IGameGrain> GetCurrentGame();
    Task JoinGame(IGameGrain game);
    Task LeaveGame(IGameGrain game);
}

[KeepAlive]
public class PlayerGrain : Grain, IPlayerGrain
{
    private IGameGrain _currentGame;

    public Task<IGameGrain> GetCurrentGame()
    {
       return Task.FromResult(_currentGame);
    }

    public Task JoinGame(IGameGrain game)
    {
       // Omitted for brevity.

       return Task.CompletedTask;
    }

   public Task LeaveGame(IGameGrain game)
   {
       // Omitted for brevity.

       return Task.CompletedTask;
   }
}
```

The preceding code prevents the idle activation collector from collecting the `PlayerGrain`.
