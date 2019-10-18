---
title: Introduction to Docker
description: This article provides an introduction and overview to Docker in the context of a .NET Core application.
ms.date: 03/20/2019
ms.custom: "mvc, seodec18"
---

# Introduction to .NET and Docker

.NET Core can easily run in a Docker container. Containers provide a lightweight way to isolate your application from the rest of the host system, sharing just the kernel, and using resources given to your application. If you're unfamiliar with Docker, it's highly recommended that you read through Docker's [overview documentation](https://docs.docker.com/engine/docker-overview/).

For more information about how to install Docker, see the download page for [Docker Desktop: Community Edition](https://www.docker.com/products/docker-desktop).

## Docker basics

There are a few concepts you should be familiar with. The Docker client has a command line interface program you use to manage images and containers. As previously stated, you should take the time to read through the [Docker overview](https://docs.docker.com/engine/docker-overview/) documentation. 

### Images

An image is an ordered collection of filesystem changes that form the basis of a container. The image doesn't have a state and is read-only. Much the time an image is based on another image, but with some customization. For example, when you create an new image for your application, you would base it on an existing image that already contains the .NET Core runtime.

Because containers are created from images, images have a set of run parameters (such as a starting executable) that run when the container starts.

### Containers

A container is a runnable instance of an image. As you build your image, you deploy your application and dependencies. Then, multiple containers can be instantiated, each isolated from one another. Each container instance has its own filesystem, memory, and network interface.

### Registries

Container registries are a collection of image repositories. You can base your images on a registry image. You can create containers directly from an image in a registry. The [relationship between Docker containers, images, and registries](../../architecture/microservices/container-docker-introduction/docker-containers-images-registries.md) is an important concept when [architecting and building containerized applications or microservices](../../architecture/microservices/architect-microservice-container-applications/index.md). This approach greatly shortens the time between development and deployment.

Docker has a public registry hosted at the [Docker Hub](https://hub.docker.com/) that you can use. [.NET Core related images](https://hub.docker.com/_/microsoft-dotnet-core/) are listed at the Docker Hub. 

The Microsoft Container Registry (MCR) is the official source of Microsoft-provided container images. The MCR is built on Azure CDN to provide globally-replicated images. However, the MCR does not have a public-facing website and the primary way to learn about Microsoft-provided container images is through the [Microsoft Docker Hub pages](https://hub.docker.com/_/microsoft-dotnet-core/).

### Dockerfile

A **Dockerfile** is a file that defines a set of instructions that creates an image. Each instruction in the **Dockerfile** creates a layer in the image. For the most part, when you rebuild the image only the layers that have changed are rebuilt. The **Dockerfile** can be distributed to others and allows them to recreate a new image in the same manner you created it. While this allows you to distribute the *instructions* on how to create the image, the main way to distribute your image is to publish it to a registry.

## .NET Core images

Official .NET Core Docker images are published to the Microsoft Container Registry (MCR) and are discoverable at the [Microsoft .NET Core Docker Hub repository](https://hub.docker.com/_/microsoft-dotnet-core/). Each repository contains images for different combinations of the .NET (SDK or Runtime) and OS that you can use. 

Microsoft provides images that are tailored for specific scenarios. For example, the [ASP.NET Core repository](https://hub.docker.com/_/microsoft-dotnet-core-aspnet/) provides images that are built for running ASP.NET Core apps in production.

## Azure services

Various Azure services support containers. You create a Docker image for your application and deploy it to one of the following services:

- [Azure Kubernetes Service (AKS)](https://azure.microsoft.com/services/kubernetes-service/)\
Scale and orchestrate Linux containers using Kubernetes.

- [Azure App Service](https://azure.microsoft.com/services/app-service/containers/)\
Deploy web apps or APIs using Linux containers in a PaaS environment.

- [Azure Container Instances](https://azure.microsoft.com/services/container-instances/)\
Host your container in the cloud without any higher-level management services.

 [Azure Batch](https://azure.microsoft.com/services/batch/)\
Run repetitive compute jobs using containers.

- [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/)\
Lift, shift, and modernize .NET applications to microservices using Windows Server containers.

- [Azure Container Registry](https://azure.microsoft.com/services/container-registry/)\
Store and manage container images across all types of Azure deployments.

## Next steps

- [Learn how to containerize a .NET Core application.](build-docker-netcore-container.md)
- [Learn how to containerize an ASP.NET Core application.](/aspnet/core/host-and-deploy/docker/building-net-docker-images)
- [Try the Learn ASP.NET Core Microservice tutorial.](https://dotnet.microsoft.com/learn/web/aspnet-microservice-tutorial/intro)
- [Learn about Container Tools in Visual Studio](/visualstudio/containers/overview)
