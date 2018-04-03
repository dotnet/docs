---
title: Architecture patterns | Serverless apps. Architecture, patterns, and Azure implementation.
description: Review common application architecture patterns including monolithic, N-layer and N-tier, and microservices.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 3/18/2018
ms.prod: .net
ms.technology: dotnet
ms.topic: article
---
# Architecture patterns

Modern business applications follow a variety of architecture patterns. This section represents a survey of common patterns. The patterns listed here aren't necessarily all best practices, but illustrate different approaches.

For more information, see: [Azure application architecture guide](https://docs.microsoft.com/en-us/azure/architecture/guide/).

## Monoliths

Many business applications follow a monolith pattern. Legacy applications are often implemented as monoliths. In the monolith pattern, all application concerns are contained in a single deployment. Everything from user interface to database calls is included in the same codebase.

![Monolith architecture](./media/architecture-patterns/monolith-architecture.png)

There are several advantages to the monolith approach. It is often easy to pull down a single code base and start working. Ramp up time may be less, and creating test environments is as simple as providing a new copy.

Unfortunately, the monolith pattern tends to breakdown at scale. Major disadvantages of the monolith approach include:

* Difficult to work in parallel in the same code base
* Any change, no matter how trivial, requires deploying a new version of the entire application
* Refactoring potentially impacts the entire application
* Often the only solution to scale is to create multiple, resource-intensive copies of the monolith
* As systems expand or other systems are acquired, integration can be difficult
* Code reuse is challenging and often other apps end up having their own copies of code

Many businesses look to the cloud as an opportunity to migrate monolith applications and at the same time refactor them to more usable patterns.

## N-Layer applications

N-layer application partition application logic into specific layers. The most common layers include:

* User interface
* Business logic
* Data access

Other layers may include middleware, batch processing, and API. It is important to note the layers are logical. Although they are developed in isolation, they may all be deployed to the same target platform. 

![N-Layer architecture](./media/architecture-patterns/n-layer-architecture.png)

There are numerous advantages to the N-Layer approach, including:

* Refactoring is isolated to a layer
* Teams can independently build, test, deploy, and maintain separate layers
* Layers can be swapped out, for example the data layer may access multiple databases without requiring changes to the UI layer

Serverless may be used to implement one or more layers.

## Microservices

The term **[microservices](https://docs.microsoft.com/azure/architecture/guide/architecture-styles/microservices)** has recently gained popularity. Although there is no universally accepted definition of microservices, there are many common traits of microservices architectures. Characteristics include:

* Applications are composed of several small services
* Each service runs in its own process
* Services are aligned around business domains
* Services communicate over lightweight APIs, typically using HTTP as the transport
* Services can be deployed and upgraded independently
* Services are not dependent on a single data store
* The system is designed with failure in mind, and the app may still run even when certain services fail

Microservices don't have to be mutual to other architecture approaches. For example, an N-Tier architecture may use microservices for the middle tier. It is also possible to implement microservices in a variety of ways, from virtual directories on IIS hosts to containers. The characteristics of microservices make them especially ideal for serverless implementations.

![Microservices architecture](./media/architecture-patterns/microservices-architecture.png)

The pros of microservices architectures include:

* Refactoring is often isolated to a single service
* Services can be upgraded independently of each other
* Resiliency and elasticity can be tuned to the demands of individual services
* Development can happen in parallel across disparate teams and platforms
* It is easier to write tests for isolated services

Microservices come with their own challenges, including:

* Determining what services are available and how to call them
* Managing the lifecycle of services
* Understanding how services fit together in the overall application
* Full system testing of calls made across disparate services

Ultimately there are solutions to address all of these challenges, including tapping into the benefits of serverless that are discussed later.

>[!div class="step-by-step"]
[Previous] (./index.md)
[Next] (./architecture-deployment-approaches.md)