---
title: What OS to target with .NET containers
description: .NET Microservices Architecture for Containerized .NET Applications | What OS to target with .NET containers
ms.date: 01/07/2019
---

# What OS to target with .NET containers

Given the diversity of operating systems supported by Docker and the differences between .NET Framework and .NET Core, you should target a specific OS and specific versions depending on the framework you are using.

For Windows, you can use Windows Server Core or Windows Nano Server. These Windows versions provide different characteristics (IIS in Windows Server Core versus a self-hosted web server like Kestrel in Nano Server) that might be needed by .NET Framework or .NET Core, respectively.

For Linux, multiple distros are available and supported in official .NET Docker images (like Debian).

In Figure 3-1 you can see the possible OS version depending on the .NET framework used.

![When deploying legacy .NET Framework applications you have to target Windows Server Core, compatible with legacy apps and IIS, has a larger image. When deploying .NET Core applications, you can target Windows Nano Server, which is cloud optimized, uses Kestrel and is smaller and starts faster. You can also target Linux, supporting Debian, Alpine and others. Also uses Kestrel and is smaller and starts faster.](./media/image1.png)

**Figure 3-1.** Operating systems to target depending on versions of the .NET framework

You can also create your own Docker image in cases where you want to use a different Linux distro or where you want an image with versions not provided by Microsoft. For example, you might create an image with ASP.NET Core running on the traditional .NET Framework and Windows Server Core, which is a not-so-common scenario for Docker.

> [!IMPORTANT]
> When using Windows Server Core images, you might find that some DLLs are missing, when compared to full Windows images. You might be able to solve this problem by creating a custom Server Core image, adding the missing files at image build time, as mentioned in this [GitHub comment](https://github.com/microsoft/dotnet-framework-docker/issues/299#issuecomment-511537448).

When you add the image name to your Dockerfile file, you can select the operating system and version depending on the tag you use, as in the following examples:

| Image | Comments |
|-------|----------|
| mcr.microsoft.com/dotnet/core/runtime:2.2 | .NET Core 2.2 multi-architecture: Supports Linux and Windows Nano Server depending on the Docker host. |
| mcr.microsoft.com/dotnet/core/aspnet:2.2 | ASP.NET Core 2.2 multi-architecture: Supports Linux and Windows Nano Server depending on the Docker host. <br/> The aspnetcore image has a few optimizations for ASP.NET Core. |
| mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine | .NET Core 2.2 runtime-only on Linux Alpine distro |
| mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1803 | .NET Core 2.2 runtime-only on Windows Nano Server (Windows Server version 1803) |

## Additional resources

- **BitmapDecoder fails due to missing WindowsCodecsExt.dll (GitHub issue)**  
  <https://github.com/microsoft/dotnet-framework-docker/issues/299>

> [!div class="step-by-step"]
> [Previous](container-framework-choice-factors.md)
> [Next](official-net-docker-images.md)
