---
title: What's new in .NET 10 runtime
description: Learn about the new features introduced in the .NET 10 runtime.
titleSuffix: ""
ms.date: 05/15/2025
ms.topic: whats-new
ai-usage: ai-assisted
---
# What's new in the .NET 10 runtime

This article describes new features and performance improvements in the .NET runtime for .NET 10. It's updated for Preview 4.

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

Efforts to reduce the abstraction overhead of array iteration via enumerators have improved the JIT's inlining, stack allocation, and loop cloning abilities. For example, the overhead of enumerating arrays via `IEnumerable` is reduced, and conditional escape analysis now enables stack allocation of enumerators in certain scenarios. For more information, see [dotnet/runtime#108913](https://github.com/dotnet/runtime/issues/108913) and [dotnet/runtime#111473](https://github.com/dotnet/runtime/pull/111473).

## Inlining of late devirtualized methods

The JIT can now inline methods that become eligible for devirtualization due to previous inlining. This improvement allows the JIT to uncover more optimization opportunities, such as further inlining and devirtualization. For more information, see [dotnet/runtime#110827](https://github.com/dotnet/runtime/pull/110827).

## Devirtualization based on inlining observations

During inlining, the JIT now updates the type of temporary variables holding return values. If all return sites in a callee yield the same type, this precise type information is used to devirtualize subsequent calls. This enhancement complements the improvements in late devirtualization and array enumeration de-abstraction. For more information, see [dotnet/runtime#111948](https://github.com/dotnet/runtime/pull/111948).

## Stack allocation of small arrays of value types

In .NET 9, the JIT gained the ability to allocate objects on the stack when the object is guaranteed to not outlive its parent method. Not only does stack allocation reduce the number of objects the GC has to track, but it also unlocks other optimizations. For example, after an object is stack-allocated, the JIT can consider replacing it entirely with its scalar values. Because of this, stack allocation is key to reducing the abstraction penalty of reference types.

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

## Stack allocation of small arrays of reference types

Building on the [stack allocation improvements introduced in .NET 9](../dotnet-9/runtime.md#object-stack-allocation-for-boxes), .NET 10 extends this optimization to small arrays of reference types. Previously, arrays of reference types were always allocated on the heap, even when their lifetime was scoped to a single method. Now, the JIT can stack-allocate such arrays when it determines that they don't outlive their creation context. For example:

```csharp
static void Print()
{
    string[] words = {"Hello", "World!"};
    foreach (var str in words)
    {
        Console.WriteLine(str);
    }
}
```

In this example, the array `words` is now allocated on the stack. The elimination of heap allocations reduces GC pressure and improves performance.

## Improved code layout

The JIT compiler in .NET 10 introduces a new approach to organizing method code into basic blocks for better runtime performance. Previously, the JIT used a reverse postorder (RPO) traversal of the program's flowgraph as an initial layout, followed by iterative transformations. While effective, this approach had limitations in modeling the trade-offs between reducing branching and increasing hot code density.

In .NET 10, the JIT models the block reordering problem as a reduction of the asymmetric Travelling Salesman Problem and implements the 3-opt heuristic to find a near-optimal traversal. This optimization improves hot path density and reduces branch distances, resulting in better runtime performance. For more details, see [dotnet/runtime#107749](https://github.com/dotnet/runtime/issues/107749).

## AVX10.2 support

.NET 10 introduces support for the Advanced Vector Extensions (AVX) 10.2 for x64-based processors. The new intrinsics available in the <xref:System.Runtime.Intrinsics.X86.Avx10v2?displayProperty=fullName> class can be tested once capable hardware is available.

Because AVX10.2-enabled hardware isn't yet available, the JIT's support for AVX10.2 is currently disabled by default.

## Support for casting and negation in NativeAOT's type preinitializer

NativeAOT's type preinitializer now supports all variants of the `conv.*` and `neg` opcodes. This enhancement allows preinitialization of methods that include casting or negation operations, further optimizing runtime performance. For more information, see [dotnet/runtime#112073](https://github.com/dotnet/runtime/pull/112073).
