---
title: What's new in .NET 9 runtime
description: Learn about the new .NET features introduced in the .NET 9 runtime.
titleSuffix: ""
ms.date: 04/11/2024
ms.topic: overview
---
# What's new in the .NET 9 runtime

This article describes new features in the .NET runtime for .NET 9. It's been updated for .NET 9 Preview 3.

## Performance

.NET 9 includes enhancements to the 64-bit JIT compiler that are aimed at improving app performance. These compiler enhancements include:

- [Better code generation for loops](#loop-optimizations).
- [More method inlining for Native AOT](#inlining-improvements-for-native-aot).
- [Faster type checks](#pgo-improvements-type-checks-and-casts).

[Arm64 vectorization](#arm64-vectorization-in-net-libraries) is another new feature of the runtime.

### Loop optimizations

Improving code generation for loops is a priority for .NET 9, and the 64-bit compiler features a new optimization called *induction variable (IV) widening*.

An IV is a variable whose value changes as the containing loop iterates. In the following `for` loop, `i` is an IV: `for (int i = 0; i < 10; i++)`. If the compiler can analyze how an IV's value evolves over its loop's iterations, it can produce more performant code for related expressions.

Consider the following example that iterates through an array:

```csharp
static int Sum(int[] arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }

    return sum;
}
```

The index variable, `i`, is 4 bytes in size. At the assembly level, 64-bit registers are typically used to hold array indices on x64, and in previous .NET versions, the compiler generated code that zero-extended `i` to 8 bytes for the array access, but continued to treat `i` as a 4-byte integer elsewhere. However, extending `i` to 8 bytes requires an additional instruction on x64. With IV widening, the 64-bit JIT compiler now widens `i` to 8 bytes throughout the loop, omitting the zero extension. Looping over arrays is very common, and the benefits of this instruction removal quickly add up.

### Inlining improvements for Native AOT

One of .NET's goals for the 64-bit JIT compiler's inliner is to remove as many restrictions that block a method from being inlined as possible. .NET 9 enables inlining of:

- Accesses to *thread-local statics* on Windows x64, Linux x64, and Linux Arm64.

  For `static` class members, exactly one instance of the member exists across all instances of the class, which "share" the member. If the value of a `static` member is unique to each thread, making that value thread-local can improve performance, because it eliminates the need for a concurrency primitive to safely access the `static` member from its containing thread.

  Previously, accesses to thread-local statics in Native AOT-compiled programs required the 64-bit JIT compiler to emit a call into the runtime to get the base address of the thread-local storage. Now, the compiler can inline these calls, resulting in far fewer instructions to access this data.

- Shared generics that require run-time lookups.

  As an example, consider the following methods:

  ```csharp
  static bool Test<T>() => Callee<T>();
  static bool Callee<T>() => typeof(T) == typeof(int);
  ```

  When `T` is a reference type like `string`, the runtime creates *shared generics*, which are special instantiations of `Test` and `Callee` that are shared by all ref-type `T` types. To make this work, the runtime builds dictionaries that map generic types to internal types. These dictionaries are specialized per generic type (or per generic method), and are accessed at run time to obtain information about `T` and types that depend on `T`. Historically, code compiled just-in-time was only capable of performing these run-time lookups against the root method's dictionary. This meant the 64-bit JIT compiler couldn't inline `Callee` into `Test`&mdash;there was no way for the inlined code from `Callee` to access the proper dictionary, even though both methods were instantiated over the same type.

  .NET 9 has lifted this restriction by freely enabling run-time type lookups in callees, meaning the 64-bit JIT compiler can now inline methods like `Callee` into `Test`.

  Suppose we call `Test<string>` in another method. In pseudocode, the inlining looks like this:

  ```csharp
  static bool Test<string>() => typeof(string) == typeof(int);
  ```

  That type check can be computed during compilation, so the final code looks like this:

  ```csharp
  static bool Test<string>() => false;
  ```

  Improvements to the 64-bit JIT compiler's inliner can have compound effects on other inlining decisions, resulting in significant performance wins. For example, the decision to inline `Callee` might enable the call to `Test<string>` to be inlined as well, and so on. Out of [hundreds](https://github.com/dotnet/runtime/pull/99265#issuecomment-2007077353) of benchmark improvements, [at least 80](https://gist.github.com/EgorBo/b6424f7118ff176682f63875d89fb52e) improved by 10% or more.

### PGO improvements: Type checks and casts

.NET 8 enabled [dynamic profile-guided optimization (PGO)](../../runtime-config/compilation.md#profile-guided-optimization) by default. NET 9 expands the 64-bit JIT compiler's PGO implementation to profile more code patterns. When tiered compilation is enabled, the 64-bit JIT compiler already inserts instrumentation into your program to profile its behavior. When it recompiles with optimizations, the compiler leverages the profile it built at run time to make decisions specific to the current run of your program. In .NET 9, the 64-bit JIT compiler uses PGO data to improve the performance of *type checks*.

Determining the type of an object requires a call into the runtime, which comes with a performance penalty. When the type of an object needs to be checked, the 64-bit JIT compiler emits this call for the sake of correctness (compilers usually cannot rule out any possibilities, even if they seem improbable). However, if PGO data suggests an object is likely to be a specific type, the 64-bit JIT compiler now emits a *fast path* that cheaply checks for that type, and falls back on the slow path of calling into the runtime only if necessary.

### Arm64 vectorization in .NET libraries

A new `EncodeToUtf8` implementation takes advantage of the 64-bit JIT compiler's ability to emit multi-register load/store instructions on Arm64. This behavior allows programs to process larger chunks of data with fewer instructions. .NET apps across various domains should see throughput improvements on Arm64 hardware that supports these features. Some [benchmarks](https://github.com/dotnet/perf-autofiling-issues/issues/27114) cut their execution time by more than half.

### Faster exceptions

The CoreCLR runtime has adopted a new exception handling approach that improves the performance of exception handling. The new implementation is based on the NativeAOT runtime's exception-handling model. The change removes support for Windows structured exception handling (SEH) and its emulation on Unix. The new approach is supported in all environment except for Windows x86 (32-bit).

The new exception handling implementation is 2-4 times faster, per some exception handling micro-benchmarks. The following perf improvements were measured in the perf lab:

- Windows x64: <https://github.com/dotnet/perf-autofiling-issues/issues/32280>
- Windows Arm64: <https://github.com/dotnet/perf-autofiling-issues/issues/32016>
- Linux x64: <https://github.com/dotnet/perf-autofiling-issues/issues/31367>
- Linux Arm64: <https://github.com/dotnet/perf-autofiling-issues/issues/31631>

The new implementation is enabled by default. However, should you need to switch back to the legacy exception handling behavior, you can do that in either of the following ways:

- Set `System.Runtime.LegacyExceptionHandling` to `true` in the [`runtimeconfig.json` file](../../runtime-config/index.md#runtimeconfigjson).
- Set the `DOTNET_LegacyExceptionHandling` environment variable to `1`.
