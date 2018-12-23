---
title: Visual Studio Tools for Docker on Windows
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/12/2018
ms.custom: vs-dotnet
---
# Using Visual Studio Tools for Docker (Visual Studio on Windows)

The Visual Studio Tools for Docker development workflow is similar to the workflow when using Visual Studio Code and Docker CLI. In fact, it's based on the same Docker CLI, but it's easier to get started, simplifies the process, and provides greater productivity for the build, run, and compose tasks. Execute and debug your containers via simple actions like **F5** and **Ctrl**+**F5**. With the optional container orchestration support, in addition to being able to run and debug a single container, you can run and debug a group of containers (a whole solution) at the same time.

> [!NOTE]
> This article applies to Visual Studio on Windows, and not Visual Studio for Mac.

## Configure your local environment

With the latest versions of Docker for Windows ([https://docs.docker.com/docker-for-windows/](https://docs.docker.com/docker-for-windows/)), the straightforward setup makes it easy to develop Docker applications.

Docker support is included in Visual Studio 2017. Download Visual Studio 2017 here: [https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs)

## Use Docker Tools in Visual Studio 2017

There are two levels of Docker support you can add to a project. In .NET Core web app projects, you can just add a *Dockerfile* file to the project by enabling Docker support. The next level is container orchestration support, which adds a *Dockerfile* to the project (if it doesn't already exist) and a *docker-compose.yml* file at the solution level. Container orchestration support, via Docker Compose, is added by default in Visual Studio 2017 versions 15.7 or earlier. Container orchestration support is an opt-in feature in Visual Studio 2017 versions 15.8 or later, in which case Docker Compose and Service Fabric are supported.

The **Add** > **Docker Support** and **Add** > **Container orchestration Support** commands are located on the right-click menu (or context menu) of the project node for a web app project in **Solution Explorer**, as shown in Figure 4-26:

![Add Docker Support menu option in Visual Studio](media/add-docker-support-menu.png)

Figure 4-26: Adding Docker support to a Visual Studio 2017 project

### Add Docker support

You can add Docker support to an existing .NET Core web app project by selecting **Add** > **Docker Support** in **Solution Explorer**. You can also enable Docker support during project creation by selecting **Enable Docker Support** in the **New ASP.NET Core Web Application** dialog box that opens after you click **OK** in the **New Project** dialog box, as shown in Figure 4-27.

![Enable Docker Support for new ASP.NET Core web app in Visual Studio](./media/enable-docker-support-visual-studio.png)

Figure 4-27: Enable Docker support during project creation in Visual Studio 2017

When you add or enable Docker support, Visual Studio adds a *Dockerfile* file to the project.

> [!NOTE]
> When you enable Docker Compose support during project creation for a .NET Framework web app project (not a .NET Core web app project) as shown in Figure 4-28, container orchestration support is also added.
>
> ![Enable Docker compose support for a .NET Framework web app project](media/enable-docker-compose-support.png)

> Figure 4-28: Enabling Docker Compose support on a .NET Framework web app project in Visual Studio 2017

### Add container orchestration support

When you want to compose a multicontainer solution, add container orchestration support to your projects. This lets you run and debug a group of containers (a whole solution) at the same time if they're defined in the same *docker-compose.yml* file.

To add container orchestration support, right-click on the solution or project node in **Solution Explorer**, and choose **Add** > **Container Orchestration Support**. Then choose **Docker Compose** or **Service Fabric** to manage the containers.

After you add container orchestration support to your project, you see a Dockerfile added to the project and a **docker-compose** folder added to the solution in **Solution Explorer**, as shown in Figure 4-29:

![Docker files in Solution Explorer in Visual Studio](media/docker-support-solution-explorer.png)

Figure 4-29: Docker files in Solution Explorer in Visual Studio 2017

If *docker-compose.yml* already exists, Visual Studio just adds the required lines of configuration code to it.

## Configure Docker tools

From the main menu, choose **Tools** > **Options**, and expand **Container Tools** > **Settings**. The container tools settings appear.

![](./media/visual-studio-docker-tools-options.png)

Figure 4-30: Docker Tools Options

The following table might help you decide how to set these options.

| Name | Default Setting | Applies To | Description |
| -----|:---------------:|:----------:| ----------- |
| Automatically pull required Docker images on project load | On | Docker Compose | For increased performance, when loading projects, Visual Studio will start a Docker pull operation in the background so that when you are ready to run your code, the image is already downloaded or in the process of downloading. If you're just loading projects and browsing code, you can turn this off to avoid downloading container images you don't need. |
| Automatically start containers in background | On | Docker Compose | Again for increased performance, Visual Studio creates a container with volume mounts ready for when you build and run your container. If you want to control when your container is created, turn this off. |
| Automatically kill containers on solution close | On | Docker Compose | Turn this off if you would like containers for your solution to continue to run after closing the solution or closing Visual Studio. |
| Do not prompt for trusting localhost SSL certificate | Off | ASP.NET Core 2.1 projects | If the localhost SSL certificate is not trusted, Visual Studio will prompt every time you run your project, unless this checkbox is checked. |

> [!WARNING]
> If the localhost SSL certificate is not trusted, and you check the box to suppress prompting, then HTTPS web requests might fail at runtime in your app or service. In that case, uncheck the **Do not prompt** checkbox, run your project, and indicate trust at the prompt.

**More information:** For further details on the services implementation and use of Visual Studio Tools for Docker, read the following articles:

Build, debug, update, and refresh apps in a local Docker container: [https://docs.microsoft.com/azure/vs-azure-tools-docker-edit-and-refresh/](https://docs.microsoft.com/azure/vs-azure-tools-docker-edit-and-refresh)

Deploy an ASP.NET Core Docker container to a container registry: [https://docs.microsoft.com/azure/vs-azure-tools-docker-hosting-web-apps-in-docker/](https://docs.microsoft.com/azure/vs-azure-tools-docker-hosting-web-apps-in-docker)

>[!div class="step-by-step"]
>[Previous](docker-apps-inner-loop-workflow.md)
>[Next](set-up-windows-containers-with-powershell.md)