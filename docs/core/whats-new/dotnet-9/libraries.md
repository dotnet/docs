---
title: What's new in .NET libraries for .NET 9
description: Learn about the new .NET libraries features introduced in .NET 9.
titleSuffix: ""
ms.date: 06/11/2024
ms.topic: whats-new
---
# What's new in .NET libraries for .NET 9

This article describes new features in the .NET libraries for .NET 9. It's been updated for .NET 9 Preview 5.

## Collections

The <xref:System.Collections.Generic.PriorityQueue%602> collection type in the <xref:System.Collections.Generic> namespace includes a new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})> method that you can use to update the priority of an item in the queue.

### PriorityQueue.Remove() method

.NET 6 introduced the <xref:System.Collections.Generic.PriorityQueue%602> collection, which provides a simple and fast array-heap implementation. One issue with array heaps in general is that they [don't support priority updates](https://github.com/dotnet/runtime/issues/44871), which makes them prohibitive for use in algorithms such as variations of [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue).

While it's not possible to implement efficient $O(\log n)$ priority updates in the existing collection, the new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})?displayProperty=nameWithType> method makes it possible to emulate priority updates (albeit at $O(n)$ time):

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="UpdatePriority":::

This method unblocks users who want to implement graph algorithms in contexts where asymptotic performance isn't a blocker. (Such contexts include education and prototyping.) For example, here's a [toy implementation of Dijkstra's algorithm](https://github.com/dotnet/runtime/blob/16cb41496d595e2568574cfe11c763d5e05136c9/src/libraries/System.Collections/tests/Generic/PriorityQueue/PriorityQueue.Tests.Dijkstra.cs#L46-L76) that uses the new API.

## Component model

### `TypeDescriptor` trimming support

<xref:System.ComponentModel> includes new opt-in trimmer-compatible APIs for describing components. Any application, especially self-contained trimmed applications, can use these new APIs to help support trimming scenarios.

The primary API is the `public static void RegisterType<T>()` <!--<xref:System.ComponentModel.TypeDescriptor.RegisterType%01?displayProperty=nameWithType>--> method on the `TypeDescriptor` class. This method has the <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> attribute so that the trimmer preserves members for that type. You should call this method once per type, and typically early on.

The secondary APIs have a `FromRegisteredType` suffix, such as `TypeDescriptor.GetPropertiesFromRegisteredType(Type componentType)` <!--<xref:System.ComponentModel.TypeDescriptor.GetPropertiesFromRegisteredType(System.Type)?displayProperty=nameWithType>-->. Unlike their counterparts that don't have the `FromRegisteredType` suffix, these APIs don't have `[RequiresUnreferencedCode]` or `[DynamicallyAccessedMembers]` trimmer attributes. The lack of trimmer attributes helps consumers by no longer having to either:

- Suppress trimming warnings, which can be risky.
- Propagate a strongly typed `Type` parameter to other methods, which can be cumbersome or infeasible.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TypeDescriptor.cs" id="TypeDescriptor":::

For more information, see the [API proposal](https://github.com/dotnet/runtime/issues/101202).

## Cryptography

For cryptography, .NET 9 adds a new one-shot hash method on the <xref:System.Security.Cryptography.CryptographicOperations> type. It also adds new classes that use the KMAC algorithm.

### CryptographicOperations.HashData() method

.NET includes several static ["one-shot"](../../../standard/security/cryptography-model.md#one-shot-apis) implementations of hash functions and related functions. These APIs include <xref:System.Security.Cryptography.SHA256.HashData%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.HMACSHA256.HashData%2A?displayProperty=nameWithType>. One-shot APIs are preferable to use because they can provide the best possible performance and reduce or eliminate allocations.

If a developer wants to provide an API that supports hashing where the caller defines which hash algorithm to use, it's typically done by accepting a <xref:System.Security.Cryptography.HashAlgorithmName> argument. However, using that pattern with one-shot APIs would require switching over every possible <xref:System.Security.Cryptography.HashAlgorithmName> and then using the appropriate method. To solve that problem, .NET 9 introduces the <xref:System.Security.Cryptography.CryptographicOperations.HashData%2A?displayProperty=nameWithType> API. This API lets you produce a hash or HMAC over an input as a one-shot where the algorithm used is determined by a <xref:System.Security.Cryptography.HashAlgorithmName>.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Cryptography.cs" id="HashData":::

### KMAC algorithm

.NET 9 provides the KMAC algorithm as specified by [NIST SP-800-185](https://csrc.nist.gov/pubs/sp/800/185/final). KECCAK Message Authentication Code (KMAC) is a pseudorandom function and keyed hash function based on KECCAK.

The following new classes use the KMAC algorithm. Use instances to accumulate data to produce a MAC, or use the static `HashData` method for a [one-shot](../../../standard/security/cryptography-model.md#one-shot-apis) over a single input.

- <xref:System.Security.Cryptography.Kmac128>
- <xref:System.Security.Cryptography.Kmac256>
- <xref:System.Security.Cryptography.KmacXof128>
- <xref:System.Security.Cryptography.KmacXof256>

KMAC is available on Linux with OpenSSL 3.0 or later, and on Windows 11 Build 26016 or later. You can use the static `IsSupported` property to determine if the platform supports the desired algorithm.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Cryptography.cs" id="Kmac":::

## Date and time

### New TimeSpan.From\* overloads

The <xref:System.TimeSpan> class offers several `From*` methods that let you create a `TimeSpan` object using a `double`. However, since `double` is a binary-based floating-point format, [inherent imprecision can lead to errors](https://github.com/dotnet/runtime/issues/93890). For instance, `TimeSpan.FromSeconds(101.832)` might not precisely represent `101 seconds, 832 milliseconds`, but rather approximately `101 seconds, 831.9999999999936335370875895023345947265625 milliseconds`. This discrepancy has caused frequent confusion, and it's also not the most efficient way to represent such data. To address this, .NET 9 adds new overloads that let you create `TimeSpan` objects from integers. There are new overloads from `FromDays`, `FromHours`, `FromMinutes`, `FromSeconds`, `FromMilliseconds`, and `FromMicroseconds`.

The following code shows an example of calling the `double` and one of the new integer overloads.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TimeSpan.cs" id="TimeSpan.From":::

## Dependency injection

### `ActivatorUtilities.CreateInstance` constructor

The constructor resolution for <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> has changed in .NET 9. Previously, a constructor that was explicitly marked using the <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructorAttribute> attribute might not be called, depending on the ordering of constructors and the number of constructor parameters. The logic has changed in .NET 9 such that a constructor that has the attribute is always called.

## Diagnostics

### New Activity.AddLink method

Previously, you could only link a tracing <xref:System.Diagnostics.Activity> to other tracing contexts when you [created the `Activity`](xref:System.Diagnostics.ActivitySource.CreateActivity(System.String,System.Diagnostics.ActivityKind,System.Diagnostics.ActivityContext,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}},System.Collections.Generic.IEnumerable{System.Diagnostics.ActivityLink},System.Diagnostics.ActivityIdFormat)?displayProperty=nameWithType). New in .NET 9, the `Activity.AddLink(System.Diagnostics.ActivityLink)` <!--<xref:System.Diagnostics.Activity.AddLink(System.Diagnostics.ActivityLink)>--> API lets you link an `Activity` object to other tracing contexts after it's created. This change aligns with the [OpenTelemetry specifications](https://github.com/open-telemetry/opentelemetry-specification/blob/6360b49d20ae451b28f7ba0be168ed9a799ac9e1/specification/trace/api.md?plain=1#L804) as well.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Diagnostics.cs" id="AddLink":::

## LINQ

New methods <xref:System.Linq.Enumerable.CountBy%2A> and <xref:System.Linq.Enumerable.AggregateBy%2A> have been introduced. These methods make it possible to aggregate state by key without needing to allocate intermediate groupings via <xref:System.Linq.Enumerable.GroupBy%2A>.

<xref:System.Linq.Enumerable.CountBy%2A> lets you quickly calculate the frequency of each key. The following example finds the word that occurs most frequently in a text string.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="CountBy":::

<xref:System.Linq.Enumerable.AggregateBy%2A> lets you implement more general-purpose workflows. The following example shows how you can calculate scores that are associated with a given key.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="AggregateBy":::

<xref:System.Linq.Enumerable.Index%60%601(System.Collections.Generic.IEnumerable{%60%600})> makes it possible to quickly extract the implicit index of an enumerable. You can now write code such as the following snippet to automatically index items in a collection.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="NewIndex":::

## Miscellaneous

In this section, find information about:

- [`params ReadOnlySpan<T>` overloads](#params-readonlyspant-overloads)
- [`SearchValues` expansion](#searchvalues-expansion)

### `params ReadOnlySpan<T>` overloads

C# has always supported marking array parameters as [`params`](../../../csharp/language-reference/keywords/method-parameters.md#params-modifier). This keyword enables a simplified calling syntax. For example, the <xref:System.String.Join(System.String,System.String[])?displayProperty=nameWithType> method's second parameter is marked with `params`. You can call this overload with an array or by passing the values individually:

```csharp
string result = string.Join(", ", new string[3] { "a", "b", "c" });
string result = string.Join(", ", "a", "b", "c");
```

Prior to .NET 9, when you pass the values individually, the C# compiler emits code identical to the first call by producing an implicit array around the three arguments.

Starting in C# 13, you can use `params` with any argument that can be constructed via a collection expression, including spans (<xref:System.Span%601> and <xref:System.ReadOnlySpan%601>). That's beneficial for a variety of reasons, including performance. The C# compiler can store the arguments on the stack, wrap a span around them, and pass that off to the method, which avoids the implicit array allocation that would have otherwise resulted.

.NET 9 now includes over 60 methods with a `params ReadOnlySpan<T>` parameter. Some are brand new overloads, and some are existing methods that already took a `ReadOnlySpan<T>` but now have that parameter marked with `params`. The net effect is if you upgrade to .NET 9 and recompile your code, you'll see performance improvements without making any code changes. That's because the compiler prefers to bind to span-based overloads than to the array-based overloads.

For example, `String.Join` now includes the following overload <!--<xref:System.String.Join(System.String,System.ReadOnlySpan`1)?displayProperty=nameWithType>-->, which implements the new pattern:

```csharp
public static string Join(string? separator, params ReadOnlySpan<string?> value)
```

Now, a call like `string.Join(", ", "a", "b", "c")` is made without allocating an array to pass in the `"a"`, `"b"`, and `"c"` arguments.

### `SearchValues` expansion

.NET 8 introduced the <xref:System.Buffers.SearchValues%601> type, which provides an optimized solution for searching for specific sets of characters or bytes within spans. In .NET 9, `SearchValues` has been extended to support searching for substrings within a larger string.

The following example searches for multiple animal names within a string value, and returns an index to the first one found.

:::code language="csharp" source="../snippets/dotnet-9/csharp/SearchValues.cs" id="SV":::

This new capability has an optimized implementation that takes advantage of the SIMD support in the underlying platform. It also enables higher-level types to be optimized. For example, <xref:System.Text.RegularExpressions.Regex> now utilizes this functionality as part of its implementation.

## Reflection

### Persisted assemblies

In .NET Core versions and .NET 5-8, support for building an assembly and emitting reflection metadata for dynamically created types was limited to a runnable <xref:System.Reflection.Emit.AssemblyBuilder>. The lack of support for *saving* an assembly was often a blocker for customers migrating from .NET Framework to .NET. .NET 9 adds a new type, <xref:System.Reflection.Emit.PersistedAssemblyBuilder>, that you can use to save an emitted assembly.

To create a `PersistedAssemblyBuilder` instance, call its constructor and pass the assembly name, the core assembly, `System.Private.CoreLib`, to reference base runtime types, and optional custom attributes. After you emit all members to the assembly, call the <xref:System.Reflection.Emit.PersistedAssemblyBuilder.Save(System.String)?displayProperty=nameWithType> method to create an assembly with default settings. If you want to set the entry point or other options, you can call <xref:System.Reflection.Emit.PersistedAssemblyBuilder.GenerateMetadata%2A?displayProperty=nameWithType> and use the metadata it returns to save the assembly. The following code shows an example of creating a persisted assembly and setting the entry point.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Reflection.cs" id="SaveAssembly":::

The new <xref:System.Reflection.Emit.PersistedAssemblyBuilder> class includes PDB support. You can emit symbol info and use it to debug a generated assembly. The API has a similar shape to the .NET Framework implementation. For more information, see [Emit symbols and generate PDB](../../../fundamentals/runtime-libraries/system-reflection-emit-persistedassemblybuilder.md#emit-symbols-and-generate-pdb).

### Type-name parsing

`TypeName` <!--<xref:System.Reflection.Metadata.TypeName>--> is a parser for ECMA-335 type names that provides much the same functionality as <xref:System.Type?displayProperty=fullName> but is decoupled from the runtime environment. Components like serializers and compilers need to parse and process type names. For example, the Native AOT compiler has switched to using `TypeName` <!--<xref:System.Reflection.Metadata.TypeName>-->.

The new `TypeName` class provides:

- Static `Parse` and `TryParse` methods for parsing input represented as `ReadOnlySpan<char>`. Both methods accept an instance of `TypeNameParseOptions` class (an option bag) that lets you customize the parsing.
- `Name`, `FullName`, and `AssemblyQualifiedName` properties that work exactly like their counterparts in <xref:System.Type?displayProperty=fullName>.
- Multiple properties and methods that provide additional information about the name itself:

  - `IsArray`, `IsSZArray` (`SZ` stands for single-dimension, zero-indexed array), `IsVariableBoundArrayType`, and `GetArrayRank` for working with arrays.
  - `IsConstructedGenericType`, `GetGenericTypeDefinition`, and `GetGenericArguments` for working with generic type names.
  - `IsByRef` and `IsPointer` for working with pointers and managed references.
  - `GetElementType()` for working with pointers, references, and arrays.
  - `IsNested` and `DeclaringType` for working with nested types.
  - `AssemblyName`, which exposes the assembly name information via the new `AssemblyNameInfo` <!--<xref:System.Reflection.Metadata.AssemblyInfoName>--> class. In contrast to `AssemblyName`, the new type is *immutable*, and parsing culture names doesn't create instances of `CultureInfo`.

Both `TypeName` and `AssemblyNameInfo` types are immutable and don't provide a way to check for equality (they don't implement `IEquatable`). Comparing assembly names is simple, but different scenarios need to compare only a subset of exposed information (`Name`, `Version`, `CultureName`, and `PublicKeyOrToken`).

The following code snippet shows some example usage.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TypeName.cs":::

The new APIs are available from the [`System.Reflection.Metadata`](https://www.nuget.org/packages/System.Reflection.Metadata/) NuGet package, which can be used with down-level .NET versions.

## Serialization

In <xref:System.Text.Json>, .NET 9 has new options for serializing JSON and a new singleton that makes it easier to serialize using web defaults.

### Indentation options

<xref:System.Text.Json.JsonSerializerOptions> includes new properties that let you customize the indentation character and indentation size of written JSON.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Indentation":::

### Default web options

If you want to serialize with the [default options that ASP.NET Core uses](../../../standard/serialization/system-text-json/configure-options.md#web-defaults-for-jsonserializeroptions) for web apps, use the new <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType> singleton.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Web":::

## Tensors for AI

Tensors are the cornerstone data structure of artificial intelligence (AI). They can often be thought of as multidimensional arrays.

Tensors are used to:

- Represent and encode data such as text sequences (tokens), images, video, and audio.
- Efficiently manipulate higher-dimensional data.
- Efficiently apply computations on higher-dimensional data.
- Store weight information and intermediate computations (in neural networks).

To use the .NET tensor APIs, install the [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors/) NuGet package.

### New Tensor\<T> type

The new `Tensor<T>` <!--xref:System.Numerics.Tensors.Tensor`1--> type expands the AI capabilities of the .NET libraries and runtime. This type:

- Provides efficient interop with AI libraries like ML.NET, TorchSharp, and ONNX Runtime using zero copies where possible.
- Builds on top of <xref:System.Numerics.TensorPrimitives> for efficient math operations.
- Enables easy and efficient data manipulation by providing indexing and slicing operations.
- Is not a replacement for existing AI and machine learning libraries. Instead, it's intended to provide a common set of APIs to reduce code duplication and dependencies, and to achieve better performance by using the latest runtime features.

The following codes shows some of the APIs included with the new `Tensor<T>` type.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Tensors.cs" id="Tensor":::

### TensorPrimitives

The `System.Numerics.Tensors` library includes the <xref:System.Numerics.TensorPrimitives> class, which provides static methods for performing numerical operations on spans of values. In .NET 9, the scope of methods exposed by <xref:System.Numerics.TensorPrimitives> has been significantly expanded, growing from 40 (in .NET 8) to almost 200 overloads. The surface area encompasses familiar numerical operations from types like <xref:System.Math> and <xref:System.MathF>. It also includes the generic math interfaces like <xref:System.Numerics.INumber%601>, except instead of processing an individual value, they process a span of values. Many operations have also been accelerated via SIMD-optimized implementations for .NET 9.

<xref:System.Numerics.TensorPrimitives> now exposes generic overloads for any type `T` that implements a certain interface. (The .NET 8 version only included overloads for manipulating spans of `float` values.) For example, the new <xref:System.Numerics.Tensors.TensorPrimitives.CosineSimilarity%60%601(System.ReadOnlySpan{%60%600},System.ReadOnlySpan{%60%600})> overload performs cosine similarity on two vectors of `float`, `double`, or `Half` values, or values of any other type that implements <xref:System.Numerics.IRootFunctions%601>.

Compare the precision of the cosine similarity operation on two vectors of type `float` versus `double`:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Tensors.cs" id="CosineSimilarity":::

## Threading

The threading APIs include improvements for iterating through tasks, and for prioritized channels, which can order their elements instead of being first-in-first-out (FIFO).

### `Task.WhenEach`

A variety of helpful new APIs have been added for working with <xref:System.Threading.Tasks.Task%601> objects. The new `Task.WhenEach` <!--<xref:System.Threading.Tasks.Task.WhenEach?displayProperty=nameWithType>--> method lets you iterate through tasks as they complete using an `await foreach` statement. You no longer need to do things like repeatedly call <xref:System.Threading.Tasks.Task.WaitAny%2A?displayProperty=nameWithType> on a set of tasks to pick off the next one that completes.

The following code makes multiple `HttpClient` calls and operates on their results as they complete.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Task.cs" id="TaskWhenEach":::

### Prioritized unbounded channel

The <xref:System.Threading.Channels> namespace lets you create first-in-first-out (FIFO) channels using the <xref:System.Threading.Channels.Channel.CreateBounded%2A> and <xref:System.Threading.Channels.Channel.CreateUnbounded%2A> methods. With FIFO channels, elements are read from the channel in the order they were written to it. In .NET 9, the new `CreateUnboundedPrioritized<T>` <!--<xref:System.Threading.Channels.Channel.CreateUnboundedPrioritized%2A>--> method has been added, which orders the elements such that the next element read from the channel is the one deemed to be most important, according to either <xref:System.Collections.Generic.Comparer%601.Default?displayProperty=nameWithType> or a custom <xref:System.Collections.Generic.IComparer%601>.

The following example uses the new method to create a channel that outputs the numbers 1 through 5 in order, even though they're written to the channel in a different order.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Channels.cs" id="Channel":::
