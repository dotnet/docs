---
title: Official .NET Docker images
description: .NET Microservices Architecture for Containerized .NET Applications | Official .NET Docker images
ms.date: 11/19/2021
---

# Official .NET Docker images

[!INCLUDE [download-alert](../includes/download-alert.md)]

The Official .NET Docker images are Docker images created and optimized by Microsoft. They're publicly available on [Microsoft Artifact Registry](https://mcr.microsoft.com/). You can search over the catalog to find all .NET image repositories, for example [.NET SDK](https://mcr.microsoft.com/product/dotnet/sdk/about) repository.

Each repository can contain multiple images, depending on .NET versions, and depending on the OS and versions (Linux Debian, Linux Alpine, Windows Nano Server, Windows Server Core, and so on). Image repositories provide extensive tagging to help you select not just a specific framework version, but also to choose an OS (Linux distribution or Windows version).

## .NET and Docker image optimizations for development versus production

When building Docker images for developers, Microsoft focused on the following main scenarios:

- Images used to *develop* and build .NET apps.

- Images used to *run* .NET apps.

Why multiple images? When developing, building, and running containerized applications, you usually have different priorities. By providing different images for these separate tasks, Microsoft helps optimize the separate processes of developing, building, and deploying apps.

### During development and build

During development, what is important is how fast you can iterate changes, and the ability to debug the changes. The size of the image isn't as important as the ability to make changes to your code and see the changes quickly. Some tools and "build-agent containers", use the development .NET image (*mcr.microsoft.com/dotnet/sdk:8.0*) during development and build process. When building inside a Docker container, the important aspects are the elements that are needed to compile your app. This includes the compiler and any other .NET dependencies.

Another great option is development containers. These containers are prebuilt development environments that are ready to use&mdash;you don't have to worry about dependencies and configurations. They are also easy to customize to include additional tools or dependencies. Development containers provide a consistent and reproducible setup that's easy to share with your team. Development containers conform to the [Development Container Specification], and many popular developer tools, including Visual Studio Code and GitHub Codespaces, support them. The .NET dev containers are based on the .NET SDK image and include the .NET SDK, runtime, and other tools you need to develop .NET applications.

[Development Container Specification]: https://containers.dev/implementors/spec/

Why is this type of build image important? You don't deploy this image to production. Instead, it's an image that you use to build the content you place into a production image. This image would be used in your continuous integration (CI) environment or build environment when using Docker multi-stage builds.

### In production

What is important in production is how fast you can deploy and start your containers based on a production .NET image. Therefore, the runtime-only image based on *mcr.microsoft.com/dotnet/aspnet:8.0* is small so that it can travel quickly across the network from your Docker registry to your Docker hosts. The contents are ready to run, enabling the fastest time from starting the container to processing results. In the Docker model, there is no need for compilation from C\# code, as there's when you run dotnet build or dotnet publish when using the build container.

In this optimized image, you put only the binaries and other content needed to run the application. For example, the content created by `dotnet publish` contains only the compiled .NET binaries, images, .js, and .css files. Over time, you'll see images that contain pre-jitted (the compilation from IL to native that occurs at run time) packages.

Although there are multiple versions of the .NET and ASP.NET Core images, they all share one or more layers, including the base layer. Therefore, the amount of disk space needed to store an image is small; it consists only of the delta between your custom image and its base image. The result is that it's quick to pull the image from your registry.

When you explore the .NET image repositories at Microsoft Artifact Registry, you'll find multiple image versions classified or marked with tags. These tags help to decide which one to use, depending on the version you need, like those in the following table:

| Image | Comments |
|-------|----------|
| mcr.microsoft.com/dotnet/aspnet:**8.0** | ASP.NET Core, with runtime only and ASP.NET Core optimizations, on Linux and Windows (multi-arch) |
| mcr.microsoft.com/dotnet/sdk:**8.0** | .NET 8, with SDKs included, on Linux and Windows (multi-arch) |

You can find all the available docker images in [dotnet-docker](https://github.com/dotnet/dotnet-docker) and also refer to the latest preview releases by using nightly build `mcr.microsoft.com/dotnet/nightly/*`

> [!div class="step-by-step"]
> [Previous](net-container-os-targets.md)
> [Next](../architect-microservice-container-applications/index.md)
