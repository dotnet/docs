---
title: Introduction to Docker
description: This article provides an introduction and overview to Docker containers in the context of a .NET application.
ms.date: 11/17/2026
ms.custom: "mvc"
ai-usage: ai-assisted
---

# Introduction to .NET and Docker

Containers are one of the most popular ways for deploying and hosting cloud applications, with tools like [Docker](https://www.docker.com/), [Kubernetes](https://kubernetes.io/), and [Podman](https://podman.io/). Many developers choose containers because it's straightforward to package an app with its dependencies and get that app to reliably run on any container host. There's extensive support for [using .NET with containers](https://devblogs.microsoft.com/dotnet/category/containers/).

Docker provides a great [overview](https://docs.docker.com/engine/docker-overview/) of containers. [Docker Desktop: Community Edition](https://www.docker.com/products/docker-desktop) is a good tool to use for using containers on developer desktop machine.

## .NET images

Official .NET container images are published to [Microsoft Artifact Registry](https://mcr.microsoft.com/) and discoverable on [Docker Hub](https://hub.docker.com/_/microsoft-dotnet/). Microsoft provides [runtime images](https://mcr.microsoft.com/product/dotnet/aspnet/) for production and [SDK images](https://mcr.microsoft.com/product/dotnet/sdk/) for building your code. Images for .NET 10 and .NET 11 are available for Linux (Alpine, Azure Linux, and Ubuntu) and Windows (Nano Server and Windows Server Core). Because the set of supported distributions changes over time, check the [full tag listing](https://github.com/dotnet/dotnet-docker/blob/main/README.aspnet.md#full-tag-listing) for the current list of images. For more information, see [.NET container images](container-images.md).

.NET images are regularly updated whenever a new .NET patch is published or when an operating system base image is updated.

[Chiseled container images](https://devblogs.microsoft.com/dotnet/announcing-dotnet-chiseled-containers/) are Ubuntu container images with only the minimal components required by the .NET runtime. These images are smaller than regular Ubuntu images and have fewer [CVEs](https://www.cve.org/) because they contain fewer components. In particular, they omit a shell and package manager, which reduces their attack surface. They also include a [non-root user](https://devblogs.microsoft.com/dotnet/securing-containers-with-rootless/) and run as that user by default.

## Building container images

You can build a container image with a **Dockerfile** or rely on the [.NET SDK to produce an image](../containers/sdk-publish.md). For samples on building images, see [dotnet/dotnet-docker](https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md) and [dotnet/sdk-container-builds](https://github.com/dotnet/sdk-container-builds).

The following example builds a container image and runs it as a container. These steps work with the .NET 10 SDK and the .NET 11 SDK. The example output uses the .NET 10 SDK.

```bash
$ dotnet new webapp -o webapp
$ cd webapp/
$ dotnet publish -t:PublishContainer
Restore complete (0.8s)
  webapp net10.0 succeeded (13.1s) → bin/Release/net10.0/publish/

Build succeeded in 15.1s
$ docker run --rm -d -p 8000:8080 webapp
b798c72fd2dc649270963a464b19db9bbc1465087eb07dbd9710a7174a8b8736
$ curl -s http://localhost:8000 | grep ASP.NET
    <p>Learn about <a href="https://learn.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
$ docker ps
CONTAINER ID   IMAGE    COMMAND                  CREATED              STATUS              PORTS                                         NAMES
b798c72fd2dc   webapp   "dotnet /app/webapp.…"   About a minute ago   Up About a minute   0.0.0.0:8000->8080/tcp, [::]:8000->8080/tcp   jovial_shtern
$ docker kill b798c72fd2dc
```

The `dotnet publish` command names the image after the project, builds it on top of the ASP.NET Core runtime image that matches the project's target framework, and loads it into your local container runtime as `webapp:latest`. In this example, the project targets .NET 10, so the base image is `mcr.microsoft.com/dotnet/aspnet:10.0`. With the .NET 11 SDK, the project targets .NET 11, and the base image is `mcr.microsoft.com/dotnet/aspnet:11.0`.

To generate a _Dockerfile_ and related starter files for your project instead, use [`docker init`](https://docs.docker.com/reference/cli/docker/init/).

## Ports

[Port mapping](https://docs.docker.com/network/#published-ports) is a key part of using containers. Ports must be published outside the container in order to respond to external web requests. ASP.NET Core container images [changed in .NET 8](../compatibility/containers/8.0/aspnet-port.md) to listen on port `8080`, by default. .NET 6 and 7 listen on port `80`.

In the prior example with `docker run`, the host port `8000` is mapped to the container port `8080`. Kubernetes works in a similar way.

The `ASPNETCORE_HTTP_PORTS`, `ASPNETCORE_HTTPS_PORTS`, and `ASPNETCORE_URLS` environment variables can be used to configure this behavior.

## Users

Starting with .NET 8, Linux images include a non-root user called `app`. The `APP_UID` environment variable in these images contains the user ID of the `app` user. Chiseled images, Azure Linux distroless images, and images built with the .NET SDK container publishing feature (shown in [Building container images](#building-container-images)) run as this user by default. Other Linux images run as `root` by default. To run as the `app` user in those images, set the user manually, for example, with the `USER $APP_UID` _Dockerfile_ instruction. If an image runs as `app` and some commands need to run as `root`, use the `USER root` instruction to switch users.

Windows images don't include the `app` user. Nano Server images run as the non-administrator `ContainerUser` account by default, and Windows Server Core images run as `ContainerAdministrator` by default. For more information, see [When to use ContainerAdmin and ContainerUser user accounts](/virtualization/windowscontainers/manage-containers/container-security#when-to-use-containeradmin-and-containeruser-user-accounts).

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
