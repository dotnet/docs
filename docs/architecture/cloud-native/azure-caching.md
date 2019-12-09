---
title: Caching in a cloud-native application
description: Learn about caching strategies in a cloud-native application.
author: robvet
ms.date: 12/08/2019
---
# Caching in a cloud-native app

The benefits of caching to improve performance and scalability are well understood.

Caching is a widely accepted technique to improve the performance and scalability of individual services and the overall system. It works by temporarily copying frequently accessed data to fast storage that's located (somewhat) close to the application. Caching is most effective when a client repeatedly reads the same data, especially when the original data store...

 - Remains relatively static.
 - Is slow compared to the speed of the cache.
 - Is subject to a high level of contention.
 - Is far away where network latency can cause access to be slow.

## Caching architecture

Cloud native applications typically implement a distributed caching service, which guarantees that each microservice can access the same cached data. The cache is hosted as a cloud-based backing service, as discussed in Chapter 1. Figure 5-100 shows a caching architecture for a cloud-native application.

![Caching in a cloud native app](media/caching-in-a-cloud-native-app.png)

**Figure 5-19**: Caching in a cloud native app

Note in the figure above how the caching service is called from the API Gateway. The gateway serves as a front end for all incoming requests. It increases performance and responsiveness by returning cached data, avoiding round-trips to a database or downstream service.

A common caching pattern is the [cache-aside pattern](https://docs.microsoft.com/azure/architecture/patterns/cache-aside). For an incoming request, you first query the cache for the response, shown in step #1 in the previous figure. If found, the data is returned immediately. If the data doesn't exist in the cache (known as a [cache miss](https://www.techopedia.com/definition/6308/cache-miss)), it's retrieved from the local database or downstream service (step #2), written to the cache for future requests (step #3), and returned to the caller. Care must be taken to periodically evict cached data so that the system remains timely and consistent.

## Azure Redis Cache

[Azure Redis Cache](https://azure.microsoft.com/services/cache/) is a secure data caching and messaging broker service, fully managed by Microsoft. It provides high throughput and low-latency access to data for applications and is exposed as a PaaS (Platform as a Service) offering. The service is accessible to any application within or outside of Azure.

At its core, the open-source Redis server backs Azure Cache for Redis. The service natively supports data structures such as [strings](http://redis.io/topics/data-types#strings), [hashes](http://redis.io/topics/data-types#hashes), [lists](http://redis.io/topics/data-types#sets), [sets](http://redis.io/topics/data-types#sets), and [sorted sets](http://redis.io/topics/data-types#sorted-sets). If your application uses Redis, it will work as-is with Azure Cache for Redis.

Azure Cache for Redis can be used as an in-memory data structure store, a distributed non-relational database, and a message broker. Application performance is improved by taking advantage of the low-latency, high-throughput performance of the Redis engine.

Azure Cache for Redis is available in three different pricing tiers. The Premium tier features many enterprise-level features such as clustering, data persistence, geo-replication, and virtual-network isolation.

## Summary

This chapter presented a detailed look at data in cloud-native systems. We started by contrasting data storage in monolithic applications with that in cloud-native systems. We looked at data patterns implemented in cloud-native systems, including cross-service queries, distributed transactions, and patterns to deal with high-volume systems. We contrasted SQL with NoSQL data stores. We looked at data storage options available in Azure that include both Microsoft-centric and open-source options. Finally, we discussed caching in a cloud-native application.

### References

- [Command and Query Responsibility Segregation (CQRS) pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

- [Event Sourcing pattern](https://docs.microsoft.com/azure/architecture/patterns/event-sourcing)

- [RDBMSs vs. NoSQL Databases: Overview](https://maxivak.com/rdbms-vs-nosql-databases/)

- [Why isn't RDBMS Partition Tolerant in CAP Theorem and why is it Available?](https://stackoverflow.com/questions/36404765/why-isnt-rdbms-partition-tolerant-in-cap-theorem-and-why-is-it-available)

- [Materialized View](https://docs.microsoft.com/en-us/azure/architecture/patterns/materialized-view)

- [All you really need to know about open source databases](https://www.ibm.com/blogs/systems/all-you-really-need-to-know-about-open-source-databases/)

- [Compensating Transaction pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/compensating-transaction)

- [Saga Pattern](https://microservices.io/patterns/data/saga.html)

- [Saga Patterns | How to implement business transactions using microservices](https://blog.couchbase.com/saga-pattern-implement-business-transactions-using-microservices-part/)

- [Compensating Transaction pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/compensating-transaction)

- [Getting Behind the 9-Ball: Cosmos DB Consistency Levels Explained](https://blog.jeremylikness.com/blog/2018-03-23_getting-behind-the-9ball-cosmosdb-consistency-levels/)

- [Exploring the different types of NoSQL Databases Part II](https://www.3pillarglobal.com/insights/exploring-the-different-types-of-nosql-databases)
- [Microservice - Data Considerations](https://docs.microsoft.com/en-us/azure/architecture/microservices/design/data-considerations)

>[!div class="step-by-step"]
>[Previous](azure-data-storage.md)
>[Next](resiliency.md) <!-- Next Chapter -->