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

### Cryptography

## See also

- [Announcing .NET 9 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-9-preview-1) (blog post)
