---
title: Domain-Driven Design – Should You Apply It? | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Domain-Driven Design – Should You Apply It?
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Domain-Driven Design – Should You Apply It?

Domain-Driven Design (DDD) is an agile approach to building software that emphasizes focusing on the *business domain*. It places a heavy emphasis on communication and interaction with business domain expert(s) who can relate to the developers how the real-world system works. For example, if you're building a system that handles stock trades, your domain expert might be an experienced stock broker. DDD is designed to address large, complex business problems, and is often not appropriate for smaller, simpler applications, as the investment in understanding and modeling the domain is not worth it.

When building software following a DDD approach, your team (including non-technical stakeholders and contributors) should develop a *ubiquitous language* for the problem space. That is, the same terminology should be used for the real-world concept being modeled, the software equivalent, and any structures that might exist to persist the concept (e.g. database tables). Thus, the concepts described in the ubiquitous language should form the basis for your *domain model*.

Your domain model is comprised of objects that interact with one another to represent the behavior of the system. These objects may fall into the following categories:

-   [Entities](http://deviq.com/entity/), which represent objects with a thread of identity. Entities are typically stored in persistence with a key by which they can later be retrieved.

-   [Aggregates](http://deviq.com/aggregate-pattern/), which represent groups of objects that should be persisted as a unit.

-   [Value objects](http://deviq.com/value-object/), which represent concepts that can be compared on the basis of the sum of their property values. For example, DateRange consisting of a start and end date.

-   [Domain events](https://martinfowler.com/eaaDev/DomainEvent.html), which represent things happening within the system that are of interest to other parts of the system.

Note that a DDD domain model should encapsulate complex behavior within the model. Entities, in particular, should not merely be collections of properties. When the domain model lacks behavior and merely represents the state of the system, it is said to be an [anemic model](http://deviq.com/anemic-model/), which is undesirable in DDD.

In addition to these model types, DDD typically employs a variety of patterns:

-   [Repository](http://deviq.com/repository-pattern/), for abstracting persistence details.

-   [Factory](https://en.wikipedia.org/wiki/Factory_method_pattern), for encapsulating complex object creation.

-   Domain events, for decoupling dependent behavior from triggering behavior.

-   [Services](http://gorodinski.com/blog/2012/04/14/services-in-domain-driven-design-ddd/), for encapsulating complex behavior and/or infrastructure implementation details.

-   [Command](https://en.wikipedia.org/wiki/Command_pattern), for decoupling issuing commands and executing the command itself.

-   [Specification](http://deviq.com/specification-pattern/), for encapsulating query details.

DDD also recommends the use of the Clean Architecture discussed previously, allowing for loose coupling, encapsulation, and code that can easily be verified using unit tests.

## When Should You Apply DDD

DDD is well-suited to large applications with significant business (not just technical) complexity. The application should require the knowledge of domain experts. There should be significant behavior in the domain model itself, representing business rules and interactions beyond simply storing and retrieving the current state of various records from data stores.

## When Shouldn't You Apply DDD

DDD involves investments in modeling, architecture, and communication that may not be warranted for smaller applications or applications that are essentially just CRUD (create/read/update/delete). If you choose to approach your application following DDD, but find that your domain has an anemic model with no behavior, you may need to rethink your approach. Either your application may not need DDD, or you may need assistance refactoring your application to encapsulate business logic in the domain model, rather than in your database or user interface.

A hybrid approach would be to only use DDD for the transactional or more complex areas of the application, but not for simpler CRUD or read-only portions of the application. For instance, you needn't have the constraints of an Aggregate if you're querying data to display a report or to visualize data for a dashboard. It's perfectly acceptable to have a separate, simpler read model for such requirements.

> ### References – Domain-Driven Design
> - **Domain-Driven Design Fundamentals (course)**  
> http://bit.ly/PS-DDD
> - **Design Patterns Library (course)**  
> <http://bit.ly/DesignPatternsLibrary>
> - **DDD in Plain English (StackOverflow Answer)**  
> <http://bit.ly/2pmVgK2>


>[!div class="step-by-step"]
[Previous] (client-communication.md)
[Next] (.md)
