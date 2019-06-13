---
title: SOA applications
description: Bear in mind that containers can also be a useful deployment option for SOA applications.
ms.date: 02/15/2019
---
# Service-oriented applications

Service-Oriented Architecture (SOA) was an overused term that meant many different things to different people. But as a common denominator, SOA means that you structure the architecture of your application by decomposing it into several services (most commonly as HTTP services) that can be classified in different types like subsystems or, in other cases, as tiers.

Today, you can deploy those services as Docker containers, which solve deployment-related issues because all of the dependencies are included in the container image. However, when you need to scale out SOAs, you might encounter challenges if you're deploying based on single instances. This challenge can be handled using Docker clustering software or an orchestrator. We'll look at orchestrators in greater detail in the next section, when we explore microservices approaches.

Docker containers are useful (but not required) for both traditional service-oriented architectures and the more advanced microservices architectures.

At the end of the day, the container clustering solutions are useful for both a traditional SOA architecture and for a more advanced microservices architecture in which each microservice owns its data model. And thanks to multiple databases, you also can scale out the data tier instead of working with monolithic databases shared by the SOA services. However, the discussion about splitting the data is purely about architecture and design.

>[!div class="step-by-step"]
>[Previous](state-and-data-in-docker-applications.md)
>[Next](orchestrate-high-scalability-availability.md)
