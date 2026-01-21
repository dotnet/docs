---
title: Grain lifecycle overview
description: Learn about grain lifecycles in .NET Orleans.
ms.date: 01/21/2026
ms.topic: article
zone_pivot_groups: orleans-version
---

# Grain lifecycle overview

Orleans grains use an observable lifecycle (see [Orleans Lifecycle](../implementation/orleans-lifecycle.md)) for ordered activation and deactivation. This allows grain logic, system components, and application logic to start and stop in an ordered manner during grain activation and collection.

## Stages

The predefined grain lifecycle stages are as follows:

```csharp
public static class GrainLifecycleStage
{
    public const int First = int.MinValue;
    public const int SetupState = 1_000;
    public const int Activate = 2_000;
    public const int Last = int.MaxValue;
}
```

- `First`: First stage in a grain's lifecycle.
- `SetupState`: Set up grain state before activation. For stateful grains, this is the stage where Orleans loads <xref:Orleans.Core.IStorage%601.State?displayProperty=nameWithType> from storage if <xref:Orleans.Core.IStorage.RecordExists?displayProperty=nameWithType> is `true`.
- `Activate`: Stage where Orleans calls <xref:Orleans.Grain.OnActivateAsync%2A?displayProperty=nameWithType> and <xref:Orleans.Grain.OnDeactivateAsync%2A?displayProperty=nameWithType>.
- `Last`: Last stage in a grain's lifecycle.

While Orleans uses the grain lifecycle during grain activation, grains aren't always deactivated during some error cases (such as silo crashes). Therefore, applications shouldn't rely on the grain lifecycle always executing during grain deactivations.

:::zone target="docs" pivot="orleans-10-0,orleans-9-0"

## Memory-based activation shedding

Orleans 9.0 introduced memory-based activation shedding, which automatically deactivates grain activations when the silo is under memory pressure. This helps prevent out-of-memory conditions by intelligently removing grains from memory based on their activity patterns.

### How it works

When enabled, Orleans monitors memory usage and begins deactivating grains when usage exceeds the configured threshold:

1. Orleans polls memory usage at a configurable interval (default: 5 seconds)
2. When memory usage exceeds `MemoryUsageLimitPercentage`, Orleans begins deactivating grains
3. Orleans prioritizes deactivating older and less-recently-used grains first
4. Deactivation continues until memory usage falls below `MemoryUsageTargetPercentage`

### Configuration

Configure memory-based activation shedding using `GrainCollectionOptions`:

```csharp
builder.Configure<GrainCollectionOptions>(options =>
{
    // Enable memory-based activation shedding
    options.EnableActivationSheddingOnMemoryPressure = true;
    
    // Memory usage percentage (0-100) at which grain collection triggers
    options.MemoryUsageLimitPercentage = 80; // default: 80
    
    // Target memory usage percentage to reach after collection
    options.MemoryUsageTargetPercentage = 75; // default: 75
    
    // How often to poll memory usage
    options.MemoryUsagePollingPeriod = TimeSpan.FromSeconds(5); // default: 5s
});
```

### GrainCollectionOptions properties

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `EnableActivationSheddingOnMemoryPressure` | `bool` | `false` | Enable automatic deactivation under memory pressure. |
| `MemoryUsageLimitPercentage` | `int` | 80 | Memory usage percentage at which shedding begins. Valid range: 0-100. |
| `MemoryUsageTargetPercentage` | `int` | 75 | Target memory usage percentage after shedding. Valid range: 0-100. |
| `MemoryUsagePollingPeriod` | `TimeSpan` | 5 seconds | How often to check memory usage. |
| `CollectionAge` | `TimeSpan` | 2 hours | Minimum time a grain must be idle before eligible for collection. |
| `CollectionQuantum` | `TimeSpan` | 1 minute | How often idle grain collection runs. |

### Best practices

- **Set thresholds conservatively**: Leave headroom between `MemoryUsageTargetPercentage` and `MemoryUsageLimitPercentage` to avoid oscillation
- **Monitor collection metrics**: Track grain deactivations to understand the impact on your workload
- **Consider grain importance**: Critical grains can extend their lifetime using timers with `KeepAlive = true` or by receiving periodic calls
- **Test under load**: Verify behavior under production-like memory conditions

:::zone-end

## Grain lifecycle participation

Application logic can participate in a grain's lifecycle in two ways:

:::zone target="docs" pivot="orleans-8-0,orleans-7-0"

- The grain can participate in its own lifecycle.
- Components can access the lifecycle via the grain activation context (see <xref:Orleans.Runtime.IGrainContext.ObservableLifecycle?displayProperty=nameWithType>).

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

- The grain can participate in its own lifecycle.
- Components can access the lifecycle via the grain activation context (see <xref:Orleans.Runtime.IGrainActivationContext.ObservableLifecycle?displayProperty=nameWithType>).

:::zone-end

A grain always participates in its lifecycle, so application logic can be introduced by overriding the participate method.

### Example participation

```csharp
public override void Participate(IGrainLifecycle lifecycle)
{
    base.Participate(lifecycle);
    lifecycle.Subscribe(
        this.GetType().FullName,
        GrainLifecycleStage.SetupState,
        OnSetupState);
}
```

In the preceding example, <xref:Orleans.Grain%601> overrides the <xref:Orleans.Grain.Participate%2A?displayProperty=nameWithType> method to tell the lifecycle to call its `OnSetupState` method during the <xref:Orleans.Runtime.GrainLifecycleStage.SetupState?displayProperty=nameWithType> stage of the lifecycle.

:::zone target="docs" pivot="orleans-8-0,orleans-7-0"

Components created during a grain's construction can also participate in the lifecycle without adding any special grain logic. Since Orleans creates the grain's context (<xref:Orleans.Runtime.IGrainContext>), including its lifecycle (<xref:Orleans.Runtime.IGrainContext.ObservableLifecycle?displayProperty=nameWithType>), before creating the grain, any component injected into the grain by the container can participate in the grain's lifecycle.

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

Components created during a grain's construction can also participate in the lifecycle without adding any special grain logic. Since Orleans creates the grain's activation context (<xref:Orleans.Runtime.IGrainActivationContext>), including its lifecycle (<xref:Orleans.Runtime.IGrainActivationContext.ObservableLifecycle?displayProperty=nameWithType>), before creating the grain, any component injected into the grain by the container can participate in the grain's lifecycle.

:::zone-end

### Example: Component participation

The following component participates in the grain's lifecycle when created using its factory function `Create(...)`. This logic could exist in the component's constructor, but that risks adding the component to the lifecycle before it's fully constructed, which might not be safe.

:::zone target="docs" pivot="orleans-8-0,orleans-7-0"

```csharp
public class MyComponent : ILifecycleParticipant<IGrainLifecycle>
{
    public static MyComponent Create(IGrainContext context)
    {
        var component = new MyComponent();
        component.Participate(context.ObservableLifecycle);
        return component;
    }

    public void Participate(IGrainLifecycle lifecycle)
    {
        lifecycle.Subscribe<MyComponent>(GrainLifecycleStage.Activate, OnActivate);
    }

    private Task OnActivate(CancellationToken ct)
    {
        // Do stuff
    }
}
```

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

```csharp
public class MyComponent : ILifecycleParticipant<IGrainLifecycle>
{
    public static MyComponent Create(IGrainActivationContext context)
    {
        var component = new MyComponent();
        component.Participate(context.ObservableLifecycle);
        return component;
    }

    public void Participate(IGrainLifecycle lifecycle)
    {
        lifecycle.Subscribe<MyComponent>(GrainLifecycleStage.Activate, OnActivate);
    }

    private Task OnActivate(CancellationToken ct)
    {
        // Do stuff
    }
}
```

:::zone-end

By registering the example component in the service container using its `Create(...)` factory function, any grain constructed with the component as a dependency has the component participate in its lifecycle without requiring any special logic in the grain itself.

#### Register component in container

:::zone target="docs" pivot="orleans-8-0,orleans-7-0"

```csharp
services.AddTransient<MyComponent>(sp =>
    MyComponent.Create(sp.GetRequiredService<IGrainContext>());
```

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

```csharp
services.AddTransient<MyComponent>(sp =>
    MyComponent.Create(sp.GetRequiredService<IGrainActivationContext>());
```

:::zone-end

#### Grain with component as a dependency

```csharp
public class MyGrain : Grain, IMyGrain
{
    private readonly MyComponent _component;

    public MyGrain(MyComponent component)
    {
        _component = component;
    }
}
```
