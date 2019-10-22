## Azure Redis Cache

The benefits of caching to improve performance and scalability are well understood. 

For a cloud-native application, a common location to add caching is inside the API Gateway. The gateway serves as a front end for all incoming requests. By adding caching, you can increase performance and responsiveness by returning cached data and avoiding round-trips to downstream services. Figure 5-19 shows a caching architecture for a cloud-native application.

![Caching in a cloud-native app](./media/caching-in-a-cloud-native-app.png)

**Figure 5-19**: Caching in a cloud-native app

A common caching pattern is the [cache-aside pattern](https://docs.microsoft.com/azure/architecture/patterns/cache-aside). For an incoming request, you first query the cache for the response, shown in step #1 in Figure 5-19. If found, the data is returned immediately. If the data doesn't exist in the cache (known as a [cache miss](https://www.techopedia.com/definition/6308/cache-miss)), it's retrieved from the downstream service (step #2), written to the cache for future requests (step #3), and returned to the caller. Care must be taken to periodically evict stale cached data so that the system remains consistent and accurate.

Note in the previous figure that the cache isn't implemented locally within the boundaries of the service, but consumed as a cloud-based backing service, as discussed in Chapter 1.

[Azure Redis Cache](https://azure.microsoft.com/services/cache/) is a data caching and messaging broker service. It provides high throughput and low-latency access to data for applications. Azure hosts and fully manages the service. The service is accessible to any application within or outside of Azure.

Internally, Azure Cache for Redis is backed by the open-source [Redis server](https://redis.io/) and natively supports data structures such as:

- [strings](http://redis.io/topics/data-types#strings)
- [hashes](http://redis.io/topics/data-types#hashes)
- [lists](http://redis.io/topics/data-types#sets
- [sets](http://redis.io/topics/data-types#sets)
- [sorted sets](http://redis.io/topics/data-types#sorted-sets)

If your application uses the open-source Redis offering, it will work as-is with Azure Cache for Redis.

Azure Cache for Redis can also be used as an in-memory data cache, a distributed non-relational database, and a message broker. It's available in three different pricing tiers. The Premium tier features enterprise features such as clustering, data persistence, geo-replication, and Virtual-network security and isolation.