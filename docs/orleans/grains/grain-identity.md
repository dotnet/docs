---
title: Grain identity
description: Learn about grain identities in .NET Orleans.
ms.date: 07/03/2024
ms.topic: how-to
---

# Grain identity

Grains in Orleans each have a single, unique, user-defined identifier which consists of two parts:

1. The grain _type_ name, which uniquely identifies the grain class.
2. The grain _key_, which uniquely identifies a logical instance of that grain class.

The grain type and key are both represented as human-readable strings in Orleans and, by convention, the grain identity is written with the grain type and key separated by a `/` character. For example, `shoppingcart/bob65` represents the grain type named `shoppingcart` with a key `bob65`.

It's not common to construct grain identities directly. Instead, it's more common to create [grain references](./grain-references.md) using <xref:Orleans.IGrainFactory?displayProperty=nameWithType>.

The following sections discuss grain type names and grain keys in more detail.

## Grain type names

Orleans creates a grain type name for you based on your grain implementation class by removing the suffix "Grain" from the class name, if it's present, and converting the resulting string into its lower-case representation. For example, a class named `ShoppingCartGrain` will be given the grain type name `shoppingcart`. It's recommended that grain type names and keys consist only of printable characters such as alpha-numeric (`a`-`z`, `A`-`Z`, and `0`-`9`) characters and symbols such as `-`, `_`, `@`, `=`. Other characters may or may not be supported and will often need special treatment when printed in logs or appearing as identifiers in other systems such as databases.

Alternatively, you can use the <xref:Orleans.GrainTypeAttribute?displayProperty=nameWithType> attribute to customize the grain type name for the grain class to which it is attached, as in the following example:

```csharp
[GrainType("cart")]
public class ShoppingCartGrain : IShoppingCartGrain
{
    // Add your grain implementation here
}
```

In the preceding example, the grain class, `ShoppingCartGrain` has a grain type name of `cart`. Each grain can only have one grain type name.

For generic grains, the generic arity must be included in the grain type name. For example, consider the following `DictionaryGrain<K, V>` class:

```csharp
[GrainType("dict`2")]
public class DictionaryGrain<K, V> : IDictionaryGrain<K, V>
{
    // Add your grain implementation here
}
```

The grain class has two generic parameters, so a backtick `` ` `` followed by the generic arity, 2, is added to the end of the grain type name, `dict` to create the grain type name ``dict`2``, as specified in the attribute on the grain class, ``[GrainType("dict`2")]``.

## Grain keys

For convenience, Orleans exposes methods which allow construction of grain keys from a <xref:System.Guid> or a <xref:System.Int64>, in addition to a <xref:System.String>.
The primary key is scoped to the grain type.
Therefore, the complete identity of a grain is formed from the grain's type and its key.

The caller of the grain decides which scheme should be used. The options are:

* <xref:System.Guid?displayProperty=nameWithType>
* <xref:System.Int64?displayProperty=nameWithType>
* <xref:System.String?displayProperty=nameWithType>
* <xref:System.Guid?displayProperty=nameWithType> and <xref:System.String?displayProperty=nameWithType>
* <xref:System.Int64?displayProperty=nameWithType> and <xref:System.String?displayProperty=nameWithType>

Because the underlying data is the same, the schemes can be used interchangeably: they are all encoded as strings.

Situations that require a singleton grain instance can use a well-known, fixed value such as `"default"`. This is merely a convention, but by adhering to this convention it becomes clear at the caller site that a singleton grain is in use.

### Using globally unique identifiers (GUIDs) as keys

<xref:System.Guid?displayProperty=nameWithType> make useful keys when randomness and global uniqueness are desired, such as when creating a new job in a job processing system. You don't need to coordinate the allocation of keys, which could introduce a single point of failure in the system, or a system-side lock on a resource that could present a bottleneck. There is a very low chance of GUIDs colliding, so they are a common choice when architecting a system which needs to allocate random identifiers.

Referencing a grain by GUID in client code:

```csharp
var grain = grainFactory.GetGrain<IExample>(Guid.NewGuid());
```

Retrieving the primary key from grain code:

```csharp
public override Task OnActivateAsync()
{
    Guid primaryKey = this.GetPrimaryKey();
    return base.OnActivateAsync();
}
```

### Using integers as keys

A long integer is also available, which would make sense if the grain is persisted to a relational database, where numerical indexes are preferred over GUIDs.

Referencing a grain by a long integer in client code:

```csharp
var grain = grainFactory.GetGrain<IExample>(1);
```

Retrieving the primary key from grain code:

```csharp
public override Task OnActivateAsync()
{
    long primaryKey = this.GetPrimaryKeyLong();
    return base.OnActivateAsync();
}
```

### Using strings as keys

A string is also available.

Referencing a grain by String in client code:

```csharp
var grain = grainFactory.GetGrain<IExample>("myGrainKey");
```

Retrieving the primary key from grain code:

```csharp
public override Task OnActivateAsync()
{
    string primaryKey = this.GetPrimaryKeyString();
    return base.OnActivateAsync();
}
```

### Using compound keys

If you have a system that doesn't fit well with either GUIDs or longs, you can opt for a compound primary key, which allows you to use a combination of a GUID or long and a string to reference a grain.

You can inherit your interface from <xref:Orleans.IGrainWithGuidCompoundKey> or <xref:Orleans.IGrainWithIntegerCompoundKey> interface like this:

```csharp
public interface IExampleGrain : Orleans.IGrainWithIntegerCompoundKey
{
    Task Hello();
}
```

In client code, this adds a second argument to the <xref:Orleans.IGrainFactory.GetGrain%2A?displayProperty=nameWithType> method on the grain factory:

```csharp
var grain = grainFactory.GetGrain<IExample>(0, "a string!", null);
```

To access the compound key in the grain, we can call an overload on the <xref:Orleans.GrainExtensions.GetPrimaryKey%2A?displayProperty=nameWithType> method (the <xref:Orleans.GrainExtensions.GetPrimaryKeyLong%2A?displayProperty=nameWithType>):

```csharp
public class ExampleGrain : Orleans.Grain, IExampleGrain
{
    public Task Hello()
    {
        long primaryKey = this.GetPrimaryKeyLong(out string keyExtension);
        Console.WriteLine($"Hello from {keyExtension}");

        return Task.CompletedTask;
    }
}
```

## Why grains use logical identifiers

In object-oriented environments, such as .NET, the identity of an object is hard to distinguish from a reference to it. When an object is created using the `new` keyword, the reference you get back represents all aspects of its identity except those that map the object to some external entity that it represents. Orleans is designed for distributed systems. In distributed systems, object references cannot represent instance identity since object references are limited to a single process' address space. Orleans uses logical identifiers to avoid this limitation. Grain use logical identifiers so that grain references remain valid across process lifetimes and are portable from one process to another, allowing them to be stored and later retrieved or to be sent across a network to another process in the application, all while still referring to the same entity: the grain which the reference was created for.
