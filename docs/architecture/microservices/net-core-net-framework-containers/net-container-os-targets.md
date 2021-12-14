---
title: What OS to target with .NET containers
description: .NET Microservices Architecture for Containerized .NET Applications | What OS to target with .NET containers
ms.date: 01/13/2021
---

# What OS to target with .NET containers

Given the diversity of operating systems supported by Docker and the differences between .NET Framework and .NET 6, you should target a specific OS and specific versions depending on the framework you are using.

For Windows, you can use Windows Server Core or Windows Nano Server. These Windows versions provide different characteristics (IIS in Windows Server Core versus a self-hosted web server like Kestrel in Nano Server) that might be needed by .NET Framework or .NET 6, respectively.

For Linux, multiple distros are available and supported in official .NET Docker images (like Debian).

In Figure 3-1, you can see the possible OS version depending on the .NET framework used.

![Diagram showing what OS to use with which .NET containers.](./media/net-container-os-targets/targeting-operating-systems.png)

**Figure 3-1.** Operating systems to target depending on versions of the .NET framework

When deploying legacy .NET Framework applications you have to target Windows Server Core, compatible with legacy apps and IIS, but it has a larger image. When deploying .NET 6 applications, you can target Windows Nano Server, which is cloud optimized, uses Kestrel and is smaller and starts faster. You can also target Linux, supporting Debian, Alpine, and others. Also uses Kestrel, is smaller, and starts faster.

You can also create your own Docker image in cases where you want to use a different Linux distro or where you want an image with versions not provided by Microsoft. For example, you might create an image with ASP.NET Core running on the traditional .NET Framework and Windows Server Core, which is a not-so-common scenario for Docker.

When you add the image name to your Dockerfile file, you can select the operating system and version depending on the tag you use, as in the following examples:

| Image | Comments |
|-------|----------|
| mcr.microsoft.com/dotnet/runtime:6.0 | .NET 6 multi-architecture: Supports Linux and Windows Nano Server depending on the Docker host. |
| mcr.microsoft.com/dotnet/aspnet:6.0 | ASP.NET Core 6.0 multi-architecture: Supports Linux and Windows Nano Server depending on the Docker host. <br/> The aspnetcore image has a few optimizations for ASP.NET Core. |
| mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim | .NET 6 runtime-only on Linux Debian distro |
| mcr.microsoft.com/dotnet/aspnet:6.0-nanoserver-1809 | .NET 6 runtime-only on Windows Nano Server (Windows Server version 1809) |

> [!div class="step-by-step"]
> [Previous](container-framework-choice-factors.md)
> [Next](official-net-docker-images.md)
