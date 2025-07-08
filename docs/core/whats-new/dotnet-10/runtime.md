---
title: What's new in .NET 10 runtime
description: Learn about the new features introduced in the .NET 10 runtime.
titleSuffix: ""
ms.date: 06/09/2025
ms.topic: whats-new
ai-usage: ai-assisted
---
# What's new in the .NET 10 runtime

This article describes new features and performance improvements in the .NET runtime for .NET 10. It's updated for Preview 5.

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

## Improved code layout

The JIT compiler in .NET 10 introduces a new approach to organizing method code into basic blocks for better runtime performance. Previously, the JIT used a reverse postorder (RPO) traversal of the program's flowgraph as an initial layout, followed by iterative transformations. While effective, this approach had limitations in modeling the trade-offs between reducing branching and increasing hot code density.

In .NET 10, the JIT models the block reordering problem as a reduction of the asymmetric Travelling Salesman Problem and implements the 3-opt heuristic to find a near-optimal traversal. This optimization improves hot path density and reduces branch distances, resulting in better runtime performance.

## AVX10.2 support

.NET 10 introduces support for the Advanced Vector Extensions (AVX) 10.2 for x64-based processors. The new intrinsics available in the <xref:System.Runtime.Intrinsics.X86.Avx10v2?displayProperty=fullName> class can be tested once capable hardware is available.

Because AVX10.2-enabled hardware isn't yet available, the JIT's support for AVX10.2 is currently disabled by default.

## Stack allocation

Stack allocation reduces the number of objects the GC has to track, and it also unlocks other optimizations. For example, after an object is stack-allocated, the JIT can consider replacing it entirely with its scalar values. Because of this, stack allocation is key to reducing the abstraction penalty of reference types. .NET 10 adds stack allocation for [small arrays of  value types](#small-arrays-of-value-types) _and_ [small arrays of reference types](#small-arrays-of-reference-types). It also includes [escape analysis](#escape-analysis) for local struct fields and delegates. (Objects that can't escape can be allocated on the stack.)

### Small arrays of value types

The JIT now stack-allocates small, fixed-sized arrays of value types that don't contain GC pointers when they can be guaranteed not to outlive their parent method. In the following example, the JIT knows at compile time that `numbers` is an array of only three integers that doesn't outlive a call to `Sum`, and therefore allocates it on the stack.

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

### Small arrays of reference types

.NET 10 extends the [.NET 9 stack allocation improvements](../dotnet-9/runtime.md#object-stack-allocation-for-boxes) to small arrays of reference types. Previously, arrays of reference types were always allocated on the heap, even when their lifetime was scoped to a single method. Now, the JIT can stack-allocate such arrays when it determines that they don't outlive their creation context. In the following example, the array `words` is now allocated on the stack.

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

### Escape analysis

*Escape analysis* determines if an object can outlive its parent method. Objects "escape" when assigned to non-local variables or passed to functions not inlined by the JIT. If an object can't escape, it can be allocated on the stack. .NET 10 includes escape analysis for:

- [Local struct fields](#local-struct-fields)
- [Delegates](#delegates)

#### Local struct fields

Starting in .NET 10, the JIT considers objects referenced by *struct fields*, which enables more stack allocations and reduces heap overhead. Consider the following example:

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

Normally, the JIT stack-allocates small, fixed-sized arrays that don't escape, such as `x`. Its assignment to `y.arr` doesn't cause `x` to escape, because `y` doesn't escape either. However, the JIT's previous escape analysis implementation didn't model struct field references. In .NET 9, the x64 assembly generated for `Main` includes a call to `CORINFO_HELP_NEWARR_1_VC` to allocate `x` on the heap, indicating it was marked as escaping:

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

In .NET 10, the JIT no longer marks objects referenced by local struct fields as escaping, as long as the struct in question does not escape. The assembly now looks like this (notice that the heap allocation helper call is gone):

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

For more information about de-abstraction improvements in .NET 10, see [dotnet/runtime#108913](https://github.com/dotnet/runtime/issues/108913).

#### Delegates

When source code is compiled to IL, each delegate is transformed into a closure class with a method corresponding to the delegate's definition and fields matching any captured variables. At run time, a closure object is created to instantiate the captured variables, along with a `Func` object to invoke the delegate. If escape analysis determines the `Func` object won't outlive its current scope, the JIT allocates it on the stack.

Consider the following `Main` method:

```csharp
 public static int Main()
{
    int local = 1;
    int[] arr = new int[100];
    var func = (int x) => x + local;
    int sum = 0;

    foreach (int num in arr)
    {
        sum += func(num);
    }

    return sum;
}
```

Previously, the JIT produces the following abbreviated x64 assembly for `Main`. Before entering the loop, `arr`, `func`, and the closure class for `func` called `Program+<>c__DisplayClass0_0` are all allocated on the _heap_, as indicated by the `CORINFO_HELP_NEW*` calls.

```asm
       ; prolog omitted for brevity
       mov      rdi, 0x7DD0AE362E28      ; Program+<>c__DisplayClass0_0
       call     CORINFO_HELP_NEWSFAST
       mov      rbx, rax
       mov      dword ptr [rbx+0x08], 1
       mov      rdi, 0x7DD0AE268A98      ; int[]
       mov      esi, 100
       call     CORINFO_HELP_NEWARR_1_VC
       mov      r15, rax
       mov      rdi, 0x7DD0AE4A9C58      ; System.Func`2[int,int]
       call     CORINFO_HELP_NEWSFAST
       mov      r14, rax
       lea      rdi, bword ptr [r14+0x08]
       mov      rsi, rbx
       call     CORINFO_HELP_ASSIGN_REF
       mov      rsi, 0x7DD0AE461140      ; code for Program+<>c__DisplayClass0_0:<Main>b__0(int):int:this
       mov      qword ptr [r14+0x18], rsi
       xor      ebx, ebx
       add      r15, 16
       mov      r13d, 100
G_M24375_IG03:  ;; offset=0x0075
       mov      esi, dword ptr [r15]
       mov      rdi, gword ptr [r14+0x08]
       call     [r14+0x18]System.Func`2[int,int]:Invoke(int):int:this
       add      ebx, eax
       add      r15, 4
       dec      r13d
       jne      SHORT G_M24375_IG03
       ; epilog omitted for brevity
```

Now, because `func` is never referenced outside the scope of `Main`, it's also allocated on the _stack_:

```asm
       ; prolog omitted for brevity
       mov      rdi, 0x7B52F7837958      ; Program+<>c__DisplayClass0_0
       call     CORINFO_HELP_NEWSFAST
       mov      rbx, rax
       mov      dword ptr [rbx+0x08], 1
       mov      rsi, 0x7B52F7718CC8      ; int[]
       mov      qword ptr [rbp-0x1C0], rsi
       lea      rsi, [rbp-0x1C0]
       mov      dword ptr [rsi+0x08], 100
       lea      r15, [rbp-0x1C0]
       xor      r14d, r14d
       add      r15, 16
       mov      r13d, 100
G_M24375_IG03:  ;; offset=0x0099
       mov      esi, dword ptr [r15]
       mov      rdi, rbx
       mov      rax, 0x7B52F7901638      ; address of definition for "func"
       call     rax
       add      r14d, eax
       add      r15, 4
       dec      r13d
       jne      SHORT G_M24375_IG03
       ; epilog omitted for brevity
```

Notice there is one remaining `CORINFO_HELP_NEW*` call, which is the heap allocation for the closure. The runtime team plans to expand escape analysis to support stack allocation of closures in a future release.

## Inlining improvements

Various inlining improvements have been made in .NET 10.

The JIT can now inline methods that become eligible for devirtualization due to previous inlining. This improvement allows the JIT to uncover more optimization opportunities, such as further inlining and devirtualization.

Some methods that have exception-handling semantics, in particular those with `try-finally` blocks, can also be inlined.

To better take advantage of the JIT's ability to stack-allocate some arrays, the inliner's heuristics have been adjusted to increase the profitability of candidates that might be returning small, fixed-sized arrays.

### Return types

During inlining, the JIT now updates the type of temporary variables that hold return values. If all return sites in a callee yield the same type, this precise type information is used to devirtualize subsequent calls. This enhancement complements the improvements in late devirtualization and array enumeration de-abstraction.

### Profile data

.NET 10 enhances the JIT's inlining policy to take better advantage of profile data. Among numerous heuristics, the JIT's inliner doesn't consider methods over a certain size to avoid bloating the caller method. When the caller has profile data that suggests an inlining candidate is frequently executed, the inliner increases its size tolerance for the candidate.

Suppose the JIT inlines some callee `Callee` without profile data into some caller `Caller` with profile data. This discrepancy can occur if the callee is too small to be worth instrumenting, or if it's inlined too often to have a sufficient call count. If `Callee` has its own inlining candidates, the JIT previously didn't consider them with its default size limit due to `Callee` lacking profile data. Now, the JIT will realize `Caller` has profile data and loosen its size restriction (but, to account for loss of precision, not to the same degree as if `Callee` had profile data).

Similarly, when the JIT decides a call site isn't profitable for inlining, it marks the method with `NoInlining` to save future inlining attempts from considering it. However, many inlining heuristics are sensitive to profile data. For example, the JIT might decide a method is too large to be worth inlining in the absence of profile data. But when the caller is sufficiently hot, the JIT might be willing to relax its size restriction and inline the call. In .NET 10, the JIT no longer flags unprofitable inlinees with `NoInlining` to avoid pessimizing call sites with profile data.

## NativeAOT type preinitializer improvements

NativeAOT's type preinitializer now supports all variants of the `conv.*` and `neg` opcodes. This enhancement allows preinitialization of methods that include casting or negation operations, further optimizing runtime performance.

## Arm64 write-barrier improvements

.NET's garbage collector (GC) is generational, meaning it separates live objects by age to improve collection performance. The GC collects younger generations more often under the assumption that long-lived objects are less likely to be unreferenced (or "dead") at any given time. However, suppose an old object starts referencing a young object; the GC needs to know it can't collect the young object. However, needing to scan older objects to collect a young object defeats the performance gains of a generational GC.

To solve this problem, the JIT inserts write barriers before object reference updates to keep the GC informed. On x64, the runtime can dynamically switch between write-barrier implementations to balance write speeds and collection efficiency, depending on the GC's configuration. In .NET 10, this functionality is also available on Arm64. In particular, the new default write-barrier implementation on Arm64 handles GC regions more precisely, which improves collection performance at a slight cost to write-barrier throughput. Benchmarks show GC pause improvements from 8% to over 20% with the new GC defaults.
