---
title: Development environment for Docker apps
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
ms.prod: ".net"
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/22/2017
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Development environment for Docker apps

## Development tools choices: IDE or editor

No matter if you prefer a full and powerful IDE or a lightweight and agile editor, Microsoft has you covered when it comes to developing Docker applications.

### Visual Studio Code and Docker CLI (cross-platform tools for Mac, Linux, and Windows)

If you prefer a lightweight, cross-platform editor supporting any development language, you can use Visual Studio Code and Docker CLI. These products provide a simple yet robust experience, which is critical for streamlining the developer workflow. By installing "Docker for Mac" or "Docker for Windows" (development environment), Docker developers can use a single Docker CLI to build apps for both Windows or Linux (runtime environment). Plus, Visual Studio Code supports extensions for Docker with IntelliSense for Dockerfiles and shortcut-tasks to run Docker commands from the editor.

> [!NOTE]
> To download Visual Studio Code, go to <https://code.visualstudio.com/download>.

To download Docker for Mac and Windows, go to <http://www.docker.com/products/docker>.

### Visual Studio with Docker Tools

When you're using Visual Studio 2015 you can install the add-on tools "Docker Tools for Visual Studio." For Visual Studio 2017, Docker Tools come built in already. In both cases you can develop, run, and validate your applications directly in the chosen Docker environment. F5 your application (single container or multiple containers) directly into a Docker host with debugging, or press Ctrl+F5 to edit and refresh your app without having to rebuild the container. This is the simplest and more powerful choice for Windows developers creating Docker containers for Linux or Windows.

> [!NOTE]
> To download Docker Tools for Visual Studio, go to <https://visualstudiogallery.msdn.microsoft.com/0f5b2caa-ea00-41c8-b8a2-058c7da0b3e4>.

## Language and framework choices

You can develop Docker applications and Microsoft tools with most modern languages. The following is an initial list, but you are not limited to it:

-   .NET Core and ASP.NET Core

-   Node.js

-   Golang

-   Java

-   Ruby

-   Python

Basically, you can use any modern language supported by Docker in Linux or Windows.


>[!div class="step-by-step"]
[Previous] (orchestrate-high-scalability-availability.md)
[Next] (docker-apps-inner-loop-workflow.md)
