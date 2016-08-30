---
title: Building .NET Core Docker Images
description: Understading Docker images and .NET Core
keywords: .NET, .NET Core, Docker
author: spboyer
manager: wpickett
ms.date: 08/29/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 03c28597-7e73-46d6-a9c3-f9cb55642739
---


#Building Docker Images for .NET Core Applications

In order to get an understanding of how to use .NET Core and Docker together, we must first get to know the different Docker images that are offered and when is the right use case to use them. Here we will walk through the variatons offered, build an ASP.NET Core Web API, use the Yeoman Docker tools to create a debuggable container as well as peek at how Visual Studio Code can assist in the process. 

## Docker image variatons

The `microsoft/dotnet` images are offerred in three different variatons, each for a specific use case.

- `microsoft/dotnet:<version>-sdk` : i.e. **microsoft/dotnet-preview2-sdk**, this image contains the .NET Core SDK which includes the .NET Core and Command Line Tools (CLI). Use this image for your development processes; dev, test debug.

- `microsoft/dotnet:<version>-onbuild` : i.e. **microsoft/dotnet:onbuild**, contains `ONBUILD` triggers which should cover most applications. The build will `COPY` you application, run `dotnet restore` and create an `ENTRYPOINT dotnet run` instruction to run the application when the Docker image is run.

- `microsoft/dotnet:<version>-core` : i.e. **microsoft/dotnet:1.0.0-core**, image contains only .NET Core (runtime and libraries) and it is optimized for running [portable .NET Core applications](https://docs.microsoft.com/en-us/dotnet/articles/core/app-types).

- `microsoft/dotnet:<version>-core-deps` : i.e. **microsoft/dotnet:1.0.0-core-deps**, if you wish to run self-contained applications use this image.  Contains the operating system with all of the native dependencies needed bt .NET Core. Can also be used to build a custom copy of .NET core by compiling coreclr and corefx.

Latest versions of each variant:

- `microsoft/dotnet` or `microsoft/dotnet:latest` (aka sdk)
- `microsoft/dotnet:onbuild`
- `microsoft/dotnet:core`
- `microsoft/dotnet-core-deps`

Here is a list of the images after a `docker pull <imagename>` on a development machine to show the various sizes.

```
REPOSITORY          TAG                  IMAGE ID            SIZE
microsoft/dotnet    onbuild              19b6a6c4b1db        540.4 MB
microsoft/dotnet    1.0.0-preview2-sdk   a92c3d9ad0e7        540.4 MB
microsoft/dotnet    core                 5224a9f2a2aa        253.2 MB
microsoft/dotnet    1.0.0-core-deps      c981a2eebe0e        166.2 MB
microsoft/dotnet    core-deps            c981a2eebe0e        166.2 MB
microsoft/dotnet    latest               03c10abbd08a        540.4 MB
microsoft/dotnet    1.0.0-core           b8da4a1fd280        253.2 MB
```

## Prerequisites

- [.NET Core](http://dot.net)
- Docker Engine : see [Docker Installation page](http://www.docker.com/products/docker)
- Yeoman tooling for ASP.NET for creating the Web API application
- Yeoman tools for Docker from Microsoft

The Yeoman tools are install using npm 

```
npm install -g yo generator-aspnet generator-docker
```

> [!NOTE]
> This sample will be using [Visual Studio Code](http://code.visualstudio.com) for the editor.

## Creating the Web API application

Using the ASP.NET Yeoman generator, open a command or terminal session and type the following.
```
yo aspnet
```

Select **Web API Application** and type **api** for the name of the app ann tap enter.  Once the application is scaffolded, change to the `/api` directory and restore the NuGet dependencies using `dotnet restore`

```
cd api
dotnet restore
```

Test the application using `dotnet run` and browsing to **http://localhost:5000/api/values**

```javascript
[
    "value1",
    "value2"
]
```

Use `Ctrl+C` to stop the application.

## Adding Docker support
Adding Docker support the project is achieved using the Yeoman generator from Microsoft. It currently supports .NET Core, node.js and Golang projects by creating a Dockerfile and scripts that help build and run project inside containers. Visual Studio Code specific files are also added (launch.json, tasks.json) for editor debugging and command pallete support.

```console
$ yo docker

     _-----_     ╭──────────────────────────╮
    |       |    │   Welcome to the Docker  │
    |--(o)--|    │        generator!        │
   `---------´   │     Let's add Docker     │
    ( _´U`_ )    │  container magic to your │
    /___A___\   /│           app!           │
     |  ~  |     ╰──────────────────────────╯
   __'.___.'__
 ´   `  |° ´ Y `

? What language is your project using? (Use arrow keys)
❯ .NET Core
  Golang
  Node.js

```

- Select `.NET Core` as the project type
- `rtm` for the version of .NET Core
- `Y` the project uses a web server
- `5000` is the port the Web API application is listening on (i.e. http://localhost:5000)
- `api` for the image name
- `api` for the service name
- `api` for the compose project 
- `Y` to overwrite the current Dockerfile

When the generator is complete the following files are added to the project

- .vscode/launch.json
- Dockerfile.debug
- Dockerfile
- docker-compose.debug.yml
- docker-compose.yml
- dockerTask.ps1
- dockerTask.sh
- .vscode/tasks.json

The generator creates a two Dockerfiles.

**Dockerfile.debug** - this file is based on the **microsoft/dotnet:1.0.0-preview2-sdk** image which if you note from the list of image variants, includes the SDK, CLI and .NET Core. Aptly named ".debug", will be the image used for debugging and development (F5) thus producing a larger image roughly 540MB.

**Dockerfile** - this image is the release image based on **microsoft/dotnet:1.0.0-core** and should be used for production. This image when built is approximately 253 MB.

### Creating the Docker images
Using the `dockerTask.sh` script we can build or compose the image and container for the **api** application for a specific environment. Build the **debug** image by running the following command.

```bash
./dockerTask.sh build debug
```

The image will build the ASP.NET application, run `dotnet restore`, add the debugger to the image, set an `ENTRYPOINT` and finally copy the app to the image. The result is a Docker image named *api* with a `TAG` of *debug*.  See the images on the machine using `docker images`.

```bash
docker images

REPOSITORY          TAG                  IMAGE ID            CREATED             SIZE
api                 debug                70e89fbc5dbe        a few seconds ago   779.8 MB
```

Another way to generate the image and run the application within the Docker container is to open the application in Visual Studio Code and use the debugging tools. 

Select the debugging icon in the View Bar on the left side of VS Code.

![vscode debugging icon](../images/debugging_debugicon.png)

Then tap the play icon or F5 to generate the image and start the application within the container. The Web API will be launched using your default web browser at http://localhost:5000.

![VSCode Docker Tools Debug](../images/docker-tools-vscode-f5.png)

You may set break points in your application, step through etc. just as if the application was running locally on your dev machine as opposed to inside the container. The benefit to debugging within the container is this is the same image that would be deployed to a production environment.

Creating the release image requires simply running the command from the terminal passing the `release` environment name.

```bash
./dockerTask build release
```

The command creates the image based on the smaller **microsoft/dotnet:core** base image, `EXPOSE` port 5000, sets the `ENTRYPOINT` for `dotnet api.dll` and copies it the app directory. There is no debugger, SDK or `dotnet restore` resulting in a much smaller image. The image is named **api** with a `TAG` of **latest**.

```
REPOSITORY          TAG                  IMAGE ID            CREATED             SIZE
api                 debug                70e89fbc5dbe        1 hour ago        779.8 MB
api                 latest               ef17184c8de6        1 hour ago        260.7 MB
```

## Summary

Using the Docker generator to add the necessary files to our Web API application made the process simple to create the debug and release versions of the images.  The tooling is cross platform by also providing a PowerShell script to accomplish the same results on Windows and Visual Studio Code integration allowed for step through debugging of the application within the container. 



