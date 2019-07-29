---
title: Development Process for Docker Based Applications
description: Get a high level overview of the options for developing Docker-based applications. Using your choice of Visual Studio for Windows, Visual Studio for Mac, or Visual Studio Code for multiplatform support (Windows, Mac and Linux).
ms.date: 09/27/2018
---
# Development Process for Docker-Based Applications

*Develop containerized .NET applications the way you like, either IDE focused with Visual Studio and Visual Studio tools for Docker or CLI/Editor focused with Docker CLI and Visual Studio Code.*

## Development environment for Docker apps

### Development tool choices: IDE or editor

Whether you prefer a full and powerful IDE or a lightweight and agile editor, Microsoft has tools that you can use for developing Docker applications.

**Visual Studio (for Windows).** When developing Docker-based applications with Visual Studio, it's recommended to use Visual Studio 2017 version 15.7 or later, that comes with tools for Docker already built-in. The tools for Docker let you develop, run, and validate your applications directly in the target Docker environment. You can press F5 to run and debug your application (single container or multiple containers) directly into a Docker host, or press CTRL+F5 to edit and refresh your application without having to rebuild the container. This is the most powerful development choice for Docker-based apps.

**Visual Studio for Mac.** It's an IDE, evolution of Xamarin Studio, running in macOS and supports Docker since mid-2017. This should be the preferred choice for developers working in Mac machines who also want to use a powerful IDE.

**Visual Studio Code and Docker CLI**. If you prefer a lightweight and cross-platform editor that supports any development language, you can use Microsoft Visual Studio Code (VS Code) and the Docker CLI. This is a cross-platform development approach for Mac, Linux, and Windows. Additionally, Visual Studio Code supports extensions for Docker such as IntelliSense for Dockerfiles and shortcut tasks to run Docker commands from the editor.

By installing [Docker Desktop Community Edition (CE)](https://hub.docker.com/search/?type=edition&offering=community), you can use a single Docker CLI to build apps for both Windows and Linux.

### Additional resources

- **Visual Studio**. Official site. \
  [https://visualstudio.microsoft.com/vs/](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link)

- **Visual Studio Code**. Official site. \
  <https://code.visualstudio.com/download>

- **Docker Desktop for Windows Community Edition (CE)** \
  [https://hub.docker.com/editions/community/docker-ce-desktop-windows](https://hub.docker.com/editions/community/docker-ce-desktop-windows)
  
- **Docker Desktop for Mac Community Edition (CE)** \
  [https://hub.docker.com/editions/community/docker-ce-desktop-mac](https://hub.docker.com/editions/community/docker-ce-desktop-mac)

## .NET languages and frameworks for Docker containers

As mentioned in earlier sections of this guide, you can use .NET Framework, .NET Core, or the open-source Mono project when developing Docker containerized .NET applications. You can develop in C\#, F\#, or Visual Basic when targeting Linux or Windows Containers, depending on which .NET framework is in use. For more details about.NET languages, see the blog post [The .NET Language Strategy](https://devblogs.microsoft.com/dotnet/the-net-language-strategy/).

>[!div class="step-by-step"]
>[Previous](../architect-microservice-container-applications/scalable-available-multi-container-microservice-applications.md)
>[Next](docker-app-development-workflow.md)
