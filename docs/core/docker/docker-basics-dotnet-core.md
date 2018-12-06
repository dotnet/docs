---
title: Containerize an app with Docker - .NET Core
description: This tutorial teaches how to create a basic .NET Core application and containerize it with Docker.
ms.date: 10/11/2018
ms.topic: tutorial
ms.custom: "mvc, seodec18"
---

# How to containerize a .NET Core application

This tutorial teaches the Docker container build and deploy tasks for a .NET Core application. The [Docker platform](https://docs.docker.com/engine/docker-overview/#the-docker-platform) uses the [Docker Engine](https://docs.docker.com/engine/docker-overview/#docker-engine) to quickly build and package apps as [Docker images](https://docs.docker.com/glossary/?term=image). These images are written in the [Dockerfile](https://docs.docker.com/glossary/?term=Dockerfile) format to be deployed and run in a [layered container](https://docs.docker.com/engine/userguide/storagedriver/imagesandcontainers/#container-and-layers).

During the course of this tutorial, you learn:

> [!div class="checklist"]
> * How to create a Dockerfile
> * How to create a .NET Core app.
> * How to deploy your app into a Docker container.

## .NET Core: Easiest way to get started

Before creating the Docker image, you need an application to containerize. You can create it on Linux, MacOS, or Windows. The quickest and easiest way to do that is to use .NET Core.

If you're unfamiliar with the .NET Core CLI toolset, read the [.NET Core SDK overview](../tools/index.md).

You can build both Windows and Linux containers with [multi-arch based tags](https://github.com/dotnet/announcements/issues/14).

## Your first .NET Core Docker app

### Prerequisites

To complete this tutorial:

#### .NET Core SDK

* Install [.NET Core 2.1 SDK](https://www.microsoft.com/net/download) or later.

See [.NET Core 2.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md) for the complete list of .NET Core 2.1 supported operating systems, out of support OS versions, and lifecycle policy links.

* Install your favorite code editor, if you haven't already.

> [!TIP]
> Need to install a code editor? Try [Visual Studio Code](https://code.visualstudio.com/download)!

#### Installing Docker Client

Install [Docker 18.06](https://docs.docker.com/release-notes/docker-ce/) or later of the Docker client.

The Docker client can be installed in:

* Linux distributions

   * [CentOS](https://docs.docker.com/install/linux/docker-ce/centos/)

   * [Debian](https://docs.docker.com/install/linux/docker-ce/debian/)

   * [Fedora](https://docs.docker.com/install/linux/docker-ce/fedora/)

   * [Ubuntu](https://docs.docker.com/install/linux/docker-ce/ubuntu/)

* [macOS](https://docs.docker.com/docker-for-mac/install/)

* [Windows](https://docs.docker.com/docker-for-windows/install/).

### Create a .NET Core 2.1 console app for Dockerization

Open a command prompt and create a folder named *Hello*. Navigate to the folder you created and type the following commands:

```console
dotnet new console
dotnet run
```

Let's do a quick walkthrough:

1. `$ dotnet new console`

   [`dotnet new`](../tools/dotnet-new.md) creates an up-to-date `Hello.csproj` project file with the dependencies necessary to build a console app.  It also creates a `Program.cs`, a basic file containing the entry point for the application.

   `Hello.csproj`:

   The project file specifies everything that's needed to restore dependencies and build the program.

   * The `OutputType` tag specifies that we're building an executable, in other words a console application.
   * The `TargetFramework` tag specifies what .NET implementation we're targeting. In an advanced scenario, you can specify multiple target frameworks and build to the specified frameworks in a single operation. In this tutorial, we build for .NET Core 2.1.

   `Program.cs`:

   The program starts by `using System`. This statement means, "Bring everything in the `System` namespace into scope for this file." The `System` namespace includes basic constructs such as `string`, or numeric types.

   We then define a namespace called `Hello`. You can change namespace to anything you want. A class named `Program` is defined within that namespace, with a `Main` method that takes an array of strings as its argument. This array contains the list of arguments passed in when the compiled program is called. In our example, the program only writes "Hello World!" to the console.

   **dotnet new** runs the [`dotnet restore`](../tools/dotnet-restore.md) command. **Dotnet restore** restores the tree of dependencies with a [NuGet](https://www.nuget.org/)(.NET package manager) call.
   NuGet performs the following tasks:
   * analyzes the *Hello.csproj* file.
   * downloads the file dependencies (or grabs from your machine cache).
   * writes the *obj/project.assets.json* file.

   The *project.assets.json* file is a complete set of the NuGet dependencies graph, binding resolutions, and other app metadata. This required file is used by other tools, such as [`dotnet build`](../tools/dotnet-build.md) and [`dotnet run`](../tools/dotnet-run.md), to correctly process the source code.

2. `$ dotnet run`

   [`dotnet run`](../tools/dotnet-run.md) calls [`dotnet build`](../tools/dotnet-build.md) to confirm a successful build, and then calls `dotnet <assembly.dll>` to run the application.

    ```console
    $ dotnet run

    Hello World!
    ```

    For advanced scenarios,  see [.NET Core Application Deployment](../deploying/index.md) for details.

## Dockerize the .NET Core application

The Hello .NET Core console app successfully runs locally. Now let's take it a step further and build and run the app in Docker.

### Your first Dockerfile

Open your text editor and let's get started! We're still working from the Hello directory we built the app in.

Add the following Docker instructions for either Linux or [Windows Containers](https://docs.microsoft.com/virtualization/windowscontainers/about/) to a new file. When finished, save it in the root of your Hello directory as **Dockerfile**, with no extension (You may need to set your file type to `All types (*.*)` or something similar).

```Dockerfile
FROM microsoft/dotnet:2.1-sdk
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/Hello.dll"]
```

The Dockerfile contains Docker build instructions that run sequentially.

The first instruction must be [**FROM**](https://docs.docker.com/engine/reference/builder/#from). This instruction initializes a new build stage and sets the Base Image for the remaining instructions. The multi-arch tags pull either Windows or Linux containers depending on the Docker for Windows [container mode](https://docs.docker.com/docker-for-windows/#switch-between-windows-and-linux-containers). The Base Image for our sample is the 2.1-sdk image from the microsoft/dotnet repository,

```Dockerfile
FROM microsoft/dotnet:2.1-sdk
```

The [**WORKDIR**](https://docs.docker.com/engine/reference/builder/#workdir) instruction sets the working directory for any remaining RUN, CMD, ENTRYPOINT, COPY, and ADD Dockerfile instructions. If the directory doesn't exist, it's created. In this case, WORKDIR is set to the app directory.

```Dockerfile
WORKDIR /app
```

The [**COPY**](https://docs.docker.com/engine/reference/builder/#copy) instruction copies new files or directories from the source path and adds them to the destination container filesystem. With this instruction, we are copying the C# project file to the container.

```Dockerfile
COPY *.csproj ./
```

The [**RUN**](https://docs.docker.com/engine/reference/builder/#run) instruction executes any commands in a new layer on top of the current image and commit the results. The resulting committed image is used for the next step in the Dockerfile. We are running **dotnet restore** to get the needed dependencies of the C# project file. 

```Dockerfile
RUN dotnet restore
```

This **COPY** instruction copies the rest of the files into our container into new [layers](https://docs.docker.com/engine/userguide/storagedriver/imagesandcontainers/#images-and-layers).

```Dockerfile
COPY . ./
```

We are publishing the app with this **RUN** instruction. The [**dotnet publish**](../tools/dotnet-publish.md) command compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. Our app is published with a **Release** configuration and output to the default directory.

```Dockerfile
RUN dotnet publish -c Release -o out
```

The [**ENTRYPOINT**](https://docs.docker.com/engine/reference/builder/#entrypoint) instruction allows the container to run as an executable.

```Dockerfile
ENTRYPOINT ["dotnet", "out/Hello.dll"]
```

Now you have a Dockerfile that:

* copies your app to the image
* your app's dependencies to the image
* builds the app to run as an executable

### Build and run the Hello .NET Core app

#### Essential Docker commands

These Docker commands are essential:

* [docker build](https://docs.docker.com/engine/reference/commandline/build/)
* [docker run](https://docs.docker.com/engine/reference/commandline/run/)
* [docker ps](https://docs.docker.com/engine/reference/commandline/ps/)
* [docker stop](https://docs.docker.com/engine/reference/commandline/stop/)
* [docker rm](https://docs.docker.com/engine/reference/commandline/rm/)
* [docker rmi](https://docs.docker.com/engine/reference/commandline/rmi/)
* [docker image](https://docs.docker.com/engine/reference/commandline/image/)

#### Build and run

You wrote the dockerfile; now Docker builds your app and then runs the container.

```console
docker build -t dotnetapp-dev .
docker run --rm dotnetapp-dev Hello from Docker
```

The output from the `docker build` command should be similar to the following console output:

```console
Sending build context to Docker daemon   173.1kB
Step 1/7 : FROM microsoft/dotnet:2.1-sdk
 ---> 288f8c45f7c2
Step 2/7 : WORKDIR /app
 ---> Using cache
 ---> 9af1fbdc7972
Step 3/7 : COPY *.csproj ./
 ---> Using cache
 ---> 86c8c332d4b3
Step 4/7 : RUN dotnet restore
 ---> Using cache
 ---> 86fcd7dd0ea4
Step 5/7 : COPY . ./
 ---> Using cache
 ---> 6faf0a53607f
Step 6/7 : RUN dotnet publish -c Release -o out
 ---> Using cache
 ---> f972328318c8
Step 7/7 : ENTRYPOINT dotnet out/Hello.dll
 ---> Using cache
 ---> 53c337887e18
Successfully built 46db075bd98d
Successfully tagged dotnetapp-dev:latest
```

As you can see from the output, the Docker Engine used the Dockerfile to build our container.

The output from the `docker run` command should be similar to the following console output:

```console
Hello World!
```

Congratulations! You have just:
> [!div class="checklist"]
> * Created a local .NET Core app
> * Created a Dockerfile to build your first container
> * Built and ran your Dockerized app

## Next steps

Here are some next steps you can take:

* [Introduction to .NET Docker Images Video](https://channel9.msdn.com/Shows/Code-Conversations/Introduction-to-NET-Docker-Images-with-Kendra-Havens?term=docker)
* [Visual Studio, Docker & Azure Container Instances better together!](https://medium.com/@AliMazaheri/visual-studio-docker-azure-container-instances-better-together-bf8c2f0419ae)
* [Docker for Azure Quickstarts](https://docs.docker.com/docker-for-azure/#docker-community-edition-ce-for-azure)
* [Deploy your app on Docker for Azure](https://docs.docker.com/docker-for-azure/deploy/)

> [!Note]
> If you do not have an Azure subscription, [sign up today](https://azure.microsoft.com/free/?b=16.48) for a free 30-day account and get $200 in Azure Credits to try out any combination of Azure services.

## Docker Images used in this sample

The following Docker images are used in this sample

* [`microsoft/dotnet:2.1-sdk`](https://hub.docker.com/r/microsoft/dotnet)

## Related resources

* [.NET Core Docker samples](https://github.com/dotnet/dotnet-docker/tree/master/samples)
* [Dockerfile on Windows Containers](https://docs.microsoft.com/virtualization/windowscontainers/manage-docker/manage-windows-dockerfile)
* [.NET Framework Docker samples](https://github.com/Microsoft/dotnet-framework-docker-samples)
* [ASP.NET Core on DockerHub](https://hub.docker.com/r/microsoft/aspnetcore/)
* [Dockerize a .NET Core application - Docker Tutorial](https://docs.docker.com/engine/examples/dotnetcore/)
* [Working with Visual Studio Docker Tools](https://docs.microsoft.com/aspnet/core/publishing/visual-studio-tools-for-docker)
* [Deploying Docker Images from the Azure Container Registry to Azure Container Instances](https://blogs.msdn.microsoft.com/stevelasker/2017/07/28/deploying-docker-images-from-the-azure-container-registry-to-azure-container-instances/)