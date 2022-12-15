---
title: Serialization of immutable types in Orleans
description: Learn how to customize serialization in .NET Orleans.
ms.date: 12/15/2022
---

# Serialization of immutable types in Orleans

Orleans has a feature that can be used to avoid some of the overhead associated with serializing messages containing immutable types. This section describes the feature and its application, starting with context on where it is relevant.

## Serialization in Orleans

When a grain method is invoked, the Orleans runtime makes a deep copy of the method arguments and forms the request out of the copies. This protects against the calling code modifying the argument objects before the data is passed to the called grain.

If the called grain is on a different silo, then the copies are eventually serialized into a byte stream and sent over the network to the target silo, where they are deserialized back into objects. If the called grain is on the same silo, then the copies are handed directly to the called method.

Return values are handled the same way: first copied, then possibly serialized and deserialized.

Note that all 3 processes, copying, serializing, and deserializing, respect object identity. In other words, if you pass a list that has the same object in it twice, on the receiving side you'll get a list with the same object in it twice, rather than with two objects with the same values in them.

## Optimize copying

In many cases, deep copying is unnecessary. For instance, a possible scenario is a web front-end that receives a byte array from its client and passes that request, including the byte array, onto a grain for processing. The front-end process doesn't do anything with the array once it has passed it on to the grain; in particular, it doesn't reuse the array to receive a future request. Inside the grain, the byte array is parsed to fetch the input data, but not modified. The grain returns another byte array that it has created to get passed back to the web client; it discards the array as soon as it returns it. The web front-end passes the result byte array back to its client, without modification.

In such a scenario, there is no need to copy either the request or response byte arrays. Unfortunately, the Orleans runtime can't figure this out by itself, since it can't tell whether or not the arrays are modified later on by the web front-end or by the grain. In the best of all possible worlds, we'd have some sort of .NET mechanism for indicating that a value is no longer modified; lacking that, we've added Orleans-specific mechanisms for this: the <xref:Orleans.Concurrency.Immutable%601> wrapper class and the <xref:Orleans.Concurrency.ImmutableAttribute>.

### Use `Immutable<T>`

The <xref:Orleans.Concurrency.Immutable%601> wrapper class is used to indicate that a value may be considered immutable; that is, the underlying value will not be modified, so no copying is required for safe sharing. Note that using `Immutable<T>` implies that neither the provider of the value nor the recipient of the value will modify it in the future; it is not a one-sided commitment, but rather a mutual dual-side commitment.

To use `Immutable<T>` in your grain interface, instead of passing `T`, pass `Immutable<T>`. For instance, in the above-described scenario, the grain method was:

```csharp
Task<byte[]> ProcessRequest(byte[] request);
```

Which would then become:

```csharp
Task<Immutable<byte[]>> ProcessRequest(Immutable<byte[]> request);
```

To create an `Immutable<T>`, simply use the constructor:

```csharp
Immutable<byte[]> immutable = new(buffer);
```

To get the values inside the immutable, use the `.Value` property:

```csharp
byte[] buffer = immutable.Value;
```

### Use `[Immutable]` attribute

For user-defined types, the <xref:Orleans.Concurrency.ImmutableAttribute> can be added to the type. This instructs Orleans' serializer to avoid copying instances of this type.
The following code snippet demonstrates using `[Immutable]` to denote an immutable type. This type will not be copied during transmission.

```csharp
[Immutable]
public class MyImmutableType
{
    public int MyValue { get; }

    public MyImmutableType(int value)
    {
        MyValue = value;
    }
}
```

## Immutability in Orleans

For Orleans' purposes, immutability is a rather strict statement: the contents of the data item will not be modified in any way that could change the item's semantic meaning, or that would interfere with another thread simultaneously accessing the item. The safest way to ensure this is to simply not modify the item at all: bitwise immutability, rather than logical immutability.

In some cases, it is safe to relax this to logical immutability, but care must be taken to ensure that the mutating code is properly thread-safe. Because dealing with multithreading is complex, and uncommon in an Orleans context, we strongly recommend against this approach and recommend sticking to bitwise immutability.
