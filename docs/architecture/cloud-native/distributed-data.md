---
title: Cloud-native data
description: Contrast data storage in monolithic and cloud-native applications
author: robvet
ms.date: 10/14/2019
---
# Cloud-native data

When constructing a cloud native system, the way you think about data storage changes.

Traditional monolithic applications favor a straightforward data structure, typically a centralized data store, shown in Figure 5-1. 

![Single monolithic database](./media/single-monolithic-database.png)

**Figure 5-1**. Data storage in monolithic applications

In the previous figure, all of the components from the monolithic application consume a single, relational database.

There are many benefits to this approach. It's straightforward to query data as it's all in the same data store. It's straightforward to update data implementing [ACID transactions](https://docs.microsoft.com/windows/desktop/cossdk/acid-properties) that guarantee data consistency. You end up with *immediate consistency*: All your data updates, or none of it does.

Cloud native systems favor a distributed data architecture shown in Figure 5-2.

![Multiple databases across microservices](./media/data-across-microservices.png)

**Figure 5-2**. Distributed data storage across microservices

 In the previous figure, each microservice owns and encapsulates its own data store. The service only exposes data to the outside world through its public API.
 
The distributed data model also provides many benefits. It enables each microservice to evolve independently without having to coordinate data schema changes with other microservices. Each microservice is free to implement the data store (relational database, document database, key-value store) type that best matches its needs. At runtime, each microservice can scale its data accordingly. Polyglot persistence is shown in Figure 5-3

![Polyglot data persistence](./media/polyglot-data-persistence.png)

**Figure 5-3**. Polyglot data persistence

In the previous figure, the product catalog microservice favors a relational database, the ordering microservice, a NoSql document database, and the shopping cart microservice, an external key-value store. While relational databases remain relevant for microservices with complex data, NoSQL databases have gained considerable popularity. They provide adaptability, fast lookup, and high availability. Their schemaless nature allows developers to move away from an architecture of typed data classes and ORMs that make change expensive and time-consuming.

>[!div class="step-by-step"]
>[Previous](service-mesh-communication-infrastructure.md)
>[Next](data-patterns.md)
