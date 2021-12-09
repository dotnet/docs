---
title: Development environment for Docker apps
description: Get to know the most important development tool options that support the Docker development life-cycle.
ms.date: 12/08/2021
---
# Development environment for Docker apps

## Development tools choices: IDE or editor

No matter if you prefer a full and powerful IDE or a lightweight and agile editor, Microsoft has you covered when it comes to developing Docker applications.

### Visual Studio Code and Docker CLI (cross-platform tools for Mac, Linux, and Windows)

If you prefer a lightweight, cross-platform editor supporting any development language, you can use Visual Studio Code and Docker CLI. These products provide a simple yet robust experience, which is critical for streamlining the developer workflow. By installing "Docker for Mac" or "Docker for Windows" (development environment), Docker developers can use a single Docker CLI to build apps for both Windows or Linux (runtime environment). Plus, Visual Studio Code supports extensions for Docker with IntelliSense for Dockerfiles and shortcut-tasks to run Docker commands from the editor.

> [!NOTE]
> To download Visual Studio Code, go to <https://code.visualstudio.com/download>.
>
> To download Docker for Mac and Windows, go to <https://www.docker.com/products/docker>.

### Visual Studio with Docker Tools (Windows development machine)

It's recommended that you use Visual Studio 2022 or later with the built-in Docker Tools enabled. With Visual Studio, you can develop, run, and validate your applications directly in the chosen Docker environment. Press F5 to debug your application (single container or multiple containers) directly in a Docker host, or press Ctrl+F5 to edit and refresh your app without having to rebuild the container. It's the simplest and most powerful choice for Windows developers to create Docker containers for Linux or Windows.

### Visual Studio for Mac (Mac development machine)

You can use [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link) when developing Docker-based applications. Visual Studio for Mac offers a richer IDE when compared to Visual Studio Code for Mac.

## Language and framework choices

You can develop Docker applications using Microsoft tools with most modern languages. The following is an initial list, but you're not limited to it:

- .NET and ASP.NET Core
- Node.js
- Go
- Java
- Ruby
- Python

Basically, you can use any modern language supported by Docker in Linux or Windows.

>[!div class="step-by-step"]
>[Previous](deploy-azure-kubernetes-service.md)
>[Next](docker-apps-inner-loop-workflow.md)
