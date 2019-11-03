---
title: Cloud-native data patterns
description: Learn about common data patterns found in cloud-native applications
author: robvet
ms.date: 11/01/2019
---
# Cloud-native data patterns

As we've seen, a key pillar of a cloud-native system is a microservice-based architecture. Microservices favor small, independent data stores scoped to each service. While isolating data can increase agility, performance, and scalability, it also presents many challenges. In this section, we discuss these challenges and present patterns and practices to help overcome them.  

## Cross-service queries

While microservices are independent and focus on specific functional capabilities, like inventory, shipping, or ordering, they frequently require integration with other microservices to execute business operations. Often the integration involves one microservice *querying* another for data. Figure 5-4 shows the scenario.

![Querying across microservices](./media/cross-service-query.png)

**Figure 5-4**. Querying across microservices

In the preceding figure, we see a shopping basket microservice that adds an item to a user's shopping basket. While the data store for this microservice contains basket and line item data, it doesn't maintain product or pricing data. Instead, those data items are found in the catalog and pricing microservices. This presents a problem. How can the shopping basket microservice add a product to the user's shopping basket when it doesn't have product nor pricing data in its database? 

One option discussed in Chapter 4 is a direct HTTP call from the shopping basket to the catalog and pricing microservices. However, we said direct HTTP calls *couple* microservices together, reducing their autonomy and diminishing their architectural benefits. 

Another option from Chapter 4 would involve the shopping basket microservice sending asynchronous messages to the catalog and pricing microservices using the request-reply pattern. The shopping basket microservice must then wait for both responses before it can continue. Implementing request-response semantics using asynchronous messaging is complicated. It requires both a send and receive queue along with plumbing to correlate the request and response message. Queue latency or an unresponsive microservice could block an operation that needs a data query response to complete.

As you can see, querying data across microservices is complex. A widely accepted pattern for removing cross-service dependencies is the [Materialized View Pattern](https://docs.microsoft.com/azure/architecture/patterns/materialized-view), shown in Figure 5-5.

![Materialized view pattern](./media/materialized-view-pattern.png)

**Figure5-5**. Materialized View Pattern

With this pattern, you place a local data table (known as a *read model*) in the shopping basket service. This table contains a denormalized copy of the data needed from the product and pricing microservices. Copying the data directly into the shopping basket microservice eliminates the need for expensive cross-service calls. With the data local to the service, you improve the service's response time and reliability. Additionally, having its own copy of the data makes the shopping basket service more resilient. If the catalog service should become unavailable, it wouldn't directly impact the shopping basket service. The shopping basket can continue operating with the data from its own store. 

The catch with this approach is that you now have duplicate data in your system. However, *strategically* duplicating data in cloud-native systems is an established practice and not considered an [anti-pattern](https://en.wikipedia.org/wiki/Anti-pattern). Keep in mind that *one and only one service* can own a dataset and have authority over it. You'll need to synchronize the read models when the system of record is updated. Synchronization is typically implemented via asynchronous messaging with a publish/subscribe pattern, also shown above in Figure 5.5

## Transactional support

While querying data across microservices is difficult, implementing a transaction across several microservices is even more complex. The inherent challenge of maintaining data consistency across independent data sources in different microservices can't be understated. The lack of distributed transactions in cloud-native applications means that you must manage distributed transactions programmatically. You move from a world of *immediate consistency* to that of *eventual consistency*. 

Figure 5-6 shows the problem.

![Transaction in saga pattern](./media/saga-transaction-operation.png)

**Figure 5-6**. Implementing a transaction across microservices

In the preceding figure, five independent microservices participate in a distributed transaction that creates an order. Each microservice maintains its own data store and implements a local transaction for its store. To create the order, the local transaction for *each* individual microservice must succeed, or *all* must abort and roll back the operation. While built-in transactional support is available inside each of the microservices, there's no support for a distributed transaction that would span across all five services to keep data consistent.

Instead, you must construct this distributed transaction *programmatically*. 

A popular pattern for adding distributed transactional support is the [Saga pattern](https://blog.couchbase.com/saga-pattern-implement-business-transactions-using-microservices-part/). It's implemented by grouping local transactions together programmatically and sequentially invoking each one. If any of the local transactions fail, the Saga aborts the operation and invokes a set of [compensating transactions](https://docs.microsoft.com/azure/architecture/patterns/compensating-transaction). The compensating transactions undo the changes made by the preceding local transactions and restore data consistency. Figure 5-7 shows a failed transaction with the Saga pattern.

![Roll back in saga pattern](./media/saga-rollback-operation.png)

**Figure 5-7**. Rolling back a transaction

In the above figure, the *GenerateContent* operation has failed in the music microservice. The Saga invokes a set of compensating transactions (in red) to remove the content, cancel the payment and the order, and return the data for each microservice back to a consistent state.

Saga patterns are typically choreographed as a series of related events, or orchestrated as a set of related commands. In Chapter 4, we discussed the service aggregator pattern that would be the foundation for an orchestrated saga implementation. We also discussed eventing along with Azure Service Bus and Azure Event Grid *topics that would be a foundation for a choreographed saga implementation.

## CQRS pattern

Cloud-native applications often support high-volume data requirements. In these scenarios, traditional data storage techniques sometimes cause performance bottlenecks. CQRS, or [Command and Query Responsibility Segregation](https://docs.microsoft.com/azure/architecture/patterns/cqrs), is an architectural pattern that can help maximize performance, scalability, and security. The pattern separates operations that read data from operations that write data. 

For normal scenarios, the data entity model and repository object are used for *both* read and write operations.

However, a high volume data scenario can benefit from separate models and data tables for reads and writes. To improve performance, the read operation could query against a highly denormalized representation of the data to avoid expensive repetitive table joins. The *write* operation, known as a *command*, would update against a fully normalized representation of the data. You then need to implement a mechanism to keep both representations in sync. Typically, whenever the write table is modified, it publishes an event that replicates the modification to the read table.

Figure 5-8 shows an implementation of the CQRS pattern.

![CQRS implementation](./media/cqrs-implementation.png)

**Figure 5-8**. CQRS implementation

Note in the previous figure how separate command and query models are implemented. Each data write operation is saved to the write store and then propagated to the read store. Pay close attention to how the data propagation process operates on the principle of [eventual consistency](http://www.cloudcomputingpatterns.org/eventual_consistency/). The read model eventually synchronizes with the write model, but there may be some lag in the process. We discuss eventual consistency in the next section.

This separation enables reads and writes to scale independently. Read operations use a schema optimized for queries, while the writes use a schema optimized for updates. Read queries go against denormalized data, while complex business logic can be applied to the write model. As well, you might impose tighter security on write operations than those concerning reads.

Implementing CQRS can improve application performance for cloud-native services. However, it does result in a more complex design. Apply this principle strategically to those sections of your cloud-native application that will most benefit from it.

## Relational vs NoSQL

The impact of [NoSQL](https://www.geeksforgeeks.org/introduction-to-nosql/) technologies for distributed cloud-native systems can't be overstated. The proliferation of new data technologies in this space has disrupted solutions that once exclusively relied on relational databases.

Relational databases have been a prevalent technology for decades. They're mature, proven, and widely implemented. Competing database products, tooling, and expertise abound. Relational databases provide a store of related data tables. These tables have a fixed schema, use SQL (Structured Query Language) to manage data, and support [ACID](https://www.geeksforgeeks.org/acid-properties-in-dbms/) guarantees. 

No-SQL databases refer to high-performance, non-relational data stores. They excel in their ease-of-use, scalability, resilience, and availability characteristics. Instead of joining tables of normalized data, NoSQL stores self-describing (schemaless) data typically in JSON documents. No-SQL databases typically don't provide [ACID](https://www.geeksforgeeks.org/acid-properties-in-dbms/) guarantees beyond the scope of a single database partition.

As a way to understand the differences between these types of databases, consider the [CAP theorem](https://towardsdatascience.com/cap-theorem-and-distributed-database-management-systems-5c2be977950e), a set of principles applied to distributed systems that store state. Figure 5-9 shows the three properties of the CAP theorem.

![CAP theorem](./media/cap-theorem.png)

**Figure 5-9**. The CAP theorem

The theorem states that distributed data systems will offer a trade-off between consistency, availability, and partition tolerance. And, that any database can only guarantee *two* of the three properties:

- *Consistency.* Every node in the cluster will respond with the most recent data, even if the system must block the request until all replicas update. If you query a "consistent system" for an item that is updating, you'll wait for that response until all replicas successfully update. However, you'll receive the most current data.

- *Availability.* Every node will return an immediate response, even if that response isn't the most recent data. If you query an "available system" for an item that is updating, you'll get the best possible answer the service can provide at that moment - even if the update hasn't replicated. 

- *Partition Tolerance.* Guarantees that the system will continue to operate if a replicated data node fails or loses connectivity with other replicated data nodes. 

Relational databases typically provide consistency and availability, but not partition tolerance. Relational databases scale-up, or vertically. Horizontally partitioning a relational database across multiple nodes, such as with [sharding](https://www.digitalocean.com/community/tutorials/understanding-database-sharding), is costly and time consuming to manage. Sharding can end up impacting performance, table joins, and referential integrity.

If data replicas were to lose network connectivity in a "highly consistent" relational database cluster, you wouldn't be able to write to the database. The system would reject the write operation as it can't replicate that change to every underlying data replica. Every data replica has to update before the transaction can complete.

NoSQL databases typically support high availability and partition tolerance. They scale out horizontally, often across commodity servers. This approach provides tremendous availability, both within and across geographical regions at a reduced cost. You partition and replicate data across these machines, or nodes, providing redundancy and fault tolerance. The downside is consistency. A change to data on one NoSQL node can take some time to propagate to other nodes. Typically, a NoSQL database node will provide an immediate response to a query - even if the data that is presented is stale and hasn't updated yet.

If data replicas were to lose connectivity in a "highly available" NoSQL database cluster, you could still complete a write operation to the database. The database cluster would allow the write operation and update each data replica as it becomes available.

This kind of result is known as [eventual consistency](http://www.cloudcomputingpatterns.org/eventual_consistency/), a characteristic of distributed data systems where ACID transactions aren't supported. It's a brief delay between the update of a data item and time that it takes to propagate that update to each of the replica nodes. Under normal conditions, the lag is typically short, but can increase when problems arise. For example, what would happen if you were to update a product item in a NoSQL database in the United States and query that same data item from a replica node in Europe? You would receive the earlier product information, until the cluster updates the European node with the product change. By immediately returning a query result and not waiting for all replica nodes to update, you gain enormous scale and volume, but with the possibility of presenting older data.

Cloud-native services typically favor the guarantees of data availability and partition tolerance over strong consistency. To the business, high availability and massive scalability are often more critical than consistency. As we've discussed, developers can implement techniques and patterns such as Sagas, CQRS, and asynchronous messaging that embraces eventual consistency.  

> Some care must be taken with these descriptions as some databases support configurations that can *"toggle"* these principles. For example, MySQL can be configured as either consistent and available or available and partition tolerant. Azure Cosmos DB also support five different consistency models as we'll see in the next section.

NoSQL databases include a variety of data models for accessing and managing data:

- *Document Store* (mongodb, couchdb, couchbase) - Data and corresponding metadata are stored hierarchically in JSON-based documents inside the database. Their schemaless nature enables developers to add or modify data properties as business requirements change, helping to promote rapid development.

- *Key/Value Store* (redis, riak, memcached) - The simplest of the NoSQL databases, data is represented as a collection of key-value pairs. These lightweight stores are capable of achieving large degrees of horizontal scale.  System operations are performed against a unique access key that maps to user data. The user data, or *value* component, can be a string value, JSON document, or even a BLOB (large binary object). 
  
- *Wide-Column Store* (hbase, Cassandra) - Related data is stored as a set of nested-key/value pairs within a single column. Read/write operations query against columns rather than rows. Popular for analytical workloads, columnar data can be retrieved as a single unit. Storing data in columns enables fast searching and data aggregation.

- *Graph stores* (neo4j, titan) - Data is stored in a graph structure in the form of nodes, edges, and data properties. The *edges* represent relationships between nodes and are stored directly with the data. With this storage pattern, you can quickly traverse large amounts of related data. A recommendation engine is the classical use case for a graph database. It searches your browsing and purchase history along with that of other customers to recommend items to purchase.
  
Based upon specific data needs, a cloud-native-based microservice can either implement a relational, or a NoSQL datastore or both.

|  Consider a NoSQL datastore when: | Consider a relational database when: | 
| :-------- | :-------- |
| You have high volume workloads that require large scale | Your workload volume is consistent and requires medium to large scale |
| Your workloads don't require ACID guarantees |  ACID guarantees are required |
| Your data is dynamic and frequently changes | Your data is predictable and highly structured |
| Data can be expressed without relationships | Data is best expressed relationally |  
| You need fast writes and write safety isn't critical | Write safety is a requirement |  
| Data retrieval is simple and tends to be flat | You work with complex queries and reports|
| Your data requires a wide geographic distribution | Your users are more centralized | 
| Your application will be deployed to commodity hardware, such as with public clouds | Your application will be deployed to large, high-end hardware | 
|||

Next, we look at how data storage requirements for cloud-natve systems can be implemented in the Azure cloud.

>[!div class="step-by-step"]
>[Previous](distributed-data.md)
>[Next](azure-data-storage.md)
