---
title: Microservices architecture | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Microservices architecture
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Microservices architecture

As the name implies, a microservices architecture is an approach to building a server application as a set of small services. Each service runs in its own process and communicates with other processes using protocols such as HTTP/HTTPS, WebSockets, or [AMQP](https://en.wikipedia.org/wiki/Advanced_Message_Queuing_Protocol). Each microservice implements a specific end-to-end domain or business capability within a certain context boundary, and each must be developed autonomously and be deployable independently. Finally, each microservice should own its related domain data model and domain logic (sovereignty and decentralized data management) based on different data storage technologies (SQL, NoSQL) and different programming languages.

What size should a microservice be? When developing a microservice, size should not be the important point. Instead, the important point should be to create loosely coupled services so you have autonomy of development, deployment, and scale, for each service. Of course, when identifying and designing microservices, you should try to make them as small as possible as long as you do not have too many direct dependencies with other microservices. More important than the size of the microservice is the internal cohesion it must have and its independence from other services.

Why a microservices architecture? In short, it provides long-term agility. Microservices enable better maintainability in complex, large, and highly-scalable systems by letting you create applications based on many independently deployable services that each have granular and autonomous lifecycles.

As an additional benefit, microservices can scale out independently. Instead of having a single monolithic application that you must scale out as a unit, you can instead scale out specific microservices. That way, you can scale just the functional area that needs more processing power or network bandwidth to support demand, rather than scaling out other areas of the application that do not need to be scaled. That means cost savings because you need less hardware.

![](./media/image6.png){width="6.6349748468941385in" height="3.516587926509186in"}

**Figure 4-6**. Monolithic deployment versus the microservices approach

As Figure 4-6 shows, the microservices approach allows agile changes and rapid iteration of each microservice, because you can change specific, small areas of complex, large, and scalable applications.

Architecting fine-grained microservices-based applications enables continuous integration and continuous delivery practices. It also accelerates delivery of new functions into the application. Fine-grained composition of applications also allows you to run and test microservices in isolation, and to evolve them autonomously while maintaining clear contracts between them. As long as you do not change the interfaces or contracts, you can change the internal implementation of any microservice or add new functionality without breaking other microservices.

The following are important aspects to enable success in going into production with a microservices-based system:

-   Monitoring and health checks of the services and infrastructure.

-   Scalable infrastructure for the services (that is, cloud and orchestrators).

-   Security design and implementation at multiple levels: authentication, authorization, secrets management, secure communication, etc.

-   Rapid application delivery, usually with different teams focusing on different microservices.

-   DevOps and CI/CD practices and infrastructure.

Of these, only the first three are covered or introduced in this guide. The last two points, which are related to application lifecycle, are covered in the additional [Containerized Docker Application Lifecycle with Microsoft Platform and Tools](https://aka.ms/dockerlifecycleebook) eBook.

### Additional resources

-   **Mark Russinovich. Microservices: An application revolution powered by the cloud**\
    [*https://azure.microsoft.com/en-us/blog/microservices-an-application-revolution-powered-by-the-cloud/*](https://azure.microsoft.com/en-us/blog/microservices-an-application-revolution-powered-by-the-cloud/)

-   **Martin Fowler. Microservices**\
    [*http://www.martinfowler.com/articles/microservices.html*](http://www.martinfowler.com/articles/microservices.html)

-   **Martin Fowler. Microservice Prerequisites**\
    [*http://martinfowler.com/bliki/MicroservicePrerequisites.html*](http://martinfowler.com/bliki/MicroservicePrerequisites.html)

-   **Jimmy Nilsson. Chunk Cloud Computing**\
    *<https://www.infoq.com/articles/CCC-Jimmy-Nilsson> *

-   **Cesar de la Torre. Containerized Docker Application Lifecycle with Microsoft Platform and Tools** (downloadable eBook)\
    [*https://aka.ms/dockerlifecycleebook*](https://aka.ms/dockerlifecycleebook)


## Data sovereignty per microservice

An important rule for microservices architecture is that each microservice must own its domain data and logic. Just as a full application owns its logic and data, so must each microservice own its logic and data under an autonomous lifecycle, with independent deployment per microservice.

This means that the conceptual model of the domain will differ between subsystems or microservices. Consider enterprise applications, where customer relationship management (CRM) applications, transactional purchase subsystems, and customer support subsystems each call on unique customer entity attributes and data, and where each employs a different Bounded Context (BC).

This principle is similar in [domain-driven design (DDD)](https://en.wikipedia.org/wiki/Domain-driven_design), where each [Bounded Context](https://martinfowler.com/bliki/BoundedContext.html) or autonomous subsystem or service must own its domain model (data plus logic and behavior). Each DDD Bounded Context correlates to one business microservice (one or several services). (We expand on this point about the Bounded Context pattern in the next section.)

On the other hand, the traditional (monolithic data) approach used in many applications is to have a single centralized database or just a few databases. This is often a normalized SQL database that is used for the whole application and all its internal subsystems, as shown in Figure 4-7.

![](./media/image7.png){width="6.239583333333333in" height="3.7558442694663166in"}

**Figure 4-7**. Data sovereignty comparison: monolithic database versus microservices

The centralized database approach initially looks simpler and seems to enable reuse of entities in different subsystems to make everything consistent. But the reality is you end up with huge tables that serve many different subsystems, and that include attributes and columns that are not needed in most cases. it is like trying to use the same physical map for hiking a short trail, taking a day-long car trip, and learning geography.

A monolithic application with typically a single relational database has two important benefits: [ACID transactions](https://en.wikipedia.org/wiki/ACID) and the SQL language, both working across all the tables and data related to your application. This approach provides a way to easily write a query that combines data from multiple tables.

However, data access becomes much more complex when you move to a microservices architecture. But even when ACID transactions can or should be used within a microservice or Bounded Context, the data owned by each microservice is private to that microservice and can only be accessed via its microservice API. Encapsulating the data ensures that the microservices are loosely coupled and can evolve independently of one another. If multiple services were accessing the same data, schema updates would require coordinated updates to all the services. This would break the microservice lifecycle autonomy. But distributed data structures mean that you cannot make a single ACID transaction across microservices. This in turn means you must use eventual consistency when a business process spans multiple microservices. This is much harder to implement than simple SQL joins; similarly, many other relational database features are not available across multiple microservices.

Going even further, different microservices often use different *kinds* of databases. Modern applications store and process diverse kinds of data, and a relational database is not always the best choice. For some use cases, a NoSQL database such as Azure DocumentDB or MongoDB might have a more convenient data model and offer better performance and scalability than a SQL database like SQL Server or Azure SQL Database. In other cases, a relational database is still the best approach. Therefore, microservices-based applications often use a mixture of SQL and NoSQL databases, which is sometimes called the [polyglot persistence](http://martinfowler.com/bliki/PolyglotPersistence.html) approach.

A partitioned, polyglot-persistent architecture for data storage has many benefits. These include loosely coupled services and better performance, scalability, costs, and manageability. However, it can introduce some distributed data management challenges, as we will explain in “[Identifying domain-model boundaries](#identifying-domain-model-boundaries-for-each-microservice)” later in this chapter.

## The relationship between microservices and the Bounded Context pattern

The concept of microservice derives from the [Bounded Context (BC) pattern](http://martinfowler.com/bliki/BoundedContext.html) in [domain-driven design (DDD)](https://en.wikipedia.org/wiki/Domain-driven_design). DDD deals with large models by dividing them into multiple BCs and being explicit about their boundaries. Each BC must have its own model and database; likewise, each microservice owns its related data. In addition, each BC usually has its own [ubiquitous language](http://martinfowler.com/bliki/UbiquitousLanguage.html) to help communication between software developers and domain experts.

Those terms (mainly domain entities) in the ubiquitous language can have different names in different Bounded Contexts, even when different domain entities share the same identity (that is, the unique ID that is used to read the entity from storage). For instance, in a user-profile Bounded Context, the User domain entity might share identity with the Buyer domain entity in the ordering Bounded Context.

A microservice is therefore like a Bounded Context, but it also specifies that it is a distributed service. It is built as a separate process for each Bounded Context, and it must use the distributed protocols noted earlier, like HTTP/HTTPS, WebSockets, or [AMQP](https://en.wikipedia.org/wiki/Advanced_Message_Queuing_Protocol). The Bounded Context pattern, however, does not specify whether the Bounded Context is a distributed service or if it is simply a logical boundary (such as a generic subsystem) within a monolithic-deployment application.

It is important to highlight that defining a service for each Bounded Context is a good place to start. But you do not have to constrain your design to it. Sometimes you must design a Bounded Context or business microservice composed of several physical services. But ultimately, both patterns—Bounded Context and microservice—are closely related.

DDD benefits from microservices by getting real boundaries in the form of distributed microservices. But ideas like not sharing the model between microservices are what you also want in a Bounded Context.

### Additional resources

-   **Chris Richardson. Pattern: Database per service\
    ***<http://microservices.io/patterns/data/database-per-service.html> *

-   **Martin Fowler. BoundedContext\
    **[*http://martinfowler.com/bliki/BoundedContext.html*](http://martinfowler.com/bliki/BoundedContext.html)

-   **Martin Fowler. PolyglotPersistence\
    **[*http://martinfowler.com/bliki/PolyglotPersistence.html*](http://martinfowler.com/bliki/PolyglotPersistence.html)

-   **Alberto Brandolini. Strategic Domain Driven Design with Context Mapping\
    **[*https://www.infoq.com/articles/ddd-contextmapping*](https://www.infoq.com/articles/ddd-contextmapping)[[]{#_Toc480368187 .anchor}]{#_Toc480361355 .anchor}

## Logical architecture versus physical architecture

It is useful at this point to stop and discuss the distinction between logical architecture and physical architecture, and how this applies to the design of microservice-based applications.

To begin, building microservices does not require the use of any specific technology. For instance, Docker containers are not mandatory in order to create a microservice-based architecture. Those microservices could also be run as plain processes. Microservices is a logical architecture.

Moreover, even when a microservice could be physically implemented as a single service, process, or container (for simplicity’s sake, that is the approach taken in the initial version of [eShopOnContainers](http://aka.ms/MicroservicesArchitecture)), this parity between business microservice and physical service or container is not necessarily required in all cases when you build a large and complex application composed of many dozens or even hundreds of services.

This is where there is a difference between an application’s logical architecture and physical architecture. The logical architecture and logical boundaries of a system do not necessarily map one-to-one to the physical or deployment architecture. It can happen, but it often does not.

Although you might have identified certain business microservices or Bounded Contexts, it does not mean that the best way to implement them is always by creating a single service (such as an ASP.NET Web API) or single Docker container for each business microservice. Having a rule saying each business microservice has to be implemented using a single service or container is too rigid.

Therefore, a business microservice or Bounded Context is a logical architecture that might coincide (or not) with physical architecture. The important point is that a business microservice or Bounded Context must be autonomous by allowing code and state to be independently versioned, deployed, and scaled.

As Figure 4-8 shows, the catalog business microservice could be composed of several services or processes. These could be multiple ASP.NET Web API services or any other kind of services using HTTP or any other protocol. More importantly, the services could share the same data, as long as these services are cohesive with respect to the same business domain.

![](./media/image8.png){width="2.9270833333333335in" height="1.8192629046369204in"}

**Figure 4-8**. Business microservice with several physical services

The services in the example share the same data model because the Web API service targets the same data as the Search service. So, in the physical implementation of the business microservice, you are splitting that functionality so you can scale each of those internal services up or down as needed. Maybe the Web API service usually needs more instances than the Search service, or vice versa.)

In short, the logical architecture of microservices does not always have to coincide with the physical deployment architecture. In this guide, whenever we mention a microservice, we mean a business or logical microservice that could map to one or more services. In most cases, this will be a single service, but it might be more.

## Challenges and solutions for distributed data management

### Challenge \#1: How to define the boundaries of each microservice

Defining microservice boundaries is probably the first challenge anyone encounters. Each microservice has to be a piece of your application and each microservice should be autonomous with all the benefits and challenges that it conveys. But how do you identify those boundaries?

First, you need to focus on the application’s logical domain models and related data. You must try to identify decoupled islands of data and different contexts within the same application. Each context could have a different business language (different business terms). The contexts should be defined and managed independently. The terms and entities used in those different contexts might sound similar, but you might discover that in a particular context, a business concept with one is used for a different purpose in another context, and might even have a different name. For instance, a user can be referred as a user in the identity or membership context, as a customer in a CRM context, as a buyer in an ordering context, and so forth.

The way you identify boundaries between multiple application contexts with a different domain for each context is exactly how you can identify the boundaries for each business microservice and its related domain model and data. You always attempt to minimize the coupling between those microservices. This guide goes into more detail about this identification and domain model design in the section [Identifying domain-model boundaries for each microservice](#identifying-domain-model-boundaries-for-each-microservice) later.

### Challenge \#2: How to create queries that retrieve data from several microservices

A second challenge is how to implement queries that retrieve data from several microservices, while avoiding chatty communication to the microservices from remote client apps. An example could be a single screen from a mobile app that needs to show user information that is owned by the basket, catalog, and user identity microservices. Another example would be a complex report involving many tables located in multiple microservices. The right solution depends on the complexity of the queries. But in any case, you will need a way to aggregate information if you want to improve the efficiency in the communications of your system. The most popular solutions are the following.

**API Gateway**. For simple data aggregation from multiple microservices that own different databases, the recommended approach is an aggregation microservice referred to as an API Gateway. However, you need to be careful about implementing this pattern, because it can be a choke point in your system, and it can violate the principle of microservice autonomy. To mitigate this possibility, you can have multiple fined-grained API Gateways each one focusing on a vertical “slice” or business area of the system. The API Gateway pattern is explained in more detail in the section in the []{#ba .anchor}Using an API Gateway later.

[]{#queryreadtables .anchor}**CQRS with query/reads tables**. Another solution for aggregating data from multiple microservices is the [Materialized View pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/materialized-view). In this approach, you generate, in advance (prepare denormalized data before the actual queries happen), a read-only table with the data that is owned by multiple microservices. The table has a format suited to the client app’s needs.

Consider something like the screen for a mobile app. If you have a single database, you might pull together the data for that screen using a SQL query that performs a complex join involving multiple tables. However, when you have multiple databases, and each database is owned by a different microservice, you cannot query those databases and create a SQL join. Your complex query becomes a challenge. You can address the requirement using a CQRS approach—you create a denormalized table in a different database that is used just for queries. The table can be designed specifically for the data you need for the complex query, with a one-to-one relationship between fields needed by your application’s screen and the columns in the query table. It could also serve for reporting purposes.

This approach not only solves the original problem (how to query and join across microservices); it also improves performance considerably when compared with a complex join, because you already have the data that the application needs in the query table. Of course, using Command and Query Responsibility Segregation (CQRS) with query/reads tables means additional development work, and you will need to embrace eventual consistency. Nonetheless, requirements on performance and high scalability in [collaborative scenarios](http://udidahan.com/2011/10/02/why-you-should-be-using-cqrs-almost-everywhere/) (or competitive scenarios, depending on the point of view) is where you should apply CQRS with multiple databases.

**“Cold data” in central databases**. For complex reports and queries that might not require real-time data, a common approach is to export your “hot data” (transactional data from the microservices) as “cold data” into large databases that are used only for reporting. That central database system can be a Big Data-based system, like Hadoop, a data warehouse like one based on Azure SQL Data Warehouse, or even a single SQL database used just for reports (if size will not be an issue).

Keep in mind that this centralized database would be used only for queries and reports that do not need real-time data. The original updates and transactions, as your source of truth, have to be in your microservices data. The way you would synchronize data would be either by using event-driven communication (covered in the next sections) or by using other database infrastructure import/export tools. If you use event-driven communication, that integration process would be similar to the way you propagate data as described earlier for CQRS query tables.

However, if your application design involves constantly aggregating information from multiple microservices for complex queries, it might be a symptom of a bad design—a microservice should be as isolated as possible from other microservices. (This excludes reports/analytics that always should use cold-data central databases.) Having this problem often might be a reason to merge microservices. You need to balance the autonomy of evolution and deployment of each microservice with strong dependencies, cohesion, and data aggregation.

### Challenge \#3: How to achieve consistency across multiple microservices

As stated previously, the data owned by each microservice is private to that microservice and can only be accessed using its microservice API. Therefore, a challenge presented is how to implement end-to-end business processes while keeping consistency across multiple microservices.

To analyze this problem, let’s look at an example from the [eShopOnContainers reference application](http://aka.ms/eshoponcontainers). The Catalog microservice maintains information about all the products, including their stock level. The Ordering microservice manages orders and must verify that a new order does not exceed the available catalog product stock. (Or the scenario might involve logic that handles backordered products.) In a hypothetical monolithic version of this application, the ordering subsystem could simply use an ACID transaction to check the available stock, create the order in the Orders table, and update the available stock in the Products table.

However, in a microservices- based application, the Order and Product tables are owned by their respective microservices. No microservice should ever include databases owned by another microservice in its own transactions or queries, as shown in Figure 4-9.

![](./media/image9.PNG){width="4.848957786526684in" height="2.8904647856517935in"}

**Figure 4-9**. A microservice cannot directly access a table in another microservice

The Ordering microservice should not update the Products table directly, because the Products table is owned by the Catalog microservice. To make an update to the Catalog microservice, the Ordering microservice should only ever use asynchronous communication such as integration events (message and event-based communication). This is how the [eShopOnContainers](http://aka.ms/eshoponcontainers) reference application performs this type of update.

As stated by the [CAP theorem](https://en.wikipedia.org/wiki/CAP_theorem), you need to choose between availability and ACID strong consistency. Most microservice-based scenarios demand availability and high scalability as opposed to strong consistency. Mission-critical applications must remain up and running, and developers can work around strong consistency by using techniques for working with weak or eventual consistency. This is the approach taken by most microservice-based architectures.

Moreover, ACID-style or two-phase commit transactions are not just against microservices principles; most NoSQL databases (like Azure Document DB, MongoDB, etc.) do not support two-phase commit transactions. However, maintaining data consistency across services and databases is essential. This challenge is also related to the question of how to propagate changes across multiple microservices when certain data needs to be redundant—for example, when you need to have the product’s name or description in the Catalog microservice and the Basket microservice.

A good solution for this problem is to use eventual consistency between microservices articulated through event-driven communication and a publish-and-subscribe system. These topics are covered in the section [Asynchronous event-driven communication](#async_event_driven_communication) later in this guide.

### Challenge \#4: How to design communication across microservice boundaries

Communicating across microservice boundaries is a real challenge. In this context, communication does not refer to what protocol you should use (HTTP and REST, AMQP, messaging, and so on). Instead, it addresses what communication style you should use, and especially how coupled your microservices should be. Depending on the level of coupling, when failure occurs, the impact of that failure on your system will vary significantly.

In a distributed system like a microservices-based application, with so many artifacts moving around and with distributed services across many servers or hosts, components will eventually fail. Partial failure and even larger outages will occur, so you need to design your microservices and the communication across them taking into account the risks common in this type of distributed system.

A popular approach is to implement HTTP (REST)- based microservices, due to their simplicity. An HTTP-based approach is perfectly acceptable; the issue here is related to how you use it. If you use HTTP requests and responses just to interact with your microservices from client applications or from API Gateways, that is fine. But if create long chains of synchronous HTTP calls across microservices, communicating across their boundaries as if the microservices were objects in a monolithic application, your application will eventually run into problems.

For instance, imagine that your client application makes an HTTP API call to an individual microservice like the Ordering microservice. If the Ordering microservice in turn calls additional microservices using HTTP within the same request/response cycle, you are creating a chain of HTTP calls. It might sound reasonable initially. However, there are important points to consider when going down this path:

-   Blocking and low performance. Due to the synchronous nature of HTTP, the original request will not get a response until all the internal HTTP calls are finished. Imagine if the number of these calls increases significantly and at the same time one of the intermediate HTTP calls to a microservice is blocked. The result is that performance is impacted, and the overall scalability will be exponentially affected as additional HTTP requests increase.

-   Coupling microservices with HTTP. Business microservices should not be coupled with other business microservices. Ideally, they should not “know” about the existence of other microservices. If your application relies on coupling microservices as in the example, achieving autonomy per microservice will be almost impossible.

-   Failure in any one microservice. If you implemented a chain of microservices linked by HTTP calls, when any of the microservices fails (and eventually they will fail) the whole chain of microservices will fail. A microservice-based system should be designed to continue to work as well as possible during partial failures. Even if you implement client logic that uses retries with exponential backoff or circuit breaker mechanisms, the more complex the HTTP call chains are, the more complex it is implement a failure strategy based on HTTP.

In fact, if your internal microservices are communicating by creating chains of HTTP requests as described, it could be argued that you have a monolithic application, but one based on HTTP between processes instead of intraprocess communication mechanisms.

Therefore, in order to enforce microservice autonomy and have better resiliency, you should minimize the use of chains of request/response communication across microservices. It is recommended that you use only asynchronous interaction for inter-microservice communication, either by using asynchronous message- and event-based communication, or by using HTTP polling independently of the original HTTP request/response cycle.

The use of asynchronous communication is explained with additional details later in this guide in the sections [Asynchronous microservice integration enforces microservice’s autonomy](#asynchronous-microservice-integration-enforce-microservices-autonomy) and [Asynchronous message-based communication](#asynchronous-message-based-communication).

### Additional resources

-   **CAP theorem**\
    [*https://en.wikipedia.org/wiki/CAP\_theorem*](https://en.wikipedia.org/wiki/CAP_theorem)

-   **Eventual consistency**\
    [*https://en.wikipedia.org/wiki/Eventual\_consistency*](https://en.wikipedia.org/wiki/Eventual_consistency)

-   **Data Consistency Primer**\
    [*https://msdn.microsoft.com/en-us/library/dn589800.aspx*](https://msdn.microsoft.com/en-us/library/dn589800.aspx)

-   **Martin Fowler. CQRS (Command and Query Responsibility Segregation)**\
    [*http://martinfowler.com/bliki/CQRS.html*](http://martinfowler.com/bliki/CQRS.html)

-   **Materialized View**\
    [*https://msdn.microsoft.com/en-us/library/dn589782.aspx*](https://msdn.microsoft.com/en-us/library/dn589782.aspx)

-   **Charles Row. ACID vs. BASE: The Shifting pH of Database Transaction Processing**\
    [*http://www.dataversity.net/acid-vs-base-the-shifting-ph-of-database-transaction-processing/*](http://www.dataversity.net/acid-vs-base-the-shifting-ph-of-database-transaction-processing/)

-   **Compensating Transaction**\
    [*https://msdn.microsoft.com/en-us/library/dn589804.aspx*](https://msdn.microsoft.com/en-us/library/dn589804.aspx)

-   [[[[[]{#_Toc480368189 .anchor}]{#_Toc480361357 .anchor}]{#_Toc474844869 .anchor}]{#_Toc480984574 .anchor}]{#_Toc480993071 .anchor}**Udi Dahan. Service Oriented Composition**

    [*http://udidahan.com/2014/07/30/service-oriented-composition-with-video/*](http://udidahan.com/2014/07/30/service-oriented-composition-with-video/)

## Identifying domain-model boundaries for each microservice

The goal when identifying model boundaries and size for each microservice is not to get to the most granular separation possible, although you should tend toward small microservices if possible. Instead, your goal should be to get to the most meaningful separation guided by your domain knowledge. The emphasis is not on the size, but instead on business capabilities. In addition, if there is clear cohesion needed for a certain area of the application based on a high number of dependencies, that indicates the need for a single microservice, too. Cohesion is a way to identify how to break apart or group together microservices. Ultimately, while you gain more knowledge about the domain, you should adapt the size of your microservice, iteratively. Finding the right size is not a one-shot process.

[Sam Newman](http://samnewman.io/), a recognized promoter of microservices and author of the book [Building Microservices](http://samnewman.io/books/building_microservices/), highlights that you should design your microservices based on the Bounded Context (BC) pattern (part of domain-driven design), as introduced earlier. Sometimes, a BC could be composed of several physical services, but not vice versa.

A domain model with specific domain entities applies within a concrete BC or microservice. A BC delimits the applicability of a domain model and gives developer team members a clear and shared understanding of what must be cohesive and what can be developed independently. These are the same goals for microservices.

Another tool that informs your design choice is [Conway’s law](https://en.wikipedia.org/wiki/Conway%27s_law), which states that an application will reflect the social boundaries of the organization that produced it. But sometimes the opposite is true—the company’s organization is formed by the software. You might need to reverse Conway’s law and build the boundaries the way you want the company to be organized, leaning toward business process consulting.

In order to identify bounded contexts, a DDD pattern that can be used for this is the [Context Mapping pattern](https://www.infoq.com/articles/ddd-contextmapping). With Context Mapping, you identify the various contexts in the application and their boundaries. It is common to have a different context and boundary for each small subsystem, for instance. The Context Map is a way to define and make explicit those boundaries between domains. A BC is autonomous and includes the details of a single domain—details like the domain entities—and defines integration contracts with other BCs. This is similar to the definition of a microservice: it is autonomous, it implements certain domain capability, and it must provide interfaces. This is why Context Mapping and the Bounded Context pattern are good approaches for identifying the domain model boundaries of your microservices.

When designing a large application, you will see how its domain model can be fragmented — a domain expert from the catalog domain will name entities differently in the catalog and inventory domains than a shipping domain expert, for instance. Or the user domain entity might be different in size and number of attributes when dealing with a CRM expert who wants to store every detail about the customer than for an ordering domain expert who just needs partial data about the customer. It is very hard to disambiguate all domain terms across all the domains related to a large application. But the most important thing is that you should not try to unify the terms; instead, accept the differences and richness provided by each domain. If you try to have a unified database for the whole application, attempts at a unified vocabulary will be awkward and will not sound right to any of the multiple domain experts. Therefore, BCs (implemented as microservices) will help you to clarify where you can use certain domain terms and where you will need to split the system and create additional BCs with different domains.

You will know that you got the right boundaries and sizes of each BC and domain model if you have few strong relationships between domain models, and you do not usually need to merge information from multiple domain models when performing typical application operations.

Perhaps the best answer to the question of how big a domain model for each microservice should be is the following: it should have an autonomous BC, as isolated as possible, that enables you to work without having to constantly switch to other contexts (other microservice’s models). In Figure 4-10 you can see how multiple microservices (multiple BCs) each have their own model and how their entities can be defined, depending on the specific requirements for each of the identified domains in your application.

![](./media/image10.png){width="6.127811679790026in" height="3.4454975940507437in"}

**Figure 4-10**. Identifying entities and microservice model boundaries

Figure 4-10 illustrates a sample scenario related to an online conference management system. You have identified several BCs that could be implemented as microservices, based on domains that domain experts defined for you. As you can see, there are entities that are present just in a single microservice model, like Payments in the Payment microservice. Those will be easy to implement.

However, you might also have entities that have a different shape but share the same identity across the multiple domain models from the multiple microservices. For example, the User entity is identified in the Conferences Management microservice. That same user, with the same identity, is the one named Buyers in the Ordering microservice, or the one named Payer in the Payment microservice, and even the one named Customer in the Customer Service microservice. This is because, depending on the [ubiquitous language](https://martinfowler.com/bliki/UbiquitousLanguage.html) that each domain expert is using, a user might have a different perspective even with different attributes. The user entity in the microservice model named Conferences Management might have most of its personal data attributes. However, that same user in the shape of Payer in the microservice Payment or in the shape of Customer in the microservice Customer Service might not need the same list of attributes.

A similar approach is illustrated in Figure 4-11.

![](./media/image11.png){width="6.65747375328084in" height="3.7060247156605426in"}

**Figure 4-11**. Decomposing traditional data models into multiple domain models

You can see how the user is present in the Conferences Management microservice model as the User entity and is also present in the form of the Buyer entity in the Pricing microservice, with alternate attributes or details about the user when it is actually a buyer. Each microservice or BC might not need all the data related to a User entity, just part of it, depending on the problem to solve or the context. For instance, in the Pricing microservice model, you do not need the address or the ID of the user, just ID (as identity) and Status, which will have an impact on discounts when pricing the seats per buyer.

The Seat entity has the same name but different attributes in each domain model. However, Seat shares identity based on the same ID, as happens with User and Buyer.

Basically, there is a shared concept of a user that exists in multiple services (domains), which all share the identity of that user. But in each domain model there might be additional or different details about the user entity. Therefore, there needs to be a way to map a user entity from one domain (microservice) to another.

There are several benefits to not sharing the same user entity with the same number of attributes across domains. One benefit is to reduce duplication, so that microservice models do not have any data that they do not need. Another benefit is having a master microservice that owns a certain type of data per entity so that updates and queries for that type of data are driven only by that microservice.


## Direct client-to-microservice communication versus the API Gateway pattern

In a microservices architecture, each microservice exposes a set of (typically) fine‑grained endpoints. This fact can impact the client‑to‑microservice communication, as explained in this section.

### Direct client-to-microservice communication

A possible approach is to use a direct client-to-microservice communication architecture. In this approach, a client app can make requests directly to some of the microservices, as shown in Figure 4-12.

![](./media/image12.png){width="5.28125in" height="3.0834470691163602in"}

**Figure 4-12**. Using a direct client-to-microservice communication architecture

In this approach. each microservice has a public endpoint, sometimes with a different TCP port for each microservice. An example of an URL for a particular service could be the following URL in Azure:

<http://eshoponcontainers.westus.cloudapp.azure.com:88/>

In a production environment based on a cluster, that URL would map to the load balancer used in the cluster, which in turn distributes the requests across the microservices. In production environments, you could have an Application Delivery Controller (ADC) like [Azure Application Gateway](https://docs.microsoft.com/en-us/azure/application-gateway/application-gateway-introduction) between your microservices and the Internet. This acts as a transparent tier that not only performs load balancing, but secures your services by offering SSL termination. This improves the load of your hosts by offloading CPU-intensive SSL termination and other routing duties to the Azure Application Gateway. In any case, a load balancer and ADC are transparent from a logical application architecture point of view.

A direct client-to-microservice communication architecture is good enough for a small microservice-based application. However, when you build large and complex microservice-based applications (for example, when handling dozens of microservice types), that approach faces possible issues. You need to consider the following questions when developing a large application based on microservices:

-   *How can client apps minimize the number of requests to the backend and reduce chatty communication to multiple microservices?*

Interacting with multiple microservices to build a single UI screen increases the number of roundtrips across the Internet. This increases latency and complexity on the UI side. Ideally, responses should be efficiently aggregated in the server side—this reduces latency, since multiple pieces of data come back in parallel and some UI can show data as soon as it is ready.

-   *How can you handle cross-cutting concerns such as authorization, data transformations, and dynamic request dispatching?*

Implementing security and cross-cutting concerns like security and authorization on every microservice can require significant development effort. A possible approach is to have those services within the Docker host or internal cluster, in order to restrict direct access to them from the outside, and to implement those cross-cutting concerns in a centralized place, like an API Gateway.

-   *How can client apps communicate with services that use non-Internet-friendly protocols?*

Protocols used on the server side (like AMQP or binary protocols) are usually not supported in client apps. Therefore, requests must be performed through protocols like HTTP/HTTPS and translated to the other protocols afterwards. A *man-in-the-middle* approach can help in this situation.

-   *How can you shape a façade especially made for mobile apps? *

The API of multiple microservices might not be well designed for the needs of different client applications. For instance, the needs of a mobile app might be different than the needs of a web app. For mobile apps, you might need to optimize even further so that data responses can be more efficient. You might do this by aggregating data from multiple microservices and returning a single set of data, and sometimes eliminating any data in the response that is not needed by the mobile app. And, of course, you might compress that data. Again, a façade or API in between the mobile app and the microservices can be convenient for this scenario.

### Using an API Gateway

When you design and build large or complex microservice-based applications with multiple client apps, a good approach to consider can be an [API Gateway](http://microservices.io/patterns/apigateway.html). This is a service that provides a single entry point for certain groups of microservices. It is similar to the [Facade pattern](https://en.wikipedia.org/wiki/Facade_pattern) from object‑oriented design, but in this case, it is part of a distributed system. The API Gateway pattern is also sometimes known as the “back end for the front end,” because you build it while thinking about the needs of the client app.

Figure 4-13 shows how an API Gateway can fit into a microservice-based architecture.

![](./media/image13.png){width="5.58121719160105in" height="3.0781255468066493in"}

**Figure 4-13**. Using the API Gateway pattern in a microservice-based architecture

In this example, the API Gateway would be implemented as a custom Web API service running as a container.

You should implement several API Gateways so that you can have a different façade for the needs of each client app. Each API Gateway can provide a different API tailored for each client app, possibly even based on the client form factor or device by implementing specific adapter code which underneath calls multiple internal microservices.

Since the API Gateway is actually an aggregator, you need to be careful with it. Usually it is not a good idea to have a single API Gateway aggregating all the internal microservices of your application. If it does, it acts as a monolithic aggregator or orchestrator and violates microservice autonomy by coupling all the microservices. Therefore, the API Gateways should be segregated based on business boundaries and not act as an aggregator for the whole application.

Sometimes a granular API Gateway can also be a microservice by itself, and even have a domain or business name and related data. Having the API Gateway’s boundaries dictated by the business or domain will help you to get a better design.

Granularity in the API Gateway tier can be especially useful for more advanced composite UI applications based on microservices, because the concept of a fine-grained API Gateway is similar to an UI composition service. We discuss this later in the [Creating composite UI based on microservices](#creating-composite-ui-based-on-microservices-including-visual-ui-shape-and-layout-generated-by-multiple-microservices).

Therefore, for many medium- and large-size applications, using a custom-built API Gateway is usually a good approach, but not as a single monolithic aggregator or unique central ASPI Gateway.

Another approach is to use a product like [Azure API Management](https://azure.microsoft.com/en-us/services/api-management/) as shown in Figure 4-14. This approach not only solves your API Gateway needs, but provides features like gathering insights from your APIs. If you are using an API management solution, an API Gateway is only a component within that full API management solution.

![](./media/image14.png){width="5.341012685914261in" height="3.432292213473316in"}

**Figure 4-14**. Using Azure API Management for your API Gateway

The insights available from an API Management system help you get an understanding of how your APIs are being used and how they are performing. They do this by letting you view near real-time analytics reports and identifying trends that might impact your business. Plus you can have logs about request and response activity for further online and offline analysis.

With Azure API Management, you can secure your APIs using a key, a token, and IP filtering. These features let you enforce flexible and fine-grained quotas and rate limits, modify the shape and behavior of your APIs using policies, and improve performance with response caching.

In this guide and the reference sample application (eShopOnContainers) we are limiting the architecture to a simpler and custom-made containerized architecture in order to focus on plain containers without using PaaS products like Azure API Management. But for large microservice-based applications that are deployed into Microsoft Azure, we encourage you to review and adopt Azure API Management as the base for your API Gateways.

### Drawbacks of the API Gateway pattern

-   The most important drawback is that when you implement an API Gateway, you are coupling that tier with the internal microservices. Coupling like this might introduce serious difficulties for your application. (The cloud architect Clemens Vaster refers to this potential difficulty as “the new ESB” in his "[Messaging and Microservices](https://www.youtube.com/watch?v=rXi5CLjIQ9k)" session from at GOTO 2016.)

-   Using a microservices API Gateway creates an additional possible point of failure.

-   An API Gateway can introduce increased response time due to the additional network call. However, this extra call usually has less impact than having a client interface that is too chatty directly calling the internal microservices.

-   The API Gateway can represent a possible bottleneck if it is not scaled out properly

-   An API Gateway requires additional development cost and future maintenance if it includes custom logic and data aggregation. Developers must update the API Gateway in order to expose each microservice’s endpoints. Moreover, implementation changes in the internal microservices might cause code changes at the API Gateway level. However, if the API Gateway is just applying security, logging, and versioning (as when using Azure API Management), this additional development cost might not apply.

-   If the API Gateway is developed by a single team, there can be a development bottleneck. This is another reason why a better approach is to have several fined-grained API Gateways that respond to different client needs. You could also segregate the API Gateway internally into multiple areas or layers that are owned by the different teams working on the internal microservices.

### Additional resources

-   **Charles Richardson. Pattern: API Gateway / Backend for Front-End**\
    [*http://microservices.io/patterns/apigateway.html*](http://microservices.io/patterns/apigateway.html)

-   **Azure API Management**\
    [*https://azure.microsoft.com/en-us/services/api-management/*](https://azure.microsoft.com/en-us/services/api-management/)

-   [[[[[]{#_Toc480984576 .anchor}]{#_Toc480993073 .anchor}]{#_Toc480368190 .anchor}]{#_Toc480361358 .anchor}]{#_Toc474844870 .anchor}**Udi Dahan. Service Oriented Composition\
    **[*http://udidahan.com/2014/07/30/service-oriented-composition-with-video/*](http://udidahan.com/2014/07/30/service-oriented-composition-with-video/)

-   **Clemens Vasters. Messaging and Microservices at GOTO 2016** (video)**\
    **[*https://www.youtube.com/watch?v=rXi5CLjIQ9k*](https://www.youtube.com/watch?v=rXi5CLjIQ9k)

## Communication between microservices

In a monolithic application running on a single process, components invoke one another using language-level method or function calls. These can be strongly coupled if you are creating objects with code (for example, new ClassName()), or can be invoked in a decoupled way if you are using Dependency Injection by referencing abstractions rather than concrete object instances. Either way, the objects are running within the same process. The biggest challenge when changing from a monolithic application to a microservices-based application lies in changing the communication mechanism. A direct conversion from in-process method calls into RPC calls to services will cause a chatty and not efficient communication that will not perform well in distributed environments. The challenges of designing distributed system properly are well enough known that there is even a canon known as the [The fallacies of distributed computing](https://en.wikipedia.org/wiki/Fallacies_of_distributed_computing) that lists assumptions that developers often make when moving from monolithic to distributed designs.

There is not one solution, but several. One solution involves isolating the business microservices as much as possible. You then use asynchronous communication between the internal microservices and replace fine-grained communication that is typical in intra-process communication between objects with coarser-grained communication. You can do this by grouping calls, and by returning data that aggregates the results of multiple internal calls, to the client.

A microservices-based application is a distributed system running on multiple processes or services, usually even across multiple servers or hosts. Each service instance is typically a process. Therefore, services must interact using an inter-process communication protocol such as HTTP, AMQP, or a binary protocol like TCP, depending on the nature of each service.

The microservice community promotes the philosophy of “[smart endpoints and dumb pipes](http://simplicable.com/new/smart-endpoints-and-dumb-pipes).” This slogan encourages a design that is as decoupled as possible between microservices, and as cohesive as possible within a single microservice. As explained earlier, each microservice owns its own data and its own domain logic. But the microservices composing an end-to-end application are usually simply choreographed by using REST communications rather than complex protocols such as WS-\* and flexible event-driven communications instead of centralized business-process-orchestrators.

The two commonly used protocols are HTTP request/response with resource APIs (when querying most of all), and lightweight asynchronous messaging when communicating updates across multiple microservices. These are explained in more detail in the following sections.

### Communication types

Client and services can communicate through many different types of communication, each one targeting a different scenario and goals. Initially, those types of communications can be classified in two axes.

The first axis is defining if the protocol is synchronous or asynchronous:

-   Synchronous protocol. HTTP is a synchronous protocol. The client sends a request and waits for a response from the service. That is independent of the client code execution that could be synchronous (thread is blocked) or asynchronous (thread is not blocked, and the response will reach a callback eventually). The important point here is that the protocol (HTTP/HTTPS) is synchronous and the client code can only continue its task when it receives the HTTP server response.

-   Asynchronous protocol. Other protocols like AMQP (a protocol supported by many operating systems and cloud environments) use asynchronous messages. The client code or message sender usually does not wait for a response. It just sends the message as when sending a message to a RabbitMQ queue or any other message broker.

The second axis is defining if the communication has a single receiver or multiple receivers:

-   Single receiver. Each request must be processed by exactly one receiver or service. An example of this communication is the [Command pattern](https://en.wikipedia.org/wiki/Command_pattern).

-   Multiple receivers. Each request can be processed by zero to multiple receivers. This type of communication must be asynchronous. An example is the [publish/subscribe](https://en.wikipedia.org/wiki/Publish%E2%80%93subscribe_pattern) mechanism used in patterns like [Event-driven architecture](http://microservices.io/patterns/data/event-driven-architecture.html). This is based on an event-bus interface or message broker when propagating data updates between multiple microservices through events; it is usually implemented through a service bus or similar artifact like [Azure Service Bus](https://azure.microsoft.com/en-us/services/service-bus/) by using [topics and subscriptions](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-how-to-use-topics-subscriptions).

A microservice-based application will often use a combination of these communication styles. The most common type is single-receiver communication with a synchronous protocol like HTTP/HTTPS when invoking a regular Web API HTTP service. Microservices also typically use messaging protocols for asynchronous communication between microservices.

These axes are good to know so you have clarity on the possible communication mechanisms, but they are not the important concerns when building microservices. The asynchronous nature of client thread execution not even the asynchronous nature of the selected protocol are the important points when integrating microservices. What *is* important is being able to integrate your microservices asynchronously while maintaining the independence of microservices, as explained in the following section.

### Asynchronous microservice integration enforce microservice’s autonomy

As mentioned, the important point when building a microservices-based application is the way you integrate your microservices. Ideally, you should try to minimize the communication between the internal microservices. The less communications between microservices, the better. But of course, in many cases you will have to somehow integrate the microservices. When you need to do that, the critical rule here is that the communication between the microservices should be asynchronous. That does not mean that you have to use a specific protocol (for example, asynchronous messaging versus synchronous HTTP). It just means that the communication between microservices should be done only by propagating data asynchronously, but try not to depend on other internal microservices as part of the initial service’s HTTP request/response operation.

If possible, never depend on synchronous communication (request/response) between multiple microservices, not even for queries. The goal of each microservice is to be autonomous and available to the client consumer, even if the other services that are part of the end-to-end application are down or unhealthy. If you think you need to make a call from one microservice to other microservices (like performing an HTTP request for a data query) in order to be able to provide a response to a client application, you have an architecture that will not be resilient when some microservices fail.

Moreover, having dependencies between microservices (like performing HTTP requests between them for querying data) not only makes your microservices not autonomous. In addition, their performance will be impacted. The more you add synchronous dependencies (like query requests) between microservices, the worse the overall response time will get for the client apps.

If your microservice needs to raise an additional action in another microservice, if possible, do not perform that action synchronously and as part of the original microservice request and reply operation. Instead, do it asynchronously (using asynchronous messaging or integration events, queues, etc.). But, as much as possible, do not invoke the action synchronously as part of the original synchronous request and reply operation.

And finally (and this is where most of the issues arise when building microservices), if your initial microservice needs data that is originally owned by other microservices, do not rely on making synchronous requests for that data. Instead, replicate or propagate that data (only the attributes you need) into the initial service’s database by using eventual consistency (typically by using integration events, as explained in upcoming sections).

As noted earlier in the section [Identifying domain-model boundaries for each microservice](#identifying-domain-model-boundaries-for-each-microservice), duplicating some data across several microservices is not an incorrect design—on the contrary, when doing that you can translate the data into the specific language or terms of that additional domain or Bounded Context. For instance, in the [eShopOnContainers](http://aka.ms/MicroservicesArchitecture) application you have a microservice named identity.api that is in charge of most of the user’s data with an entity named User. However, when you need to store data about the user within the Ordering microservice, you store it as a different entity named Buyer. The Buyer entity shares the same identity with the original User entity, but it might have only the few attributes needed by the Ordering domain, and not the whole user profile.

You might use any protocol to communicate and propagate data asynchronously across microservices in order to have eventual consistency. As mentioned, you could use integration events using an event bus or message broker or you could even use HTTP by polling the other services instead. It does not matter. The important rule is to not create synchronous dependencies between your microservices.

The following sections explain the multiple communication styles you can consider using in a microservice-based application.

### Communication styles

There are many protocols and choices you can use for communication, depending on the communication type you want to use. If you are using a synchronous request/response-based communication mechanism, protocols such as HTTP and REST approaches are the most common, especially if you are publishing your services outside the Docker host or microservice cluster. If you are communicating between services internally (within your Docker host or microservices cluster) you might also want to use binary format communication mechanisms (like Service Fabric remoting or WCF using TCP and binary format). Alternatively, you can use asynchronous, message-based communication mechanisms such as AMQP.

There are also multiple message formats like JSON or XML, or even binary formats, which can be more efficient. If your chosen binary format is not a standard, it is probably not a good idea to publicly publish your services using that format. You could use a non-standard format for internal communication between your microservices. You might do this when communicating between microservices within your Docker host or microservice cluster (Docker orchestrators or Azure Service Fabric), or for proprietary client applications that talk to the microservices.

#### Request/response communication with HTTP and REST 

When a client uses request/response communication, it sends a request to a service, then the service processes the request and sends back a response. Request/response communication is especially well suited for querying data for a real-time UI (a live user interface) from client apps. Therefore, in a microservice architecture you will probably use this communication mechanism for most queries, as shown in Figure 4-15.

![](./media/image15.png){width="5.907638888888889in" height="2.1506944444444445in"}

**Figure 4-15**. Using HTTP request/response communication (synchronous or asynchronous)

When a client uses request/response communication, it assumes that the response will arrive in a short time, typically less than a second, or a few seconds at most. For delayed responses, you need to implement asynchronous communication based on [messaging patterns](https://docs.microsoft.com/en-us/azure/architecture/patterns/category/messaging) and [messaging technologies](https://en.wikipedia.org/wiki/Message-oriented_middleware), which is a different approach that we explain in the next section.

A popular architectural style for request/response communication is [REST](https://en.wikipedia.org/wiki/Representational_state_transfer). This approach is based on, and tightly coupled to, the [HTTP](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol) protocol, embracing HTTP verbs like GET, POST, and PUT. REST is the most commonly used architectural communication approach when creating services. You can implement REST services when you develop ASP.NET Core Web API services.

There is additional value when using HTTP REST services as your interface definition language. For instance, if you use [Swagger metadata](http://swagger.io/) to describe your service API, you can use tools that generate client stubs that can directly discover and consume your services.

#### Additional resources

-   **Martin Fowler. Richardson Maturity Model.** A description of the REST model.\
    *<http://martinfowler.com/articles/richardsonMaturityModel.html> *

-   **Swagger.** The official site.\
    [*http://swagger.io/*](http://swagger.io/)

#### Push and real-time communication based on HTTP

Another possibility (usually for different purposes than REST) is a real-time and one-to-many communication with higher-level frameworks such as [ASP.NET SignalR](https://www.asp.net/signalr) and protocols such as [WebSockets](https://en.wikipedia.org/wiki/WebSocket).

As Figure 4-16 shows, real-time HTTP communication means that you can have server code pushing content to connected clients as the data becomes available, rather than having the server wait for a client to request new data.

![](./media/image16.png){width="5.765508530183727in" height="2.963542213473316in"}

**Figure 4-16**. One-to-one real-time asynchronous message communication

Since communication is in real time, client apps show the changes almost instantly. This is usually handled by a protocol such as WebSockets, using many WebSockets connections (one per client). A typical example is when a service communicates a change in the score of a sports game to many client web apps simultaneously.

**\
**

### Asynchronous message-based communication

Asynchronous messaging and event-driven communication are critical when propagating changes across multiple microservices and their related domain models. As mentioned earlier in the discussion microservices and Bounded Contexts (BCs), models (User, Customer, Product, Account, etc.) can mean different things to different microservices or BCs. That means that when changes occur, you need some way to reconcile changes across the different models. A solution is eventual consistency and event-driven communication based on asynchronous messaging.

When using messaging, processes communicate by exchanging messages asynchronously. A client makes a command or a request to a service by sending it a message. If the service needs to reply, it sends a different message back to the client. Since it is a message-based communication, the client assumes that the reply will not be received immediately, and that there might be no response at all.

A message is composed by a header (metadata such as identification or security information) and a body. Messages are usually sent through asynchronous protocols like AMQP.

The preferred infrastructure for this type of communication in the microservices community is a lightweight message broker, which is different than the large brokers and orchestrators used in SOA. In a lightweight message broker, the infrastructure is typically “dumb,” acting only as a message broker, with simple implementations such as RabbitMQ or a scalable service bus in the cloud like Azure Service Bus. In this scenario, most of the “smart” thinking still lives in the endpoints that are producing and consuming messages—that is, in the microservices.

Another rule you should try to follow, as much as possible, is to use only asynchronous messaging between the internal services, and to use synchronous communication (such as HTTP) only from the client apps to the front-end services (API Gateways plus the first level of microservices).

There are two kinds of asynchronous messaging communication: single receiver message-based communication, and multiple receivers message-based communication. In the following sections we provide details about them.

#### Single-receiver message-based communication 

Message-based asynchronous communication with a single receiver means there is point-to-point communication that delivers a message to exactly one of the consumers that is reading from the channel, and that the message is processed just once. However, there are special situations. For instance, in a cloud system that tries to automatically recover from failures, the same message could be sent multiple times. Due to network or other failures, the client has to be able to retry sending messages, and the server has to implement an operation to be idempotent in order to process a particular message just once.

Single-receiver message-based communication is especially well suited for sending asynchronous commands from one microservice to another as shown in Figure 4-17 that illustrates this approach.

Once you start sending message-based communication (either with commands or events), you should avoid mixing message-based communication with synchronous HTTP communication.

![](./media/image17.PNG){width="6.122411417322835in" height="3.53125in"}

**Figure 4-17**. A single microservice receiving an asynchronous message

Note that when the commands come from client applications, they can be implemented as HTTP synchronous commands. You should use message-based commands when you need higher scalability or when you are already in a message-based business process.

#### Multiple-receivers message-based communication 

[]{#async_event_driven_communication .anchor}As a more flexible approach, you might also want to use a publish/subscribe mechanism so that your communication from the sender will be available to additional subscriber microservices or to external applications. Thus, it helps you to follow the [open/closed principle](https://en.wikipedia.org/wiki/Open/closed_principle) in the sending service. That way, additional subscribers can be added in the future without the need to modify the sender service.

When you use a publish/subscribe communication, you might be using an event bus interface to publish events to any subscriber.

##### Asynchronous event-driven communication

When using asynchronous event-driven communication, a microservice publishes an integration event when something happens within its domain and another microservice needs to be aware of it, like a price change in a product catalog microservice. Additional microservices subscribe to the events so they can receive them asynchronously. When that happens, the receivers might update their own domain entities, which can cause more integration events to be published. This publish/subscribe system is usually performed by using an implementation of an event bus. The event bus can be designed as an abstraction or interface, with the API that is needed to subscribe or unsubscribe to events and to publish events. The event bus can also have one or more implementations based on any inter-process and messaging broker, like a messaging queue or service bus that supports asynchronous communication and a publish/subscribe model.

If a system uses eventual consistency driven by integration events, it is recommended that this approach be made completely clear to the end user. The system should not use an approach that mimics integration events, like SignalR or polling systems from the client. The end user and the business owner have to explicitly embrace eventual consistency in the system and realize that in many cases the business does not have any problem with this approach, as long as it is explicit.

As noted earlier in the [Challenges and solutions for distributed data management](#challenges-and-solutions-for-distributed-data-management) section, you can use integration events to implement business tasks that span multiple microservices. Thus you will have eventual consistency between those services. An eventually consistent transaction is made up of a collection of distributed actions. At each action, the related microservice updates a domain entity and publishes another integration event that raises the next action within the same end-to-end business task.

An important point is that you might want to communicate to multiple microservices that are subscribed to the same event. To do so, you can use publish/subscribe messaging based on event-driven communication, as shown in Figure 4-18. This publish/subscribe mechanism is not exclusive to the microservice architecture. It is similar to the way [Bounded Contexts](http://martinfowler.com/bliki/BoundedContext.html) in DDD should communicate, or to the way you propagate updates from the write database to the read database in the [Command and Query Responsibility Segregation (CQRS)](http://martinfowler.com/bliki/CQRS.html) architecture pattern. The goal is to have eventual consistency between multiple data sources across your distributed system.

![](./media/image18.png){width="6.065371828521434in" height="3.088542213473316in"}

**Figure 4-18**. Asynchronous event-driven message communication

Your implementation will determine what protocol to use for event-driven, message-based communications. [AMQP](https://en.wikipedia.org/wiki/Advanced_Message_Queuing_Protocol) can help achieve reliable queued communication.

When you use an event bus, you might want to use an abstraction level (like an event bus interface) based on a related implementation in classes with code using the API from a message broker like [RabbitMQ](https://www.rabbitmq.com/) or a service bus like [Azure Service Bus with Topics](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-how-to-use-topics-subscriptions). Alternatively, you might want to use a higher-level service bus like NServiceBus, MassTransit, or Brighter to articulate your event bus and publish/subscribe system.

##### A note about messaging technologies for production systems

The messaging technologies available for implementing your abstract event bus are at different levels. For instance, products like RabbitMQ (a messaging broker transport) and Azure Service Bus sit at a lower level than other products like, NServiceBus, MassTransit, or Brighter, which can work on top of RabbitMQ and Azure Service Bus. Your choice depends on how many rich features at the application level and out-of-the-box scalability you need for your application. For implementing just a proof-of-concept event bus for your development environment, as we have done in the eShopOnContainers sample, a simple implementation on top of RabbitMQ running on a Docker container might be enough.

However, for mission-critical and production systems that need hyper-scalability, you might want to evaluate Azure Service Bus. For high-level abstractions and features that make the development of distributed applications easier, we recommend that you evaluate other commercial and open-source service buses, such as NServiceBus, MassTransit, and Brighter. Of course, you can build your own service-bus features on top of lower-level technologies like RabbitMQ and Docker. But that plumbing work might cost too much for a custom enterprise application.

### Resiliently publishing to the event bus

A challenge when implementing an event-driven architecture across multiple microservices is how to atomically update state in the original microservice while resiliently publishing its related integration event into the event bus, somehow based on transactions. The following are a few ways to accomplish this, although there could be additional approaches as well.

-   Using a transactional (DTC-based) queue like MSMQ. (However, this is a legacy approach.)

-   Using [transaction log mining](http://www.scoop.it/t/sql-server-transaction-log-mining).

-   Using full [Event Sourcing](https://msdn.microsoft.com/en-us/library/dn589792.aspx) pattern.

-   Using the [Outbox pattern](http://gistlabs.com/2014/05/the-outbox/): a transactional database table as a message queue that will be the base for an event-creator component that would create the event and publish it.

Additional topics to consider when using asynchronous communication are message idempotence and message deduplication. These topics are covered in the section [Implementing event-based communication between microservices (integration events)](#implementing_event_based_comms_microserv) later in this guide.

### Additional resources

-   **Event Driven Messaging**\
    [*http://soapatterns.org/design\_patterns/event\_driven\_messaging*](http://soapatterns.org/design_patterns/event_driven_messaging)

-   **Publish/Subscribe Channel**\
    [*http://www.enterpriseintegrationpatterns.com/patterns/messaging/PublishSubscribeChannel.html*](http://www.enterpriseintegrationpatterns.com/patterns/messaging/PublishSubscribeChannel.html)

-   **Udi Dahan. Clarified CQRS**\
    [*http://udidahan.com/2009/12/09/clarified-cqrs/*](http://udidahan.com/2009/12/09/clarified-cqrs/)

-   **Command and Query Responsibility Segregation (CQRS)\
    **[*https://msdn.microsoft.com/en-us/library/dn568103.aspx*](https://msdn.microsoft.com/en-us/library/dn568103.aspx)

-   **Communicating Between Bounded Contexts**\
    [*https://msdn.microsoft.com/en-us/library/jj591572.aspx*](https://msdn.microsoft.com/en-us/library/jj591572.aspx)

-   **Eventual consistency**\
    [*https://en.wikipedia.org/wiki/Eventual\_consistency*](https://en.wikipedia.org/wiki/Eventual_consistency)

-   **Jimmy Bogard. Refactoring Towards Resilience: Evaluating Coupling\
    **[*https://jimmybogard.com/refactoring-towards-resilience-evaluating-coupling/*](https://jimmybogard.com/refactoring-towards-resilience-evaluating-coupling/)

### Creating, evolving, and versioning microservice APIs and contracts

A microservice API is a contract between the service and its clients. You will be able to evolve a microservice independently only if you do not break its API contract, which is why the contract is so important. If you change the contract, it will impact your client applications or your API Gateway.

The nature of the API definition depends on which protocol you are using. For instance, if you are using messaging (like [AMQP](https://www.amqp.org/)), the API consists of the message types. If you are using HTTP and RESTful services, the API consists of the URLs and the request and response JSON formats.

However, even if you are thoughtful about your initial contract, a service API will need to change over time. When that happens—and especially if your API is a public API consumed by multiple client applications—you typically cannot force all clients to upgrade to your new API contract. You usually need to incrementally deploy new versions of a service in a way that both old and new versions of a service contract are running simultaneously. Therefore, it is important to have a strategy for your service versioning.

When the API changes are small, like if you add attributes or parameters to your API, clients that use an older API should switch and work with the new version of the service. You might be able to provide default values for any missing attributes that are required, and the clients might be able to ignore any extra response attributes.

However, sometimes you need to make major and incompatible changes to a service API. Because you might not be able to force client applications or services to upgrade immediately to the new version, a service must support older versions of the API for some period. If you are using an HTTP-based mechanism such as REST, one approach is to embed the API version number in the URL or into a HTTP header. Then you can decide between implementing both versions of the service simultaneously within the same service instance, or deploying different instances that each handle a version of the API. A good approach for this is the [Mediator pattern](https://en.wikipedia.org/wiki/Mediator_pattern) (for example, [MediatR library](https://github.com/jbogard/MediatR)) to decouple the different implementation versions into independent handlers.

Finally, if you are using a REST architecture, [Hypermedia](https://www.infoq.com/articles/mark-baker-hypermedia) is the best solution for versioning your services and allowing evolvable APIs.

### Additional resources

-   **Scott Hanselman. ASP.NET Core RESTful Web API versioning made easy\
    **<http://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx>

-   **Versioning a RESTful web API\
    ***<https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design#versioning-a-restful-web-api> *

-   **Roy Fielding. Versioning, Hypermedia, and REST\
    **<https://www.infoq.com/articles/roy-fielding-on-versioning>

### Microservices addressability and the service registry

Each microservice has a unique name (URL) that is used to resolve its location. Your microservice needs to be addressable wherever it is running. If you have to think about which computer is running a particular microservice, things can go bad quickly. In the same way that DNS resolves a URL to a particular computer, your microservice needs to have a unique name so that its current location is discoverable. Microservices need addressable names that make them independent from the infrastructure that they are running on. This implies that there is an interaction between how your service is deployed and how it is discovered, because there needs to be a [service registry](http://microservices.io/patterns/service-registry.html). In the same vein, when a computer fails, the registry service must be able to indicate where the service is now running.

The [service registry pattern](http://microservices.io/patterns/service-registry.html) is a key part of service discovery. The registry is a database containing the network locations of service instances. A service registry needs to be highly available and up to date. Clients could cache network locations obtained from the service registry. However, that information eventually goes out of date and clients can no longer discover service instances. Consequently, a service registry consists of a cluster of servers that use a replication protocol to maintain consistency.

In some microservice deployment environments (called clusters, to be covered in a later section), service discovery is built-in. For example, within an Azure Container Service environment, Kubernetes and DC/OS with Marathon can handle service instance registration and deregistration. They also run a proxy on each cluster host that plays the role of server-side discovery router. Another example is Azure Service Fabric, which also provides a service registry through its out-of-the-box Naming Service.

[[]{#_Toc474844871 .anchor}]{#_Toc474844867 .anchor}Note that there is certain overlap between the service registry and the API gateway pattern, which helps solve this problem as well. For example, the [Service Fabric Reverse Proxy](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-reverseproxy) is a type of implementation of an API Gateway that is based on the Service Fabrice Naming Service and that helps resolve address resolution to the internal services.

### Additional resources

-   **Chris Richardson. Pattern: Service registry\
    ***http://microservices.io/patterns/service-registry.html,xu*

-   **Auth0. The Service Registry\
    **[*https://auth0.com/blog/an-introduction-to-microservices-part-3-the-service-registry/*](https://auth0.com/blog/an-introduction-to-microservices-part-3-the-service-registry/)

-   **Gabriel Schenker. Service discovery\
    **[*https://lostechies.com/gabrielschenker/2016/01/27/service-discovery/*](https://lostechies.com/gabrielschenker/2016/01/27/service-discovery/)

## Creating composite UI based on microservices, including visual UI shape and layout generated by multiple microservices

Microservices architecture often starts with the server side handling data and logic. However, a more advanced approach is to design your application UI based on microservices as well. That means having a composite UI produced by the microservices, instead of having microservices on the server and just a monolithic client app consuming the microservices. With this approach, the microservices you build can be complete with both logic and visual representation.

Figure 4-19 shows the simpler approach of just consuming microservices from a monolithic client application. Of course, you could have an ASP.NET MVC service in between producing the HTML and JavaScript. The figure is a simplification that highlights that you have a single (monolithic) client UI consuming the microservices, which just focus on logic and data and not on the UI shape (HTML and JavaScript).

![](./media/image19.png){width="6.020833333333333in" height="3.1505544619422574in"}

**Figure 4-19**. A monolithic UI application consuming back-end microservices

In contrast, a composite UI is precisely generated and composed by the microservices themselves. Some of the microservices drive the visual shape of specific areas of the UI. The key difference is that you have client UI components (TS classes, for example) based on templates, and the data-shaping-UI ViewModel for those templates comes from each microservice.

At client application start-up time, each of the client UI components (TypeScript classes, for example) registers itself with an infrastructure microservice capable of providing ViewModels for a given scenario. If the microservice changes the shape, the UI changes also.

Figure 4-20 shows a version of this composite UI approach. This is simplified, because you might have other microservices that are aggregating granular parts based on different techniques—it depends on whether you are building a traditional web approach (ASP.NET MVC) or an SPA (Single Page Application).

![](./media/image20.png){width="6.259722222222222in" height="3.1414588801399823in"}

**Figure 4-20**. Example of a composite UI application shaped by back-end microservices

Each of those UI composition microservices would be similar to a small API Gateway. But in this case each is responsible for a small UI area.

A composite UI approach that is driven by microservices can be more challenging or less so, depending on what UI technologies you are using. For instance, you will not use the same techniques for building a traditional web application that you use for building an SPA or for native mobile app (as when developing Xamarin apps, which can be more challenging for this approach).

The [eShopOnContainers](http://aka.ms/MicroservicesArchitecture) sample application uses the monolithic UI approach for multiple reasons. First, it is an introduction to microservices and containers. A composite UI is more advanced but also requires further complexity when designing and developing the UI. Second, eShopOnContainers also provides a native mobile app based on Xamarin, which would make it more complex on the client C\# side.

However, we encourage you to use the following references to learn more about composite UI based on microservices.

### Additional resources

-   **Composite UI using ASP.NET (Particular’s Workshop)**\
    [*https://github.com/Particular/Workshop.Microservices/tree/master/demos/CompositeUI-MVC*](https://github.com/Particular/Workshop.Microservices/tree/master/demos/CompositeUI-MVC)

-   **Ruben Oostinga. The Monolithic Frontend in the Microservices Architecture**\
    [*http://blog.xebia.com/the-monolithic-frontend-in-the-microservices-architecture/*](http://blog.xebia.com/the-monolithic-frontend-in-the-microservices-architecture/)

-   **Mauro Servienti. The secret of better UI composition**\
    [*https://particular.net/blog/secret-of-better-ui-composition*](https://particular.net/blog/secret-of-better-ui-composition)

-   **Viktor Farcic. Including Front-End Web Components Into Microservices**\
    [*https://technologyconversations.com/2015/08/09/including-front-end-web-components-into-microservices/*](https://technologyconversations.com/2015/08/09/including-front-end-web-components-into-microservices/)

-   []{#_Toc474844868 .anchor}**Managing Frontend in the Microservices Architecture**\
    [*http://allegro.tech/2016/03/Managing-Frontend-in-the-microservices-architecture.html*](http://allegro.tech/2016/03/Managing-Frontend-in-the-microservices-architecture.html)

## Resiliency and high availability in microservices

Dealing with unexpected failures is one of the hardest problems to solve, especially in a distributed system. Much of the code that developers write involves handling exceptions, and this is also where the most time is spent in testing. The problem is more involved than writing code to handle failures. What happens when the machine where the microservice is running fails? Not only do you need to detect this microservice failure (a hard problem on its own), but you also need something to restart your microservice.

A microservice needs to be resilient to failures and to be able to restart often on another machine for availability. This resiliency also comes down to the state that was saved on behalf of the microservice, where the microservice can recover this state from, and whether the microservice can restart successfully. In other words, there needs to be resiliency in the compute capability (the process can restart at any time) as well as resilience in the state or data (no data loss, and the data remains consistent).

The problems of resiliency are compounded during other scenarios, such as when failures occur during an application upgrade. The microservice, working with the deployment system, needs to determine whether it can continue to move forward to the newer version or instead roll back to a previous version to maintain a consistent state. Questions such as whether enough machines are available to keep moving forward and how to recover previous versions of the microservice need to be considered. This requires the microservice to emit health information so that the overall application and orchestrator can make these decisions.

In addition, resiliency is related to how cloud-based systems must behave. As mentioned, a cloud-based system must embrace failures and must try to automatically recover from them. For instance, in case of network or container failures, client apps or client services must have a strategy to retry sending messages or to retry requests, since in many cases failures in the cloud are partial. The [Implementing Resilient Applications](#implementing_resilient_apps) section in this guide addresses how to handle partial failure. It describes techniques like retries with exponential backoff or the Circuit Breaker pattern in .NET Core by using libraries like [Polly](https://github.com/App-vNext/Polly), which offers a large variety of policies to handle this subject.

## Health management and diagnostics in microservices

It may seem obvious, and it is often overlooked, but a microservice must report its health and diagnostics. Otherwise, there is little insight from an operations perspective. Correlating diagnostic events across a set of independent services and dealing with machine clock skews to make sense of the event order is challenging. In the same way that you interact with a microservice over agreed-upon protocols and data formats, there is a need for standardization in how to log health and diagnostic events that ultimately end up in an event store for querying and viewing. In a microservices approach, it is key that different teams agree on a single logging format. There needs to be a consistent approach to viewing diagnostic events in the application.

### Health checks

Health is different from diagnostics. Health is about the microservice reporting its current state to take appropriate actions. A good example is working with upgrade and deployment mechanisms to maintain availability. Although a service might currently be unhealthy due to a process crash or machine reboot, the service might still be operational. The last thing you need is to make this worse by performing an upgrade. The best approach is to do an investigation first or allow time for the microservice to recover. Health events from a microservice help us make informed decisions and, in effect, help create self-healing services.

In the []{#_Toc478741165 .anchor}Implementing health checks in ASP.NET Core services section of this guide, we explain how to use a new ASP.NET HealthChecks library in your microservices so they can report their state to a monitoring service to take appropriate actions.

### Using diagnostics and logs event streams

Logs provide information about how an application or service is running, including exceptions, warnings, and simple informational messages. Usually, each log is in a text format with one line per event, although exceptions also often show the stack trace across multiple lines.

In monolithic server-based applications, you can simply write logs to a file on disk (a logfile) and then analyze it with any tool. Since application execution is limited to a fixed server or VM, it generally is not too complex to analyze the flow of events. However, in a distributed application where multiple services are executed across many nodes in an orchestrator cluster, being able to correlate distributed events is a challenge.

A microservice-based application should not try to store the output stream of events or logfiles by itself, and not even try to manage the routing of the events to a central place. It should be transparent, meaning that each process should just write its event stream to a standard output that underneath will be collected by the execution environment infrastructure where it is running. An example of these event stream routers is [Microsoft.Diagnostic.EventFlow](https://github.com/Azure/diagnostics-eventflow), which collects event streams from multiple sources and publishes it to output systems. These can include simple standard output for a development environment or cloud systems like [Application Insights](https://azure.microsoft.com/en-us/services/application-insights/), [OMS](https://github.com/Azure/diagnostics-eventflow#oms-operations-management-suite) (for on-premises applications), and [Azure Diagnostics](https://docs.microsoft.com/en-us/azure/monitoring-and-diagnostics/azure-diagnostics). There are also good third-party log analysis platforms and tools that can search, alert, report, and monitor logs, even in real time, like [Splunk](http://www.splunk.com/goto/Splunk_Log_Management?ac=ga_usa_log_analysis_phrase_Mar17&_kk=logs%20analysis&gclid=CNzkzIrex9MCFYGHfgodW5YOtA).

### Orchestrators managing health and diagnostics information

When you create a microservice-based application, you need to deal with complexity. Of course, a single microservice is simple to deal with, but dozens or hundreds of types and thousands of instances of microservices is a complex problem. It is not just about building your microservice architecture—you also need high availability, addressability, resiliency, health, and diagnostics if you intend to have a stable and cohesive system.

![](./media/image21.png){width="4.774600831146107in" height="2.08576334208224in"}

**Figure 4-21**. A Microservice Platform is fundamental for an application’s health management

The complex problems shown in Figure 4-21 are very hard to solve by yourself. Development teams should focus on solving business problems and building custom applications with microservice-based approaches. They should not focus on solving complex infrastructure problems; if they did, the cost of any microservice-based application would be huge. Therefore, there are microservice-oriented platforms, referred to as orchestrators or microservice clusters, that try to solve the hard problems of building and running a service and using infrastructure resources efficiently. This reduces the complexities of building applications that use a microservices approach.

Different orchestrators might sound similar, but the diagnostics and health checks offered by each of them differ in features and state of maturity, sometimes depending on the OS platform, as explained in the next section.

### Additional resources

-   **The Twelve-Factor App. XI. Logs: Treat logs as event streams**\
    *<https://12factor.net/logs> *

-   **Microsoft Diagnostic EventFlow Library.** GitHub repo.

    [*https://github.com/Azure/diagnostics-eventflow*](https://github.com/Azure/diagnostics-eventflow)

-   **What is Azure Diagnostics**\
    *<https://docs.microsoft.com/en-us/azure/azure-diagnostics> *

-   **Connect Windows computers to the Log Analytics service in Azure**\
    *[https://docs.microsoft.com/en-us/azure/log-analytics/log-analytics-windows-agents](https://docs.microsoft.com/en-us/azure/log-analytics/log-analytics-windows-agents%20) *

-   **Logging What You Mean: Using the Semantic Logging Application Block**\
    *<https://msdn.microsoft.com/en-us/library/dn440729(v=pandp.60).aspx> *

-   **Splunk.** Official site.\
    [*http://www.splunk.com*](http://www.splunk.com)

-   **EventSource Class**. API for events tracing for Windows (ETW)\
    [*https://msdn.microsoft.com/en-us/library/system.diagnostics.tracing.eventsource(v=vs.110).aspx*](https://msdn.microsoft.com/en-us/library/system.diagnostics.tracing.eventsource(v=vs.110).aspx)



>[!div class="step-by-step"]
[Previous] (service-oriented-architecture-.md)
[Next] (orchestrating-microservices-and-multi-container-applications-for-high-scalability-and-availability.md)
