---
title: Migrating ASP.NET MVC Applications to Windows Containers
description: Learn how to take an existing ASP.NET MVC application and run it in a Windows Docker Container
keywords: Windows Containers, Docker, ASP.NET MVC
author: BillWagner
ms.author: wiwagn
ms.date: 09/28/2016
ms.topic: article
ms.prod: .net-framework
ms.technology: dotnet-mvc
ms.devlang: dotnet
ms.assetid: c9f1d52c-b4bd-4b5d-b7f9-8f9ceaf778c4
---

# Migrating ASP.NET MVC Applications to Windows Containers

Running an existing .NET Framework-based application in a Windows container
requires creating the Docker image that contains your application, and
starting one or more containers to run that image. This topic explains
the tasks you must perform to take an existing [ASP.NET MVC application](http://www.asp.net/mvc)
and deploy it in a Windows container.

You'll start with an existing ASP.NET MVC application. Then 
build the published assets using Visual Studio. You'll use Docker
to create the image that contains your application, and
runs that application when it is started. When you've finished, you can connect
a browser to the site running in a Windows container and verify the application is
running.

This article assumes a basic understanding of Docker. You can learn more
about the Docker architecture by reading the 
[Docker Overview](https://docs.docker.com/engine/understanding-docker/)
on the Docker site, if these concepts are new.

The application you'll run in a container is a simple website that
answers questions randomly. This application is a basic MVC application
with no authentication support, or database storage, letting you focus
on moving the web tier to a container. Future topics will show how to
move and manage persistent storage in containerized applications.

Moving your application involves these steps:

1. [Creating a publish task to build the assets for an image.](#publish-script)
2. [Building a Docker image that will run your application.](#build-the-image)
3. [Starting a Docker container that runs your image.](#start-a-container)
4. [Verifying the application using your browser.](#verify-in-the-browser)

The finished application is located in the
[dotnet/core-docs repository on GitHub](https://github.com/dotnet/docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator).

## Prerequisites

At a minimum, your development machine must be running
[Windows 10 Anniversary Update](https://www.microsoft.com/en-us/software-download/windows10/)
or [Windows Server 2016](https://www.microsoft.com/en-us/cloud-platform/windows-server). 

Before starting, you need to install [Docker for Windows](https://docs.docker.com/docker-for-windows/),
version 1.12 Beta 26, or newer. Windows Container support is only available
in the Beta channel at this time.

> [!IMPORTANT]
> If you are using Windows Server 2016, you need to follow the
> instructions for [Container Host Deployment - Windows Server](https://msdn.microsoft.com/virtualization/windowscontainers/deployment/deployment)
> before you can run Docker containers.

After installing and starting Docker, you'll need to right-click on the
tray icon and select **Switch to Windows containers** in order to run
Docker images based on Windows. This command takes a few seconds to
execute:

![Windows Container][windows-container]

## Publish script

The first step is to get all the assets that you'll need to load into
a Docker image in one place. Fortunately, you can use the Visual Studio
**Publish** command to create a publish profile for your application. This
profile will put all the assets in one directory tree that you will
copy to your target image later in this tutorial.

**Publish Steps**

1. Right click on the web project in Visual Studio, and select **Publish**.
2. Click the **Custom profile button, and then select **File System** as the method.
3. Choose the directory. By convention, the downloaded sample uses `bin/PublishOutput`.

![Publish Connection][publish-connection]

Next, open the **File Publish Options** section of the **Settings** tab. Select
**Precompile during publishing**. This optimization means that you be
compiling views in the Docker container, you are copying the precompiled
views.

![Publish Settings][publish-settings]

Click **Publish**, and Visual Studio will copy all the needed assets to the
destination folder. 

## Build the image

You define your Docker image in a Dockerfile that contains instructions
for the base image, any additional components, the application you
want to run, and other configuration image.  The Dockerfile is the input
to the `docker build` command, which creates the image.

You will build an image based on the `microsft/aspnet`
image located on [Docker Hub](https://hub.docker.com/r/microsoft/aspnet/).
The base image, `microsoft/aspnet`, is a Windows Server image. In addition
to the Windows Server Core, it has IIS and ASP.NET 4.6.2
installed and enabled. When you run this image in a container, it will
automatically start IIS and any installed websites will be active.

The Dockerfile that creates your image looks like this:

```
# The `FROM` instruction specifies the base image. You are
# extending the `microsoft/aspnet` image.

FROM microsoft/aspnet

# Next, this Dockerfile creates a directory for your application
RUN mkdir C:\randomanswers

# configure the new site in IIS.
RUN powershell -NoProfile -Command \
    Import-module IISAdministration; \
    New-IISSite -Name "ASPNET" -PhysicalPath C:\randomanswers -BindingInformation "*:8000:"

# This instruction tells the container to listen on port 8000. 
EXPOSE 8000

# The final instruction copies the site you published earlier into the container.
ADD containerImage/ /randomanswers
```

There is no `ENTRYPOINT` command in this Dockerfile. You don't need one.
The base image ensures that IIS starts when the container starts. 

Next, you will need run a Docker build command to create the image that
will run your ASP.NET application. To do this, open a PowerShell
window, and type the following command in the solution directory:

```
docker build -t mvcrandomanswers .
```

This command will build the new image by following the instructions in your
Dockerfile. This may include pulling the base image from [Docker Hub](http://hub.docker.com),
Then it will add your application to that image.

Once that command completes, you can run the `docker images` command
to see information on the new image:

```
REPOSITORY                    TAG                 IMAGE ID            CREATED             SIZE
mvcrandomanswers              latest              86838648aab6        2 minutes ago       8.104 GB
```

The IMAGE ID will be different on your machine. Now, let's run the application.

## Start a container

You start a container by executing the following `docker run` command:

```
docker run -d -p 8000:8000 --name randomanswers mvcrandomanswers
```

The `-d` argument tells Docker to start the image in detached mode. That
means the Docker image runs disconnected from the current shell.

The `-p 8000:8000` argument tells Docker how to map incoming ports. In this
example, we're using port 8000 on both the host and the container.

The `--name randomanswers` gives a name to the running container. You can use
this name instead of the container ID in most commands.

The `mvcrandomanswers` is the name of the image to start.

## Verify in the browser

> [!NOTE]
> With the current release, you can't use `http://localhost` to browse
> to your site. This is because of a known behavior in WinNAT, and it will
> be resolved in the future. Until that is addressed, you need to use
> the IP address of the container.

Once the container starts, you'll need to find its IP address so that you
can connect to your running container from a browser:

```
docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" randomanswers
172.31.194.61
```

You can connect to the running container using the IPv4 
address and the configured port (8000), `http://172.31.194.61:8000`
in the example shown. Type that URL into your browser, and you should
see the running site.

> [!NOTE]
> Some VPN or proxy software may prevent you from navigating to your site.
> You can temporarily disable it to make sure your container is working.

The sample directory on GitHub contains a 
[PowerShell script](https://github.com/dotnet/docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator/run.ps1)
that executes these commands for you. Open a PowerShell window, change directory to
your solution directory, and type:

```
./run.ps1
```

It builds the image, displays the list of images on your machine, starts
a container, and displays the IP address for that container. 

When you are done, and you want to stop your container, issue a `docker
stop` command:

```
docker stop randomanswers
```

To remove the container, issue a `docker rm` command:

```
docker rm randomanswers
```

## Summary

In this topic, you've seen the steps to move and run an existing
ASP.NET MVC application in a Windows Server container. Running an
existing application does not require any changes to your
application. You need to run the tasks to publish your application,
build a Docker image, and start that image in a new container. Leveraging
Windows Server Containers are the easiest path to migrate your existing
applications to this environment.

[windows-container]: media/aspnetmvc/SwitchContainer.png "Switch to Windows Container"
[publish-connection]: media/aspnetmvc/PublishConnection.png "Publish to File System"
[publish-settings]: media/aspnetmvc/PublishSettings.png "Publish Settings"
