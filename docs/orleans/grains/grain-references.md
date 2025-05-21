---
title: Grain references
description: Learn about grain references in .NET Orleans.
ms.date: 07/03/2024
ms.topic: how-to
---

# Grain references

Before calling a method on grain, you first need a reference to that grain. A grain reference is a proxy object that implements the same grain interface as the corresponding grain class. It encapsulates the logical identity (type and unique key) of the target grain. Grain references are used for making calls to the target grain. Each grain reference is to a single grain (a single instance of the grain class), but one can create multiple independent references to the same grain.

Since a grain reference represents the logical identity of the target grain, it is independent of the physical location of the grain, and stays valid even after a complete restart of the system. Developers can use grain references like any other .NET object. It can be passed to a method, used as a method return value, and even saved to persistent storage.

A grain reference can be obtained by passing the identity of a grain to the <xref:Orleans.IGrainFactory.GetGrain%60%601(System.Type,System.Guid)?displayProperty=nameWithType> method, where `T` is the grain interface and `key` is the unique key of the grain within the type.

The following are examples of how to obtain a grain reference of the `IPlayerGrain` interface defined above.

From within a grain class:

```csharp
// This would typically be read from an HTTP request parameter or elsewhere.
Guid playerId = Guid.NewGuid();
IPlayerGrain player = GrainFactory.GetGrain<IPlayerGrain>(playerId);
```

From Orleans client code:

```csharp
// This would typically be read from an HTTP request parameter or elsewhere.
Guid playerId = Guid.NewGuid();
IPlayerGrain player = client.GetGrain<IPlayerGrain>(playerId);
```

Grain references contain three pieces of information:

1. The grain _type_, which uniquely identifies the grain class.
2. The grain _key_, which uniquely identifies a logical instance of that grain class.
3. The _interface_ which the grain reference must implement.

> [!NOTE]
> The grain _type_ and _key_ form the [grain identity](grain-identity.md).

Notice that the above calls to <xref:Orleans.IGrainFactory.GetGrain*?displayProperty=nameWithType> accepted only two of those three things:

* The _interface_ implemented by the grain reference, `IPlayerGrain`.
* The grain _key_, which is the value of `playerId`.

Despite stating that a grain reference contains a grain _type_, _key_, and _interface_, the examples only provided Orleans with the _key_ and _interface_. That is because Orleans maintains a mapping between grain interfaces and grain types. When you ask the grain factory for `IShoppingCartGrain`, Orleans consults its mapping to find the corresponding grain type so that it can create the reference. This works when there's only one implementation of a grain interface, but if there are multiple implementations, then you will need to disambiguate them in the `GetGrain` call. For more information, see the next section, [disambiguating grain type resolution](#disambiguating-grain-type-resolution).

> [!NOTE]
> Orleans generates grain reference implementation types for each grain interface in your application  during compilation. These grain reference implementations inherit from the <xref:Orleans.Runtime.GrainReference?displayProperty=nameWithType> class. `GetGrain` returns instances of the generated <xref:Orleans.Runtime.GrainReference?displayProperty=nameWithType> implementation corresponding to the requested grain interface.

## Disambiguating grain type resolution

When there are multiple implementations of a grain interface, such as in the following example, Orleans attempts to determine the intended implementation when creating a grain reference. Consider the following example, in which there are two implementations of the `ICounterGrain` interface:

```csharp
public interface ICounterGrain : IGrainWithStringKey
{
    ValueTask<int> UpdateCount();
}

public class UpCounterGrain : ICounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(++_count); // Increment count
}

public class DownCounterGrain : ICounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(--_count); // Decrement count
}
```

The following call to `GetGrain` will throw an exception because Orleans doesn't know how to unambiguously map `ICounterGrain` to one of the grain classes.

```csharp
// This will throw an exception: there is no unambiguous mapping from ICounterGrain to a grain class.
ICounterGrain myCounter = grainFactory.GetGrain<ICounterGrain>("my-counter");
```

An <xref:System.ArgumentException?displayProperty=nameWithType> will thrown with the following message:

```Output
Unable to identify a single appropriate grain type for interface ICounterGrain. Candidates: upcounter (UpCounterGrain), downcounter (DownCounterGrain)
```

The error message tells you which grain implementation's Orleans has which match the requested grain interface type, `ICounterGrain`. It shows you the grain type names (`upcounter` and `downcounter`) as well as the grain classes (`UpCounterGrain` and `DownCounterGrain`).

> [!NOTE]
> The grain type names in the preceding error message, `upcounter` and `downcounter`, are derived from the grain class names, `UpCounterGrain` and `DownCounterGrain` respectively. This is the default behavior in Orleans and it can be customized by adding a `[GrainType(string)]` attribute to the grain class. For example:
>
> ```csharp
> [GrainType("up")]
> public class UpCounterGrain : IUpCounterGrain { /* as above */ }
> ```

There are several ways to resolve this ambiguity detailed in the following subsections.

### Disambiguating grain types using unique marker interfaces

The clearest way to disambiguate these grains is to give them unique grain interfaces. For example, if we add the interface `IUpCounterGrain` to the `UpCounterGrain` class and add the interface `IDownCounterGrain` to the `DownCounterGrain` class, like in the following example, then we can resolve the correct grain reference by passing `IUpCounterGrain` or `IDownCounterGrain` to the `GetGrain<T>` call instead of passing the ambiguous `ICounterGrain` type.

```csharp
public interface ICounterGrain : IGrainWithStringKey
{
    ValueTask<int> UpdateCount();
}

// Define unique interfaces for our implementations
public interface IUpCounterGrain : ICounterGrain, IGrainWithStringKey {}
public interface IDownCounterGrain : ICounterGrain, IGrainWithStringKey {}

public class UpCounterGrain : IUpCounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(++_count); // Increment count
}

public class DownCounterGrain : IDownCounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(--_count); // Decrement count
}
```

To create a reference to either grain, consider the following code:

```csharp
// Get a reference to an UpCounterGrain.
ICounterGrain myUpCounter = grainFactory.GetGrain<IUpCounterGrain>("my-counter");

// Get a reference to a DownCounterGrain.
ICounterGrain myDownCounter = grainFactory.GetGrain<IDownCounterGrain>("my-counter");
```

> [!NOTE]
> In the preceding example, you created two grain references with the same key, but different grain types. The first, stored in the `myUpCounter` variable, is a reference to the grain with the id `upcounter/my-counter`. The second, stored in the `myDownCounter` variable, is a reference to the grain with the id `downcounter/my-counter`. It's the combination of grain _type_ and grain _key_ which uniquely identify a grain. Therefore, `myUpCounter` and `myDownCounter` refer to different grains.

#### Disambiguating grain types by providing a grain class prefix

You can provide a grain class name prefix to <xref:Orleans.IGrainFactory.GetGrain*?displayProperty=nameWithType>, for example:

```csharp
ICounterGrain myUpCounter = grainFactory.GetGrain<ICounterGrain>("my-counter", grainClassNamePrefix: "Up");
ICounterGrain myDownCounter = grainFactory.GetGrain<ICounterGrain>("my-counter", grainClassNamePrefix: "Down");
```

### Specifying the default grain implementation using the naming convention

When disambiguating multiple implementations of the same grain interface, Orleans will select an implementation using the convention of stripping a leading 'I' from the interface name. For example, if the interface name is `ICounterGrain` and there are two implementations, `CounterGrain` and `DownCounterGrain`, Orleans will chose `CounterGrain` when asked for a reference to `ICounterGrain`, as in the following example:

```csharp
/// This will refer to an instance of CounterGrain, since that matches the convention.
ICounterGrain myUpCounter = grainFactory.GetGrain<ICounterGrain>("my-counter");
```

### Specifying the default grain type using an attribute

The <xref:Orleans.Metadata.DefaultGrainTypeAttribute?displayProperty=nameWithType> attribute can be added to a grain interface to specify the grain type of the default implementation for that interface, as in the following example:

```csharp
[DefaultGrainType("up-counter")]
public interface ICounterGrain : IGrainWithStringKey
{
    ValueTask<int> UpdateCount();
}

[GrainType("up-counter")]
public class UpCounterGrain : ICounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(++_count); // Increment count
}

[GrainType("down-counter")]
public class DownCounterGrain : ICounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(--_count); // Decrement count
}
```

```csharp
/// This will refer to an instance of UpCounterGrain, due to the [DefaultGrainType("up-counter"')] attribute
ICounterGrain myUpCounter = grainFactory.GetGrain<ICounterGrain>("my-counter");
```

### Disambiguating grain types by providing the resolved grain id

Some overloads of <xref:Orleans.IGrainFactory.GetGrain*?displayProperty=nameWithType> accept an argument of type <xref:Orleans.Runtime.GrainId?displayProperty=nameWithType>. When using these overloads, Orleans doesn't need to map from an interface type to a grain type and therefore there is no ambiguity to be resolved. For example:

```csharp
public interface ICounterGrain : IGrainWithStringKey
{
    ValueTask<int> UpdateCount();
}

[GrainType("up-counter")]
public class UpCounterGrain : ICounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(++_count); // Increment count
}

[GrainType("down-counter")]
public class DownCounterGrain : ICounterGrain
{
    private int _count;

    public ValueTask<string> UpdateCount() => new(--_count); // Decrement count
}
```

```csharp
// This will refer to an instance of UpCounterGrain, since "up-counter" was specified as the grain type
// and the UpCounterGrain uses [GrainType("up-counter")] to specify its grain type.
ICounterGrain myUpCounter = grainFactory.GetGrain<ICounterGrain>(GrainId.Create("up-counter", "my-counter"));
```
