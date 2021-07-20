---
title: Caching in .NET
description: Learn how to use various in-memory and distributed caching mechanisms in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 07/20/2021
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

All of the `Microsoft.Extensions.*` packages come dependency injection (DI) ready, both the <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> and <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> interfaces can be used as services.

## In-memory caching

In this section, you'll learn about the [`Microsoft.Extensions.Caching.Memory`](/dotnet/api/microsoft.extensions.caching.memory) package. The current implementation of the <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> is a wrapper around the <xref:System.Collections.Concurrent.ConcurrentDictionary%602>, exposing a feature-rich API. Entries within the cache are represented by the <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry>, and can be any `object`. The in-memory cache solution is great for apps that run in a single server, where all the cached data rents memory in the app's process.

> [!TIP]
> For multi-server caching scenarios, consider the [Distributed caching](#distributed-caching) approach as an alternative simple in-memory caching.

### In-memory caching API

The consumer of the cache has control over both sliding and absolute expirations:

- <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.AbsoluteExpiration?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.AbsoluteExpirationRelativeToNow?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.SlidingExpiration?displayProperty=nameWithType>

Setting an expiration will cause entries in the cache to be *evicted* if they're not accessed within the expiration time allotment. Consumers have additional options for controlling cache entries, through the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions>. Each <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry> is paired with <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions> which exposes expiration eviction functionality with <xref:Microsoft.Extensions.Primitives.IChangeToken>, priority settings with <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority>, and controlling the <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.Size?displayProperty=nameWithType>.

- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.AddExpirationToken%2A>
- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.RegisterPostEvictionCallback%2A>
- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetSize%2A>
- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetPriority%2A>

### In-memory cache example

To use the default <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> implementation, call the <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache%2A> extension method to register all the required services with DI. In the following code sample, the generic host is used to expose the <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureServices%2A> functionality:

:::code source="snippets/caching/memory/Program.cs" range="3-9" highlight="5":::

Depending on your .NET workload, you may access the `IMemoryCache` differently; such as constructor injection. In this sample, you use the `IServiceProvider` instance on the `host` and call generic <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%60%601(System.IServiceProvider)> extension method:

:::code source="snippets/caching/memory/Program.cs" range="12-13":::

With in-memory caching services registered, and resolved through DI - you're ready to start caching. This sample iterates through the letters in the English alphabet 'A' through 'Z'. There is a `record` that holds the reference to the letter, and generates a message.

:::code source="snippets/caching/memory/Program.cs" range="70-74":::

The sample includes a helper function that iterates through the alphabet letters:

:::code source="snippets/caching/memory/Program.cs" range="26-35":::

In the preceding C# code:

- The `Func<char, Task> asyncFunc` is awaited on each interation, passing the current `letter`.
- After all letters have been processed, a blank line is written to the console.

To add items to the cache call one of the `Create`, or `Set` APIs:

:::code source="snippets/caching/memory/Program.cs" range="37-55":::

In the preceding C# code:

- The invocation of `IterateAlphabetAsync` is awaited.
- The `Func<char, Task> asyncFunc` is argued with a lambda.
- The `MemoryCacheEntryOptions` is instantiated with an absolute expiration relative to now.
- A post eviction callback is registered.
- An `AlphabetLetter` object is instantiated, and passed into <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Set%2A> along with `letter` and `options`.
- The letter is written to the console as being cached.
- Finally, a <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> is returned.

For each letter in the alphabet, a cache entry is written with an expiration, and post eviction callback.

The post eviction callback writes the details of the value that was evicted to the console:

:::code source="snippets/caching/memory/Program.cs" range="17-24":::

Now that the cache is populated, another call to `IterateAlphabetAsync` is awaited, but this time you'll call <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache.TryGetValue%2A?displayProperty=nameWithType>:

:::code source="snippets/caching/memory/Program.cs" range="57-66":::

If the `cache` contains the `letter` key, and the `value` is an instance of an `AlphabetLetter` it's written to the console. When the `letter` key is not in the cache, it was evicted and its post eviction callback was invoked.

#### Put it all together

The entire sample app source code is a top-level program and requires two NuGet packages:

- [`Microsoft.Extensions.Caching.Memory`](/dotnet/api/microsoft.extensions.caching.memory)
- [`Microsoft.Extensions.Hosting`](/dotnet/api/microsoft.extensions.hosting)

:::code source="snippets/caching/memory/Program.cs":::

Feel free to adjust the `MillisecondsDelayAfterAdd` and `MillisecondsAbsoluteExpiration` values to observe the changes in behavior to the expiration and eviction of cached entries.

## Distributed caching

In some scenarios, a distributed cache is required. A distributed cache can support higher scale-out than an in-memory cache. Using a distributed cache offloads the cache memory to an external process.

<!-- TODO: Add a lot more content here. -->

## See also

- [Dependency injection in .NET](dependency-injection.md)
- [.NET Generic Host](generic-host.md)
- [Worker Services in .NET](workers.md)
- [Azure for .NET developers](../../azure/index.yml)
- [Cache in-memory in ASP.NET Core](/aspnet/core/performance/caching/memory)
- [Distributed caching in ASP.NET Core](/aspnet/core/performance/caching/distributed)
