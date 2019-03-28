---
title: Introduction to Docker
description: This article provides an introduction and overview to Docker in the context of a .NET Core application.
ms.date: 03/20/2019
ms.custom: "mvc, seodec18"
---

# Introduction to .NET and Docker

.NET Core can easily run in a Docker hosted container. Containers provide a lightweight way to isolate your application from the rest of the host system, sharing just the kernel, and using resources given to your application. If you're unfamiliar with Docker, it's highly recommended that you read through Docker's [overview documentation](https://docs.docker.com/engine/docker-overview/).

For more information about how to install Docker, see the download page for [Docker Desktop: Community Edition](https://www.docker.com/products/docker-desktop).

## Docker basics

There are a few concepts you should be familiar with. The Docker client has a command line interface program you use to manage images and containers. As previously stated, you should take the time to read through the [Docker overview](https://docs.docker.com/engine/docker-overview/) documentation. 

### Images

An image is a read-only template with instructions on how to create a container. Much the time an image is based on another image, but with some customization. For example, when you create an image for your application, you would base it on an existing image that already contains the .NET Core runtime.

### Containers

A container is a runnable instance of an image. As you build your image, you deploy your application and dependencies. Then, multiple containers can be instantiated, each isolated from one another. Each container instance has its own filesystem, memory, network interface.

### Registries

Container registries are repositories of container images. You can base your images on a registry image. You can create containers directly from an image in a registry. 

Docker has a public registry hosted at the [Docker Hub](https://hub.docker.com/) that you can use. [.NET Core related images](https://hub.docker.com/_/microsoft-dotnet-core/) are listed at the Docker Hub. 

The [relationship between Docker containers, images, and registries](../../standard/microservices-architecture/container-docker-introduction/docker-containers-images-registries.md) is an important concept when [architecting and building containerized applications or microservices](../../standard/microservices-architecture/architect-microservice-container-applications/index.md). This approach greatly shortens the time between development and deployment.

### Dockerfile

A **Dockerfile** is a file that defines a set of instructions that creates an image. Each instruction in the **Dockerfile** creates a layer in the image. When you rebuild the image, only the layers that have changed are rebuilt. The **Dockerfile** can be distributed to others and allows them to recreate the image on their own system.

## .NET Core images

Official .NET Core Docker images are available at the [Microsoft .NET Core Docker Hub repository](https://hub.docker.com/_/microsoft-dotnet-core/). Each repository contains multiple images for different combinations of the .NET (SDK or Runtime) and OS that you can use. 

Microsoft provides images that are tailored for specific scenarios. For example, the [ASP.NET Core repository](https://hub.docker.com/_/microsoft-dotnet-core-aspnet/) provides images that are built for running ASP.NET Core apps in production. You can use images that include only the Runtime, omitting the SDK so that you can mirror a production environment.

## Azure services

Various Azure services support containers. You create a Docker image for your application and deploy it to one of the following services:

* [Azure Kubernetes Service (AKS)](https://azure.microsoft.com/services/kubernetes-service/)\
Scale and orchestrate Linux containers using Kubernetes.

* [Azure App Service](https://azure.microsoft.com/services/app-service/containers/)\
Deploy web apps or APIs using Linux containers in a PaaS environment.

* [Azure Batch](https://azure.microsoft.com/services/batch/)\
Run repetitive compute jobs using containers.

* [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/)\
Lift, shift, and modernize .NET applications to microservices using Windows Server containers

* [Azure Container Registry](https://azure.microsoft.com/services/container-registry/)\
Store and manage container images across all types of Azure deployments.

## Next steps

* [Learn how to containerize a .NET Core application.](build-docker-netcore-container.md)
* [Try the Learn ASP.NET Core Microservice tutorial.](https://dotnet.microsoft.com/learn/web/aspnet-microservice-tutorial/intro)
