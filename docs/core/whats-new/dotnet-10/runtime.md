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

This code shape is easy for the JIT to optimize, mainly because there aren't any virtual calls to reason about. Instead, the JIT can focus on removing bounds checks on the array access and applying the [loop optimizations that were added in .NET 9](../dotnet-9/runtime.md#loop-optimizations). The following example adds some virtual calls:

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

The type of the underlying collection is clear, and the JIT should be able to transform this snippet into the first one. However, array interfaces are implemented differently from "normal" interfaces, such that the JIT doesn't know how to devirtualize them. This means the enumerator calls in the `foreach` loop remain virtual, blocking multiple optimizations such as inlining and stack allocation.

Starting in .NET 10, the JIT can devirtualize and inline array interface methods. This is the first of many steps to achieve performance parity between the implementations, as detailed in the [.NET 10 de-abstraction plans](https://github.com/dotnet/runtime/issues/108913).

## Array enumeration de-abstraction

Efforts to reduce the abstraction overhead of array iteration via enumerators have improved the JIT's inlining, stack allocation, and loop cloning abilities. For example, the overhead of enumerating arrays via `IEnumerable` is reduced, and conditional escape analysis now enables stack allocation of enumerators in certain scenarios.

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

.NET 10 extends the [.NET 9 stack allocation improvements](../dotnet-9/runtime.md#object-stack-allocation-for-boxes) to small arrays of reference types. Previously, arrays of reference types were always allocated on the heap, even when their lifetime was scoped to a single method. Now, the JIT can stack-allocate such arrays when it determines that they don't outlive their creation context. For example:

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

In .NET 10, the JIT models the block reordering problem as a reduction of the asymmetric Travelling Salesman Problem and implements the 3-opt heuristic to find a near-optimal traversal. This optimization improves hot path density and reduces branch distances, resulting in better runtime performance.

## AVX10.2 support

.NET 10 introduces support for the Advanced Vector Extensions (AVX) 10.2 for x64-based processors. The new intrinsics available in the <xref:System.Runtime.Intrinsics.X86.Avx10v2?displayProperty=fullName> class can be tested once capable hardware is available.

Because AVX10.2-enabled hardware isn't yet available, the JIT's support for AVX10.2 is currently disabled by default.

## Support for casting and negation in NativeAOT's type preinitializer

NativeAOT's type preinitializer now supports all variants of the `conv.*` and `neg` opcodes. This enhancement allows preinitialization of methods that include casting or negation operations, further optimizing runtime performance.

## Escape analysis for local struct fields

*Escape analysis* determines if an object can outlive its parent method. Objects "escape" when assigned to non-local variables or passed to functions not inlined by the JIT. If an object can't escape, it can be allocated on the stack. Starting in .NET 10, the JIT also considers objects referenced by *struct fields*, which enables more stack allocations and reduces heap overhead.

Consider the following example:

```csharp
public class Program
{
    struct GCStruct
    {
        public int[] arr;
    }

    public static void Main()
    {
        int[] x = new int[10];
        GCStruct y = new GCStruct() { arr = x };
        return y.arr[0];
    }
}
```

Normally, the JIT stack-allocates small, fixed-sized arrays that don't escape, such as `x`. Its assignment to `y.arr` doesn't cause `x` to escape, because `y` doesn't escape either. However, the JIT's escape analysis implementation previously did not model struct field references. In .NET 9, the x64 assembly generated for `Main` looks like this:

```asm
Program:Main():int (FullOpts):
       push     rax
       mov      rdi, 0x719E28028A98      ; int[]
       mov      esi, 10
       call     CORINFO_HELP_NEWARR_1_VC
       mov      eax, dword ptr [rax+0x10]
       add      rsp, 8
       ret
```

Note the call to `CORINFO_HELP_NEWARR_1_VC` to allocate `x` on the heap, indicating it was marked as escaping. In .NET 10, the JIT no longer marks objects referenced by local struct fields as escaping, as long as the struct in question does not escape. The assembly now looks like this:

```asm
Program:Main():int (FullOpts):
       sub      rsp, 56
       vxorps   xmm8, xmm8, xmm8
       vmovdqu  ymmword ptr [rsp], ymm8
       vmovdqa  xmmword ptr [rsp+0x20], xmm8
       xor      eax, eax
       mov      qword ptr [rsp+0x30], rax
       mov      rax, 0x7F9FC16F8CC8      ; int[]
       mov      qword ptr [rsp], rax
       lea      rax, [rsp]
       mov      dword ptr [rax+0x08], 10
       lea      rax, [rsp]
       mov      eax, dword ptr [rax+0x10]
       add      rsp, 56
       ret
```

Notice that the heap allocation helper call is gone.

For more information about de-abstraction improvements in .NET 10, see [dotnet/runtime#108913](https://github.com/dotnet/runtime/issues/108913).

## Inlining improvements

In .NET 10, the JIT can inline:

* Methods that become eligible for devirtualization due to previous inlining. This improvement allows the JIT to uncover more optimization opportunities, such as further inlining and devirtualization.
* Some methods that have exception-handling semantics, in particular those with `try-finally` blocks.

The following improvements are also new for .NET 10:

* To better take advantage of the JIT's ability to stack-allocate some arrays, the inliner's heuristics were adjusted to increase the profitability of candidates that might be returning small, fixed-sized arrays.
* During inlining, the JIT now updates the type of temporary variables holding return values. If all return sites in a callee yield the same type, this precise type information is used to devirtualize subsequent calls. This enhancement complements the improvements in late devirtualization and array enumeration de-abstraction.
* When the JIT decides a call site isn't profitable for inlining, to reduce compile times, it marks the method with `NoInlining` to save future inlining attempts from considering it. However, many inlining heuristics are sensitive to profile data. For example, the JIT might decide a method is too large to be worth inlining in the absence of profile data. But when the caller is sufficiently hot, the JIT might be willing to relax its size restriction and inline the call. In .NET 10, the JIT no longer flags unprofitable inlinees with `NoInlining` to avoid pessimizing call sites with profile data.
