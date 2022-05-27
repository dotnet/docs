---
title: Caching in .NET
description: Learn how to use various in-memory and distributed caching mechanisms in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 12/08/2021
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
> For multi-server caching scenarios, consider the [Distributed caching](#distributed-caching) approach as an alternative to in-memory caching.

### In-memory caching API

The consumer of the cache has control over both sliding and absolute expirations:

- <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.AbsoluteExpiration?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.AbsoluteExpirationRelativeToNow?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.SlidingExpiration?displayProperty=nameWithType>

Setting an expiration will cause entries in the cache to be *evicted* if they're not accessed within the expiration time allotment. Consumers have additional options for controlling cache entries, through the <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions>. Each <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry> is paired with <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions> which exposes expiration eviction functionality with <xref:Microsoft.Extensions.Primitives.IChangeToken>, priority settings with <xref:Microsoft.Extensions.Caching.Memory.CacheItemPriority>, and controlling the <xref:Microsoft.Extensions.Caching.Memory.ICacheEntry.Size?displayProperty=nameWithType>. Consider the following extension methods:

- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.AddExpirationToken%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.RegisterPostEvictionCallback%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetSize%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.SetPriority%2A?displayProperty=nameWithType>

### In-memory cache example

To use the default <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache> implementation, call the <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache%2A> extension method to register all the required services with DI. In the following code sample, the generic host is used to expose the <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureServices%2A> functionality:

:::code source="snippets/caching/memory-apis/Program.cs" range="1-7" highlight="6":::

Depending on your .NET workload, you may access the `IMemoryCache` differently; such as constructor injection. In this sample, you use the `IServiceProvider` instance on the `host` and call generic <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%60%601(System.IServiceProvider)> extension method:

:::code source="snippets/caching/memory-apis/Program.cs" range="9-10":::

With in-memory caching services registered, and resolved through DI &mdash; you're ready to start caching. This sample iterates through the letters in the English alphabet 'A' through 'Z'. The `record AlphabetLetter` type holds the reference to the letter, and generates a message.

:::code source="snippets/caching/memory-apis/Program.cs" range="70-74":::

The sample includes a helper function that iterates through the alphabet letters:

:::code source="snippets/caching/memory-apis/Program.cs" range="24-33":::

In the preceding C# code:

- The `Func<char, Task> asyncFunc` is awaited on each iteration, passing the current `letter`.
- After all letters have been processed, a blank line is written to the console.

To add items to the cache call one of the `Create`, or `Set` APIs:

:::code source="snippets/caching/memory-apis/Program.cs" range="35-54" highlight="12-13":::

In the preceding C# code:

- The variable `addLettersToCacheTask` delegates to `IterateAlphabetAsync` and is awaited.
- The `Func<char, Task> asyncFunc` is argued with a lambda.
- The `MemoryCacheEntryOptions` is instantiated with an absolute expiration relative to now.
- A post eviction callback is registered.
- An `AlphabetLetter` object is instantiated, and passed into <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Set%2A> along with `letter` and `options`.
- The letter is written to the console as being cached.
- Finally, a <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> is returned.

For each letter in the alphabet, a cache entry is written with an expiration, and post eviction callback.

The post eviction callback writes the details of the value that was evicted to the console:

:::code source="snippets/caching/memory-apis/Program.cs" range="15-22":::

Now that the cache is populated, another call to `IterateAlphabetAsync` is awaited, but this time you'll call <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache.TryGetValue%2A?displayProperty=nameWithType>:

:::code source="snippets/caching/memory-apis/Program.cs" range="56-66":::

If the `cache` contains the `letter` key, and the `value` is an instance of an `AlphabetLetter` it's written to the console. When the `letter` key is not in the cache, it was evicted and its post eviction callback was invoked.

#### Additional extension methods

The `IMemoryCache` comes with many convenience-based extension methods, including an asynchronous `GetOrCreateAsync`:

- <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Get%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreate%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.GetOrCreateAsync%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.Set%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Memory.CacheExtensions.TryGetValue%2A?displayProperty=nameWithType>

#### Put it all together

The entire sample app source code is a top-level program and requires two NuGet packages:

- [`Microsoft.Extensions.Caching.Memory`](/dotnet/api/microsoft.extensions.caching.memory)
- [`Microsoft.Extensions.Hosting`](/dotnet/api/microsoft.extensions.hosting)

:::code source="snippets/caching/memory-apis/Program.cs":::

Feel free to adjust the `MillisecondsDelayAfterAdd` and `MillisecondsAbsoluteExpiration` values to observe the changes in behavior to the expiration and eviction of cached entries. The following is sample output from running this code, due to the non-deterministic nature of .NET events &mdash; there is no guarantee that your output will be identical.

```console
A was cached.
B was cached.
C was cached.
D was cached.
E was cached.
F was cached.
G was cached.
H was cached.
I was cached.
J was cached.
K was cached.
L was cached.
M was cached.
N was cached.
O was cached.
P was cached.
Q was cached.
R was cached.
S was cached.
T was cached.
U was cached.
V was cached.
W was cached.
X was cached.
Y was cached.
Z was cached.

A was evicted for Expired.
C was evicted for Expired.
B was evicted for Expired.
E was evicted for Expired.
D was evicted for Expired.
F was evicted for Expired.
H was evicted for Expired.
K was evicted for Expired.
L was evicted for Expired.
J was evicted for Expired.
G was evicted for Expired.
M was evicted for Expired.
N was evicted for Expired.
I was evicted for Expired.
P was evicted for Expired.
R was evicted for Expired.
O was evicted for Expired.
Q was evicted for Expired.
S is still in cache. The 'S' character is the 19 letter in the English alphabet.
T is still in cache. The 'T' character is the 20 letter in the English alphabet.
U is still in cache. The 'U' character is the 21 letter in the English alphabet.
V is still in cache. The 'V' character is the 22 letter in the English alphabet.
W is still in cache. The 'W' character is the 23 letter in the English alphabet.
X is still in cache. The 'X' character is the 24 letter in the English alphabet.
Y is still in cache. The 'Y' character is the 25 letter in the English alphabet.
Z is still in cache. The 'Z' character is the 26 letter in the English alphabet.
```

Since the absolute expiration (<xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow?displayProperty=nameWithType>) is set, all the cached items will eventually be evicted.

## Worker Service caching

One common strategy for caching data, is updating the cache independently from the consuming data services. The *Worker Service* template is a great example, as the <xref:Microsoft.Extensions.Hosting.BackgroundService> runs independent (or in the background) from the other application code. When an application starts running that hosts an implementation of the <xref:Microsoft.Extensions.Hosting.IHostedService>, the corresponding implementation (in this case the `BackgroundService` or "worker") start running in the same process. These hosted services are registered with DI as singletons, through the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)> extension method. Other services can be registered with DI with any [service lifetime](dependency-injection.md#service-lifetimes).

> [!IMPORTANT]
> The service lifetime's are very important to understand. When you call <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache%2A> to register all of the in-memory caching services, the services are registered as singletons.

### Photo service scenario

Imagine you're developing a photo service that relies on third-party API accessible via HTTP. This photo data doesn't change very often, but there is a lot of it. Each photo is represented by a simple `record`:

:::code source="snippets/caching/memory-worker/Photo.cs":::

In the following example, you'll see several services being registered with DI. Each service has a single responsibility.

:::code source="snippets/caching/memory-worker/Program.cs" range="1-14":::

In the preceding C# code:

- The generic host is created with [defaults](generic-host.md#default-builder-settings).
- In-memory caching services are registered with <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache%2A>.
- An `HttpClient` instance is registered for the `CacheWorker` class with <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)>.
- The `CacheWorker` class is registered with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)>.
- The `PhotoService` class is registered with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)>.
- The `CacheSignal<T>` class is registered with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton%2A>.
- The `host` is instantiated from the builder, and started asynchronously.

The `PhotoService` is responsible for getting photos that match a given criteria (or `filter`):

:::code source="snippets/caching/memory-worker/PhotoService.cs":::

In the preceding C# code:

- The constructor requires an `IMemoryCache`, `CacheSignal<Photo>`, and `ILogger`.
- The `GetPhotosAsync` method:
  - Defines a `Func<Photo, bool> filter` parameter, and returns an `IAsyncEnumerable<Photo>`.
  - Calls and waits for the `_cacheSignal.WaitAsync()` to release, this ensures that the cache is populated before accessing the cache.
  - Calls `_cache.GetOrCreateAsync()`, asynchronously getting all of the photos in the cache.
  - The `factory` argument logs a warning, and returns an empty photo array - this should never happen.
  - Each photo in the cache is iterated, filtered and materialized with `yield return`.
  - Finally, the cache signal is reset.

Consumers of this service are free to call `GetPhotosAsync` method, and handle photos accordingly. No `HttpClient` is required as the cache contains the photos.

The `CacheWorker` is a subclass of <xref:Microsoft.Extensions.Hosting.BackgroundService>:

:::code source="snippets/caching/memory-worker/CacheWorker.cs":::

> [!IMPORTANT]
> You need to `override` <xref:Microsoft.Extensions.Hosting.BackgroundService.StartAsync%2A?displayProperty=nameWithType> and call `await _cacheSignal.WaitAsync()` in order to prevent a race condition between the starting of the `CacheWorker` and a call to `PhotoService.GetPhotosAsync`.

In the preceding C# code:

- The constructor requires an `ILogger`, `HttpClient`, `CacheSignal<Photo>`, and `IMemoryCache`.
- The defines an `_updateInterval` of three hours.
- The `ExecuteAsync` method:
  - Loops while the app is running.
  - Makes an HTTP request to `"https://jsonplaceholder.typicode.com/photos"`, and maps the response as an array of `Photo` objects.
  - The array of photos is placed in the `IMemoryCache` under the `"Photos"` key.
  - The `_cacheSignal.Release()` is called, releasing any consumers who were waiting for the signal.
  - The call to <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> is awaited, given the update interval.
  - After delaying for three hours, the cache is again updated.

The asynchronous signal is based on an encapsulated <xref:System.Threading.SemaphoreSlim> instance, within a generic-type constrained singleton. The `CacheSignal<T>` relies on an instance of `SemaphoreSlim`:

:::code source="snippets/caching/memory-worker/CacheSignal.cs":::

In the preceding C# code, the decorator pattern is used to wrap an instance of the `SemaphoreSlim`. Since the `CacheSignal<T>` is registered as a singleton, it can be used across all service lifetimes with any generic type &mdash; in this case, the `Photo`. It is responsible for signaling the seeding of the cache.

## Distributed caching

In some scenarios, a distributed cache is required &mdash; such is the case with multiple app servers. A distributed cache supports higher scale-out than the in-memory caching approach. Using a distributed cache offloads the cache memory to an external process, but does require extra network I/O and introduces a bit more latency (even if nominal).

The distributed caching abstractions are part of the [`Microsoft.Extensions.Caching.Memory`](/dotnet/api/microsoft.extensions.caching.memory) NuGet package, and there is even an `AddDistributedMemoryCache` extension method.

> [!CAUTION]
> The <xref:Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddDistributedMemoryCache%2A> should only be used in development and/or testing scenarios, and is **not** a viable production implementation.

Consider any of the available implementations of the `IDistributedCache` from the following packages:

- [`Microsoft.Extensions.Caching.SqlServer`](https://www.nuget.org/packages/Microsoft.Extensions.Caching.SqlServer)
- [`Microsoft.Extensions.Caching.StackExchangeRedis`](https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis)
- [`NCache.Microsoft.Extensions.Caching.OpenSource`](https://www.nuget.org/packages/NCache.Microsoft.Extensions.Caching.OpenSource)

### Distributed caching API

The distributed caching APIs are a bit more primitive than their in-memory caching API counterparts. The key-value pairs are a bit more basic. In-memory caching keys are based on an `object`, whereas the distributed keys are a `string`. With in-memory caching, the value can be any strongly-typed generic, whereas values in distributed caching are persisted as `byte[]`. That's not to say that various implementations don't expose strongly-typed generic values but that would be an implementation detail.

#### Create values

To create values in the distributed cache, call one of the set APIs:

- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.SetAsync%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Set%2A?displayProperty=nameWithType>

Using the `AlphabetLetter` record from the in-memory cache example, you could serialize the object to JSON and then encode the `string` as a `byte[]`:

:::code source="snippets/caching/distributed/Program.cs" id="Create" highlight="7-9":::

Much like in-memory caching, cache entries can have options to help fine-tune their existence in the cache &mdash; in this case, the <xref:Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions>.

##### Create extension methods

There are several convenience-based extension methods for creating values, that help to avoid encoding `string` representations of objects into a `byte[]`:

- <xref:Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetStringAsync%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetString%2A?displayProperty=nameWithType>

#### Read values

To read values from the distributed cache, call one of the get APIs:

- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.GetAsync%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Get%2A?displayProperty=nameWithType>

:::code source="snippets/caching/distributed/Program.cs" id="Read" highlight="5-6":::

Once a cache entry is read out of the cache, you can get the UTF8 encoded `string` representation from the `byte[]`

##### Read extension methods

There are several convenience-based extension methods for reading values, that help to avoid decoding `byte[]` into `string` representations of objects:

- <xref:Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.GetStringAsync%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.GetString%2A?displayProperty=nameWithType>

#### Update values

There is no way to actually update the values in the distributed cache with a single API call, instead values can have their sliding expirations reset with one of the refresh APIs:

- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.RefreshAsync%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Refresh%2A?displayProperty=nameWithType>

If the actual value needs to be updated, you'd have to delete the value and then re-add it.

#### Delete values

To delete values in the distributed cache, call one of the remove APIs:

- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.RemoveAsync%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Remove%2A?displayProperty=nameWithType>

> [!TIP]
> While there are synchronous versions of the aforementioned APIs, please consider the fact that implementations of distributed caches are reliant on network I/O. For this reason, it is preferred more often than not to use the asynchronous APIs.

## See also

- [Dependency injection in .NET](dependency-injection.md)
- [.NET Generic Host](generic-host.md)
- [Worker Services in .NET](workers.md)
- [Azure for .NET developers](../../azure/index.yml)
- [Cache in-memory in ASP.NET Core](/aspnet/core/performance/caching/memory)
- [Distributed caching in ASP.NET Core](/aspnet/core/performance/caching/distributed)
