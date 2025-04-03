---
title: What's new in .NET 10 runtime
description: Learn about the new .NET features introduced in the .NET 10 runtime.
titleSuffix: ""
ms.date: 03/18/2025
ms.topic: whats-new
ai-usage: ai-assisted
---
# What's new in the .NET 10 runtime

This article describes new features and performance improvements in the .NET runtime for .NET 10. It's updated for Preview 2.

## Array interface method devirtualization

One of the [focus areas](https://github.com/dotnet/runtime/issues/108988) for .NET 10 is to reduce the abstraction overhead of popular language features. In pursuit of this goal, the JIT's ability to devirtualize method calls has expanded to cover array interface methods.

Consider the typical approach of looping over an array:

```csharp
static int Sum(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }
    return sum;
}
```

This code shape is easy for the JIT to optimize, mainly because there aren't any virtual calls to reason about. Instead, the JIT can focus on removing bounds checks on the array access and applying the [loop optimizations that were added in .NET 9](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/). The following example adds some virtual calls:

```csharp
static int Sum(int[] array)
{
    int sum = 0;
    IEnumerable<int> temp = array;

    foreach (var num in temp)
    {
        sum += num;
    }
    return sum;
}
```

The type of the underlying collection is clear, and the JIT should be able to transform this snippet into the first one. However, array interfaces are implemented differently from "normal" interfaces, such that the JIT doesn't know how to devirtualize them. This means the enumerator calls in the `for-each` loop remain virtual, blocking multiple optimizations such as inlining and stack allocation.

Starting in .NET 10, the JIT can devirtualize and inline array interface methods. This is the first of many steps to achieve performance parity between the implementations, as detailed in the [.NET 10 de-abstraction plans](https://github.com/dotnet/runtime/issues/108913).

## Array enumeration de-abstraction

Efforts to reduce the abstraction overhead of array iteration via enumerators have improved the JIT's inlining, stack allocation, and loop cloning abilities. For example, the overhead of enumerating arrays via `IEnumerable` is reduced, and conditional escape analysis now enables stack allocation of enumerators in certain scenarios. For more information, see [dotnet/runtime #108913](https://github.com/dotnet/runtime/issues/108913) and [dotnet/runtime #111473](https://github.com/dotnet/runtime/pull/111473).

## Inlining of late devirtualized methods

The JIT can now inline methods that become eligible for devirtualization due to previous inlining. This improvement allows the JIT to uncover more optimization opportunities, such as further inlining and devirtualization. For more information, see [dotnet/runtime #110827](https://github.com/dotnet/runtime/pull/110827).

## Devirtualization based on inlining observations

During inlining, the JIT now updates the type of temporary variables holding return values. If all return sites in a callee yield the same type, this precise type information is used to devirtualize subsequent calls. This enhancement complements the improvements in late devirtualization and array enumeration de-abstraction. For more information, see [dotnet/runtime #111948](https://github.com/dotnet/runtime/pull/111948).

## Stack allocation of arrays of value types

In .NET 9, the JIT gained the ability to allocate objects on the stack, when the object is guaranteed to not outlive its parent method. Not only does stack allocation reduce the number of objects the GC has to track, but it also unlocks other optimizations. For example, after an object is stack-allocated, the JIT can consider replacing it entirely with its scalar values. Because of this, stack allocation is key to reducing the abstraction penalty of reference types.

In .NET 10, the JIT now stack-allocates small, fixed-sized arrays of value types that don't contain GC pointers when it can make the same lifetime guarantees described previously. Consider the following example:

```csharp
static void Sum()
{
    int[] numbers = {1, 2, 3};
    int sum = 0;

    for (int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }

    Console.WriteLine(sum);
}
```

Because the JIT knows `numbers` is an array of only three integers at compile time, and it doesn't outlive a call to `Sum`, it allocates it on the stack.

## AVX10.2 support

.NET 10 introduces support for the Advanced Vector Extensions (AVX) 10.2 for x64-based processors. The new intrinsics available in the <xref:System.Runtime.Intrinsics.X86.Avx10v2?displayProperty=fullName> class can be tested once capable hardware is available.

Because AVX10.2-enabled hardware isn't yet available, the JIT's support for AVX10.2 is currently disabled by default.

## Support for casting and negation in NativeAOT's type preinitializer

NativeAOT's type preinitializer now supports all variants of the `conv.*` and `neg` opcodes. This enhancement allows preinitialization of methods that include casting or negation operations, further optimizing runtime performance. For more information, see [dotnet/runtime #112073](https://github.com/dotnet/runtime/pull/112073).
