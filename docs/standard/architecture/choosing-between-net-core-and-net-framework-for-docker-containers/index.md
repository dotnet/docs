---
title: Choosing Between .NET Core and .NET Framework for Docker Containers | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Choosing Between .NET Core and .NET Framework for Docker Containers
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
-   [General guidance](#general-guidance)
-   [When to choose .NET Core for Docker containers](#when-to-choose-.net-core-for-docker-containers)
    -   [Developing and deploying cross platform](#developing-and-deploying-cross-platform)
    -   [Using containers for new (“green-field”) projects](#using-containers-for-new-green-field-projects)
    -   [Creating and deploying microservices on containers](#creating-and-deploying-microservices-on-containers)
    -   [Deploying high density in scalable systems](#deploying-high-density-in-scalable-systems)
-   [When to choose .NET Framework for Docker containers](#when-to-choose-.net-framework-for-docker-containers)
    -   [Migrating existing applications directly to a Docker container](#migrating-existing-applications-directly-to-a-docker-container)
    -   [Using third-party .NET libraries or NuGet packages not available for .NET Core](#using-third-party-.net-libraries-or-nuget-packages-not-available-for-.net-core)
    -   [Using.NET technologies not available for .NET Core ](#using.net-technologies-not-available-for-.net-core)
    -   [Using a platform or API that does not support .NET Core](#using-a-platform-or-api-that-does-not-support-.net-core)
        -   [Additional resources](#additional-resources)
-   [Decision table: .NET frameworks to use for Docker](#decision-table-.net-frameworks-to-use-for-docker)
-   [What OS to target with .NET containers](#what-os-to-target-with-.net-containers)
-   [Official .NET Docker images](#official-.net-docker-images)
    -   [.NET Core and Docker image optimizations for development versus production](#net-core-and-docker-image-optimizations-for-development-versus-production)
        -   [During development and build](#during-development-and-build)
        -   [In production](#in-production)


There are two supported frameworks for building server-side containerized Docker applications with .NET: [.NET Framework](https://www.microsoft.com/net/download/framework) and [.NET Core](https://www.microsoft.com/net/download/core). They share many.NET platform components, and you can share code across the two. However, there are fundamental differences between them, and which framework you use will depend on what you want to accomplish. This section provides guidance on when to choose each framework.


>[!div class="step-by-step"]
[Previous] (../introduction-to-containers-and-docker/docker-containers,-images,-and-registries.md)
[Next] (general-guidance.md)
