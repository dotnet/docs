---
title: Official .NET Docker images
description: .NET Microservices Architecture for Containerized .NET Applications | Official .NET Docker images
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 01/07/2019
---
# Official .NET Docker images

The Official .NET Docker images are Docker images created and optimized by Microsoft. They are publicly available in the Microsoft repositories on [Docker Hub](https://hub.docker.com/u/microsoft/). Each repository can contain multiple images, depending on .NET versions, and depending on the OS and versions (Linux Debian, Linux Alpine, Windows Nano Server, Windows Server Core, etc.).

Since .NET Core 2.1, all the .NET Core images, including for ASP.NET Core are available at Docker Hub at the .NET Core image repo: https://hub.docker.com/r/microsoft/dotnet/

Most image repos provide extensive tagging to help you select not just a specific framework version, but also to choose an OS (Linux distro or Windows version).

## .NET Core and Docker image optimizations for development versus production

When building Docker images for developers, Microsoft focused on the following main scenarios:

-   Images used to *develop* and build .NET Core apps.

-   Images used to *run* .NET Core apps.

Why multiple images? When developing, building, and running containerized applications, you usually have different priorities. By providing different images for these separate tasks, Microsoft helps optimize the separate processes of developing, building, and deploying apps.

### During development and build

During development, what is important is how fast you can iterate changes, and the ability to debug the changes. The size of the image is not as important as the ability to make changes to your code and see the changes quickly. Some tools and "build-agent containers", use the development .NET Core image (*microsoft/dotnet:2.2-sdk*) during development and build proces. When building inside a Docker container, the important aspects are the elements that are needed in order to compile your app. This includes the compiler and any other .NET dependencies.

Why is this type of build image important? You do not deploy this image to production. Instead, it is an image you use to build the content you place into a production image. This image would be used in your continuous integration (CI) environment or build environment when using Docker Multi-stage builds.

### In production

What is important in production is how fast you can deploy and start your containers based on a production .NET Core image. Therefore, the runtime-only image based on *microsoft/dotnet:2.2-aspnetcore-runtime* is small so that it can travel quickly across the network from your Docker registry to your Docker hosts. The contents are ready to run, enabling the fastest time from starting the container to processing results. In the Docker model, there is no need for compilation from C\# code, as there is when you run dotnet build or dotnet publish when using the build container.

In this optimized image you put only the binaries and other content needed to run the application. For example, the content created by dotnet publish contains only the compiled .NET binaries, images, .js, and .css files. Over time, you will see images that contain pre-jitted (the compilation from IL to native that occurs at runtime) packages.

Although there are multiple versions of the .NET Core and ASP.NET Core images, they all share one or more layers, including the base layer. Therefore, the amount of disk space needed to store an image is small; it consists only of the delta between your custom image and its base image. The result is that it is quick to pull the image from your registry.

When you explore the .NET image repositories at Docker Hub, you will find multiple image versions classified or marked with tags. These tags help to decide which one to use, depending on the version you need, like those in the following table:

| Image                                       | Comments                                                                                          |
| ------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| microsoft/dotnet:**2.2-aspnetcore-runtime** | ASP.NET Core, with runtime only and ASP.NET Core optimizations, on Linux and Windows (multi-arch) |
| microsoft/dotnet:**2.2-sdk**                | .NET Core, with SDKs included, on Linux and Windows (multi-arch)                                  |

>[!div class="step-by-step"]
>[Previous](net-container-os-targets.md)
>[Next](../architect-microservice-container-applications/index.md)