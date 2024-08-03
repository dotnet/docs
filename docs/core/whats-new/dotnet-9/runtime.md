---
title: What's new in .NET 9 runtime
description: Learn about the new .NET features introduced in the .NET 9 runtime.
titleSuffix: ""
ms.date: 07/11/2024
ms.topic: whats-new
---
# What's new in the .NET 9 runtime

This article describes new features and performance improvements in the .NET runtime for .NET 9. It's been updated for .NET 9 Preview 6.

## Attribute model for feature switches with trimming support

Two new attributes make it possible to define [feature switches](https://github.com/dotnet/designs/blob/main/accepted/2020/feature-switch.md) that the .NET libraries (and you) can use to toggle areas of functionality. If a feature isn't supported, the unsupported (and thus unused) features are removed when trimming or compiling with Native AOT, which keeps the app size smaller.

- <xref:System.Diagnostics.CodeAnalysis.FeatureSwitchDefinitionAttribute> is used to treat a feature-switch property as a constant when trimming, and dead code that's guarded by the switch can be removed:

  ```csharp
  if (Feature.IsSupported)
      Feature.Implementation();

  public class Feature
  {
      [FeatureSwitchDefinition("Feature.IsSupported")]
      internal static bool IsSupported => AppContext.TryGetSwitch("Feature.IsSupported", out bool isEnabled) ? isEnabled : true;

      internal static Implementation() => ...;
  }
  ```

  When the app is trimmed with the following feature settings in the project file, `Feature.IsSupported` is treated as `false`, and `Feature.Implementation` code is removed.

  ```xml
  <ItemGroup>
    <RuntimeHostConfigurationOption Include="Feature.IsSupported" Value="false" Trim="true" />
  </ItemGroup>
  ```

- <xref:System.Diagnostics.CodeAnalysis.FeatureGuardAttribute> is used to treat a feature-switch property as a guard for code annotated with <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute>, <xref:System.Diagnostics.CodeAnalysis.RequiresAssemblyFilesAttribute>, or <xref:System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute>. For example:

  ```csharp
  if (Feature.IsSupported)
      Feature.Implementation();

  public class Feature
  {
      [FeatureGuard(typeof(RequiresDynamicCodeAttribute))]
      internal static bool IsSupported => RuntimeFeature.IsDynamicCodeSupported;

      [RequiresDynamicCode("Feature requires dynamic code support.")]
      internal static Implementation() => ...; // Uses dynamic code
  }
  ```

  When built with `<PublishAot>true</PublishAot>`, the call to `Feature.Implementation()` doesn't produce analyzer warning [IL3050](../../deploying/native-aot/warnings/il3050.md), and `Feature.Implementation` code is removed when publishing.

## UnsafeAccessorAttribute supports generic parameters

The <xref:System.Runtime.CompilerServices.UnsafeAccessorAttribute> feature allows unsafe access to type members that are unaccessible to the caller. This feature was designed in .NET 8 but implemented without support for generic parameters. .NET 9 adds support for generic parameters for CoreCLR and native AOT scenarios. The following code shows example usage.

:::code language="csharp" source="../snippets/dotnet-9/csharp/UnsafeAccessor.cs":::

## Performance improvements

The following performance improvements have been made for .NET 9:

- [Loop optimizations](#loop-optimizations)
- [Inlining improvements](#inlining-improvements)
- [PGO improvements: Type checks and casts](#pgo-improvements-type-checks-and-casts)
- [Arm64 vectorization in .NET libraries](#arm64-vectorization-in-net-libraries)
- [Arm64 code generation](#arm64-code-generation)
- [Faster exceptions](#faster-exceptions)
- [Code layout](#code-layout)
- [Reduced address exposure](#reduced-address-exposure)
- [AVX10v1 support](#avx10v1-support)
- [Hardware intrinsic code generation](#hardware-intrinsic-code-generation)
- [Constant folding for floating point and SIMD operations](#constant-folding-for-floating-point-and-simd-operations)

### Loop optimizations

Improving code generation for loops is a priority for .NET 9. The following improvements are now available:

- [Induction variable widening](#induction-variable-widening)
- [Loop counter variable direction](#loop-counter-variable-direction)

#### Induction variable widening

The 64-bit compiler features a new optimization called *induction variable (IV) widening*.

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

#### Loop counter variable direction

The JIT compiler now recognizes when the direction of a loop's counter variable can be flipped without affecting the program's behavior, and does the transformation.

In the idiomatic `for (int i = ...)` pattern, the counter variable typically increases. Consider the following example:

```csharp
for (int i = 0; i < 100; i++)
{
    Foo();
}
```

However, on many architectures, it's more performant to decrement the loop's counter, like so:

``` csharp
for (int i = 100; i > 0; i--)
{
    Foo();
}
```

For the first example, the compiler needs to emit an instruction to increment `i`, followed by an instruction to perform the `i < 100` comparison, followed by a conditional jump to continue the loop if the condition is still `true`&mdash;that's three instructions in total. However, if the counter's direction is flipped, one less instruction is needed. For example, on x64, the compiler can use the `dec` instruction to decrement `i`; when `i` reaches zero, the `dec` instruction sets a CPU flag that can be used as the condition for a jump instruction immediately following the `dec`.

The code size reduction is small, but if the loop runs for a nontrivial number of iterations, the performance improvement can be significant.

### Inlining improvements

One of .NET's goals for the JIT compiler's inliner is to remove as many restrictions that block a method from being inlined as possible. .NET 9 enables inlining of:

- Shared generics that require run-time lookups.

  As an example, consider the following methods:

  ```csharp
  static bool Test<T>() => Callee<T>();
  static bool Callee<T>() => typeof(T) == typeof(int);
  ```

  When `T` is a reference type like `string`, the runtime creates *shared generics*, which are special instantiations of `Test` and `Callee` that are shared by all ref-type `T` types. To make this work, the runtime builds dictionaries that map generic types to internal types. These dictionaries are specialized per generic type (or per generic method), and are accessed at run time to obtain information about `T` and types that depend on `T`. Historically, code compiled just-in-time was only capable of performing these run-time lookups against the root method's dictionary. This meant the JIT compiler couldn't inline `Callee` into `Test`&mdash;there was no way for the inlined code from `Callee` to access the proper dictionary, even though both methods were instantiated over the same type.

  .NET 9 has lifted this restriction by freely enabling run-time type lookups in callees, meaning the JIT compiler can now inline methods like `Callee` into `Test`.

  Suppose we call `Test<string>` in another method. In pseudocode, the inlining looks like this:

  ```csharp
  static bool Test<string>() => typeof(string) == typeof(int);
  ```

  That type check can be computed during compilation, so the final code looks like this:

  ```csharp
  static bool Test<string>() => false;
  ```

  Improvements to the JIT compiler's inliner can have compound effects on other inlining decisions, resulting in significant performance wins. For example, the decision to inline `Callee` might enable the call to `Test<string>` to be inlined as well, and so on. This produced [hundreds](https://github.com/dotnet/runtime/pull/99265#issuecomment-2007077353) of benchmark improvements, with at least 80 benchmarks improving by 10% or more.

- Accesses to *thread-local statics* on Windows x64, Linux x64, and Linux Arm64.

  For `static` class members, exactly one instance of the member exists across all instances of the class, which "share" the member. If the value of a `static` member is unique to each thread, making that value thread-local can improve performance, because it eliminates the need for a concurrency primitive to safely access the `static` member from its containing thread.

  Previously, accesses to thread-local statics in Native AOT-compiled programs required the compiler to emit a call into the runtime to get the base address of the thread-local storage. Now, the compiler can inline these calls, resulting in far fewer instructions to access this data.

### PGO improvements: Type checks and casts

.NET 8 enabled [dynamic profile-guided optimization (PGO)](../../runtime-config/compilation.md#profile-guided-optimization) by default. NET 9 expands the JIT compiler's PGO implementation to profile more code patterns. When tiered compilation is enabled, the JIT compiler already inserts instrumentation into your program to profile its behavior. When it recompiles with optimizations, the compiler leverages the profile it built at run time to make decisions specific to the current run of your program. In .NET 9, the JIT compiler uses PGO data to improve the performance of *type checks*.

Determining the type of an object requires a call into the runtime, which comes with a performance penalty. When the type of an object needs to be checked, the JIT compiler emits this call for the sake of correctness (compilers usually cannot rule out any possibilities, even if they seem improbable). However, if PGO data suggests an object is likely to be a specific type, the JIT compiler now emits a *fast path* that cheaply checks for that type, and falls back on the slow path of calling into the runtime only if necessary.

### Arm64 vectorization in .NET libraries

A new `EncodeToUtf8` implementation takes advantage of the JIT compiler's ability to emit multi-register load/store instructions on Arm64. This behavior allows programs to process larger chunks of data with fewer instructions. .NET apps across various domains should see throughput improvements on Arm64 hardware that supports these features. Some [benchmarks](https://github.com/dotnet/perf-autofiling-issues/issues/27114) cut their execution time by more than half.

### Arm64 code generation

The JIT compiler already has the ability to transform its representation of contiguous loads to use the `ldp` instruction (for loading values) on Arm64. .NET 9 extends this ability to *store* operations.

The `str` instruction stores data from a single register to memory, while the `stp` instruction stores data from a *pair* of registers. Using `stp` instead of `str` means the same task can be accomplished with fewer store operations, which improves execution time. Shaving off one instruction might seem like a small improvement, but if the code runs in a loop for a nontrivial number of iterations, the performance gains can add up quickly.

For example, consider the following snippet:

```csharp
class Body { public double x, y, z, vx, vy, vz, mass; }

static void Advance(double dt, Body[] bodies)
{
    foreach (Body b in bodies)
    {
        b.x += dt * b.vx;
        b.y += dt * b.vy;
        b.z += dt * b.vz;
    }
}
```

The values of `b.x`, `b.y`, and `b.z` are updated in the loop body. At the assembly level, each member could be stored with a `str` instruction; or using `stp`, two of the stores (`b.x` and `b.y`, or `b.y` and `b.z`, because these pairs are contiguous in memory) can be handled with one instruction. To use the `stp` instruction to store to `b.x` and `b.y` simultaneously, the compiler also needs to determine that the computations `b.x + (dt * b.vx)` and `b.y + (dt * b.vy)` are independent of one another and can be performed before storing to `b.x` and `b.y`.

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

### Code layout

Compilers typically reason about a program's control flow using basic *blocks*, where each block is a chunk of code that can only be entered at the first instruction and exited via the last instruction. The order of basic blocks is important. If a block ends with a branch instruction, control flow transfers to another block. One goal of block reordering is to reduce the number of branch instructions in the generated code by maximizing *fall-through* behavior. If each basic block is followed by its most-likely successor, it can "fall into" its successor without needing a jump.

Until recently, the block reordering in the JIT compiler was limited by the flowgraph implementation. In .NET 9, the JIT compiler's block reordering algorithm has been replaced with a simpler, more global approach. The flowgraph data structures have been refactored to:

- Remove some restrictions around block ordering.
- Ingrain execution likelihoods into every control-flow change between blocks.

In addition, profile data is propagated and maintained as the method's flowgraph is transformed.

### Reduced address exposure

In .NET 9, the JIT compiler can better track the usage of local variable addresses and avoid unnecessary *address exposure*.

When the address of a local variable is used, the JIT compiler must take extra precautions when optimizing the method. For example, suppose the compiler is optimizing a method that passes the address of a local variable in a call to another method. Since the callee might use the address to access the local variable, to maintain correctness, the compiler avoids transforming the variable. Addressed-exposed locals can significantly inhibit the compiler's optimization potential.

### AVX10v1 support

New APIs have been added for AVX10, which is a new SIMD instruction set from Intel. You can accelerate your .NET applications on AVX10-enabled hardware with vectorized operations using the new `System.Runtime.Intrinsics.X86.Avx10v1` <!--<xref:System.Runtime.Intrinsics.X86.Avx10v1>--> APIs.

### Hardware intrinsic code generation

Many hardware intrinsic APIs expect users to pass constant values for certain parameters. These constants are encoded directly into the intrinsic's underlying instruction, rather than being loaded into registers or accessed from memory. If a constant isn't provided, the intrinsic is replaced with a call to a fallback implementation that's functionally equivalent, but slower.

Consider the following example:

```csharp
static byte Test1()
{
    Vector128<byte> v = Vector128<byte>.Zero;
    byte size = 1;
    v = Sse2.ShiftRightLogical128BitLane(v, size);
    return Sse41.Extract(v, 0);
}
```

The use of `size` in the call to `Sse2.ShiftRightLogical128BitLane` can be substituted with the constant 1, and under normal circumstances, the JIT compiler is already capable of this substitution optimization. But when determining whether to generate the accelerated or fallback code for `Sse2.ShiftRightLogical128BitLane`, the compiler detects that a variable is being passed instead of a constant and prematurely decides against "intrinsifying" the call. Starting in .NET 9, the compiler recognizes more cases like this and substitutes the variable argument with its constant value, thus generating the accelerated code.

### Constant folding for floating point and SIMD operations

*Constant folding* is an existing optimization in the JIT compiler. *Constant folding* refers to the replacement of expressions that can be computed at compile time with the constants they evaluate to, thus eliminating computations at run time. .NET 9 adds new constant-folding capabilities:

- For floating-point binary operations, where one of the operands is a constant:
  - `x + NaN` is now folded into `NaN`.
  - `x * 1.0` is now folded into `x`.
  - `x + -0` is now folded into `x`.
- For hardware intrinsics. For example, assuming `x` is a `Vector<T>`:
  - `x + Vector<T>.Zero` is now folded into `x`.
  - `x & Vector<T>.Zero` is now folded into `Vector<T>.Zero`.
  - `x & Vector<T>.AllBitsSet` is now folded into `x`.
