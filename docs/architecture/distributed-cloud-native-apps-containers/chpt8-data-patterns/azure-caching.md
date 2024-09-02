---
title: Caching in a cloud-native application
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Caching in a cloud-native application
author:
ms.date: 04/06/2022
---

# Caching in a cloud-native application

[!INCLUDE [download-alert](includes/download-alert.md)]

The benefits of caching are well understood. The technique works by temporarily copying frequently accessed data from a backend data store to *fast storage* that's located closer to the application. Caching is often implemented where:

- Data remains relatively static.
- Data access is slow, especially compared to the speed of the cache.
- Data is subject to high levels of contention.

## Why use a cache?

As discussed in the [Microsoft caching guidance](/azure/architecture/best-practices/caching), caching can increase performance, scalability, and availability for individual microservices and the system as a whole. It reduces the latency and contention of handling large volumes of concurrent requests to a data store. As data volume and the number of users increase, the benefits of caching become greater.

Caching is most effective when a client repeatedly reads data that is immutable or that changes infrequently. Examples include reference information such as product and pricing information, or shared static resources that are costly to construct.

While microservices should be stateless, a distributed cache can support concurrent access to session state data when absolutely required.

Also consider caching to avoid repetitive computations. If an operation transforms data or performs a complicated calculation, cache the result for subsequent requests.

## Caching architecture

Cloud native applications typically implement a distributed caching architecture. The cache is hosted as a cloud-based [backing service](./definition.md#backing-services), separate from the microservices. Figure 5-15 shows the architecture.

![A diagram showing how a cache is implemented in a cloud-native app.](media/distributed-data.png)

**Figure 5-15**. Caching in a cloud-native app

The previous figure presents a common caching pattern known as the [cache-aside pattern](/azure/architecture/patterns/cache-aside). For an incoming request, you first query the cache (step \#1) for a response. If found, the data is returned immediately. If the data doesn't exist in the cache (known as a [cache miss](https://www.techopedia.com/definition/6308/cache-miss)), it's retrieved from a local database in a downstream service (step \#2). It's then written to the cache for future requests (step \#3), and returned to the caller. Care must be taken to periodically evict cached data so that the system remains timely and consistent.

As a shared cache grows, it might prove beneficial to partition its data across multiple nodes. Doing so can help minimize contention and improve scalability. Many caching services support the ability to add and remove nodes dynamically and rebalance data across partitions. This approach typically involves clustering. Clustering exposes a collection of federated nodes as a seamless, single cache. Internally, however, the data is dispersed across the nodes following a predefined distribution strategy that balances the load evenly.

## Azure Cache for Redis

[Azure Cache for Redis](https://azure.microsoft.com/services/cache/) is a secure data caching and messaging broker service, fully managed by Microsoft. It's a Platform as a Service (PaaS) offering that provides high throughput and low-latency access to data. The service is accessible to any application within or outside of Azure.

The Azure Cache for Redis service manages access to open-source Redis servers hosted across Azure data centers. The service acts as a facade providing management, access control, and security. The service natively supports a rich set of data structures, including strings, hashes, lists, and sets. If your application already uses Redis, it will work as-is with Azure Cache for Redis.

Azure Cache for Redis is more than a simple cache server. It can support a number of scenarios to enhance a microservices architecture:

- An in-memory data store
- A distributed non-relational database
- A message broker
- A configuration or discovery server
  
For advanced scenarios, a copy of the cached data can be [persisted to disk](/azure/azure-cache-for-redis/cache-how-to-premium-persistence). If a catastrophic event disables both the primary and replica caches, the cache is reconstructed from the most recent snapshot.

Azure Redis Cache is available across a number of predefined configurations and pricing tiers. The [Premium tier](/azure/azure-cache-for-redis/cache-overview#service-tiers) features many enterprise-level features such as clustering, data persistence, geo-replication, and virtual-network isolation.

## Using Redis caches with .NET Aspire

.NET Aspire includes several built-in components that can help you cache data in Redis, whether that service is running in Azure, in a container, or elsewhere. The components come in three types:

- **Caching.** This component stores frequently accessed data in a single instance of Redis.
- **Distributed Caching.** Use this component if your Redis cache may consist of multiple servers. 
- **Output Caching.** Use this component if you want to cache complete HTTP responses, such as a full web page or a response to an API call in HTML format.

In the app host, you add the Redis hosting package. In this case, we'll add a distributed cache:

```dotnetcli
dotnet add package Aspire.Hosting.Redis
```

Then, to ease service discovery, create the cache instance in the app host project's _Program.cs_ file and pass it to any microservice that needs to use it:

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

builder.AddProject<Projects.ExampleProject>()
       .WithReference(cache)
```

In the microservice where you want to use the cache, start by installing the component:

```dotnetcli
dotnet add package Aspire.StackExchange.Redis.DistributedCaching
```

Then, add the cache service to the dependency injection container, by adding this code to the microservice's _Program.cs_ file:

```csharp
builder.AddRedisDistributedCache("cache");
```

Now, whenever you want to add data to the cache or retrieve it, you can get the `IDistributedCache` object and code it as normal:

```csharp
public class ExampleService(IDistributedCache cache)
{
    // Use the cache object to store and retrieve data.
}
```

>[!div class="step-by-step"]
>[Previous](relational-vs-nosql-data.md)
>[Next](data-driven-crud-microservice.md)
