---
title: Cloud-native data
description: Contrast data storage in monolithic and cloud-native applications
author: robvet
ms.date: 10/29/2019
---
# Cloud-native data

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

While cloud native transforms the way you design systems, it also changes the way you manage and store data.

To experienced developers, the shared, monolithic database from figure 5-1 should look all too familiar.

![Single monolithic database](./media/single-monolithic-database.png)

**Figure 5-1**. Data storage in monolithic applications

In the above figure, all of the application components collocate together in the application services tier and share the same data from a single relational database.

In many ways, this approach keeps data management simple. Data is straightforward to query across multiple tables and straightforward to update. [ACID transactions](https://docs.microsoft.com/windows/desktop/cossdk/acid-properties) guarantee immediate consistency. Data changes update together or they all rollback.

With cloud native, however, we embrace a more complex system design: Applications are built as small, independent microservices. These services...

- Encapsulate specific business capabilities
- Evolve independently
- Deploy frequently
- Scale separately
- Isolate failure

Just as we segregate business functionality into separate microservices, we also segregate the data for each service. Moving from a shared database model, each microservice encapsulates its data in its own data store as illustrated in Figure 5-2.

![Each microservice owns it own data](./media/data-across-microservices.png)

**Figure 5-2**. Each microservice owns it own data

In the figure above, each microservice owns and encapsulates its data. The monolithic database model decomposes into a *distributed data model* with many smaller databases that each align with a microservice.

This distributed data model provides many benefits:

- Each microservice owns its own domain data.
- Each microservice can evolve its data schema without affecting other microservices.
- Each microservice can scale its own data independently of others.
- Each microservice improves it resiliency from failures in other services.

This data independence also enables each microservice to implement the data store that is best optimized for its workload, storage needs, and read/write patterns. Choices include relational, document, key-value, and even graph-based data stores.

Figure 5-3 presents the principle of polyglot persistence in a cloud-native system.

![Polyglot data persistence](./media/polyglot-data-persistence.png)

**Figure 5-3**. Polyglot data persistence

Note in the above figure how each microservice supports a different type of data store.

- The product catalog microservice consumes a relational database to accommodate the relational structure of its underlying data.
- The shopping cart microservice consumes a distributed cache that supports its simple, key-value data store.
- The ordering microservice consumes both a NoSql document database for write operations along with a highly denormalized key/value store to accommodate high-volumes of read operations.
  
While relational databases remain relevant for microservices with complex data, NoSQL databases have gained considerable popularity. They provide adaptability, massive scale, and high availability. Their schemaless nature allows developers to move away from an architecture of typed data classes and ORMs that make change expensive and time-consuming.

We'll explore these different types of data stores and some common cloud-native data patterns in this chapter.

>[!div class="step-by-step"]
>[Previous](service-mesh-communication-infrastructure.md)
>[Next](data-patterns.md)
