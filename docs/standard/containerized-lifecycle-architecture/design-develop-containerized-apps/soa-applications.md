---
title: SOA applications
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
ms.prod: ".net"
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/22/2017
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# SOA applications

SOA was an overused term and meant so many different things to different people. But at a minimum and as a common denominator, SOA, or service orientation, mean that you structure the architecture of your application by decomposing it in multiple services (most commonly as HTTP services) that can be classified in different types like subsystems or, in other cases, as tiers.

Today, you can deploy those services as Docker containers, which solves deployment-related issues because all of the dependencies are included within the container image. However, when you need to scale-out SOAs, you might encounter challenges if you are deploying based on single instances. This is where a Docker clustering software or orchestrator will help you. We'll look at this in greater detail in the next section when we examine microservices approaches.

At the end of the day, the container clustering solutions are useful for both a traditional SOA architecture or for a more advanced microservices architecture in which each microservice owns its data model. And, thanks to multiple databases, you also can scale-out the data tier instead of working with monolithic databases shared by the SOA services. However, the discussion about splitting the data is purely about architecture and design.


>[!div class="step-by-step"]
[Previous] (state-and-data-in-docker-applications.md)
[Next] (orchestrate-high-scalability-availability.md)
