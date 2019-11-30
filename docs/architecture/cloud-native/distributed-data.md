---
title: Cloud-native data
description: Contrast data storage in monolithic and cloud-native applications
author: robvet
ms.date: 11/29/2019
---
# Database-per-microservice

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

While cloud native transforms the way you design systems, it also changes the way you manage and store data.

Figure 5-1 contrasts the differences.

![Data storage in cloud-native applications](./media/distributed-data.png)

**Figure 5-1**. Data management in cloud-native applications

Experienced developers will recognize the architecture on the left-side of figure 5-1. In a monolithic application, business service components collocate together in a shared services tier, sharing data from a single relational database.

In many ways, this approach keeps data management simple. Querying data across multiple tables is straightforward. Data changes update together or they all rollback. [ACID transactions](https://docs.microsoft.com/windows/desktop/cossdk/acid-properties) guarantee immediate consistency.

Designing for cloud-native, we take a different approach. On the right-side of Figure 5-1, note how business functionality segregates into small, independent microservices. Each microservice...

- Encapsulates specific business capabilities
- Evolves independently
- Deploys frequently
- Scales separately
- Isolates failure

The design also segregates the data for each microservice. The monolithic database decomposes into a distributed data model with many smaller databases, each aligning with a microservice. When the smoke clears, we emerge with a design that exposes a *database per microservice*.

## Why?

An application design that favors small, independent data stores scoped to each microservice provides many benefits, especially for larger systems that require massive scale and availability. With this model...

The database per microservices model provides many benefits, especially for larger systems that require massive scale and availability. With this model...

- Each microservice owns its own domain data
- Each can evolve its data schema without affecting other services
- Each can scale its data independently of others
- Each isolates itself from database failures in other services

Segregating data enables each microservice to implement the data store that is best optimized for its workload, storage needs, and read/write patterns. Choices include relational, document, key-value, and even graph-based data stores.

Figure 5-2 presents the principle of polyglot persistence in a cloud-native system.

![Polyglot data persistence](./media/polyglot-data-persistence.png)

**Figure 5-2**. Polyglot data persistence

Note in the above figure how each microservice supports a different type of data store.

- The product catalog microservice consumes a relational database to accommodate the rich relational structure of its underlying data.
- The shopping cart microservice consumes a distributed cache that supports its simple, key-value data store.
- The ordering microservice consumes both a NoSql document database for write operations along with a highly denormalized key/value store to accommodate high-volumes of read operations.
  
While relational databases remain relevant for microservices with complex data, NoSQL databases have gained considerable popularity. They provide massive scale and high availability. Their schemaless nature allows developers to move away from an architecture of typed data classes and ORMs that make change expensive and time-consuming.

## Increased complexity

 While isolating domain data in each microservice can increase agility, performance, and scalability, it also presents many challenges. In this section, we discuss these challenges along with patterns and practices to help overcome them.  

### Cross-service queries

While microservices are independent and focus on specific functional capabilities, like inventory, shipping, or ordering, they frequently require integration with other microservices to execute business operations. Often the integration involves one microservice *querying* another for data. Figure 5-4 shows the scenario.

![Querying across microservices](./media/cross-service-query.png)

**Figure 5-4**. Querying across microservices

In the preceding figure, we see a shopping basket microservice that adds an item to a user's shopping basket. While the data store for this microservice contains basket and line item data, it doesn't maintain product or pricing data. Instead, those data items are owned by the catalog and pricing microservices. This presents a problem. How can the shopping basket microservice add a product to the user's shopping basket when it doesn't have product nor pricing data in its database?

One option discussed in Chapter 4 is a [direct HTTP call](./service-to-service-communication.md#Request/Response-Messaging) from the shopping basket to the catalog and pricing microservices. However, we said synchronous HTTP calls *couple* microservices together, reducing their autonomy and diminishing their architectural benefits. 

We could also implement a [request-reply pattern](./service-to-service-communication.md#Request-reply-pattern) with separate inbound and outbound queues for each service. However, this pattern is complicated and requires plumbing to correlate request and response messages. Queue latency or an unresponsive microservice could block an operation that needs a data query response to complete.



applications/asynchronous-message-based-communication#asynchronous-event-driven-communication


Instead, a widely accepted pattern for removing cross-service dependencies is the [Materialized View Pattern](https://docs.microsoft.com/azure/architecture/patterns/materialized-view), shown in Figure 5-5.

![Materialized view pattern](./media/materialized-view-pattern.png)

**Figure5-5**. Materialized View Pattern

With this pattern, you place a local data table (known as a *read model*) in the shopping basket service. This table contains a denormalized copy of the data needed from the product and pricing microservices. Copying the data directly into the shopping basket microservice eliminates the need for expensive cross-service calls. With the data local to the service, you improve the service's response time and reliability. Additionally, having its own copy of the data makes the shopping basket service more resilient. If the catalog service should become unavailable, it wouldn't directly impact the shopping basket service. The shopping basket can continue operating with the data from its own store. 

The catch with this approach is that you now have duplicate data in your system. However, *strategically* duplicating data in cloud-native systems is an established practice and not considered an [anti-pattern](https://en.wikipedia.org/wiki/Anti-pattern). Keep in mind that *one and only one service* can own a dataset and have authority over it. You'll need to synchronize the read models when the system of record is updated. Synchronization is typically implemented via asynchronous messaging with a publish/subscribe pattern, also shown above in Figure 5.5







>[!div class="step-by-step"]
>[Previous](service-mesh-communication-infrastructure.md)
>[Next](data-patterns.md)




================================

As we've seen, a key pillar of a cloud-native system is a microservice-based architecture.

Cloud-native application design favor small, independent data stores scoped to each microservice.

Another option from Chapter 4 would involve the shopping basket microservice sending asynchronous messages to the catalog and pricing microservices using the request-reply pattern. The shopping basket microservice must then wait for both responses before it can continue. Implementing request-response semantics using asynchronous messaging is complicated. It requires both a send and receive queue along with plumbing to correlate the request and response message. Queue latency or an unresponsive microservice could block an operation that needs a data query response to complete.



We'll explore these different types of data stores and some common cloud-native data patterns in this chapter.