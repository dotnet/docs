---
title: Distributed data
description: Architecting Cloud Native .NET Apps for Azure | Distributed Data for Cloud Native Apps
ms.date: 06/30/2019
---
# Distributed data for cloud native apps

When constructing a cloud native system that consists of many independent, decoupled microservices, the way you think about data storage changes.

Traditional monolthic applicaitons favor a centralized data store shown in Figure 5-1. 

![Single monolithic database](media/single-monolithic-database.png)

**Figure 5-1**. Single monolithic database

Note in the previous figure how all of the application components consume a single relational database.

There are many benefits to this approach. It's straightforward to query data spread across  multiple tables, and it's straightforward to implement [ACID transactions](https://docs.microsoft.com/windows/desktop/cossdk/acid-properties) that ensure data consistency. You always end up with *immediate consistency*: Either all your data updates or none of it updates.

Cloud native systems favor a data architecture where each microservice owns and encapsulates its own data shown in Figure 5-2.

![Multiple databases across microservices](media/data-across-microservices.png)

**Figure 5-2**. Multiple databases across microservices

Note how in the previous figure each data store is encapsulated within a single microservice exposing its data to the outside world only from the microservice's public API.
 
In this model, the data for each service is owned and managed by that service, enabling it to evolve independently without having to coordinate data schema changes with other services. Each service is free to implement the data store (relational database, document database, key-value store) type that best matches its needs shown in Figure 5-3. At runtime, each service can scale its data accordingly.

![Polyglot data persistence](media/polyglot-data-persistence.png)

**Figure 5-3**. Polyglot data persistence

Note how in the previous figure the product catalog and inventory microservices adopt relational databases, the ordering microservice, a NoSql document database and the shopping cart microservice, an external key-value store. While relational databases remain relevant for microservices with complex data, NoSQL databases have gained considerable popularity, providing adaptability, fast lookup, and high availability. Their schemaless nature move you away from an architecture of typed data classes and ORMs that make change expensive and time-consuming.


>[!div class="step-by-step"]
>[Previous](cross-service-communication.md)
>[Next](data-patterns.md)
