---
title: Grain extensions
description: Learn how to extend an Orleans Grain.
ms.date: 05/08/2023
---

# Grain extensions

Grain extensions provide a way to add extra behavior to grains. By extending a grain with an interface that derives from <xref:Orleans.Runtime.IGrainExtension>, you can add new methods and functionality to the grain.

In this article, you see two examples of grain extensions. The first example shows how to add a `Deactivate` method to all grains that can be used to deactivate the grain. The second example shows how to add a `GetState` and `SetState` method to any grain, allowing you to manipulate the grain's internal state.

## Deactivate extension example

In this example, you will learn how to add a `Deactivate` method to all grains automatically. The method can be used to deactivate the grain and accepts a string as a message parameter. Orleans grains already support this functionality via the <xref:Orleans.Core.Internal.IGrainManagementExtension> interface. Nevertheless, this example serves to show how you could add this or similar functionality yourself.

### Deactivate extension interface

Start by defining an `IGrainDeactivateExtension` interface, which contains the `Deactivate` method. The interface must derive from `IGrainExtension`.

```csharp
public interface IGrainDeactivateExtension : IGrainExtension
{
    Task Deactivate(string msg);
}
```

### Deactivate extension implementation

Next, implement the `GrainDeactivateExtension` class, which provides the implementation for the `Deactivate` method.

To access the target grain, you retrieve the `IGrainContext` from the constructor. It's injected when creating the extension with dependency injection.

```csharp
public sealed class GrainDeactivateExtension : IGrainDeactivateExtension
{
    private IGrainContext _context;

    public GrainDeactivateExtension(IGrainContext context)
    {
        _context = context;
    }

    public async Task Deactivate(string msg)
    {
        var reason = new DeactivationReason(DeactivationReasonCode.ApplicationRequested, msg);
        await _context.DeactivateAsync(reason);
    }
}
```

### Deactivate extension registration and usage

Now that you've defined the interface and implementation, you register the extension when configuring the silo with the <xref:Orleans.Hosting.HostingGrainExtensions.AddGrainExtension%2A> method.

```csharp
siloBuilder.AddGrainExtension<IGrainDeactivateExtension, GrainDeactivateExtension>();
```

To use the extension on any grain, retrieve a reference to the extension and call the `Deactivate` method.

```csharp
var grain = client.GetGrain<SomeExampleGrain>(someKey);
var grainReferenceAsInterface = grain.AsReference<IGrainDeactivateExtension>();

await grainReferenceAsInterface.Deactivate("Because, I said so...");
```

## State manipulation extension example

In this example, you learn how to add a `GetState` and `SetState` method to any grain through extensions, allowing you to manipulate the grain's internal state.

### State manipulation extension interface

First, define the `IGrainStateAccessor<T>` interface, which contains the `GetState` and `SetState` methods. Again, this interface must derive from `IGrainExtension`.

```csharp
public interface IGrainStateAccessor<T> : IGrainExtension
{
    Task<T> GetState();
    Task SetState(T state);
}
```

Once you have access to the target grain, you can use the extension to manipulate its state. In this example, you use an extension to access and modify a specific integer state value within the target grain.

### State manipulation extension implementation

The extension you use is `IGrainStateAccessor<T>`, which provides methods to get and set a state value of type `T`. To create the extension, you implement the interface in a class that takes a `getter` and a `setter` as arguments in its constructor.

```csharp
public sealed class GrainStateAccessor<T> : IGrainStateAccessor<T>
{
    private readonly Func<T> _getter;
    private readonly Action<T> _setter;

    public GrainStateAccessor(Func<T> getter, Action<T> setter)
    {
        _getter = getter;
        _setter = setter;
    }

    public Task<T> GetState()
    {
        return Task.FromResult(_getter.Invoke());
    }

    public Task SetState(T state)
    {
        _setter.Invoke(state);
        return Task.CompletedTask;
    }
}
```

In the preceding implementation, the `GrainStateAccessor<T>` class takes `getter` and `setter` arguments in its constructor. These delegates are used to read and modify the target grain's state. The `GetState()` method returns a <xref:System.Threading.Tasks.Task%601> wraps the current value of the `T` state, while the `SetState(T state)` method sets the new value of the `T` state.

### State manipulation extension registration and usage

To use the extension to access and modify the target grain's state, you need to register the extension and set its components in the <xref:Orleans.Grain.OnActivateAsync?displayProperty=nameWithType> method of the target grain.

```csharp
public override Task OnActivateAsync()
{
    // Retrieve the IGrainStateAccessor<T> extension
    var accessor = new GrainStateAccessor<int>(
        getter: () => this.Value,
        setter: value => this.Value = value);

    // Set the extension as a component of the target grain's context
    ((IGrainBase)this).GrainContext.SetComponent<IGrainStateAccessor<int>>(accessor);

    return base.OnActivateAsync();
}
```

In the preceding example, you create a new instance of `GrainStateAccessor<int>` that takes a `getter` and a `setter` for an integer state value. The `getter` reads the `Value` property of the target grain, while the `setter` sets the new value of the `Value` property. you then set this instance as a component of the target grain's context using the <xref:Orleans.Runtime.IGrainContext.SetComponent%2A?displayProperty=nameWithType> method.

Once the extension is registered, you can use it to get and set the target grain's state by accessing it through a reference to the extension.

```csharp
// Get a reference to the IGrainStateAccessor<int> extension
var accessor = grain.AsReference<IGrainStateAccessor<int>>();

// Get the current value of the state
var value = await accessor.GetState();

// Set a new value of the state
await accessor.SetState(10);
```

In the preceding example, you get a reference to the `IGrainStateAccessor<int>` extension for a specific grain instance using the <xref:Orleans.GrainExtensions.AsReference%2A?displayProperty=nameWithType> method. you can then use this reference to call the `GetState()` and `SetState(T state)` methods to read and modify the state value of the target grain.

## See also

- [Develop a grain](index.md)
- [Grain identity](grain-identity.md)
- [Grain lifecycle overview](grain-lifecycle.md)
- [Grain placement](grain-placement.md)
