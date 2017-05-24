---
title: Getting data from the existing catalog .NET Core microservice | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Getting data from the existing catalog .NET Core microservice
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Getting data from the existing catalog .NET Core microservice

You can configure the Web Forms application to use the eShopOnContainers catalog microservice to get data instead of using fake data. To do this, you edit the web.config file and set the value of the useFake key to false. The DI container will use the class that accesses the live catalog microservice instead of the class that returns the hard-coded data. No other code changes are needed.

Accessing the live catalog service does mean you need to update the **docker-compose** project to build the catalog service image and launch the catalog service container. Docker CE for Windows supports both Linux containers and Windows Containers, but not at the same time. To run the catalog microservice, you need to build an image that runs the catalog microservice on top of a Windows-based container. This approach requires a different Dockerfile for the microservices project than you have seen in earlier sections. The Dockerfile.windows file contains the configuration settings to build the catalog API container image so that it runs on a Windows container—for example, to use a Windows Nano Docker image.

The catalog microservice relies on the SQL Server database. Therefore, you need to use a Windows-based SQL Server Docker image as well.

After these changes, the docker-compose project does more to start the application. The project now starts the SQL Server using the Windows based SQL Server image. It starts the catalog microservice in a Windows container. And it starts the Web Forms catalog editor container, also in a Windows container. If any of the images need building, the images are created first.


>[!div class="step-by-step"]
[Previous] (lifting-and-shifting.md)
[Next] (development-and-production-environments.md)
