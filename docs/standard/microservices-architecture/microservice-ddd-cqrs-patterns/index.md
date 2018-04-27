---
title: Tackling Business Complexity in a Microservice with DDD and CQRS Patterns
description: .NET Microservices Architecture for Containerized .NET Applications | Tackling Business Complexity in a Microservice with DDD and CQRS Patterns
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Tackling Business Complexity in a Microservice with DDD and CQRS Patterns

*Design a domain model for each microservice or Bounded Context that reflects understanding of the business domain.*

This section focuses on more advanced microservices that you implement when you need to tackle complex subsystems, or microservices derived from the knowledge of domain experts with ever-changing business rules. The architecture patterns used in this section are based on domain-driven design (DDD) and Command and Query Responsibility Segregation (CQRS) approaches, as illustrated in Figure 9-1.

![](./media/image1.png)

**Figure 9-1**. External microservice architecture versus internal architecture patterns for each microservice

However, most of the techniques for data driven microservices, such as how to implement an ASP.NET Core Web API service or how to expose Swagger metadata with Swashbuckle, are also applicable to the more advanced microservices implemented internally with DDD patterns. This section is an extension of the previous sections, because most of the practices explained earlier also apply here or for any kind of microservice.

This section first provides details on the simplified CQRS patterns used in the eShopOnContainers reference application. Later, you will get an overview of the DDD techniques that enable you to find common patterns that you can reuse in your applications.

DDD is a large topic with a rich set of resources for learning. You can start with books like [Domain-Driven Design](https://domainlanguage.com/ddd/) by Eric Evans and additional materials from Vaughn Vernon, Jimmy Nilsson, Greg Young, Udi Dahan, Jimmy Bogard, and many other DDD/CQRS experts. But most of all you need to try to learn how to apply DDD techniques from the conversations, whiteboarding, and domain modeling sessions with the experts in your concrete business domain.

#### Additional resources

##### DDD (Domain-Driven Design)

-   **Eric Evans. Domain Language**
    [*https://domainlanguage.com/*](https://domainlanguage.com/)

-   **Martin Fowler. Domain-Driven Design**
    [*https://martinfowler.com/tags/domain%20driven%20design.html*](https://martinfowler.com/tags/domain%20driven%20design.html)

-   **Jimmy Bogard. Strengthening your domain: a primer**
    [*https://lostechies.com/jimmybogard/2010/02/04/strengthening-your-domain-a-primer/*](https://lostechies.com/jimmybogard/2010/02/04/strengthening-your-domain-a-primer/)

##### DDD books

-   **Eric Evans. Domain-Driven Design: Tackling Complexity in the Heart of Software**
    [*https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215/*](https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215/)

-   **Eric Evans. Domain-Driven Design Reference: Definitions and Pattern Summaries**
    [*https://www.amazon.com/Domain-Driven-Design-Reference-Definitions-2014-09-22/dp/B01N8YB4ZO/*](https://www.amazon.com/Domain-Driven-Design-Reference-Definitions-2014-09-22/dp/B01N8YB4ZO/)

-   **Vaughn Vernon. Implementing Domain-Driven Design**
    [*https://www.amazon.com/Implementing-Domain-Driven-Design-Vaughn-Vernon/dp/0321834577/*](https://www.amazon.com/Implementing-Domain-Driven-Design-Vaughn-Vernon/dp/0321834577/)

-   **Vaughn Vernon. Domain-Driven Design Distilled**
    [*https://www.amazon.com/Domain-Driven-Design-Distilled-Vaughn-Vernon/dp/0134434420/*](https://www.amazon.com/Domain-Driven-Design-Distilled-Vaughn-Vernon/dp/0134434420/)

-   **Jimmy Nilsson. Applying Domain-Driven Design and Patterns**
    [*https://www.amazon.com/Applying-Domain-Driven-Design-Patterns-Examples/dp/0321268202/*](https://www.amazon.com/Applying-Domain-Driven-Design-Patterns-Examples/dp/0321268202/)

-   **Cesar de la Torre. N-Layered Domain-Oriented Architecture Guide with .NET**
    [*https://www.amazon.com/N-Layered-Domain-Oriented-Architecture-Guide-NET/dp/8493903612/*](https://www.amazon.com/N-Layered-Domain-Oriented-Architecture-Guide-NET/dp/8493903612/)

-   **Abel Avram and Floyd Marinescu. Domain-Driven Design Quickly**
    [*https://www.amazon.com/Domain-Driven-Design-Quickly-Abel-Avram/dp/1411609255/*](https://www.amazon.com/Domain-Driven-Design-Quickly-Abel-Avram/dp/1411609255/)

DDD training

-   **Julie Lerman and Steve Smith. Domain-Driven Design Fundamentals**
    [*http://bit.ly/PS-DDD*](http://bit.ly/PS-DDD)


>[!div class="step-by-step"]
[Previous] (../multi-container-microservice-net-applications/background-tasks-with-ihostedservice.md)
[Next] (apply-simplified-microservice-cqrs-ddd-patterns.md)
