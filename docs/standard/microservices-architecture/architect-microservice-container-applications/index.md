---
title: Architecting Container and Microservice Based Applications
description: .NET Microservices Architecture for Containerized .NET Applications | Architecting Container and Microservice Based Applications
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
# Architecting Container- and Microservice-Based Applications

*Microservices offer great benefits but also raise huge new challenges. Microservice architecture patterns are fundamental pillars when creating a microservice-based application.*

Earlier in this guide, you learned basic concepts about containers and Docker. That was the minimum information you need in order to get started with containers. Although, even when containers are enablers and a great fit for microservices, they are not mandatory for a microservice architecture and many architectural concepts in this architecture section could be applied without containers, too. However, this guidance focuses on the intersection of both due to the already introduced importance of containers.

Enterprise applications can be complex and are often composed of multiple services instead of a single service-based application. For those cases, you need to understand additional architectural approaches, such as the microservices and certain Domain-Driven Design (DDD) patterns plus container orchestration concepts. Note that this chapter describes not just microservices on containers, but any containerized application, as well.

## Container design principles

In the container model, a container image instance represents a single process. By defining a container image as a process boundary, you can create primitives that can be used to scale the process or to batch it.

When you design a container image, you will see an [ENTRYPOINT](https://docs.docker.com/engine/reference/builder/) definition in the Dockerfile. This defines the process whose lifetime controls the lifetime of the container. When the process completes, the container lifecycle ends. Containers might represent long-running processes like web servers, but can also represent short-lived processes like batch jobs, which formerly might have been implemented as Azure [WebJobs](https://docs.microsoft.com/azure/app-service-web/websites-webjobs-resources).

If the process fails, the container ends, and the orchestrator takes over. If the orchestrator was configured to keep five instances running and one fails, the orchestrator will create another container instance to replace the failed process. In a batch job, the process is started with parameters. When the process completes, the work is complete. This guidance drills-down on orchestrators, later on.

You might find a scenario where you want multiple processes running in a single container. For that scenario, since there can be only one entry point per container, you could run a script within the container that launches as many programs as needed. For example, you can use [Supervisor](http://supervisord.org/) or a similar tool to take care of launching multiple processes inside a single container. However, even though you can find architectures that hold multiple processes per container, that approach it is not very common.


>[!div class="step-by-step"]
[Previous] (../net-core-net-framework-containers/official-net-docker-images.md)
[Next] (containerize-monolithic-applications.md)
