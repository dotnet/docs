---
title: Creating, evolving, and versioning microservice APIs and contracts
description: .NET Microservices Architecture for Containerized .NET Applications | Creating, evolving, and versioning microservice APIs and contracts
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
# Creating, evolving, and versioning microservice APIs and contracts

A microservice API is a contract between the service and its clients. You will be able to evolve a microservice independently only if you do not break its API contract, which is why the contract is so important. If you change the contract, it will impact your client applications or your API Gateway.

The nature of the API definition depends on which protocol you are using. For instance, if you are using messaging (like [AMQP](https://www.amqp.org/)), the API consists of the message types. If you are using HTTP and RESTful services, the API consists of the URLs and the request and response JSON formats.

However, even if you are thoughtful about your initial contract, a service API will need to change over time. When that happens—and especially if your API is a public API consumed by multiple client applications—you typically cannot force all clients to upgrade to your new API contract. You usually need to incrementally deploy new versions of a service in a way that both old and new versions of a service contract are running simultaneously. Therefore, it is important to have a strategy for your service versioning.

When the API changes are small, like if you add attributes or parameters to your API, clients that use an older API should switch and work with the new version of the service. You might be able to provide default values for any missing attributes that are required, and the clients might be able to ignore any extra response attributes.

However, sometimes you need to make major and incompatible changes to a service API. Because you might not be able to force client applications or services to upgrade immediately to the new version, a service must support older versions of the API for some period. If you are using an HTTP-based mechanism such as REST, one approach is to embed the API version number in the URL or into a HTTP header. Then you can decide between implementing both versions of the service simultaneously within the same service instance, or deploying different instances that each handle a version of the API. A good approach for this is the [Mediator pattern](https://en.wikipedia.org/wiki/Mediator_pattern) (for example, [MediatR library](https://github.com/jbogard/MediatR)) to decouple the different implementation versions into independent handlers.

Finally, if you are using a REST architecture, [Hypermedia](https://www.infoq.com/articles/mark-baker-hypermedia) is the best solution for versioning your services and allowing evolvable APIs.

## Additional resources

-   **Scott Hanselman. ASP.NET Core RESTful Web API versioning made easy**
    <https://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx>

-   **Versioning a RESTful web API**
    [*https://docs.microsoft.com/azure/architecture/best-practices/api-design#versioning-a-restful-web-api*](https://docs.microsoft.com/azure/architecture/best-practices/api-design#versioning-a-restful-web-api)

-   **Roy Fielding. Versioning, Hypermedia, and REST**
    <https://www.infoq.com/articles/roy-fielding-on-versioning>


>[!div class="step-by-step"]
[Previous] (asynchronous-message-based-communication.md)
[Next] (microservices-addressability-service-registry.md)
