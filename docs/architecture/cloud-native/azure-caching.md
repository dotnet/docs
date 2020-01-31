---
title: Caching in a cloud-native application
description: Learn about caching strategies in a cloud-native application.
author: robvet
ms.date: 01/22/2020
---
# Caching in a cloud-native app

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

The benefits of caching are well understood. The technique works by temporarily copying frequently accessed data from a backend data store to *fast storage* that's located closer to the application. Caching is often implemented where...

- Data remains relatively static.
- Data access is slow, especially compared to the speed of the cache.
- Data is subject to high levels of contention.

## Why?

As discussed in the [Microsoft caching guidance](https://docs.microsoft.com/azure/architecture/best-practices/caching), caching can increase performance, scalability, and availability for individual microservices and the system as a whole. It reduces the latency and contention of handling large volumes of concurrent requests to a data store. As data volume and the number of users increase, the greater the benefits of caching become.

Caching is most effective when a client repeatedly reads data that is immutable or that changes infrequently. Examples include reference information such as product and pricing information, or shared static resources that are costly to construct.

While microservices should be stateless, a distributed cache can support concurrent access to session state data when absolutely required.

Also consider caching to avoid repetitive computations. If an operation transforms data or performs a complicated calculation, cache the result for subsequent requests.

## Caching architecture

Cloud native applications typically implement a distributed caching architecture. The cache is hosted as a cloud-based [backing service](./definition.md#backing-services), separate from the microservices. Figure 5-20 shows the architecture.

![Caching in a cloud native app](media/caching-in-a-cloud-native-app.png)

**Figure 5-19**: Caching in a cloud native app

In the previous figure, note how the cache is independent of and shared by the microservices. In this scenario, the cache is invoked by the [API Gateway](./front-end-communication.md). As discussed in chapter 4, the gateway serves as a front end for all incoming requests. The distributed cache increases system responsiveness by returning cached data whenever possible. Additionally, separating the cache from the services allows the cache to scale up or out independently to meet increased traffic demands.

The figure presents a common caching pattern known as the [cache-aside pattern](https://docs.microsoft.com/azure/architecture/patterns/cache-aside). For an incoming request, you first query the cache (step \#1) for a response. If found, the data is returned immediately. If the data doesn't exist in the cache (known as a [cache miss](https://www.techopedia.com/definition/6308/cache-miss)), it's retrieved from a local database in a downstream service (step \#2). It's then written to the cache for future requests (step \#3), and returned to the caller. Care must be taken to periodically evict cached data so that the system remains timely and consistent.

As a shared cache grows, it might prove beneficial to partition its data across multiple nodes. Doing so can help minimize contention and improve scalability. Many Caching services support the ability to dynamically add and remove nodes and rebalance data across partitions. This approach typically involves clustering. Clustering exposes a collection of federated nodes as a seamless, single cache. Internally, however, the data is dispersed across the nodes following a predefined distribution strategy that balances the load evenly.

## Azure Cache for Redis

[Azure Cache for Redis](https://azure.microsoft.com/services/cache/) is a secure data caching and messaging broker service, fully managed by Microsoft. Consumed as a Platform as a Service (PaaS) offering, it provides high throughput and low-latency access to data. The service is accessible to any application within or outside of Azure.

The Azure Cache for Redis service manages access to open-source Redis servers hosted across Azure data centers. The service acts as a facade providing management, access control, and security. The service natively supports a rich set of data structures, including strings, hashes, lists, and sets. If your application already uses Redis, it will work as-is with Azure Cache for Redis.

Azure Cache for Redis is more than a simple cache server. It can support a number of scenarios to enhance a microservices architecture:

- An in-memory data store
- A distributed non-relational database
- A message broker
- A configuration or discovery server
  
For advanced scenarios, a copy of the cached data can be [persisted to disk](https://docs.microsoft.com/azure/azure-cache-for-redis/cache-how-to-premium-persistence). If a catastrophic event disables both the primary and replica caches, the cache is reconstructed from the most recent snapshot.

Azure Redis Cache is available across a number of predefined configurations and pricing tiers.  The [Premium tier](https://docs.microsoft.com/azure/azure-cache-for-redis/cache-premium-tier-intro) features many enterprise-level features such as clustering, data persistence, geo-replication, and virtual-network isolation.

## NCache Cache in Azure
NCache is a native .NET based open source in-memory distributed cache that enables you to do improve application’s performance and scalability. NCache is available as a [preconfigured VM](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/alachisoft.ncache_enterprise-50sp2?tab=Overview) from Azure Marketplace. You can incorporate NCache not only inside the API gateway as mentioned above but also in your application’s persistence layer. Using it in the persistence layer is better because it allows you to cache different types of data (datasets) for different periods of time and control their updates in a more detailed level. You can update these datasets individually in the cache whenever your application updates this data in the database. And, to cater for situation where other application might update this data in the database without updating your caching, you can create [Sql Dependency](https://www.alachisoft.com/resources/docs/ncache/prog-guide/sql-dependency.html) on some of your data so when the corresponding data in SQL Server changes, your cache is automatically updated. All of this keeps your cache always correct and fresh. Figure 5-20 illustrates the architecture of an application that uses NCache using the cache through pattern to meet its caching requirements.

![Caching in a cloud using cache through pattern](media/caching-in-a-cloud-using-cache-through-pattern.png)

**Figure 5-20**: Caching in a cloud using cache through pattern

On top of this, in addition to providing [cache-aside pattern](https://www.alachisoft.com/resources/docs/ncache/prog-guide/read-through-caching.html) which is a very good pattern, NCache also provides cache-through pattern that is also very useful. Cache-through pattern provides all the features of cache-aside pattern but simplifies your application code greatly by shifting all of your application persistence logic inside the caching tier. In cache-through pattern, your application does not fetch data from the database directly. Instead, it always asks the cache for it. And, if the cache doesn’t have it, then the cache fetches it from your database or data-source by calling a [read-through](https://www.alachisoft.com/resources/docs/ncache/prog-guide/read-through-caching.html) handler that you’ve written and registered with the cache. The same thing happens when your application wants to update data as it updates the cache and the cache updates your database or data-source by calling a [write-through](https://www.alachisoft.com/resources/docs/ncache/prog-guide/write-through-caching.html) handler that you’ve written. 
Cache-through pattern also allows your cache to auto-reload data upon expiration or when [Sql Dependency](https://www.alachisoft.com/resources/docs/ncache/prog-guide/sql-dependency.html) invalidates a cached item. So, your cache becomes self-reliant in keeping data fresh. And, this simplifies your application’s code greatly.
NCache also provides support for [distributed data structures](https://www.alachisoft.com/ncache/distributed-data-structures-ncache.html) such as List, HashSet, Distributed queue, Dictionary, and Distributed Counter. Furthermore, NCache can be used as a messaging broker, providing a platform for the publisher-subscriber (Pub/Sub) model in your .NET application.

>[!div class="step-by-step"]
>[Previous](relational-vs-nosql-data.md)
>[Next](elastic-search-in-azure.md)
