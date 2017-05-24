---
title: Development and production environments | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Development and production environments
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Development and production environments

There are a couple of differences between the development configuration and a production configuration. In the development environment, you run the Web Forms application, the catalog microservice, and SQL Server in Windows Containers, as part of the same Docker host. In earlier sections, we mentioned SQL Server images deployed in the same Docker host as the other .NET Core-based services on a Linux-based Docker host. The advantage of running the multiple microservices in the same Docker host (or cluster) is that there is less network communication and the communication between containers has lower latency.

In the development environment, you must run all the containers in the same OS. Docker CE for Windows does not support running Windows- and Linux-based containers at the same time. In production, you can decide if you want to run the catalog microservice in a Windows container in a single Docker host (or cluster), or have the Web Forms application communicate with an instance of the catalog microservice running in a Linux container on a different Docker host. It depends on how you want to optimize for network latency. In most cases, you want the microservices that your applications depend on running in the same Docker host (or swarm) for ease of deployment and lower communication latency. In those configurations, the only costly communications is between the microservice instances and the high-availability servers for the persistent data storage.

>[!div class="step-by-step"]
[Previous] (getting-data-from-the-existing-catalog-net-core-microservice.md)
[Next] (../designing-and-developing-multi-container-and-microservice-based-net-applications/index.md)
