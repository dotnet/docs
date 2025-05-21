---
title: Introduction to Docker
description: This article provides an introduction and overview to Docker containers in the context of a .NET application.
ms.date: 09/25/2023
ms.custom: "mvc"
ms.topic: concept-article
---

# Introduction to .NET and Docker

Containers are one of the most popular ways for deploying and hosting cloud applications, with tools like [Docker](https://www.docker.com/), [Kubernetes](https://kubernetes.io/), and [Podman](https://podman.io/). Many developers choose containers because it's straightforward to package an app with its dependencies and get that app to reliably run on any container host. There's extensive support for [using .NET with containers](https://devblogs.microsoft.com/dotnet/category/containers/).

Docker provides a great [overview](https://docs.docker.com/engine/docker-overview/) of containers. [Docker Desktop: Community Edition](https://www.docker.com/products/docker-desktop) is a good tool to use for using containers on developer desktop machine.

## .NET images

Official .NET container images are published to the [Microsoft Artifact Registry](https://mcr.microsoft.com/) and are discoverable on the [Docker Hub](https://hub.docker.com/_/microsoft-dotnet/). There are [runtime images](https://mcr.microsoft.com/product/dotnet/aspnet/) for production and [SDK images](https://mcr.microsoft.com/product/dotnet/sdk/) for building your code, for Linux (Alpine, Debian, Ubuntu, Mariner) and Windows. For more information, see [.NET container images](container-images.md).

.NET images are regularly updated whenever a new .NET patch is published or when an operating system base image is updated.

[Chiseled container images](https://devblogs.microsoft.com/dotnet/announcing-dotnet-chiseled-containers/) are Ubuntu container images with a minimal set of components required by the .NET runtime. These images are ~100 MB smaller than the regular Ubuntu images and have fewer [CVEs](https://www.cve.org/) since they have fewer components. In particular, they don't contain a shell or package manager, which significantly improves their security profile. They also include a [non-root user](https://devblogs.microsoft.com/dotnet/securing-containers-with-rootless/) and are configured with that user enabled.

## Building container images

You can build a container image with a **Dockerfile** or rely on the [.NET SDK to produce an image](../containers/sdk-publish.md). For samples on building images, see [dotnet/dotnet-docker](https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md) and [dotnet/sdk-container-builds](https://github.com/dotnet/sdk-container-builds).

The following example demonstrates building and running a container image in a few quick steps (supported with .NET 8 and .NET 7.0.300).

```bash
$ dotnet new webapp -o webapp
$ cd webapp/
$ dotnet publish -t:PublishContainer
MSBuild version 17.8.3+195e7f5a3 for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  webapp -> /home/rich/webapp/bin/Release/net8.0/webapp.dll
  webapp -> /home/rich/webapp/bin/Release/net8.0/publish/
  Building image 'webapp' with tags 'latest' on top of base image 'mcr.microsoft.com/dotnet/aspnet:8.0'.
  Pushed image 'webapp:latest' to local registry via 'docker'.
$ docker run --rm -d -p 8000:8080 webapp
7c7ad33409e52ddd3a9d330902acdd49845ca4575e39a6494952b642e584016e
$ curl -s http://localhost:8000 | grep ASP.NET
    <p>Learn about <a href="https://learn.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
$ docker ps
CONTAINER ID   IMAGE     COMMAND               CREATED              STATUS              PORTS                                       NAMES
7c7ad33409e5   webapp    "dotnet webapp.dll"   About a minute ago   Up About a minute   0.0.0.0:8000->8080/tcp, :::8000->8080/tcp   jovial_shtern
$ docker kill 7c7ad33409e5
```

[`docker init`](https://www.docker.com/blog/docker-desktop-4-23/) is a new option for developers wanting to use Dockerfiles.

## Ports

[Port mapping](https://docs.docker.com/network/#published-ports) is a key part of using containers. Ports must be published outside the container in order to respond to external web requests. ASP.NET Core container images [changed in .NET 8](../compatibility/containers/8.0/aspnet-port.md) to listen on port `8080`, by default. .NET 6 and 7 listen on port `80`.

In the prior example with `docker run`, the host port `8000` is mapped to the container port `8080`. Kubernetes works in a similar way.

The `ASPNETCORE_HTTP_PORTS`, `ASPNETCORE_HTTPS_PORTS`, and `ASPNETCORE_URLS` environment variables can be used to configure this behavior.

## Users

Starting with .NET 8, all images include a non-root user called `app`. By default, chiseled images are configured with this user enabled. The publish app as .NET container feature (demonstrated in the [Building container images](#building-container-images) section) also configures images with this user enabled by default. In all other scenarios, the `app` user can be set manually, for example with the `USER` *Dockerfile* instruction. If an image has been configured with `app` and commands need to run as `root`, then the `USER` instruction can be used to set to the user to `root`.

## Staying informed

Container-related news is posted to [dotnet/dotnet-docker discussions](https://github.com/dotnet/dotnet-docker/discussions) and to the [.NET Blog "containers" category](https://devblogs.microsoft.com/dotnet/category/containers/).

## Azure services

Various Azure services support containers. You create a Docker image for your application and deploy it to one of the following services:

- [Azure Kubernetes Service (AKS)](https://azure.microsoft.com/services/kubernetes-service/)\
Scale and orchestrate Windows & Linux containers using Kubernetes.

- [Azure App Service](https://azure.microsoft.com/services/app-service/containers/)\
Deploy web apps or APIs using containers in a PaaS environment.

- [Azure Container Apps](https://azure.microsoft.com/services/container-apps/)\
Run your container workloads without managing servers, orchestration, or infrastructure and leverage native support for [Dapr](https://dapr.io/) and [KEDA](https://keda.sh/) for observability and scaling to zero.

- [Azure Container Instances](https://azure.microsoft.com/services/container-instances/)\
Create individual containers in the cloud without any higher-level management services.

- [Azure Batch](https://azure.microsoft.com/services/batch/)\
Run repetitive compute jobs using containers.

- [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/)\
Lift, shift, and modernize .NET applications to microservices using Windows & Linux containers.

- [Azure Container Registry](https://azure.microsoft.com/services/container-registry/)\
Store and manage container images across all types of Azure deployments.

## Next steps

- [Learn how to containerize a .NET Core application.](build-container.md)
- [Learn how to containerize an ASP.NET Core application.](/aspnet/core/host-and-deploy/docker/building-net-docker-images)
- [Try the Learn ASP.NET Core Microservice tutorial.](https://dotnet.microsoft.com/learn/web/aspnet-microservice-tutorial/intro)
- [Learn about Container Tools in Visual Studio](/visualstudio/containers/overview)
