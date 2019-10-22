---
title: Cloud-native data
description: Contrast data storage in monolithic and cloud-native applications
author: robvet
ms.date: 10/21/2019
---
# Cloud-native data

When architecting cloud-native systems, the way you think about data and data storage dramatically changes.

Traditional monolithic applications typically favor a centralized relational database, shown in Figure 5-1. 

![Single monolithic database](./media/single-monolithic-database.png)

**Figure 5-1**. Data storage in monolithic applications

The components in the monolithic app show in the previous figure all share the same relational database.

There are benefits to this approach. It's straightforward to query data as all data is in the same store. It's also straightforward to update data as [ACID transactions](https://docs.microsoft.com/windows/desktop/cossdk/acid-properties) guarantee data consistency. You end up with *immediate consistency*: All your data updates, or none of it does.

However, distributed cloud-native systems present a different set of requirements. They're typically built as a set of small, independent microservices that deploy frequently and evolve independently. Services scale separately and tend to be built in short development sprints where data is rapidly changing. 

For these reasons, cloud-native systems favor a distributed data architecture shown in Figure 5-2.

![Multiple databases across microservices](./media/data-across-microservices.png)

**Figure 5-2**. Distributed data storage across microservices

 Note in the figure above how each microservice owns and encapsulates its own data store. The service only exposes data to the outside world through its public API.
 
This distributed data model also provides many benefits. It enables each microservice to develop independently without having to coordinate data schema changes with other microservices. Each microservice is free to implement the data store (relational, document, key-value store) that best matches its needs for storage and read and write patterns. At runtime, each microservice can scale its data store accordingly. Figure 5-3 presents the principle of polyglot persistence in a cloud-native system. 

![Polyglot data persistence](./media/polyglot-data-persistence.png)

**Figure 5-3**. Polyglot data persistence

Note in the above figure how each microservice supports a different type of data store. The product catalog microservice supports a relational database to accommodate the relational structure of its underlying data. The shopping cart microservice has a simple data structure and supports a key-value data store, exposed as a distributed cache. The ordering microservice supports a NoSql document database for write operations and a denormalized key/value store to accommodate high-volumes of read operations. While relational databases remain relevant for microservices with complex data, NoSQL databases have gained considerable popularity. They provide adaptability, fast lookup, and high availability. Their schemaless nature allows developers to move away from an architecture of typed data classes and ORMs that make change expensive and time-consuming.

We'll explore these different types of data stores and some common cloud-native data patterns in this chapter.

>[!div class="step-by-step"]
>[Previous](service-mesh-communication-infrastructure.md)
>[Next](data-patterns.md)
