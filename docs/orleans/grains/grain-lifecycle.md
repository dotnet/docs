---
title: Grain lifecycle overview
description: Learn about grain lifecycles in .NET Orleans.
ms.date: 02/13/2023
zone_pivot_groups: orleans-version
---

# Grain lifecycle overview

Orleans grains use an observable lifecycle (See [Orleans Lifecycle](../implementation/orleans-lifecycle.md)) for ordered activation and deactivation. This allows grain logic, system components, and application logic to be started and stopped in an ordered manner during grain activation and collection.

## Stages

The pre-defined grain lifecycle stages are as follows.

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
- `SetupState`: Setup grain state, before activation. For stateful grains, this is the stage where <xref:Orleans.Core.IStorage%601.State?displayProperty=nameWithType> is loaded from storage, when <xref:Orleans.Core.IStorage.RecordExists?displayProperty=nameWithType> return `true`.
- `Activate`: Stage where <xref:Orleans.Grain.OnActivateAsync%2A?displayProperty=nameWithType> and <xref:Orleans.Grain.OnDeactivateAsync%2A?displayProperty=nameWithType> are called.
- `Last`: Last stage in a grain's lifecycle.

While the grain lifecycle will be used during grain activation, since grains are not always deactivated during some error cases (such as silo crashes), applications should not rely on the grain lifecycle always being executed during grain deactivations.

## Grain lifecycle participation

Application logic can participate with a grain's lifecycle in two ways:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

1. The grain can participate in its lifecycle (and/or)
1. Components can access the lifecycle via the grain activation context (see <xref:Orleans.Runtime.IGrainContext.ObservableLifecycle?displayProperty=nameWithType>).

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

1. The grain can participate in its lifecycle (and/or)
1. Components can access the lifecycle via the grain activation context (see <xref:Orleans.Runtime.IGrainActivationContext.ObservableLifecycle%2A?displayProperty=nameWithType>).

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

In the above example, <xref:Orleans.Grain%601> overrides the <xref:Orleans.Grain.Participate%2A?displayProperty=nameWithType> method to tell the lifecycle to call its `OnSetupState` method during the <xref:Orleans.Runtime.GrainLifecycleStage.SetupState?displayProperty=nameWithType> stage of the lifecycle.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

Components created during a grain's construction can take part in the lifecycle as well, without any special grain logic being added. Since the grain's context (<xref:Orleans.Runtime.IGrainContext>), including the grain's lifecycle (<xref:Orleans.Runtime.IGrainContext.ObservableLifecycle?displayProperty=nameWithType>), is created before the grain is created, any component injected into the grain by the container can participate in the grain's lifecycle.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Components created during a grain's construction can take part in the lifecycle as well, without any special grain logic being added. Since the grain's activation context (<xref:Orleans.Runtime.IGrainActivationContext>), including the grain's lifecycle (<xref:Orleans.Runtime.IGrainActivationContext.ObservableLifecycle?displayProperty=nameWithType>), is created before the grain is created, any component injected into the grain by the container can participate in the grain's lifecycle.

:::zone-end

### Example participation, creation, and activation

The below component participates in the grain's lifecycle when created using its factory function `Create(...)`. This logic could exist in the component's constructor, but that risks the component being added to the lifecycle before it's fully constructed, which may not be safe.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

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

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

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

By registering the above component in the service container using its `Create(...)` factory function, any grain constructed with the component as a dependency will have the component taking part in its lifecycle without any special logic in the grain.

#### Register component in container

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
services.AddTransient<MyComponent>(sp =>
    MyComponent.Create(sp.GetRequiredService<IGrainContext>());
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

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
