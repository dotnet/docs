---
title: Running ASP.NET MVC applications in Docker
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

# Running ASP.NET MVC Applications in Windows Docker Containers

Running an existing .NET Framework based application in a Windows Docker container
requires creating the Docker image that contains your application, and
starting one or more containers to run that image. This topic explains
the tasks you must perform to take an existing ASP.NET MVC application
and deploy it in a Windows Docker container.

You'll start with an existing ASP.NET MVC application. You'll see how to
build the assets to publish using Visual Studio. You'll use the Docker tools
to build the image that contains your application, and
runs that application when it is started. You'll see how to connect to your
application running in a Windows based Docker container.

The application you'll run in a container is a simple website that
answers questions randomly. This application
is a basic MVC application with no authentication support, or database
storage. That lets you focus on moving the web tier to a container. Later
topics show how to move and manage persistent storage in containerized
applications.

The finished application is located in the
[dotnet/core-docs repository on GitHub](https://github.com/dotnet/core-docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator).

You need to be familiar with some Docker terms before you begin working
on moving your application to a container.

> A **Docker image** is a read-only template that defines the environment
> for a running container, including the OS, system components, and application(s).

One important feature of Docker images is that images are composed from a
base image. Each new image adds a small set of features to an existing
image. 

> A **Docker container** is a running instance of an image. 

You scale an application by running the same image in many containers.
Conceptually, this is similar to running the same application in multiple
hosts.

You can learn more about the Docker architecture by reading the 
[Docker Overview](https://docs.docker.com/engine/understanding-docker/)
on the Docker site. 

Before starting, you need to install [Docker for Windows](https://docs.docker.com/docker-for-windows/).
You need to install version 1.12 Beta 26, or newer for Windows container support.
After installing and starting Docker, you'll need to right-click on the
tray icon and select 'Switch to Windows containers...' in order to run
Docker images based on Windows OSs. This command takes a few seconds to
execute.

Moving your application involves these steps:

1. Creating a publish task to build the assets for an image.
2. Building a Docker image that will run your application.
3. Starting a Docker container that runs your image.
4. Verifying the application using your browser.

## Publish script

You can use the Visual Studio Publish command to create a publish profile
for your application. You'll copy all the published assets to your Docker
image later in this tutorial. The publish command will put all the publish
assets in one directory tree that you will copy to your target image.
Right-click on your solution in Visual Studio, and select "Publish".
Click the "Custom" profile button, and then select "File System" as the
method (see image). Choose a new directory in your solution folder. (The
downloaded sample uses "containerImage" as the folder name).

![Publish Connection][publish-connection]

Next, open the "Advanced" section of the "File Publish" options. Select
"Precompile during publishing". This optimization means that you be
compiling views in the Docker container, you are copying the precompiled
views.

![Publish Settings][publish-settings]

Click publish, and Visual Studio will copy all the needed assets to the
destination folder. 

## Build the image

To run your application, you'll build an image based on the `microsft/aspnet`
image located on [Docker Hub](https://hub.docker.com/r/microsoft/aspnet/).

You'll compose this image using the `microsoft/aspnet` image as the base:

```
FROM microsoft/aspnet
```

The next command creates the directory that holds your application:

```
RUN mkdir C:\randomanswers
```

After that, you run a powershell command in the Docker image to setup
the new site: 

```
RUN powershell -NoProfile -Command \
    Import-module IISAdministration; \
    New-IISSite -Name "ASPNET" -PhysicalPath C:\randomanswers -BindingInformation "*:8000:"
```

Following that, you instruct your Docker image to listen on port 8000: 

```
EXPOSE 8000
```

And last, you copy everything from your publish directory to the Docker image:

```
ADD containerImage/ /randomanswers
```

Run a Docker build command to create the image that will run your asp.net
application. Open a powershell window, and type the following command in
the solution directory:

```
docker build -t mvcrandomanswers .
```

Once that command completes, you can run the `docker images` command
to see information on the new image:

```
REPOSITORY                    TAG                 IMAGE ID            CREATED             SIZE
mvcrandomanswers              latest              86838648aab6        2 minutes ago       8.104 GB
```

The IMAGE ID will be different on your machine. Now, let's run the applicaton.

## Start a container

You start a container by executing the `docker run` command:

```
docker run -d -p 8000:8000 --name randomanswers mvcrandomanswers
```

The `-d` argument tells Docker to start the image in detached mode. That
means the Docker image runs disconnected from the current shell.

The `-p 8000:8000` argument tells docker how to map incoming ports. In this
example, I'm using port 8000 on both the host and the container.

The `--name randomanswers` gives a name to the running container. You can use
this name instead of the container ID in most commands.

The `mvcrandomanswers` is the name of the image to start.

## Find the IP address

Once the container starts, you'll need to find its IP address so that you
can connect to your running container from a browser. You use the `docker exec`
command to do that:

```
docker exec randomanswers ipconfig
```

You will see output similar to this:

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
[powershell script](https://github.com/dotnet/core-docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator/run.ps1)
that executes these commands for you. Open a Powershell window, cd to
your solution directory, and type:

```
./run.ps1
```

It will build the image, display the list of images on your machine, start
a container, and display the IP address for that container. 

When you are done, and you want to stop your container, issue a docker
stop command:

```
docker stop randomanswers
```

To remove the container, issue a docker rm command:

```
docker rm randomanswers
```

## Closing

In this topic, you've seen the step you must take to move an existing
ASP.NET MVC application to run in a Windows container. Running an
existing application does not require any changes to your the
application. You need to run the tasks to publish your application,
build a Docker image, and start that image in a new container. You're
existing ASP.NET MVC applications are container-ready.

[publish-connection]: media/aspnetmvc/PublishConnection.png "Publish to File System"
[publish-settings]: media/aspnetmvc/PublishSettings.png "Publish Settings"
