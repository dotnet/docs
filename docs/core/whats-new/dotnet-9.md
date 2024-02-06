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

.NET 9, the successor to [.NET 8](dotnet-8.md), has a special focus on cloud-native apps and performance. It will be [supported for 18 months](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a short-term support (STS) release. You can [download .NET 9 here](https://dotnet.microsoft.com/download/dotnet/9.0).

New for .NET 9, the engineering team posts .NET 9 preview updates on [GitHub Discussions](https://github.com/dotnet/core/discussions). That's a great place to ask questions and provide feedback about the release.

This article has been updated for .NET 9 Preview 1.

## .NET library updates

- [Serialization](#serialization)
- [LINQ](#linq)
- [Collections](#collections)
- [Cryptography](#cryptography)

### Serialization

### LINQ

New methods `CountBy` and `AggregateBy` have been introduced. These methods make it possible to aggregate state by key without needing to allocate intermediate groupings via <xref:System.Linq.Enumerable.GroupBy%2A>.

`CountBy` lets you quickly calculate the frequency of each key. The following example finds the word that occurs most frequently in a text string.

:::code language="csharp" source="snippets/dotnet-9/csharp/Linq.cs" id="CountBy":::

`AggregateBy` lets you implement more general-purpose workflows. The following example shows how you can calculate scores that are associated with a given key.

:::code language="csharp" source="snippets/dotnet-9/csharp/Linq.cs" id="AggregateBy":::

### Collections

#### PriorityQueue.Remove() method

.NET 6 introduced the <xref:System.Collections.Generic.PriorityQueue%602> collection, which provides a simple and fast array-heap implementation. One issue with array heaps in general is that they [don't support priority updates](https://github.com/dotnet/runtime/issues/44871), which makes them prohibitive for use in algorithms such as variations of [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue).

While it's not possible to implement efficient `O(log n)` priority updates in the existing collection, the new `PriorityQueue.Remove` method makes it possible to emulate priority updates (albeit at `O(n)` time):

:::code language="csharp" source="snippets/dotnet-9/csharp/Collections.cs" id="UpdatePriority":::

This method unblocks users who want to implement graph algorithms in contexts where asymptotic performance isn't a blocker. (Such contexts include education and prototyping.) For example, here's a [toy implementation of Dijkstra's algorithm](https://github.com/dotnet/runtime/blob/16cb41496d595e2568574cfe11c763d5e05136c9/src/libraries/System.Collections/tests/Generic/PriorityQueue/PriorityQueue.Tests.Dijkstra.cs#L46-L76) that uses the new API.

### Cryptography

## See also

- [Announcing .NET 9 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-9-preview-1) (blog post)
