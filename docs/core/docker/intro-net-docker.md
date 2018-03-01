---
title: Introduction to .NET and Docker
description: Understanding Docker and .NET Core
keywords: .NET, .NET Core, Docker
author: jralexander
ms.author: johalex
ms.date: 11/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-docker
ms.devlang: dotnet
ms.assetid: 03c28597-7e73-46d6-a9c3-f9cb55642739
manager: wpickett
ms.custom: mvc
ms.workload: 
  - dotnetcore
---
# Introduction to .NET and Docker

This article provides an introduction and conceptual background to working with .NET on Docker.

## Docker: Packaging your apps to deploy and run anywhere

[Docker](../../standard/microservices-architecture/container-docker-introduction/docker-defined.md) is an open platform that enables developers and administrators to build [images](https://docs.docker.com/glossary/?term=image), ship, and run distributed applications in a loosely isolated environment called a [container](https://www.docker.com/what-container). This approach enables efficient application lifecycle management between development, QA, and production environments.
 
The [Docker platform](https://docs.docker.com/engine/docker-overview/#the-docker-platform) uses the [Docker Engine](https://docs.docker.com/engine/docker-overview/#docker-engine) to quickly build and package apps as [Docker images](https://docs.docker.com/glossary/?term=image) created using files written in the [Dockerfile](https://docs.docker.com/glossary/?term=Dockerfile) format that then is deployed and run in a [layered container](https://docs.docker.com/engine/userguide/storagedriver/imagesandcontainers/#container-and-layers).

You can either create your own [layered images](https://docs.docker.com/engine/userguide/storagedriver/imagesandcontainers/#images-and-layers) as dockerfiles or use existing ones from a [registry](https://docs.docker.com/glossary/?term=registry), like [Docker Hub](https://docs.docker.com/glossary/?term=Docker%20Hub).

The [relationship between Docker containers, images, and registries](../../standard/microservices-architecture/container-docker-introduction/docker-containers-images-registries.md) is an important concept when [architecting and building containerized applications or microservices](../../standard/microservices-architecture/architect-microservice-container-applications/index.md). This approach greatly shortens the time between development and deployment.

### Further reading (and watching)

* [Windows-based containers: Modern app development with enterprise-grade control.](https://www.youtube.com/watch?v=Ryx3o0rD5lY&feature=youtu.be)
* [Docker overview](https://docs.docker.com/engine/docker-overview/)
* [Dockerfile on Windows Containers](/virtualization/windowscontainers/manage-docker/manage-windows-dockerfile)
* [Best practices for writing Dockerfiles](https://docs.docker.com/engine/userguide/eng-image/dockerfile_best-practices/)
* [Building Docker Images for .NET Core applications](../docker/building-net-docker-images.md)


### Getting .NET Docker images

The Official .NET Docker images are created and optimized by Microsoft. They are publicly available in the Microsoft repositories on Docker Hub. Each repository can contain multiple images, depending on .NET versions, and on OS versions. Most image repos provide extensive tagging to help you select both a specific framework version and an OS (Linux distro or Windows version).

## Scenario based guidance

Microsoft’s intent for .NET repositories is to have granular and focused repos, which represent a specific scenario or workload.

The `microsoft/aspnetcore` images are optimized for ASP.NET Core apps on Docker, so containers can start faster.

The .NET Core images (`microsoft/dotnet`) are intended for console apps based on .NET Core. For example, batch processes, Azure WebJobs, and other console scenarios should use optimized .NET Core images.

The most obvious horizontal scenario for using Docker and .NET applications is for production deployment and hosting. It turns out that production is just one scenario and the other ones are equally useful. These scenarios are not specific to .NET, but should apply to most developer platforms.

* **Low friction install** — You can try out .NET without a local install. Just download a Docker image with .NET in it.

* **Develop in a container** — You can develop in a consistent environment, making development and production environments similar (avoiding issues like global state on developer machines). Visual Studio Tools for Docker even enable you to start a container directly from Visual Studio.

* **Test in a container** — You can test in a container, reducing failures due to incorrectly configured environments or other changes left behind from the last test.

* **Build in a container** — You can build code in a container, avoiding the need to correctly configure shared build machines for multiple environments but instead move to a “BYOC” (bring your own container) approach.

* **Deployment in all environments** — You can deploy an image through all of your environments. This approach reduces failures due to configuration differences, typically changing the image behavior via external configuration (for example, injected environment variables).

[General guidance](../../standard/microservices-architecture/net-core-net-framework-containers/general-guidance.md) for deciding between .NET Core and .NET Framework for Docker container development.

### Common Docker development scenarios

#### .NET Core

**.NET Core resources**

 Pick the .NET Core samples that fit your scenarios of interest. All sample instructions describe how to target Windows or Linux Docker images from Windows, Linux, or macOS hosts.

The samples use .NET Core 2.0. They use Docker [multi-stage build](https://github.com/dotnet/announcements/issues/18) and [multi-arch tags](https://github.com/dotnet/announcements/issues/14) where appropriate.

* [.NET Core images on DockerHub](https://hub.docker.com/r/microsoft/dotnet/)

* [Dockerize a .NET Core application](https://docs.docker.com/engine/examples/dotnetcore/)

* This .NET Core Docker sample demonstrates how to [use Docker in your .NET Core development process](https://github.com/dotnet/dotnet-docker-samples/tree/master/dotnetapp-dev). The sample works with both Linux and Windows containers.

* This .NET Core Docker sample demonstrates a best practice pattern for [building Docker images for .NET Core apps for production.](https://github.com/dotnet/dotnet-docker-samples/tree/master/dotnetapp-prod) The sample works with both Linux and Windows containers.

* This [.NET Core Docker sample](https://github.com/dotnet/dotnet-docker-samples/tree/master/dotnetapp-selfcontained) demonstrates a best practice pattern for building Docker images for [self-contained .NET Core applications](../deploying/index.md). Used for the smallest production container without a benefit from [sharing base images between containers](https://docs.docker.com/engine/userguide/storagedriver/imagesandcontainers/). However, lower Docker layers could be shared.

#### ARM32 / Raspberry Pi

* [.NET Core Runtime ARM32 builds announcement](https://github.com/dotnet/announcements/issues/29)

* [ARM32 / Raspberry Pi .NET Core images on DockerHub](https://hub.docker.com/r/microsoft/dotnet/)

* [ARM32 / Raspberry Pi .NET Core Docker Samples on GitHub](https://github.com/dotnet/dotnet-docker-samples#arm32--raspberry-pi)

#### .NET Framework

* [.NET Framework images on DockerHub](https://hub.docker.com/r/microsoft/dotnet-framework/)

This repo contain samples that demonstrate various .NET Framework Docker configurations. You can use these images as the basis of your own Docker images.

**.NET Framework 4.7**

The [dotnet-framework:4.7 sample](https://github.com/Microsoft/dotnet-framework-docker-samples/tree/master/dotnetapp-4.7) demonstrates basic "hello world" usage of the [.NET Framework 4.7](../../framework/whats-new/index.md#v47). It shows you how you can build and deploy the app relying on the [.NET Framework 4.7 docker image](https://github.com/Microsoft/dotnet-framework-docker/blob/master/4.7/Dockerfile).

**.NET Framework 4.6.2**

The [dotnet-framework:4.6.2 sample](https://github.com/Microsoft/dotnet-framework-docker-samples/tree/master/dotnetapp-4.6.2) demonstrates basic "hello world" usage of the [.NET Framework 4.6.2](../../framework/whats-new/index.md#v462). It shows you how you can build and deploy the app relying on the [.NET Framework 4.6.2 docker image](https://github.com/Microsoft/dotnet-framework-docker/tree/master/4.6.2).

**.NET Framework 3.5**

 The [dotnet-framework:3.5 sample](https://github.com/Microsoft/dotnet-framework-docker-samples/tree/master/dotnetapp-3.5) demonstrates basic "hello world" usage of [.NET Framework 3.5](https://github.com/Microsoft/dotnet-framework-docker/tree/master/3.5). It shows you how you can build and deploy a project relying on .NET Framework 3.5 in Docker.

#### ASP.NET Core

* [This ASP.NET Core Docker sample](https://github.com/dotnet/dotnet-docker-samples/tree/master/aspnetapp) demonstrates a best practice pattern for building Docker images for ASP.NET Core apps for production. The sample works with both Linux and Windows containers.

* [ASP.NET Core images on DockerHub](https://hub.docker.com/r/microsoft/aspnetcore-build/)

* [ASP.NET Core images on GitHub](https://github.com/aspnet/aspnet-docker)

#### ASP.NET Framework

* [ASP.NET Framework images on DockerHub](https://hub.docker.com/r/microsoft/aspnet/)

* [ASP.NET Web Forms app on .NET Framework 4.6.2 sample](https://github.com/Microsoft/dotnet-framework-docker-samples/tree/master/aspnetapp)

#### Windows Communication Framework (WCF)

* [Windows Communication Framework (WCF) images on DockerHub](https://hub.docker.com/r/microsoft/wcf/)

* [Windows Communication Framework (WCF) images on GitHub](https://github.com/microsoft/iis-docker)

* [Windows Communication Framework (WCF) Docker samples using .NET Full Framework 4.6.2](https://github.com/Microsoft/wcf-docker-samples)

#### Internet Information Server (IIS)

* [Internet Information Server (IIS) images on DockerHub](https://hub.docker.com/r/microsoft/iis/)

* [Internet Information Server (IIS) images on GitHub](https://github.com/microsoft/wcf-docker)

### Interact with other Microsoft stack container images

#### Microsoft SQL Server

* [Run the Microsoft SQL Server for Linux 2017 container image with Docker Quickstart](https://docs.microsoft.com/sql/linux/quickstart-install-connect-docker)

* [Microsoft SQL Server for Linux images on DockerHub](https://hub.docker.com/r/microsoft/mssql-server-windows/)

* [Microsoft SQL Server for Windows Containers images on DockerHub](https://hub.docker.com/r/microsoft/mssql-server-windows/)

* [Microsoft SQL Server Express Edition images for Windows Containers on DockerHub](https://hub.docker.com/r/microsoft/mssql-server-windows-express/)

* [Microsoft SQL Server Developer Edition images for Windows Containers on DockerHub](https://hub.docker.com/r/microsoft/mssql-server-windows-developer/)

#### Visual Studio Team Services (VSTS) agent

* [Visual Studio Team Services (VSTS) agent images on DockerHub](https://hub.docker.com/r/microsoft/vsts-agent/)

* [Visual Studio Team Services (VSTS) agent images on GitHub](https://github.com/Microsoft/vsts-agent-docker)

#### Operations Management Suite (OMS) Linux agent

* [Operations Management Suite (OMS) Linux agent overview](https://github.com/Microsoft/OMS-Agent-for-Linux/blob/master/docs/Docker-Instructions.md#overview)

* [Operations Management Suite (OMS) images on DockerHub](https://hub.docker.com/r/microsoft/vsts-agent/)

* [Operations Management Suite (OMS) images on GitHub](https://github.com/Microsoft/OMS-docker)

#### Microsoft Azure Command Line Interface (CLI)

* [Microsoft Azure Command Line Interface (CLI) images on DockerHub](https://hub.docker.com/r/microsoft/azure-cli/) 

* [Microsoft Azure Command-Line Interface (CLI) images on GitHub](https://github.com/Microsoft/OMS-docker)

> [!NOTE]
> If you do not have an Azure subscription, [sign up today](https://azure.microsoft.com/free/?b=16.48) for a free 30-day account and get $200 in Azure Credits to try out any combination of Azure services.

#### Microsoft Azure Cosmos DB Emulator (Windows Containers only)

* [Microsoft Azure Cosmos DB Emulator images on DockerHub](https://hub.docker.com/r/microsoft/azure-cosmosdb-emulator) 

* [Use the Azure Cosmos DB Emulator for local development and testing](/azure/cosmos-db/local-emulator#developing-with-the-emulator)

## Exploring the rich Docker development ecosystem

Now that you have learned about the Docker platform and different Docker images, the next step is to explore the rich Docker ecosystem. The following links show you how the Microsoft tools complement container development.

* [Using .NET and Docker together](https://blogs.msdn.microsoft.com/dotnet/2017/05/25/using-net-and-docker-together/)
* [Designing and Developing Multi-Container and Microservice-Based .NET Applications](../../standard/microservices-architecture/multi-container-microservice-net-applications/index.md)
* [Visual Studio Code Docker extension](https://code.visualstudio.com/docs/languages/dockerfile)
* [Learn how to use Azure Service Fabric](/azure/service-fabric/index)
* [Service Fabric Getting Started Sample](https://azure.microsoft.com/resources/samples/service-fabric-dotnet-getting-started/)
* [Benefits of Windows Containers](/virtualization/windowscontainers/about/index#video-overview)
* [Working with Visual Studio Docker Tools](/aspnet/core/host-and-deploy/docker/visual-studio-tools-for-docker)
* [Deploying Docker Images from the Azure Container Registry to Azure Container Instances](https://blogs.msdn.microsoft.com/stevelasker/2017/07/28/deploying-docker-images-from-the-azure-container-registry-to-azure-container-instances/)
* [Debugging with Visual Studio Code](https://code.visualstudio.com/docs/nodejs/debugging-recipes#_nodejs-typescript-docker-container)
* [Getting hands on with Visual Studio for Mac, containers, and serverless code in the cloud](https://blogs.msdn.microsoft.com/visualstudio/2017/08/31/hands-on-with-visual-studio-for-mac-containers-serverless-code-in-the-cloud/#comments)
* [Getting Started with Docker and Visual Studio for Mac Lab](https://github.com/Microsoft/vs4mac-labs/tree/master/Docker/Getting-Started)

## Next steps

* [Learn Docker Basics with .NET Core](docker-basics-dotnet-core.md)
* [Building .NET Core Docker Images](building-net-docker-images.md)
