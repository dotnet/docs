---
title: Visual Studio Tools for Docker on Windows
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/22/2017
---
# Use Visual Studio Tools for Docker (Visual Studio on Windows)

The developer workflow when using Visual Studio Tools for Docker is similar to the workflow when using Visual Studio Code and Docker CLI (in fact, it is based on the same Docker CLI). Visual Studio Tools for Docker makes it even easier to get started, simplifies the process, and provides greater productivity for the build, run, and compose tasks. It's also able to execute and debug your containers via simple actions like **F5** and **Ctrl**+**F5** from Visual Studio. With Visual Studio 2017, in addition to being able to run and debug a single container, you can run and debug a group of containers (a whole solution) at the same time if they're defined in the same *docker-compose.yml* file at the solution level.

## Configure your local environment

With the latest versions of [Docker for Windows](https://docs.docker.com/docker-for-windows/), it is easier than ever to develop Docker applications because the setup is straightforward.

If you're using Visual Studio 2017, Docker support is included. If you're using Visual Studio 2015, you must have Update 3 or a later version, plus the Visual Studio Tools for Docker.

## Use Docker Tools in Visual Studio 2017

When you add Docker support to a service project in your solution, Visual Studio is not just adding a DockerFile file to your project, it also is adding a service section in your solution's *docker-compose.yml* files (or creating the files if they didn't exist). It's an easy way to begin composing your multicontainer solution. You can then open the *docker-compose.yml* files and update them with additional features.

![Add Docker Support menu item in Visual Studio](./media/image32.png)

This action not only adds the DockerFile to your project, it also adds the required configuration lines of code to a global *docker-compose.yml* set at the solution level.

You can also turn on Docker support when creating an ASP.NET Core project in Visual Studio 2017:

![Enable Docker Support for new ASP.NET Core web app in Visual Studio](./media/image33.png)

After you add Docker support to your solution in Visual Studio, you also will see a new node tree in **Solution Explorer** with the added *docker-compose.yml* files:

![docker-compose node in Solution Explorer](./media/image34.PNG)

You could deploy a multicontainer application by using a single *docker-compose.yml* file when you run docker-compose up; however, Visual Studio adds a group of them, so you can override values depending on the environment (development versus production) and the execution type (release versus debug). This capability will be better explained in later chapters.

>[!div class="step-by-step"]
[Previous](docker-apps-inner-loop-workflow.md)
[Next](set-up-windows-containers-with-powershell.md)

## Use Docker Tools in Visual Studio 2015

The Visual Studio Tools for Docker for Visual Studio 2015 provides a consistent way to develop and validate locally your Docker containers for Linux in a Linux Docker host or VM, or your Windows Containers directly on Windows.

If you're using a single container, the first thing you need to begin is to turn on Docker support into your .NET Core project. To do this, right-click your project file:

![Add Docker Support in Visual Studio 2015](./media/image31.png)

## See also

- [Visual Studio Tools for Docker with ASP.NET Core](/aspnet/core/host-and-deploy/docker/visual-studio-tools-for-docker)
- [Deploy an ASP.NET container to a container registry using Visual Studio](/azure/vs-azure-tools-docker-hosting-web-apps-in-docker)
- [Debugging apps in a local Docker container](/azure/vs-azure-tools-docker-edit-and-refresh)