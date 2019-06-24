---
title: Distributed Data
description: Architecting Cloud Native .NET Apps for Azure | Distributed Data for Cloud Native Apps
ms.date: 06/30/2019
---
# Distributed Data for Cloud Native Apps

When constructing a cloud native system consisting of many independent, decoupled services, the way you think about data storage radically changes.

The traditional monolithic apps that we've built for years favor a centralized data store, typically a relational database as shown in Figure 5-1.

![Single monolithic database](media/single-monolithic-database.png)
**Figure 5-1**. Single monolithic database

In Figure 5-1, all application components consume a large relational enterprise database. There are several key benefits to this approach. It's straightforward to query data across multiple tables and straightforward to implement [ACID transactions](https://docs.microsoft.com/en-us/windows/desktop/cossdk/acid-properties), i,e, basic properties that ensure consistency across database transactions. You end up with *immediate consistency*: Either all your data updates or nothing updates.

On the contrary, cloud native systems favor a data architecture where, by design, each microservice owns and encapsulates its own data, as shown in Figure 5-2.

![Data across microservices](media/data-across-microservices.png)
**Figure 5-2**. Data across microservices

In Figure 5-2, note how each data store is encapsulated within the [bounded context](https://martinfowler.com/bliki/BoundedContext.html) of its encompassing microservice, exposing external access only via the microservice's public API.

Such data encapsulation buys a great deal of flexibility. Data for each service is decoupled, which enables services to deploy frequently and evolve independently without having to coordinate schema changes across other services. Each service is free to implement the data store that best matches its needs, as shown below in Figure 5-3, and can independently scale to fit its specific needs.

![Polyglot data persistence](media/polyglot-data-persistence.png)
**Figure 5-3**. Polyglot data persistence

In Figure 5-3, note how the ProductCatalog and Inventory microservices each bind to a full relational database, while the Ordering microservice leverages a NoSql document data store, and the ShoppingCart microservice leverages a simple externalized key-value store. While relational databases remain relevant for more complex microservices, NoSQL databases have gained considerable popularity, providing adaptability, fast lookup, and high availability. Their schemaless nature moves you away from an architecture of typed data classes and ORMs that make change expensive and time-consuming.


>[!div class="step-by-step"]
>[Previous](cross-service-communication.md)
>[Next](data-patterns.md)
