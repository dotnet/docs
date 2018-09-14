---
title: Using Visual Studio Tools for Docker (Visual Studio on Windows)
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/12/2018
ms.custom: vs-dotnet
---
# Using Visual Studio Tools for Docker (Visual Studio on Windows)

The development workflow when using Visual Studio Tools for Docker is similar to the workflow when using Visual Studio Code and Docker CLI. In fact, it's based on the same Docker CLI, but it's easier to get started, simplifies the process, and provides greater productivity for the build, run, and compose tasks. It's also able to execute and debug your containers via simple actions like F5 and Ctrl+F5 from Visual Studio. With the optional container orchestration support, in addition to being able to run and debug a single container, you can run and debug a group of containers (a whole solution) at the same time. Just define the containers in the same *docker-compose.yml* file at the solution level.

## Configuring your local environment

Docker support is included in Visual Studio 2017 with any of the .NET and .NET Core workloads installed. Install Docker for Windows separately.

With the latest versions of Docker for Windows, it is easier than ever to develop Docker applications because the setup is straightforward, as explained in the following references.

**More info:** To learn more about installing Docker for Windows, go to <https://docs.docker.com/docker-for-windows/>.

**More info:** For instructions on installing Visual Studio, go to [https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/).

To see more about installing Visual Studio Tools for Docker, go to <http://aka.ms/vstoolsfordocker> and <https://docs.microsoft.com/aspnet/core/host-and-deploy/docker/visual-studio-tools-for-docker>.

## Using Docker Tools in Visual Studio 2017

When adding Docker support to a project (see Figure 4-26), Visual Studio adds a *Dockerfile* to the project root.

![Turning on Docker Solution support in a Visual Studio 2017 project](./media/image32.png)

Figure 4-26: Turning on Docker Solution support in a Visual Studio 2017 project

 Container orchestration support, via Docker Compose, is added by default in Visual Studio 2017 versions 15.7 or earlier. Container orchestration support is an opt-in feature in Visual Studio 2017 versions 15.8 or later, in which case Docker Compose and Service Fabric are supported.

With Visual Studio version 15.8 and later, you can add support for multiple projects in a solution that each have an associated container. Right-click on the solution or project node in **Solution Explorer**, and choose **Add** > **Container Orchestration Support**.  Then choose **Docker Compose** or **Service Fabric** to manage the containers.

When you choose **Docker Compose**, Visual Studio adds a service section in your solution's *docker-compose.yml* files (or creates the files if they didn't exist). It's an easy way to begin composing your multi-container solution; you then can open the *docker-compose.yml* files and update them with additional features.

This action adds the required configuration lines of code to a *docker-compose.yml* set at the solution level.

You also can turn on Docker support when creating an ASP.NET Core project in Visual Studio 2017, as shown in Figure 4-27.

![Turning on Docker support when creating a project](./media/image33.png)

Figure 4-27: Turning on Docker support when creating a project

After you add Docker support to your solution in Visual Studio, you also will see a new node tree in **Solution Explorer** with the added *docker-compose.yml* files, as depicted in Figure 4-28.

![docker-compose.yml files now display in Solution Explorer](./media/image34.PNG)

Figure 4-28: docker-compose.yml files now display in **Solution Explorer**

You could deploy a multi-container app by using a single *docker-compose.yml* file when you run `docker-compose up`; however, Visual Studio adds a group of them, so you can override values depending on the environment (development versus production) and the execution type (release versus debug). This capability is better explained in later chapters.

You can also use Service Fabric instead of Docker Compose to manage multiple containers. See [Tutorial: Deploy a .NET application in a Windows container to Azure Service Fabric](https://docs.microsoft.com/azure/service-fabric/service-fabric-host-app-in-a-container).

**More info:** For further details on the services implementation and use of Visual Studio Tools for Docker, read the following articles:

Build, debug, update, and refresh apps in a local Docker container: [https://docs.microsoft.com/azure/vs-azure-tools-docker-edit-and-refresh/](https://docs.microsoft.com/azure/vs-azure-tools-docker-edit-and-refresh)

Deploy an ASP.NET Core Docker container to a container registry: [https://docs.microsoft.com/azure/vs-azure-tools-docker-hosting-web-apps-in-docker/](https://docs.microsoft.com/azure/vs-azure-tools-docker-hosting-web-apps-in-docker)

>[!div class="step-by-step"]
[Previous](docker-apps-inner-loop-workflow.md)
[Next](set-up-windows-containers-with-powershell.md)
