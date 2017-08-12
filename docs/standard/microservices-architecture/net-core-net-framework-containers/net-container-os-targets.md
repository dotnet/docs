---
title: What OS to target with .NET containers
description: .NET Microservices Architecture for Containerized .NET Applications | What OS to target with .NET containers
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# What OS to target with .NET containers

Given the diversity of operating systems supported by Docker and the differences between .NET Framework and .NET Core, you should target a specific OS and specific versions depending on the framework you are using. For instance, in Linux there are many distros available, but only few of them are supported in the official .NET Docker images (like Debian and Alpine). For Windows you can use Windows Server Core or Nano Server; these versions of Windows provide different characteristics (like IIS versus a self-hosted web server like Kestrel) that might be needed by .NET Framework or NET Core.

In Figure 3-1 you can see the possible OS version depending on the .NET framework used.

![](./media/image1.png)

**Figure 3-1.** Operating systems to target depending on versions of the .NET framework

You can also create your own Docker image in cases where you want to use a different Linux distro or where you want an image with versions not provided by Microsoft. For example, you might create an image with ASP.NET Core running on the full .NET Framework and Windows Server Core, which is a not-so-common scenario for Docker.

When you add the image name to your Dockerfile file, you can select the operating system and version depending on the tag you use, as in the following examples:

-   microsoft/dotnet**:1.1-runtime**
    .NET Core 1.1 runtime-only on Linux

-   microsoft/dotnet:**1.1-runtime-nanoserver**
    .NET Core 1.1 runtime-only on Windows Nano Server




>[!div class="step-by-step"]
[Previous] (container-framework-choice-factors.md)
[Next] (official-net-docker-images.md)
