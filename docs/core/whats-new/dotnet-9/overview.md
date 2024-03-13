---
title: What's new in .NET 9
description: Learn about the new .NET features introduced in .NET 9.
titleSuffix: ""
ms.date: 03/11/2024
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 9

Learn about the new features in .NET 9 and find links to further documentation.

.NET 9, the successor to [.NET 8](../dotnet-8/overview.md), has a special focus on cloud-native apps and performance. It will be [supported for 18 months](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a standard-term support (STS) release. You can [download .NET 9 here](https://dotnet.microsoft.com/download/dotnet/9.0).

New for .NET 9, the engineering team posts .NET 9 preview updates on [GitHub Discussions](https://github.com/dotnet/core/discussions). That's a great place to ask questions and provide feedback about the release.

This article has been updated for .NET 9 Preview 2. The following sections describe the updates to the core .NET libraries in .NET 9.

## .NET runtime

- [Serialization](#serialization)
- [LINQ](#linq)
- [Collections](#collections)
- [Cryptography](#cryptography)
- [Reflection](#reflection)
- [Performance](#performance)

### Serialization

In <xref:System.Text.Json>, .NET 9 has new options for serializing JSON and a new singleton that makes it easier to serialize using web defaults.

#### Indentation options

<xref:System.Text.Json.JsonSerializerOptions> includes new properties that let you customize the indentation character and indentation size of written JSON.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Indentation":::

#### Default web options

If you want to serialize with the [default options that ASP.NET Core uses](../../../standard/serialization/system-text-json/configure-options.md#web-defaults-for-jsonserializeroptions) for web apps, use the new <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType> singleton.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Web":::

### LINQ

New methods <xref:System.Linq.Enumerable.CountBy%2A> and <xref:System.Linq.Enumerable.AggregateBy%2A> have been introduced. These methods make it possible to aggregate state by key without needing to allocate intermediate groupings via <xref:System.Linq.Enumerable.GroupBy%2A>.

<xref:System.Linq.Enumerable.CountBy%2A> lets you quickly calculate the frequency of each key. The following example finds the word that occurs most frequently in a text string.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="CountBy":::

<xref:System.Linq.Enumerable.AggregateBy%2A> lets you implement more general-purpose workflows. The following example shows how you can calculate scores that are associated with a given key.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="AggregateBy":::

<xref:System.Linq.Enumerable.Index%60%601(System.Collections.Generic.IEnumerable{%60%600})> makes it possible to quickly extract the implicit index of an enumerable. You can now write code such as the following snippet to automatically index items in a collection.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="NewIndex":::

### Collections

The <xref:System.Collections.Generic.PriorityQueue%602> collection type in the <xref:System.Collections.Generic> namespace includes a new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})> method that you can use the update the priority of an item in the queue.

#### PriorityQueue.Remove() method

.NET 6 introduced the <xref:System.Collections.Generic.PriorityQueue%602> collection, which provides a simple and fast array-heap implementation. One issue with array heaps in general is that they [don't support priority updates](https://github.com/dotnet/runtime/issues/44871), which makes them prohibitive for use in algorithms such as variations of [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue).

While it's not possible to implement efficient $O(\log n)$ priority updates in the existing collection, the new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})?displayProperty=nameWithType> method makes it possible to emulate priority updates (albeit at $O(n)$ time):

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="UpdatePriority":::

This method unblocks users who want to implement graph algorithms in contexts where asymptotic performance isn't a blocker. (Such contexts include education and prototyping.) For example, here's a [toy implementation of Dijkstra's algorithm](https://github.com/dotnet/runtime/blob/16cb41496d595e2568574cfe11c763d5e05136c9/src/libraries/System.Collections/tests/Generic/PriorityQueue/PriorityQueue.Tests.Dijkstra.cs#L46-L76) that uses the new API.

### Cryptography

For cryptography, .NET 9 adds a new one-shot hash method on the <xref:System.Security.Cryptography.CryptographicOperations> type. It also adds new classes that use the KMAC algorithm.

#### CryptographicOperations.HashData() method

.NET includes several static ["one-shot"](../../../standard/security/cryptography-model.md#one-shot-apis) implementations of hash functions and related functions. These APIs include <xref:System.Security.Cryptography.SHA256.HashData%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.HMACSHA256.HashData%2A?displayProperty=nameWithType>. One-shot APIs are preferable to use because they can provide the best possible performance and reduce or eliminate allocations.

If a developer wants to provide an API that supports hashing where the caller defines which hash algorithm to use, it's typically done by accepting a <xref:System.Security.Cryptography.HashAlgorithmName> argument. However, using that pattern with one-shot APIs would require switching over every possible <xref:System.Security.Cryptography.HashAlgorithmName> and then using the appropriate method. To solve that problem, .NET 9 introduces the <xref:System.Security.Cryptography.CryptographicOperations.HashData%2A?displayProperty=nameWithType> API. This API lets you produce a hash or HMAC over an input as a one-shot where the algorithm used is determined by a <xref:System.Security.Cryptography.HashAlgorithmName>.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Cryptography.cs" id="HashData":::

#### KMAC algorithm

.NET 9 provides the KMAC algorithm as specified by [NIST SP-800-185](https://csrc.nist.gov/pubs/sp/800/185/final). KECCAK Message Authentication Code (KMAC) is a pseudorandom function and keyed hash function based on KECCAK.

The following new classes use the KMAC algorithm. Use instances to accumulate data to produce a MAC, or use the static `HashData` method for a [one-shot](../../../standard/security/cryptography-model.md#one-shot-apis) over a single input.

- <xref:System.Security.Cryptography.Kmac128>
- <xref:System.Security.Cryptography.Kmac256>
- <xref:System.Security.Cryptography.KmacXof128>
- <xref:System.Security.Cryptography.KmacXof256>

KMAC is available on Linux with OpenSSL 3.0 or later, and on Windows 11 Build 26016 or later. You can use the static `IsSupported` property to determine if the platform supports the desired algorithm.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Cryptography.cs" id="Kmac":::

### Reflection

In .NET Core versions and .NET 5-8, support for building an assembly and emitting reflection metadata for dynamically created types was limited to a runnable <xref:System.Reflection.Emit.AssemblyBuilder>. The lack of support for *saving* an assembly was often a blocker for customers migrating from .NET Framework to .NET. .NET 9 adds public APIs to <xref:System.Reflection.Emit.AssemblyBuilder> to save an emitted assembly.

The new, persisted <xref:System.Reflection.Emit.AssemblyBuilder> implementation is runtime and platform independent. To create a persisted `AssemblyBuilder` instance, use the new <xref:System.Reflection.Emit.AssemblyBuilder.DefinePersistedAssembly%2A?displayProperty=nameWithType> API. The existing <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> API accepts the assembly name and optional custom attributes. To use the new API, pass the core assembly, `System.Private.CoreLib`, which is used for referencing base runtime types. There's no option for <xref:System.Reflection.Emit.AssemblyBuilderAccess>. And for now, the persisted `AssemblyBuilder` implementation only supports saving, not running. After you create an instance of the persisted `AssemblyBuilder`, the subsequent steps for defining a module, type, method, or enum, writing IL, and all other usages remain unchanged. That means you can use existing <xref:System.Reflection.Emit> code as-is for saving the assembly. The following code shows an example.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Reflection.cs" id="SaveAssembly":::

### Performance

.NET 9 includes enhancements to the 64-bit JIT compiler that are aimed at improving app performance. These compiler enhancements include:

- [Better code generation for loops](#loop-optimizations).
- [More method inlining for Native AOT](#inlining-improvements-for-native-aot).
- [Faster type checks](#pgo-improvements-type-checks-and-casts).

[Arm64 vectorization](#arm64-vectorization-in-net-libraries) is another new feature of the runtime.

#### Loop optimizations

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

#### Inlining improvements for Native AOT

One of .NET's goals for the 64-bit JIT compiler's inliner is to remove as many restrictions that block a method from being inlined as possible. .NET 9 enables inlining of accesses to *thread-local statics* on Windows x64, Linux x64, and Linux Arm64.

For `static` class members, exactly one instance of the member exists across all instances of the class, which "share" the member. If the value of a `static` member is unique to each thread, making that value thread-local can improve performance, because it eliminates the need for a concurrency primitive to safely access the `static` member from its containing thread.

Previously, accesses to thread-local statics in Native AOT-compiled programs required the 64-bit JIT compiler to emit a call into the runtime to get the base address of the thread-local storage. Now, the compiler can inline these calls, resulting in far fewer instructions to access this data.

#### PGO improvements: Type checks and casts

.NET 8 enabled [dynamic profile-guided optimization (PGO)](../../runtime-config/compilation.md#profile-guided-optimization) by default. NET 9 expands the 64-bit JIT compiler's PGO implementation to profile more code patterns. When tiered compilation is enabled, the 64-bit JIT compiler already inserts instrumentation into your program to profile its behavior. When it recompiles with optimizations, the compiler leverages the profile it built at run time to make decisions specific to the current run of your program. In .NET 9, the 64-bit JIT compiler uses PGO data to improve the performance of *type checks*.

Determining the type of an object requires a call into the runtime, which comes with a performance penalty. When the type of an object needs to be checked, the 64-bit JIT compiler emits this call for the sake of correctness (compilers usually cannot rule out any possibilities, even if they seem improbable). However, if PGO data suggests an object is likely to be a specific type, the 64-bit JIT compiler now emits a *fast path* that cheaply checks for that type, and falls back on the slow path of calling into the runtime only if necessary.

#### Arm64 vectorization in .NET libraries

A new `EncodeToUtf8` implementation takes advantage of the 64-bit JIT compiler's ability to emit multi-register load/store instructions on Arm64. This behavior allows programs to process larger chunks of data with fewer instructions. .NET apps across various domains should see throughput improvements on Arm64 hardware that supports these features. Some [benchmarks](https://github.com/dotnet/perf-autofiling-issues/issues/27114) cut their execution time by more than half.

## .NET SDK

- [Unit testing](#unit-testing)
- [.NET tool roll-forward](#net-tool-roll-forward)

### Unit testing

This section describes the updates to unit testing in .NET 9: running tests in parallel, and terminal logger test output.

#### Run tests in parallel

In .NET 9, `dotnet test` is more fully integrated with MSBuild. Because MSBuild supports [building in parallel](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild), you can run tests for the same project across different target frameworks in parallel. By default, MSBuild limits the number of parallel processes to the number of processors on the computer. You can also set your own limit using the [-maxcpucount](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild#-maxcpucount-switch) switch. If you want to opt out of the parallelism, set the `TestTfmsInParallel` MSBuild property to `false`.

#### Terminal logger test display

Test result reporting for [`dotnet test`](../../tools/dotnet-test.md) is now supported directly in the MSBuild terminal logger. You get more fully featured test reporting both *while* tests are running (displays the running test name) and *after* tests are completed (any test errors are rendered in a better way).

For more information about the terminal logger, see [dotnet build options](../../tools/dotnet-build.md#options).

### .NET tool roll-forward

[.NET tools](../../tools/global-tools.md) are framework-dependent apps that you can install globally or locally, then run using the .NET SDK and installed .NET runtimes. These tools, like all .NET apps, target a specific major version of .NET. By default, apps don't run on *newer* versions of .NET. Tool authors have been able to opt in to running their tools on newer versions of the .NET runtime by setting the `RollForward` MSBuild property. However, not all tools do so.

A new option for [`dotnet tool install`](../../tools/dotnet-tool-install.md) lets *users* decide how .NET tools should be run. When you install a tool via `dotnet tool install`, or when you run tool via [`dotnet tool run <toolname>`](../../tools/dotnet-tool-run.md), you can specify a new flag called `--allow-roll-forward`. This option configures the tool with roll-forward mode `Major`. This mode allows the tool to run on a newer major version of .NET if the matching .NET version is not available. This feature helps early adopters use .NET tools without tool authors having to change any code.

## See also

- [Our vision for .NET 9](https://devblogs.microsoft.com/dotnet/our-vision-for-dotnet-9/) blog post
