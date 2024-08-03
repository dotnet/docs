---
title: Activation collection
description: Learn about activation collection in .NET Orleans.
ms.date: 07/03/2024
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

A *grain activation* is an in-memory instance of a grain class that gets automatically created by the Orleans runtime on an as-needed basis as a temporary physical embodiment of a grain.

Activation collection is the process of removal from memory of unused grain activations. It's conceptually similar to how garbage collection of memory works in .NET. However, activation collection only takes into consideration how long a particular grain activation has been idle. Memory usage isn't used as a factor.

## How activation collection works

The general process of activation collection involves Orleans runtime in a silo periodically scanning for grain activations that haven't been used at all for the configured period (Collection Age Limit). Once a grain activation has been idle for that long, it gets deactivated. The deactivation process begins by the runtime calling the grain's <xref:Orleans.Grain.OnDeactivateAsync> method, and completes by removing references to the grain activation object from all data structures of the silo, so that the memory is reclaimed by the .NET GC.

As a result, with no burden put on the application code, only recently used grain activations stay in memory while activations that aren't used anymore get automatically removed, and system resources used by them get reclaimed by the runtime.

**What counts as "being active" for grain activation collection**

* Receiving a method call.
* Receiving a reminder.
* Receiving an event via streaming.

**What does NOT count as "being active" for grain activation collection**

* Performing a call (to another grain or an Orleans client).
* Timer events.
* Arbitrary IO operations or external calls not involving Orleans framework.

**Collection Age Limit**

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->
This time after which an idle grain activation becomes subject to collection is called Collection Age Limit. The default Collection Age Limit is 15 minutes, but it can be changed globally or for individual grain classes.
:::zone-end
<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->
This time after which an idle grain activation becomes subject to collection is called Collection Age Limit. The default Collection Age Limit is 2 hours, but it can be changed globally or for individual grain classes.
:::zone-end

## Explicit control of activation collection

### Delay activation collection

A grain activation can delay its own collection, by calling <xref:Orleans.Grain.DelayDeactivation%2A> method:

```csharp
protected void DelayDeactivation(TimeSpan timeSpan)
```

This call ensures that this activation isn't deactivated for at least the specified time duration. It takes priority over activation collection settings specified in the config, but doesn't cancel them. Therefore, this call provides another hook to **delay the deactivation beyond what is specified in the activation collection settings**. This call can't be used to expedite activation collection.

A positive `timeSpan` value means "prevent collection of this activation for that time."

A negative `timeSpan` value means "cancel the previous setting of the `DelayDeactivation` call and make this activation behave based on the regular activation collection settings."

**Scenarios:**

1. Activation collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(20))`, which causes this activation to not be collected for at least 20 min.

1. Activation collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(5))`, the activation will be collected after 10 min, if no extra calls were made.

1. Activation collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(5))`, and after 7 minutes there's another call on this grain, the activation will be collected after 17 min from time zero if no extra calls were made.

1. Activation collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(20))`, and after 7 minutes there's another call on this grain, the activation will be collected after 20 min from time zero if no extra calls were made.

The `DelayDeactivation` doesn't 100% guarantee that the grain activation won't be deactivated before the specified time expires. Certain failure cases may cause 'premature' deactivation of grains. That means that `DelayDeactivation` **can not be used as a means to 'pin' a grain activation in memory forever or to a specific silo**. `DelayDeactivation` is merely an optimization mechanism that can help reduce the aggregate cost of a grain getting deactivated and reactivated over time. In most cases, there should be no need to use `DelayDeactivation` at all.

### Expedite activation collection

A grain activation can also instruct the runtime to deactivate it the next time it becomes idle by calling <xref:Orleans.Grain.DeactivateOnIdle> method:

```csharp
protected void DeactivateOnIdle()
```

A grain activation is considered idle if it isn't processing any message at the moment. If you call `DeactivateOnIdle` while a grain is processing a message, it gets deactivated as soon as the processing of the current message is finished. If there are any requests queued for the grain, they'll be forwarded to the next activation.

`DeactivateOnIdle` takes priority over any activation collection settings specified in the config or `DelayDeactivation`.

> [!NOTE]
> Setting only applies to the grain activation from which it has been called and it does not apply to other grain activation of this type.

## Configuration

Activation collection can be configured using the <xref:Orleans.Configuration.GrainCollectionOptions>:

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

To keep a grain alive, you apply the <xref:Orleans.KeepAliveAttribute?displayProperty=fullName> to the grain implementation. The `KeepAlive` attribute instructs the Orleans runtime to avoid collecting the grain by the idle activation collector. Avoiding collection is useful for grains that are used infrequently but that you want to keep alive to avoid any potential creation overhead.

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
