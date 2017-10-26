---
title: Walkthrough 2: Containerize your existing .NET applications with Windows Containers | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Walkthrough 2: Containerize your existing .NET applications with Windows Containers
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# Walkthrough 2: Containerize your existing .NET applications with Windows Containers

## Technical walkthrough availability

The full technical walkthrough is available in the eShopModernizing GitHub repo wiki:

[https://github.com/dotnet-architecture/eShopModernizing/wiki/02.-How-to-containerized-the-.NET-Framework-web-apps-with-Windows-Containers-and-Docker](https://https://github.com/dotnet-architecture/eShopModernizing/wiki/02.-How-to-containerized-the-.NET-Framework-web-apps-with-Windows-Containers-and-DockerTBD)

## Overview

Use Windows Containers to improve deployment of existing .NET applications, like those based on MVC, Web Forms, or WCF, to production, development, and test environments.

## Goals

The goal of this walkthrough is to show you several options for containerizing an existing .NET Framework application. You can:

-   Containerize your application by using [Visual Studio 2017 Tools for Docker](https://docs.microsoft.com/en-us/dotnet/core/docker/visual-studio-tools-for-docker) (Visual Studio 2017 or later versions).

-   Containerize your application by manually adding a [Dockerfile](https://docs.docker.com/engine/reference/builder/), and then using the [Docker CLI](https://docs.docker.com/engine/reference/commandline/cli/).

-   Containerize your application by using the [Img2Docker](https://github.com/docker/communitytools-image2docker-win) tool (an open-source tool from Docker).

This walkthrough focuses on the Visual Studio 2017 Tools for Docker approach, but the other two approaches are fairly similar in regards to using Dockerfiles.

## Scenario

Figure 5-3 shows the scenario for containerized eShop legacy applications.

> ![](./media/image3.png)
>
> **Figure 5-3.** Simplified architecture diagram of containerized applications in a development environment

## Benefits

There are advantages to running your monolithic application in a container. First, you create an image for the application. From that point on, every deployment runs in the same environment. Every container uses the same OS version, has the same version of dependencies installed, uses the same .NET framework version, and is built by using the same process. Basically, you control the dependencies of your application by using a Docker image. The dependencies travel with the application when you deploy the containers.

An additional benefit is that developers can run the application in the consistent environment that's provided by Windows Containers. Issues that appear only with certain versions can be spotted immediately, instead of surfacing in a staging or production environment. Differences in development environments used by members of the development team matter less when applications run in containers.

Containerized applications also have a flatter scale-out curve. Containerized apps enable you to have more application and service instances (based on containers) in a VM or physical machine compared to regular application deployments per machine. This translates to higher density and fewer required resources, especially when you use orchestrators like Kubernetes or Service Fabric.

Containerization, in ideal situations, does not require making any changes to the application code (C\#). In most scenarios, you just need the Docker deployment metadata files (Dockerfiles and Docker Compose files).

## Next steps

Explore this content more in-depth on the GitHub wiki:

<https://https://github.com/dotnet-architecture/eShopModernizing/wiki/02.-How-to-containerized-the-.NET-Framework-web-apps-with-Windows-Containers-and-Docker>


> [Previous](walkthrough-1-tour-of-eshop-legacy-apps.md)  
[Next](walkthrough-3-deploy-your-windows-containers-based-app-to-azure-vms.md)
