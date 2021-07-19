---
title: Caching in .NET
description: Learn how to use various in-memory and distributed caching mechanisms in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 07/19/2021
---

# Caching in .NET

In this article, you'll learn about various caching mechanisms. Caching is the act of storing data in an intermediate-layer, making subsequent data retrievals faster. Conceptually, caching is a performance optimization strategy and design consideration. Caching can significantly improve app performance by making infrequently changing (or expensive to retrieve) data more readily available. This article introduces the two primary types of caching, and provides sample source code for both:

- [`Microsoft.Extensions.Caching.Memory`](/dotnet/api/microsoft.extensions.caching.memory)
- [`Microsoft.Extensions.Caching.Distributed`](/dotnet/api/microsoft.extensions.caching.distributed)

> [!IMPORTANT]
> There are two `MemoryCache` classes within .NET, one in the `System.Runtime.Caching` namespace and the other in the `Microsoft.Extensions.Caching` namespace:
>
> - <xref:System.Runtime.Caching.MemoryCache?displayProperty=fullName>
> - <xref:Microsoft.Extensions.Caching.Memory.MemoryCache?displayProperty=fullName>
>
> While this article focuses on caching, it doesn't include the [`System.Runtime.Caching`](https://www.nuget.org/packages/System.Runtime.Caching) NuGet package. All references to `MemoryCache` are within the `Microsoft.Extensions.Caching` namespace.

## In-memory caching

The current implementation of the <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> is based on a <xref:System.Collections.Concurrent.ConcurrentDictionary%602>.

## Distributed caching

In some scenarios, a distributed cache is required. A distributed cache can support higher scale-out than an in-memory cache. Using a distributed cache offloads the cache memory to an external process.

## See also

- [Dependency injection in .NET](dependency-injection.md)
- [Worker Services in .NET](workers.md)
- [Azure for .NET developers](../../azure/index.yml)
