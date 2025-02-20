---
title: What's new in .NET 10 runtime
description: Learn about the new .NET features introduced in the .NET 10 runtime.
titleSuffix: ""
ms.date: 02/20/2025
ms.topic: whats-new
---
# What's new in the .NET 10 runtime

This article describes new features and performance improvements in the .NET runtime for .NET 10. It has been updated for Preview 1.

## Array interface method devirtualization

One of the code generation team's [focus areas](https://github.com/dotnet/runtime/issues/108988) for .NET 10 is to reduce the abstraction overhead of popular language features. In pursuit of this goal, the JIT's ability to devirtualize method calls has been expanded to cover array interface methods.

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

The type of the underlying collection is clear, and the JIT should be able to transform this snippet into the first one. However, array interfaces are implemented differently from "normal" interfaces, such that the JIT does not know how to devirtualize them. This means the enumerator calls in the `for-each` loop remain virtual, blocking multiple optimizations such as inlining and stack allocation.

Starting in .NET 10, the JIT can devirtualize and inline array interface methods. This is the first of many steps to achieve performance parity between the implementations, as detailed in the [.NET 10 de-abstraction plans](https://github.com/dotnet/runtime/issues/108913).

## Stack allocation of arrays of value types

In .NET 9, the JIT gained the ability to allocate objects on the stack, when the object is guaranteed to not outlive its parent method. Not only does stack allocation reduce the number of objects the GC has to track, but it also unlocks other optimizations. For example, after an object has been stack-allocated, the JIT can consider replacing it entirely with its scalar values. Because of this, stack allocation is key to reducing the abstraction penalty of reference types.

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

.NET 10 introduces support for the Advanced Vector Extensions (AVX) 10.2 for x64-based processors. The new intrinsics available in the `System.Runtime.Intrinsics.X86.Avx10v2` <!--xref:System.Runtime.Intrinsics.X86.Avx10v2--> class can be tested once capable hardware is available.

Because AVX10.2-enabled hardware is not yet available, the JIT's support for AVX10.2 is currently disabled by default.
