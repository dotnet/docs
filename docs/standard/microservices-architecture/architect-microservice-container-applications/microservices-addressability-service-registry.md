---
title: Microservices addressability and the service registry
description: .NET Microservices Architecture for Containerized .NET Applications | Microservices addressability and the service registry
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
# Microservices addressability and the service registry

Each microservice has a unique name (URL) that is used to resolve its location. Your microservice needs to be addressable wherever it is running. If you have to think about which computer is running a particular microservice, things can go bad quickly. In the same way that DNS resolves a URL to a particular computer, your microservice needs to have a unique name so that its current location is discoverable. Microservices need addressable names that make them independent from the infrastructure that they are running on. This implies that there is an interaction between how your service is deployed and how it is discovered, because there needs to be a [service registry](https://microservices.io/patterns/service-registry.html). In the same vein, when a computer fails, the registry service must be able to indicate where the service is now running.

The [service registry pattern](https://microservices.io/patterns/service-registry.html) is a key part of service discovery. The registry is a database containing the network locations of service instances. A service registry needs to be highly available and up to date. Clients could cache network locations obtained from the service registry. However, that information eventually goes out of date and clients can no longer discover service instances. Consequently, a service registry consists of a cluster of servers that use a replication protocol to maintain consistency.

In some microservice deployment environments (called clusters, to be covered in a later section), service discovery is built-in. For example, within an Azure Container Service environment, Kubernetes and DC/OS with Marathon can handle service instance registration and deregistration. They also run a proxy on each cluster host that plays the role of server-side discovery router. Another example is Azure Service Fabric, which also provides a service registry through its out-of-the-box Naming Service.

Note that there is certain overlap between the service registry and the API gateway pattern, which helps solve this problem as well. For example, the [Service Fabric Reverse Proxy](https://docs.microsoft.com/azure/service-fabric/service-fabric-reverseproxy) is a type of implementation of an API Gateway that is based on the Service Fabrice Naming Service and that helps resolve address resolution to the internal services.

## Additional resources

-   **Chris Richardson. Pattern: Service registry**
    *https://microservices.io/patterns/service-registry.html*

-   **Auth0. The Service Registry**
    [*https://auth0.com/blog/an-introduction-to-microservices-part-3-the-service-registry/*](https://auth0.com/blog/an-introduction-to-microservices-part-3-the-service-registry/)

-   **Gabriel Schenker. Service discovery**
    [*https://lostechies.com/gabrielschenker/2016/01/27/service-discovery/*](https://lostechies.com/gabrielschenker/2016/01/27/service-discovery/)


>[!div class="step-by-step"]
[Previous] (maintain-microservice-apis.md)
[Next] (microservice-based-composite-ui-shape-layout.md)
