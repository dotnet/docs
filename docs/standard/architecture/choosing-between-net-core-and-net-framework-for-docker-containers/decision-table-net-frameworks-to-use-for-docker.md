---
title: Decision table. .NET frameworks to use for Docker | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Decision table, .NET frameworks to use for Docker
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Decision table: .NET frameworks to use for Docker

The following decision table summarizes whether to use .NET Framework or .NET Core. Remember that for Linux containers, you need Linux-based Docker hosts (VMs or servers) and that for Windows Containers you need Windows Server based Docker hosts (VMs or servers).

  **Architecture / App Type**                                         **Linux containers**                                                               **Windows Containers**
```
  Microservices on containers                                         .NET Core                                                                          .NET Core
  Monolithic app                                                      .NET Core                                                                          .NET Framework, .NET Core
  Best-in-class performance and scalability                           .NET Core                                                                          .NET Core
  Windows Server legacy app (“brown-field”) migration to containers   --                                                                                 .NET Framework
  New container-based development (“green-field”)                     .NET Core                                                                          .NET Core
  ASP.NET Core                                                        .NET Core                                                                          .NET Core (recommended), .NET Framework
  ASP.NET 4 (MVC 5, Web API 2, and Web Forms)                         --                                                                                 .NET Framework
  SignalR services                                                    .NET Core (future release)                                                         .NET Framework,.NET Core (future release)
  WCF, WF, and other legacy frameworks                                WCF in .NET Core (in the roadmap)                                                  .NET Framework, WCF in .NET Core (in the roadmap)
  Consumption of Azure services                                       .NET Core (eventually all Azure services will provide client SDKs for .NET Core)   .NET Framework,.NET Core (eventually all Azure services will provide client SDKs for .NET Core)

# What OS to target with .NET containers

Given the diversity of operating systems supported by Docker and the differences between .NET Framework and .NET Core, you should target a specific OS and specific versions depending on the framework you are using. For instance, in Linux there are many distros available, but only few of them are supported in the official .NET Docker images (like Debian and Alpine). For Windows you can use Windows Server Core or Nano Server; these versions of Windows provide different characteristics (like IIS versus a self-hosted web server like Kestrel) that might be needed by .NET Framework or NET Core.

In Figure 3-1 you can see the possible OS version depending on the .NET framework used.

![](./media/image1.png){width="6.217391732283464in" height="3.163745625546807in"}

**Figure 3-1.** Operating systems to target depending on versions of the .NET framework

You can also create your own Docker image in cases where you want to use a different Linux distro or where you want an image with versions not provided by Microsoft. For example, you might create an image with ASP.NET Core running on the full .NET Framework and Windows Server Core, which is a not-so-common scenario for Docker.

When you add the image name to your Dockerfile file, you can select the operating system and version depending on the tag you use, as in the following examples:

-   microsoft/dotnet**:1.1-runtime**\
    .NET Core 1.1 runtime-only on Linux

-   microsoft/dotnet:**1.1-runtime-nanoserver**\
    .NET Core 1.1 runtime-only on Windows Nano Server

[[[[[[[[[[[[[[[[[[[]{#_Toc481772514 .anchor}]{#_Toc481767757 .anchor}]{#_Toc481764181 .anchor}]{#_Toc481762814 .anchor}]{#_Toc481693752 .anchor}]{#_Toc481597736 .anchor}]{#_Toc481506609 .anchor}]{#_Toc481506177 .anchor}]{#_Toc481491984 .anchor}]{#_Toc481490160 .anchor}]{#_Toc481090200 .anchor}]{#_Toc480984559 .anchor}]{#_Toc480993056 .anchor}]{#_Toc480280982 .anchor}]{#_Toc480212189 .anchor}]{#_Toc474844851 .anchor}]{#_Toc474337816 .anchor}]{#_Toc473731924 .anchor}]{#_Toc473731724 .anchor}

# Official .NET Docker images

The Official .NET Docker images are Docker images created and optimized by Microsoft. They are publicly available in the Microsoft repositories on [Docker Hub](https://hub.docker.com/u/microsoft/). Each repository can contain multiple images, depending on .NET versions, and depending on the OS and versions (Linux Debian, Linux Alpine, Windows Nano Server, Windows Server Core, etc.).

Microsoft’s vision for .NET repositories is to have granular and focused repos, where a repo represents a specific scenario or workload. For instance, the [microsoft/aspnetcore](https://hub.docker.com/r/microsoft/aspnetcore/) images should be used when using ASP.NET Core on Docker, because those ASP.NET Core images provide additional optimizations so containers can start faster.

On the other hand, the .NET Core images (microsoft/dotnet) are intended for console apps based on .NET Core. For example, batch processes, Azure WebJobs, and other console scenarios should use .NET Core. Those images do not include the ASP.NET Core stack, resulting in a smaller container image.

Most image repos provide extensive tagging to help you select not just a specific framework version, but also to choose an OS (Linux distro or Windows version).

For further information about the official .NET Docker images provided by Microsoft, see the [.NET Docker Images summary](https://aka.ms/dotnetdockerimages).

## .NET Core and Docker image optimizations for development versus production

When building Docker images for developers, Microsoft focused on the following main scenarios:

-   Images used to *develop* and build .NET Core apps.

-   Images used to *run* .NET Core apps.

Why multiple images? When developing, building, and running containerized applications, you usually have different priorities. By providing different images for these separate tasks, Microsoft helps optimize the separate processes of developing, building, and deploying apps.

### During development and build

During development, what is important is how fast you can iterate changes, and the ability to debug the changes. The size of the image is not as important as the ability to make changes to your code and see the changes quickly. Some of our tools, like [yo docker](https://github.com/Microsoft/generator-docker) for Visual Studio Code, use the development ASP.NET Core image (microsoft/aspnetcore-build) during development; you could even use that image as a build container. When building inside a Docker container, the important aspects are the elements that are needed in order to compile your app. This includes the compiler and any other .NET dependencies, plus web development dependencies like npm, Gulp, and Bower.

Why is this type of build image important? You do not deploy this image to production. Instead, it is an image you use to build the content you place into a production image. This image would be used in your continuous integration (CI) environment or build environment. For instance, rather than manually installing all your application dependencies directly on a build agent host (a VM, for example), the build agent would instantiate a .NET Core build image with all the dependencies required to build the application. Your build agent only needs to know how to run this Docker image. This simplifies your CI environment and makes it much more predictable.

### In production

What is important in production is how fast you can deploy and start your containers based on a production .NET Core image. Therefore, the runtime-only image based on [microsoft/aspnetcore](https://hub.docker.com/r/microsoft/aspnetcore/) is small so that it can travel quickly across the network from your Docker registry to your Docker hosts. The contents are ready to run, enabling the fastest time from starting the container to processing results. In the Docker model, there is no need for compilation from C\# code, as there is when you run dotnet build or dotnet publish when using the build container.

In this optimized image you put only the binaries and other content needed to run the application. For example, the content created by dotnet publish contains only the compiled .NET binaries, images, .js, and .css files. Over time, you will see images that contain pre-jitted packages.

Although there are multiple versions of the .NET Core and ASP.NET Core images, they all share one or more layers, including the base layer. Therefore, the amount of disk space needed to store an image is small; it consists only of the delta between your custom image and its base image. The result is that it is quick to pull the image from your registry.

When you explore the .NET image repositories at Docker Hub, you will find multiple image versions classified or marked with tags. These help decide which one to use, depending on the version you need, like those in the following list::

-   microsoft/aspnetcore:**1.1**\
    ASP.NET Core, with runtime only and ASP.NET Core optimizations, on Linux

-   microsoft/aspnetcore-build:**1.0-1.1\
    **ASP.NET Core, with SDKs included, on Linux

-   microsoft/dotnet:**1.1-runtime**\
    .NET Core 1.1, with runtime only, on Linux

-   microsoft/dotnet:**1.1-runtime-deps**\
    .NET Core 1.1, with runtime and framework dependencies for self-contained apps, on Linux

-   microsoft/dotnet**:1.1.0-sdk-msbuild**\
    .NET Core 1.1 with SDKs included, on Linux

>[!div class="step-by-step"]
[Previous] (when-to-choose-net-framework-for-docker-containers.md)
[Next] (../architecting-container-and-microservice-based-applications/index.md)
