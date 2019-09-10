---
title: Distributed data
description: Architecting Cloud Native .NET Apps for Azure | Distributed Data for Cloud Native Apps
ms.date: 06/30/2019
---
# Distributed data for cloud native apps

When constructing a cloud native system that consists of many independent microservices, the way you think about data storage changes.

Traditional monolithic applications favor a centralized data store shown in Figure 5-1. 

![Single monolithic database](media/single-monolithic-database.png)

**Figure 5-1**. Single monolithic database

Note in the previous figure how all of the application components consume a single relational database.

There are many benefits to this approach. It's straightforward to query data spread across  multiple tables, and it's straightforward to implement [ACID transactions](https://docs.microsoft.com/windows/desktop/cossdk/acid-properties) that ensure data consistency. You always end up with *immediate consistency*: Either all your data updates or none of it does.

Cloud native systems favor a data architecture shown in Figure 5-2 in which each microservice owns and encapsulates its own data.

![Multiple databases across microservices](media/data-across-microservices.png)

**Figure 5-2**. Multiple databases across microservices

Note how in the previous figure each microservice owns and encapsulates it data store and only exposes data to the outside world from its public API.
 
This model enables each microservice to evolve independently without having to coordinate data schema changes with other microservices. Each microservice is free to implement the data store (relational database, document database, key-value store) type that best matches its needs. At runtime, each microservice can scale its data accordingly. This is shown in Figure 5-3

![Polyglot data persistence](media/polyglot-data-persistence.png)

**Figure 5-3**. Polyglot data persistence

Note how in the previous figure the product catalog and inventory microservices adopt relational databases, the ordering microservice, a NoSql document database and the shopping cart microservice, an external key-value store. While relational databases remain relevant for microservices with complex data, NoSQL databases have gained considerable popularity, providing adaptability, fast lookup, and high availability. Their schemaless nature allows developers to move away from an architecture of typed data classes and ORMs that make change expensive and time-consuming.

>[!div class="step-by-step"]
>[Previous](service-mesh-communication-infrastructure.md)
>[Next](data-patterns.md)
