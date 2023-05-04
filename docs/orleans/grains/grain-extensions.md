---
title: Grain extensions
description: Learn how to extend an Orleans Grain.
ms.date: 05/04/2023
---

# Grain extensions

Grain extensions provide a way to add additional behavior to grains. By extending a grain with an interface that derives from `IGrainExtension`, you can add new methods and functionality to the grain.

In this article, we'll cover two examples of grain extensions. The first example will show how to add a `Deactivate` method to all grains that can be used to deactivate the grain. The second example will show how to add a `GetState` and `SetState` method to any grain, allowing you to manipulate the grain's internal state.

## Simple example: automatic extension to add a deactivate method on all grains

In this example, we'll show how to add a `Deactivate` method to all grains automatically. The method can be used to deactivate the grain and will take a string as a message parameter.

### Extension interface

First, let's define the `IGrainDeactivateExtension` interface, which will contain the `Deactivate` method. Note that this interface derives from `IGrainExtension`.

``` csharp
public interface IGrainDeactivateExtension : IGrainExtension
{
    Task Deactivate(string msg);
}
```

### Extension implementation

Next, we'll implement the `GrainDeactivateExtension` class, which will provide the implementation for the `Deactivate` method.

To access the target grain, we retrieve the `IGrainContextAccessor` from the constructor. It will be injected when creating the extension with dependency injection.

``` csharp
public class GrainDeactivateExtension : IGrainDeactivateExtension
{
    private IGrainContextAccessor _contextAccessor;

    public GrainDeactivateExtension(IGrainContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public async Task Deactivate(string msg)
    {
        var reason = new DeactivationReason(DeactivationReasonCode.ApplicationRequested, msg);
        await _contextAccessor.GrainContext.DeactivateAsync(reason);
    }
}
```

### Extension registration and usage

Now that we've defined the interface and implementation, we can register the extension when configuring our silo.

``` csharp
siloBuilder.AddGrainExtension<IGrainDeactivateExtension, GrainDeactivateExtension>();
```

To use the extension on any grain, we can simply retrieve a reference to the extension and call the `Deactivate` method.

``` csharp
var myGrain = client.GetGrain<IMyGrain>(someKey);
var myGrainExtension = myGrain.AsReference<IGrainDeactivateExtension>();
await myGrainExtension.Deactivate("Because I said so");
```

## Advanced example: testing extension used to manipulate in-memory state

In this example, we'll show how to add a `GetState` and `SetState` method to any grain, allowing you to manipulate the grain's internal state.

### Extension interface

First, let's define the `IGrainStateAccessor<T>` interface, which will contain the `GetState` and `SetState` methods. Note that this interface derives from `IGrainExtension`.

``` csharp
public interface IGrainStateAccessor<T> : IGrainExtension
{
    Task<T> GetState();
    Task SetState(T state);
}
```

Once we have access to the target grain, we can use the extension to manipulate its state. In this example, we will use an extension to access and modify a specific integer state value within the target grain.

### Extension implementation

The extension we will use is `IGrainStateAccessor<T>`, which provides methods to get and set a state value of type `T`. To create the extension, we implement the interface in a class that takes a getter and a setter as arguments in its constructor.

``` csharp
public class GrainStateAccessor<T> : IGrainStateAccessor<T>
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
        return Task.FromResult(_getter());
    }

    public Task SetState(T state)
    {
        _setter(state);
        return Task.CompletedTask;
    }
}
```

In the above implementation, the `GrainStateAccessor<T>` class takes a getter and a setter as arguments in its constructor. These delegates are used to read and modify the target grain's state. The `GetState()` method returns a task that wraps the current value of the state, while the `SetState()` method sets the new value of the state.

### Extension registration and usage

To use the extension to access and modify the target grain's state, we need to register the extension and set its components in the `OnActivateAsync()` method of the target grain.

```csharp
public override Task OnActivateAsync()
{
    // Retrieve the IGrainStateAccessor<T> extension
    var accessor = new GrainStateAccessor<int>(
        () => this.Value, 
        value => this.Value = value);

    // Set the extension as a component of the target grain's context
    var context = _contextAccessor.GrainContext;
    context.SetComponent<IGrainStateAccessor<int>>(accessor);

    return base.OnActivateAsync();
}
```

In the above example, we create a new instance of `GrainStateAccessor<int>` that takes a getter and a setter for an integer state value. The getter reads the `Value` property of the target grain, while the setter sets the new value of the `Value` property. We then set this instance as a component of the target grain's context using the `SetComponent<T>(T value)` method. 

Once the extension is registered, we can use it to get and set the target grain's state by accessing it through a reference to the extension.

```csharp
// Get a reference to the IGrainStateAccessor<int> extension
var accessor = grain.AsReference<IGrainStateAccessor<int>>();

// Get the current value of the state
var value = await accessor.GetState();

// Set a new value of the state
await accessor.SetState(10);
```

In the above example, we get a reference to the `IGrainStateAccessor<int>` extension for a specific grain instance using the `AsReference<TGrainInterface>()` method. We can then use this reference to call the `GetState()` and `SetState()` methods to read and modify the state value of the target grain.














# Grain extensions

You can extend grains using Grain Extensions

## Simple example: automatic extension to add a deactivate method on all grains

### Extension interface

Note that it must derive from `IGrainExtension`

``` csharp
public interface IGrainDeactivateExtension : IGrainExtension
{
    Task Deactivate(string msg);
}
```

### Extension implementation

To access the target grain, we retrieve the `IGrainContextAccessor` from the constructor. It will be injected when creating the extension with DI.

``` csharp
public class GrainDeactivateExtension : IGrainDeactivateExtension
{
    private IGrainContextAccessor _contextAccessor;

    public GrainDeactivateExtension(IGrainContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public async Task Deactivate(string msg)
    {
        var reason = new DeactivationReason(DeactivationReasonCode.ApplicationRequested, msg);
        await _contextAccessor.GrainContext.DeactivateAsync(reason);
    }
}
```

### Extension registration and usage

You need to register the extension when configuring your silo:

``` csharp
siloBuilder.AddGrainExtension<IGrainDeactivateExtension,GrainDeactivateExtension>();
```

To use on *any* grain, now you can simply do:

``` csharp
var myGrain = client.GetGrain<IMyGrain>(someKey);
var myGrainExtension = myGrain.AsReference<IGrainDeactivateExtension>();
await myGrainExtension.Deactivate("Because I said so");
```

## Advanced example: testing extension used to manipulate in memory state

### Extension interface

Note that it must derive from `IGrainExtension`

``` csharp
public interface IGrainStateAccessor<T> : IGrainExtension
{
    Task<T> GetState();
    Task SetState(T state);
}
```

### Extension implementation

To use the `IGrainStateAccessor` extension, we need to register it with the grain's `GrainContext`. We do this by creating an instance of the extension and setting it as a component of the grain's `GrainContext` in the grain's `OnActivateAsync` method.

Here's an example of how to do this:

``` csharp
public class MyGrain : Grain<int>, IMyGrain
{
    private readonly IGrainContextAccessor _contextAccessor;

    public MyGrain(IGrainContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public override Task OnActivateAsync()
    {
        var context = _contextAccessor.GrainContext;
        var accessor = new GrainStateAccessor<int>(() => this.State, s => this.State = s);
        context.SetComponent<IGrainStateAccessor<int>>(accessor);

        return base.OnActivateAsync();
    }

    public Task<int> GetState()
    {
        var accessor = _contextAccessor.GrainContext.GetComponent<IGrainStateAccessor<int>>();
        return accessor.GetState();
    }

    public Task SetState(int state)
    {
        var accessor = _contextAccessor.GrainContext.GetComponent<IGrainStateAccessor<int>>();
        return accessor.SetState(state);
    }
}
```

In this example, we define a `MyGrain` class that derives from `Grain<int>` and implements the `IMyGrain` interface. We also define a constructor that takes an `IGrainContextAccessor` parameter that we use to access the grain's `GrainContext`.

In the `OnActivateAsync` method, we create an instance of the `GrainStateAccessor<int>` class and set it as a component of the grain's `GrainContext` using the `SetComponent` method.

Finally, we define methods to get and set the grain's state using the `GetState` and `SetState` methods of the `IGrainStateAccessor<int>` extension.

To use this extension on a specific grain instance, we can call the `AsReference` method on the grain instance to get a reference to the `IGrainStateAccessor<int>` interface. We can then use this reference to call the `GetState` and `SetState` methods to read and modify the state value of the target grain.
