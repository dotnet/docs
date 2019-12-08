---
title: Cloud-native data
description: Contrast data storage in monolithic and cloud-native applications
author: robvet
ms.date: 12/08/2019
---
# Database-per-microservice

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

While a cloud-native approach transforms the way you design systems, it also changes the way you manage and store data.

Figure 5-1 contrasts the differences.

![Data storage in cloud-native applications](./media/distributed-data.png)

**Figure 5-1**. Data management in cloud-native applications

Experienced developers will recognize the architecture on the left-side of figure 5-1. In a *monolithic application*, business service components collocate together in a shared services tier, sharing data from a single relational database.

In many ways, a single database keeps data management simple. Querying data across multiple tables is straightforward. Changes to data update together or they all rollback. [ACID transactions](https://docs.microsoft.com/windows/desktop/cossdk/acid-properties) guarantee strong and immediate consistency.

Designing for cloud-native, we take a different approach. On the right-side of Figure 5-1, note how business functionality segregates into small, independent microservices. Each microservice encapsulates a specific business capability and its own data. The monolithic database decomposes into a distributed data model with many smaller databases, each aligning with a microservice. When the smoke clears, we emerge with a design that exposes a *database per microservice*.

## Why?

This database per microservice provides many benefits, especially for systems that must evolve rapidly and support massive scale. With this model...

- Domain data is encapsulated within the service
- Data schema can evolve without directly impacting other services
- Each data store can independently scale
- A data store failure in one service won't directly impact other services

Segregating data also enables each microservice to implement the data store type that is best optimized for its workload, storage needs, and read/write patterns. Choices include relational, document, key-value, and even graph-based data stores.

Figure 5-2 presents the principle of polyglot persistence in a cloud-native system.

![Polyglot data persistence](./media/polyglot-data-persistence.png)

**Figure 5-2**. Polyglot data persistence

Note in the above figure how each microservice supports a different type of data store.

- The product catalog microservice consumes a relational database to accommodate the rich relational structure of its underlying data.
- The shopping cart microservice consumes a distributed cache that supports its simple, key-value data store.
- The ordering microservice consumes both a NoSql document database for write operations along with a highly denormalized key/value store to accommodate high-volumes of read operations.
  
While relational databases remain relevant for microservices with complex data, NoSQL databases have gained considerable popularity. They provide massive scale and high availability. Their schemaless nature allows developers to move away from an architecture of typed data classes and ORMs that make change expensive and time-consuming. We cover NoSQL databases later in this chapter.

 While encapsulating  data into separate microservices can increase agility, performance, and scalability, it also presents many challenges. In the next section, we discuss these challenges along with patterns and practices to help overcome them.  

## Cross-service queries

While microservices are independent and focus on specific functional capabilities, like inventory, shipping, or ordering, they frequently require integration with other microservices. Often the integration involves one microservice *querying* another for data. Figure 5-3 shows the scenario.

![Querying across microservices](./media/cross-service-query.png)

**Figure 5-3**. Querying across microservices

In the preceding figure, we see a shopping basket microservice that adds an item to a user's shopping basket. While the data store for this microservice contains basket and line item data, it doesn't maintain product or pricing data. Instead, those data items are owned by the catalog and pricing microservices. This presents a problem. How can the shopping basket microservice add a product to the user's shopping basket when it doesn't have product nor pricing data in its database?

One option discussed in Chapter 4 is a [direct HTTP call](./service-to-service-communication.md#Request/Response-Messaging) from the shopping basket to the catalog and pricing microservices. However, in chapter 4, we said synchronous HTTP calls *couple* microservices together, reducing their autonomy and diminishing their architectural benefits.

We could also implement a [request-reply pattern](./service-to-service-communication.md#Request-reply-pattern) with separate inbound and outbound queues for each service. However, this pattern is complicated and requires plumbing to correlate request and response messages.
While it does decouple the backend microservice calls, the calling service must still synchronously wait for the call to complete. Network congestion, transient faults, or an overloaded microservice and can result in long-running and even failed operations.

Instead, a widely accepted pattern for removing cross-service dependencies is the [Materialized View Pattern](https://docs.microsoft.com/azure/architecture/patterns/materialized-view), shown in Figure 5-4.

![Materialized view pattern](./media/materialized-view-pattern.png)

**Figure5-4**. Materialized View Pattern

With this pattern, you place a local data table (known as a *read model*) in the shopping basket service. This table contains a denormalized copy of the data needed from the product and pricing microservices. Copying the data directly into the shopping basket microservice eliminates the need for expensive cross-service calls. With the data local to the service, you improve the service's response time and reliability. Additionally, having its own copy of the data makes the shopping basket service more resilient. If the catalog service should become unavailable, it wouldn't directly impact the shopping basket service. The shopping basket can continue operating with the data from its own store. 

The catch with this approach is that you now have duplicate data in your system. However, *strategically* duplicating data in cloud-native systems is an established practice and not considered an [anti-pattern](https://en.wikipedia.org/wiki/Anti-pattern). Keep in mind that *one and only one service* can own a dataset and have authority over it. You'll need to synchronize the read models when the system of record is updated. Synchronization is typically implemented via asynchronous messaging with a [publish/subscribe pattern](./service-to-service-communication.md#events), also shown above in Figure 5.5

## Distributed transactions

While querying data across microservices is difficult, implementing a transaction across several microservices is even more complex. The inherent challenge of maintaining data consistency across independent data sources in different microservices can't be understated. The lack of distributed transactions in cloud-native applications means that you must manage distributed transactions programmatically. You move from a world of *immediate consistency* to that of *eventual consistency*. 

Figure 5-5 shows the problem.

![Transaction in saga pattern](./media/saga-transaction-operation.png)

**Figure 5-5**. Implementing a transaction across microservices

In the preceding figure, five independent microservices participate in a distributed transaction that creates an order. Each microservice maintains its own data store and implements a local transaction for its store. To create the order, the local transaction for *each* individual microservice must succeed, or *all* must abort and roll back the operation. While built-in transactional support is available inside each of the microservices, there's no support for a distributed transaction that would span across all five services to keep data consistent.

Instead, you must construct this distributed transaction *programmatically*. 

A popular pattern for adding distributed transactional support is the [Saga pattern](https://blog.couchbase.com/saga-pattern-implement-business-transactions-using-microservices-part/). It's implemented by grouping local transactions together programmatically and sequentially invoking each one. If any of the local transactions fail, the Saga aborts the operation and invokes a set of [compensating transactions](https://docs.microsoft.com/azure/architecture/patterns/compensating-transaction). The compensating transactions undo the changes made by the preceding local transactions and restore data consistency. Figure 5-6 shows a failed transaction with the Saga pattern.

![Roll back in saga pattern](./media/saga-rollback-operation.png)

**Figure 5-6**. Rolling back a transaction

In the above figure, the *Update Inventory* operation has failed in the Inventory microservice. The Saga invokes a set of compensating transactions (in red) to adjust the inventory counts, cancel the payment and the order, and return the data for each microservice back to a consistent state.

Saga patterns are typically choreographed as a series of related events, or orchestrated as a set of related commands. In Chapter 4, we discussed the service aggregator pattern that would be the foundation for an orchestrated saga implementation. We also discussed eventing along with Azure Service Bus and Azure Event Grid *topics that would be a foundation for a choreographed saga implementation.

## High volume data

Cloud-native applications often support high-volume data requirements. In these scenarios, traditional data storage techniques sometimes cause bottlenecks. For complex systems that deploy on a large scale, both CQRS and Event Sourcing may be improve application performance.  

### CQRS

CQRS, or [Command and Query Responsibility Segregation](https://docs.microsoft.com/azure/architecture/patterns/cqrs), is an architectural pattern that can help maximize performance, scalability, and security. The pattern separates operations that read data from those that write data. 

For normal scenarios, the same entity model and [data repository](https://martinfowler.com/eaaCatalog/repository.html) object are used for *both* read and write operations.

However, a high volume data scenario can benefit from separate models and data tables for reads and writes. To improve performance, the read operation could query against a highly denormalized representation of the data to avoid expensive repetitive table joins and table locks. The *write* operation, known as a *command*, would update against a fully normalized representation of the data that would guarantee consistency. You then need to implement a mechanism to keep both representations in sync. Typically, whenever the write table is modified, it publishes an event that replicates the modification to the read table.

Figure 5-7 shows an implementation of the CQRS pattern.

![CQRS implementation](./media/cqrs-implementation.png)

**Figure 5-7**. CQRS implementation

In the previous figure, separate command and query models are implemented. Each data write operation is saved to the write store and then propagated to the read store. Pay close attention to how the data propagation process operates on the principle of [eventual consistency](http://www.cloudcomputingpatterns.org/eventual_consistency/). The read model eventually synchronizes with the write model, but there may be some lag in the process. We discuss eventual consistency in the next section.

This separation enables reads and writes to scale independently. Read operations use a schema optimized for queries, while the writes use a schema optimized for updates. Read queries go against denormalized data, while complex business logic can be applied to the write model. As well, you might impose tighter security on write operations than those concerning reads.

Implementing CQRS can improve application performance for cloud-native services. However, it does result in a more complex design. Apply this principle carefully and strategically to those sections of your cloud-native application that will benefit from it. For more on CQRS, see the Microsoft book [.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/apply-simplified-microservice-cqrs-ddd-patterns).

### Event Sourcing

Another approach to storing data involves [Event Sourcing](https://docs.microsoft.com/azure/architecture/patterns/event-sourcing).

A database typically stores the current state of a data entity. If a user changes their phone number, the customer record is updated with the new number. We always know the current state of a data item, but each update overwrites the previous state. Without some kind audit mechanism, we lose the history.

In high volume systems, however, overhead from transactional locking and frequent database update operations can sometimes impact database performance, responsiveness, and limit scalability.

Event Sourcing takes a different approach to capturing data. Each operation that affects data is added to an event store. Instead of changing the state of a data record, we append each change to a sequential list of past events - similar to an accountant's ledger. The Event Store becomes the system of record and is used to create materialized data views for a microservice. Processing each event in the sequence will project the current state of a data entity. Figure 5.7 depicts the pattern. 

![Event Sourcing](./media/event-sourcing.png)

**Figure 5-7**. Event Sourcing

In the figure above note how each entry (in blue) for a user's shopping cart is appended to the underlying event store. In the materialized view, the system derives the current state by replaying all the events associated with each shopping cart, which is then exposed back to the UI. Events can also be integrated with external systems and applications or queried to determine the current state of an entity.

Event sourcing provides an efficient write model since information is always appended with no locking - each event is immutable and there are no updates or deletes. This minimizes the contention found implementing database transactions.

Implementing read models using materialized views enables you to decouple from the write model and choose the best data store to optimize the needs of your application.

In the event of an incorrect event entry, a compensating event can be added cancel out the earlier event and correct the mistake.


can help prevent concurrent updates from causing conflicts because it avoids the requirement to directly update objects in the data store.

Based on the system requirements We can achieve better performance and scalability, but at the expense of complexity


-- Extra

This way we not only know the current state of the system but we can easily track how we reached this state.

Events can be replayed to create a projection of the current state for each data item. For example, the Shopping Basket microservice could maintain a materialized view for each customer

In addition, at any point it's possible for applications to read the history of events, and use it to materialize the current state of an entity by playing back and consuming all the events related to that entity. This can occur on demand to materialize a domain object when handling a request, or through a scheduled task so that the state of the entity can be stored as a materialized view to support the presentation layer.


What are some advantages of event sourcing?
- Ability to put the system in any prior state. Useful for debugging. (I.e. what did the system look like last week?)
- Having a true history of the system. Gives further benefits such as audit and traceability. In some fields this is required by law.
- We mitigate the negative effects of not being able to predict future needs, by storing all events and being able to create arbitrary read-side projections as needed. This allows for more nimble responses to new requirements.
- The kind of operations made on an event store is very limited, making the persistence very predictable and thus easing testing.
- Event stores are conceptually simpler than full RDBMS solutions, and it's easy to scale up from an in-memory list of events to a full-featured event store.
- Compensating actions are what you can add in order to correct actual mistakes. They are simply events which cancel out earlier events.

An optimization where a snapshot of the aggregate's state is also saved (conceptually) in the event queue every so often, so that event application can start from the snapshot instead of from scratch. This can speed things up. Snapshots can always be discarded or re-created as needed, since they represent computed information from the event stream.

just as in an accountant's ledger, incidentally.) 

Use cases:

Financial transactions, air traffic control systems

End with complexity of Event Sourcing.


>[!div class="step-by-step"]
>[Previous](service-mesh-communication-infrastructure.md)
>[Next](data-patterns.md)
