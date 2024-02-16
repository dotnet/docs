---
title: What's new in .NET 9
description: Learn about the new .NET features introduced in .NET 9.
titleSuffix: ""
ms.date: 02/13/2024
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 9

Learn about the new features in .NET 9 and find links to further documentation.

.NET 9, the successor to [.NET 8](../dotnet-8/overview.md), has a special focus on cloud-native apps and performance. It will be [supported for 18 months](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a standard-term support (STS) release. You can [download .NET 9 here](https://dotnet.microsoft.com/download/dotnet/9.0).

New for .NET 9, the engineering team posts .NET 9 preview updates on [GitHub Discussions](https://github.com/dotnet/core/discussions). That's a great place to ask questions and provide feedback about the release.

This article has been updated for .NET 9 Preview 1. The following sections describe the updates to the core .NET libraries in .NET 9.

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

<xref:System.Linq.Enumerable.Index> makes it possible to quickly extract the implicit index of an enumerable. You can now write code such as the following snippet to automatically index items in a collection.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Linq.cs" id="IndexNew":::

## Collections

The <xref:System.Collections.Generic.PriorityQueue%602> collection type in the <xref:System.Collections.Generic> namespace includes a new <xref:System.Collections.Generic.PriorityQueue%602.Remove> method that you can use the update the priority of an item in the queue.

### PriorityQueue.Remove() method

.NET 6 introduced the <xref:System.Collections.Generic.PriorityQueue%602> collection, which provides a simple and fast array-heap implementation. One issue with array heaps in general is that they [don't support priority updates](https://github.com/dotnet/runtime/issues/44871), which makes them prohibitive for use in algorithms such as variations of [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue).

While it's not possible to implement efficient $O(\log n)$ priority updates in the existing collection, the new <xref:System.Collections.Generic.PriorityQueue%602.Remove?displayProperty=nameWithType> method makes it possible to emulate priority updates (albeit at $O(n)$ time):

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

In .NET Core versions and .NET 5-8, support for building an assembly and emitting reflection metadata for dynamically created types was limited to a runnable <xref:System.Reflection.Emit.AssemblyBuilder>. The lack of support for *saving* an assembly was often a blocker for customers migrating from .NET Framework to .NET. .NET 9 adds public APIs to <xref:System.Reflection.Emit.AssemblyBuilder> to save an emitted assembly.

The new, persisted <xref:System.Reflection.Emit.AssemblyBuilder> implementation is runtime and platform independent. To create a persisted `AssemblyBuilder` instance, use the new <xref:System.Reflection.Emit.AssemblyBuilder.DefinePersistedAssembly%2A?displayProperty=nameWithType> API. The existing <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> API accepts the assembly name and optional custom attributes. To use the new API, pass the core assembly, `System.Private.CoreLib`, which is used for referencing base runtime types. There's no option for <xref:System.Reflection.Emit.AssemblyBuilderAccess>. And for now, the persisted `AssemblyBuilder` implementation only supports saving, not running. After you create an instance of the persisted `AssemblyBuilder`, the subsequent steps for defining a module, type, method, or enum, writing IL, and all other usages remain unchanged. That means you can use existing <xref:System.Reflection.Emit> code as-is for saving the assembly. The following code shows an example.

:::code language="csharp" source="../snippets/dotnet-9/csharp/Reflection.cs" id="SaveAssembly":::

## See also

- [Announcing .NET 9 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-9-preview-1) (blog post)
