---
title: Development Process for Docker Based Applications
description: .NET Microservices Architecture for Containerized .NET Applications | Development Process for Docker Based Applications
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Development Process for Docker-Based Applications

*Develop containerized .NET applications the way you like, either IDE focused with Visual Studio and Visual Studio tools for Docker or CLI/Editor focused with Docker CLI and Visual Studio Code.*

## Development environment for Docker apps

### Development tool choices: IDE or editor

Whether you prefer a full and powerful IDE or a lightweight and agile editor, Microsoft has tools that you can use for developing Docker applications.

**Visual Studio with Tools for Docker**. If you are using Visual Studio 2015, you can install the [Visual Studio Tools for Docker](https://marketplace.visualstudio.com/items?itemName=MicrosoftCloudExplorer.VisualStudioToolsforDocker-Preview) add-in. If you are using Visual Studio 2017, tools for Docker are already built-in. In either case, the tools for Docker let you develop, run, and validate your applications directly in the target Docker environment. You can press F5 to run and debug your application (single container or multiple containers) directly into a Docker host, or press CTRL+F5 to edit and refresh your application without having to rebuild the container. This is the simplest and most powerful choice for Windows developers targeting Docker containers for Linux or Windows.

**Visual Studio Code and Docker CLI**. If you prefer a lightweight and cross-platform editor that supports any development language, you can use Microsoft Visual Studio Code (VS Code) and the Docker CLI. This is a cross-platform development approach for Mac, Linux, and Windows.

These products provide a simple but robust experience that streamlines the developer workflow. By installing [Docker Community Edition (CE)](https://www.docker.com/community-edition) tools, you can use a single Docker CLI to build apps for both Windows and Linux. Additionally, Visual Studio Code supports extensions for Docker such as IntelliSense for Dockerfiles and shortcut tasks to run Docker commands from the editor.

### Additional resources

-   **Visual Studio Tools for Docker**
    [*https://visualstudiogallery.msdn.microsoft.com/0f5b2caa-ea00-41c8-b8a2-058c7da0b3e4*](https://visualstudiogallery.msdn.microsoft.com/0f5b2caa-ea00-41c8-b8a2-058c7da0b3e4)

-   **Visual Studio Code**. Official site.
    [*https://code.visualstudio.com/download*](https://code.visualstudio.com/download)

-   **Docker Community Edition (CE) for Mac and Windows**
    [*https://www.docker.com/community-editions*](https://www.docker.com/community-edition)

## .NET languages and frameworks for Docker containers

As mentioned in earlier sections of this guide, you can use .NET Framework, .NET Core, or the open-source Mono project when developing Docker containerized .NET applications. You can develop in C\#, F\#, or Visual Basic when targeting Linux or Windows Containers, depending on which .NET framework is in use. For more details about.NET languages, see the blog post [The .NET Language Strategy](https://blogs.msdn.microsoft.com/dotnet/2017/02/01/the-net-language-strategy/).


>[!div class="step-by-step"]
[Previous] (../architect-microservice-container-applications/using-azure-service-fabric.md)
[Next] (docker-app-development-workflow.md)
