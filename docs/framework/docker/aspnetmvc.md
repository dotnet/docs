---
title: Migrating ASP.NET MVC Applications to Windows Containers
description: Learn how to take an existing ASP.NET MVC application and run it in a Windows Docker Container
keywords: .NET, .NET Server, .NET Desktop
author: BillWagner
manager: wpickett
ms.date: 09/28/2016
ms.topic: article
ms.prod: .net-framework-4.6
ms.technology: dotnet-mvc
ms.devlang: dotnet
ms.assetid: c9f1d52c-b4bd-4b5d-b7f9-8f9ceaf778c4
---

# Migrating ASP.NET MVC Applications to Windows Containers

Running an existing .NET Framework-based application in a Windows container
requires creating the Docker image that contains your application, and
starting one or more containers to run that image. This topic explains
the tasks you must perform to take an existing ASP.NET MVC application
and deploy it in a Windows container.

You'll start with an existing ASP.NET MVC application. You'll see how to
build the assets to publish using Visual Studio. You'll use Docker
to build the image that contains your application, and
runs that application when it is started. You'll see how to connect to your
application running in a Windows container.

If you are unfamiliar with Docker, you can learn more about the Docker
architecture by reading the 
[Docker Overview](https://docs.docker.com/engine/understanding-docker/)
on the Docker site. 

The application you'll run in a container is a simple website that
answers questions randomly. This application
is a basic MVC application with no authentication support, or database
storage. That lets you focus on moving the web tier to a container. Later
topics show how to move and manage persistent storage in containerized
applications.

Moving your application involves these steps:

1. [Creating a publish task to build the assets for an image.](#publish-script)
2. [Building a Docker image that will run your application.](#build-the-image)
3. [Starting a Docker container that runs your image.](#start-a-container)
4. [Verifying the application using your browser.](#verify-in-the-browser)

The finished application is located in the
[dotnet/core-docs repository on GitHub](https://github.com/dotnet/core-docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator).

## Prerequisites

Your development machine must be running Windows 10 Anniversary Update, or newe,
or, Windows Server 2016, or newer.

Before starting, you need to install [Docker for Windows](https://docs.docker.com/docker-for-windows/).
You need to install version 1.12 Beta 26, or newer for Windows container support.
After installing and starting Docker, you'll need to right-click on the
tray icon and select **Switch to Windows containers...** in order to run
Docker images based on Windows. This command takes a few seconds to
execute:

![Windows Container][windows-container]


## Publish script

You can use the Visual Studio Publish command to create a publish profile
for your application. You'll copy all the published assets to your Docker
image later in this tutorial. The publish command will put all the publish
assets in one directory tree that you will copy to your target image.
Right-click on your solution in Visual Studio, and select "Publish".
Click the "Custom" profile button, and then select "File System" as the
method (see image). Choose a new directory in your solution folder. (The
downloaded sample uses "bin/PublishOutput" as the folder name).

![Publish Connection][publish-connection]

Next, open the "File Publish Options" section of the "Settings" tab. Select
"Precompile during publishing". This optimization means that you be
compiling views in the Docker container, you are copying the precompiled
views.

![Publish Settings][publish-settings]

Click Publish, and Visual Studio will copy all the needed assets to the
destination folder. 

## Build the image

To run your application, you'll build an image based on the `microsft/aspnet`
image located on [Docker Hub](https://hub.docker.com/r/microsoft/aspnet/).

The base image, `microsoft/aspnet` is a Windows Server image. In addition
to the Windows Server Core, it has IIS enabled. It also has ASP.NET 4.6.2
installed and enabled. When you run this image in a container, it will start
IIS and any installed websites will be active.

The Dockerfile that creates your image looks like this:

```
FROM microsoft/aspnet
RUN mkdir C:\randomanswers

RUN powershell -NoProfile -Command \
    Import-module IISAdministration; \
    New-IISSite -Name "ASPNET" -PhysicalPath C:\randomanswers -BindingInformation "*:8000:"

EXPOSE 8000

ADD containerImage/ /randomanswers
```

The `FROM` instruction specifies the base image. You're image is built by
extending the `microsoft/aspnet` image. Next, this Dockerfile creates a
directory for your application, and configures the new site in IIS.
The next instruction tells the container to listen on port 8000. The
final instruction copies the site you published earlier into the
container.

There is no `ENTRYPOINT` command in this Dockerfile. You don't need one.
The base image ensures that IIS starts when the container starts. 

Run a Docker build command to create the image that will run your ASP.NET
application. Open a PowerShell window, and type the following command <in></in>
the solution directory:

```
docker build -t mvcrandomanswers .
```

This command will build the new image by following the instructions in your
Dockerfile. This may include puling the base image from [Docker Hub](http://hub.docker.com),
Then it will add your application to that image.

Once that command completes, you can run the `docker images` command
to see information on the new image:

```
REPOSITORY                    TAG                 IMAGE ID            CREATED             SIZE
mvcrandomanswers              latest              86838648aab6        2 minutes ago       8.104 GB
```

The IMAGE ID will be different on your machine. Now, let's run the applicaton.

## Start a container

You start a container by executing the follows `docker run` command:

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
can connect to your running container from a browser. You use the `docker exec`
command to do that:

```
docker exec randomanswers ipconfig
```

You will see an output similar to this:

```
Windows IP Configuration


Ethernet adapter Ethernet 2:

   Connection-specific DNS Suffix  . :
   Link-local IPv6 Address . . . . . : fe80::91d:ce97:dd27:460d%5
   IPv4 Address. . . . . . . . . . . : 172.31.194.61
   Subnet Mask . . . . . . . . . . . : 255.240.0.0
   Default Gateway . . . . . . . . . : 172.16.0.1
```

You can connect to the running container using the IPv4 
address and the configured port (8000), `http://172.31.194.61:8000`
in the example shown. Type that URL into your browser, and you should
see the running site.

> [!NOTE]
> Some VPN or proxy software may prevent you from navigating to your site.
> You can temporarily disable it to make sure your container is working.

The sample directory on GitHub contains a 
[PowerShell script](https://github.com/dotnet/core-docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator/run.ps1)
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

To remove the container, issue a docker rm command:

```
docker rm randomanswers
```

## Summary

In this topic, you've seen the steps to move an existing
ASP.NET MVC application to run in a Windows container. Running an
existing application does not require any changes to your
application. You need to run the tasks to publish your application,
build a Docker image, and start that image in a new container. Your
existing ASP.NET MVC applications are container-ready.

[windows-container]: media/aspnetmvc/SwitchContainer.png "Switch to Windows Container"
[publish-connection]: media/aspnetmvc/PublishConnection.png "Publish to File System"
[publish-settings]: media/aspnetmvc/PublishSettings.png "Publish Settings"
