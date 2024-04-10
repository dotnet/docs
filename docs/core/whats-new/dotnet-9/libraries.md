---
title: What's new in .NET libraries for .NET 9
description: Learn about the new .NET libraries features introduced in .NET 9.
titleSuffix: ""
ms.date: 04/11/2024
ms.topic: overview
---
# What's new in .NET libraries for .NET 9

This article describes new features in the .NET libraries for .NET 9. It's been updated for .NET 9 Preview 3.

## Serialization

In <xref:System.Text.Json>, .NET 9 has new options for serializing JSON and a new singleton that makes it easier to serialize using web defaults.

### Indentation options

<xref:System.Text.Json.JsonSerializerOptions> includes new properties that let you customize the indentation character and indentation size of written JSON.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Indentation":::

### Default web options

If you want to serialize with the [default options that ASP.NET Core uses](../../../standard/serialization/system-text-json/configure-options.md#web-defaults-for-jsonserializeroptions) for web apps, use the new <xref:System.Text.Json.JsonSerializerOptions.Web?displayProperty=nameWithType> singleton.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Serialization.cs" id="Web":::

## LINQ

New methods <xref:System.Linq.Enumerable.CountBy%2A> and <xref:System.Linq.Enumerable.AggregateBy%2A> have been introduced. These methods make it possible to aggregate state by key without needing to allocate intermediate groupings via <xref:System.Linq.Enumerable.GroupBy%2A>.

<xref:System.Linq.Enumerable.CountBy%2A> lets you quickly calculate the frequency of each key. The following example finds the word that occurs most frequently in a text string.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="CountBy":::

<xref:System.Linq.Enumerable.AggregateBy%2A> lets you implement more general-purpose workflows. The following example shows how you can calculate scores that are associated with a given key.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="AggregateBy":::

<xref:System.Linq.Enumerable.Index%60%601(System.Collections.Generic.IEnumerable{%60%600})> makes it possible to quickly extract the implicit index of an enumerable. You can now write code such as the following snippet to automatically index items in a collection.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="NewIndex":::

## Collections

The <xref:System.Collections.Generic.PriorityQueue%602> collection type in the <xref:System.Collections.Generic> namespace includes a new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})> method that you can use to update the priority of an item in the queue.

### PriorityQueue.Remove() method

.NET 6 introduced the <xref:System.Collections.Generic.PriorityQueue%602> collection, which provides a simple and fast array-heap implementation. One issue with array heaps in general is that they [don't support priority updates](https://github.com/dotnet/runtime/issues/44871), which makes them prohibitive for use in algorithms such as variations of [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue).

While it's not possible to implement efficient $O(\log n)$ priority updates in the existing collection, the new <xref:System.Collections.Generic.PriorityQueue%602.Remove(%600,%600@,%601@,System.Collections.Generic.IEqualityComparer{%600})?displayProperty=nameWithType> method makes it possible to emulate priority updates (albeit at $O(n)$ time):

:::code language="csharp" source="../snippets/dotnet-9/csharp/Collections.cs" id="UpdatePriority":::

This method unblocks users who want to implement graph algorithms in contexts where asymptotic performance isn't a blocker. (Such contexts include education and prototyping.) For example, here's a [toy implementation of Dijkstra's algorithm](https://github.com/dotnet/runtime/blob/16cb41496d595e2568574cfe11c763d5e05136c9/src/libraries/System.Collections/tests/Generic/PriorityQueue/PriorityQueue.Tests.Dijkstra.cs#L46-L76) that uses the new API.

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

## Reflection

In .NET Core versions and .NET 5-8, support for building an assembly and emitting reflection metadata for dynamically created types was limited to a runnable <xref:System.Reflection.Emit.AssemblyBuilder>. The lack of support for *saving* an assembly was often a blocker for customers migrating from .NET Framework to .NET. .NET 9 adds a new type, `PersistedAssemblyBuilder` <!--<xref:System.Reflection.Emit.AssemblyBuilder.PersistedAssemblyBuilder>-->, that you can use to save an emitted assembly.

To create a `PersistedAssemblyBuilder` instance, call its constructor and pass the assembly name, the core assembly, `System.Private.CoreLib`, to reference base runtime types, and optional custom attributes. After you emit all members to the assembly, call the `PersistedAssemblyBuilder.Save(string assemblyFileName)` <!--<xref:System.Reflection.Emit.AssemblyBuilder.PersistedAssemblyBuilder.Save(System.String)>--> method to create an assembly with default settings. If you want to set the entry point or other options, you can call `PersistedAssemblyBuilder.GenerateMetadata(System.Reflection.Metadata.BlobBuilder,System.Reflection.Metadata.BlobBuilder)` <!--<xref:System.Reflection.Emit.AssemblyBuilder.PersistedAssemblyBuilder.GenerateMetadata(System.Reflection.Metadata.BlobBuilder,System.Reflection.Metadata.BlobBuilder)>--> and use the metadata it returns to save the assembly. The following code shows an example of creating a persisted assembly and setting the entry point.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Reflection.cs" id="SaveAssembly":::

## Tokenizers

Tokenization is a fundamental component in the preprocessing of natural language text for AI models. Tokenizers are responsible for breaking down a string of text into smaller, more manageable parts, often referred to as *tokens*. When using services like Azure OpenAI, you can use tokenizers to get a better understanding of cost and manage context. When working with self-hosted or local models, tokens are the inputs provided to those models.

[Microsoft.ML.Tokenizers](https://devblogs.microsoft.com/dotnet/announcing-ml-net-2-0/#tokenizer-support) is an open-source, cross-platform tokenization library. When it was introduced, the library was scoped to the [Byte-Pair Encoding (BPE)](https://en.wikipedia.org/wiki/Byte_pair_encoding) tokenization strategy to satisfy the language set of scenarios in ML.NET. .NET 9 adds the following enhancements to the library:

- Refines APIs and existing functionality.
- Adds `Tiktoken` support.
- Adds `LlamaTokenizer` support.
- Adds support for scenarios covered by the `DeepDev` and `SharpToken` libraries. If you're using `DeepDev` or `SharpToken`, we recommend migrating to `Microsoft.ML.Tokenizers`. For more details, see the [migration guide](https://github.com/dotnet/machinelearning/blob/main/docs/code/microsoft-ml-tokenizers-migration-guide.md).

The following examples show how to use the `Tiktoken` and `LlamaTokenizer` text tokenizers.

Use `Tiktoken` tokenizer:

:::code language="csharp" source="../snippets/dotnet-9/csharp/Tiktoken.cs" id="Tiktoken":::

Use `LlamaTokenizer` tokenizer:

:::code language="csharp" source="../snippets/dotnet-9/csharp/LlamaTokenizer.cs" id="Llama":::

## New TimeSpan.From\* overloads

The <xref:System.TimeSpan> class offers several `From*` methods that let you create a `TimeSpan` object using a `double`. However, since `double` is a binary-based floating-point format, [inherent imprecision can lead to errors](https://github.com/dotnet/runtime/issues/93890). For instance, `TimeSpan.FromSeconds(101.832)` might not precisely represent `101 seconds, 832 milliseconds`, but rather approximately `101 seconds, 831.9999999999936335370875895023345947265625 milliseconds`. This discrepancy has caused frequent confusion, and it's also not the most efficient way to represent such data. To address this, .NET 9 adds new overloads that let you create `TimeSpan` objects from integers. There are new overloads from `FromDays`, `FromHours`, `FromMinutes`, `FromSeconds`, `FromMilliseconds`, and `FromMicroseconds`.

The following code shows an example of calling the `double` and one of the new integer overloads.

:::code language="csharp" source="../snippets/dotnet-9/csharp/TimeSpan.cs" id="TimeSpan.From":::

## `ActivatorUtilities.CreateInstance` constructor

The constructor resolution for <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> has changed in .NET 9. Previously, a constructor that was explicitly marked using the <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilitiesConstructorAttribute> attribute might not be called, depending on the ordering of constructors and the number of constructor parameters. The logic has changed in .NET 9 such that a constructor that has the attribute is always called.
