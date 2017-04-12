---
title: Building .NET Core Docker Images
description: Understanding Docker images and .NET Core
keywords: .NET, .NET Core, Docker
author: spboyer
ms.author: shboyer
ms.date: 08/29/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-docker
ms.devlang: dotnet
ms.assetid: 03c28597-7e73-46d6-a9c3-f9cb55642739
---
 

#Building Docker Images for .NET Core Applications

In order to get an understanding of how to use .NET Core and Docker together, we must first get to know the different Docker images that are offered and when is the right use case for them. Here we will walk through the variations offered, build an ASP.NET Core Web API, use the Yeoman Docker tools to create a debuggable container as well as peek at how Visual Studio Code can assist in the process. 

## Docker Image Optimizations

When building Docker images for developers, we focused on three main scenarios:

- Images used to develop .NET Core apps
- Images used to build .NET Core apps
- Images used to run .NET Core apps

Why three images?
When developing, building and running containerized applications, we have different priorities.
- **Development:**  How fast can you iterate changes, and the ability to debug the changes. The size of the image isn't as important, rather can you make changes to your code and see them quickly. Some of our tools, like [yo docker](https://aka.ms/yodocker) for use in VS Code use this image during development time. 
- **Build:** What's needed to compile your app. This includes the compiler and any other dependencies to optimize the binaries. This image isn't the image you deploy, rather it's an image you use to build the content you place into a production image. This image would be used in your continuous integration, or build environment. For instance, rather than installing all the dependencies directly on a build agent, the build agent would instance a build image to compile the application with all the dependencies required to build the app contained within the image. Your build agent only needs to know how to run this Docker image. 
- **Production:** How fast you can deploy and start your image. This image is small so it can quickly travel across the network from your Docker Registry to your Docker hosts. The contents are ready to run enabling the fastest time from Docker run to processing results. In the immutable Docker model, there's no need for dynamic compilation of code. The content you place in this image would be limited to the binaries and content needed to run the application. For example, the published output using `dotnet publish` which contains the compiled binaries, images, .js and .css files. Over time, you'll see images that contain pre-jitted packages.  

Though there are multiple versions of the .NET Core image, they all share one or more layers. The amount of disk space needed to store or the delta to pull from your registry is much smaller than the whole because all of the images share the same base layer and potentially others.  

## Docker image variations

To achieve the goals above, we provide image variants under [microsoft/dotnet](https://hub.docker.com/r/microsoft/dotnet/).

- `microsoft/dotnet:<version>-sdk` : that is **microsoft/dotnet:1.0.0-preview2-sdk**, this image contains the .NET Core SDK which includes the .NET Core and Command Line Tools (CLI). This image maps to the **development scenario**. You would use this image for local development, debugging and unit testing. For example, all the development you do, before you check in your code. This image can also be used for your **build** scenarios.

- `microsoft/dotnet:<version>-core` : that is **microsoft/dotnet:1.0.0-core**, image which runs [portable .NET Core applications](../deploying/index.md) and it is optimized for running your application in **production**. It does not contain the SDK, and is meant to take the optimized output of `dotnet publish`. The portable runtime is well suited for Docker container scenarios as running multiple containers benefit from shared image layers.  

## Alternative images

In addition to the optimized scenarios of development, build and production, we provide additional images:

- `microsoft/dotnet:<version>-onbuild` : that is **microsoft/dotnet:1.0.0-preview2-onbuild**, contains [ONBUILD](https://docs.docker.com/engine/reference/builder/#/onbuild) triggers. The build will [COPY](https://docs.docker.com/engine/reference/builder/#/copy) your application, run `dotnet restore` and create an [ENTRYPOINT](https://docs.docker.com/engine/reference/builder/#/entrypoint) `dotnet run` instruction to run the application when the Docker image is run. While not an optimized image for production, some may find it useful to simply copy their source code into an image and run it. 

- `microsoft/dotnet:<version>-core-deps` : that is **microsoft/dotnet:1.0.0-core-deps**, if you wish to run self-contained applications use this image. It contains the operating system with all of the native dependencies needed by .NET Core. This image can also be used as a base image for your own custom CoreFX or CoreCLR builds. While the **onbuild** variant is optimized to simply place your code in an image and run it, this image is optimized to have only the operating system dependencies required to run .NET Core apps that have the .NET Runtime packaged with the application. This image isn't generally optimized for running multiple .NET Core containers on the same host, as each image carries the .NET Core runtime within the application, and you will not benefit from image layering.   

Latest versions of each variant:

- `microsoft/dotnet` or `microsoft/dotnet:latest` (includes SDK)
- `microsoft/dotnet:onbuild`
- `microsoft/dotnet:core`
- `microsoft/dotnet:core-deps`

Here is a list of the images after a `docker pull <imagename>` on a development machine to show the various sizes. Notice, the development/build variant, `microsoft/dotnet:1.0.0-preview2-sdk` is larger as it contains the SDK to develop and build your application. The production variant, `microsoft/dotnet:core` is smaller, as it only contains the .NET Core runtime. 
The minimal image capable of being used on Linux, `core-deps`, is quite smaller, however your application will need to copy a private copy of the .NET Runtime with it. Since containers are already private isolation barriers, you will lose that optimization when running multiple dotnet based containers. 

```
REPOSITORY          TAG                     IMAGE ID            SIZE
microsoft/dotnet    1.0.0-preview2-onbuild  19b6a6c4b1db        540.4 MB
microsoft/dotnet    onbuild                 19b6a6c4b1db        540.4 MB
microsoft/dotnet    1.0.0-preview2-sdk      a92c3d9ad0e7        540.4 MB
microsoft/dotnet    core                    5224a9f2a2aa        253.2 MB
microsoft/dotnet    1.0.0-core-deps         c981a2eebe0e        166.2 MB
microsoft/dotnet    core-deps               c981a2eebe0e        166.2 MB
microsoft/dotnet    latest                  03c10abbd08a        540.4 MB
microsoft/dotnet    1.0.0-core              b8da4a1fd280        253.2 MB
```

## Prerequisites

To build and run, you'll need a few things installed:

- [.NET Core](http://dot.net)
- [Docker](https://www.docker.com/products/docker) to run your Docker containers locally 
- [Yeoman generator for ASP.NET](https://github.com/omnisharp/generator-aspnet) for creating the Web API application
- [Yeoman generator for Docker](http://aka.ms/yodocker) from Microsoft

Install the Yeoman generators for ASP.NET Core and Docker using npm 

```
npm install -g yo generator-aspnet generator-docker
```

> [!NOTE]
> This sample will be using [Visual Studio Code](http://code.visualstudio.com) for the editor.

## Creating the Web API application

For a reference point, before we containerize the application, first run the application locally. 

The finished application is located in the
[dotnet/docs repository on GitHub](https://github.com/dotnet/docs/tree/master/samples/core/docker/building-net-docker-images). For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

Create a directory for your application.

Open a command or terminal session in that directory and use the ASP.NET Yeoman generator by typing the following:
```
yo aspnet
```

Select **Web API Application** and type **api** for the name of the app and tap enter.  Once the application is scaffolded, change to the `/api` directory and restore the NuGet dependencies using `dotnet restore`.

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

Adding Docker support to the project is achieved using the Yeoman generator from Microsoft. It currently supports .NET Core, Node.js and Go projects by creating a Dockerfile and scripts that help build and run projects inside containers. Visual Studio Code specific files are also added (launch.json, tasks.json) for editor debugging and command palette support.

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
- `5000` is the port the Web API application is listening on (http://localhost:5000)
- `api` for the image name
- `api` for the service name
- `api` for the compose project 
- `Y` to overwrite the current Dockerfile

When the generator is complete, the following files are added to the project

- .vscode/launch.json
- Dockerfile.debug
- Dockerfile
- docker-compose.debug.yml
- docker-compose.yml
- dockerTask.ps1
- dockerTask.sh
- .vscode/tasks.json

The generator creates two Dockerfiles.

**Dockerfile.debug** - this file is based on the **microsoft/dotnet:1.0.0-preview2-sdk** image which if you note from the list of image variants, includes the SDK, CLI and .NET Core and will be the image used for development and debugging (F5). Including all of these components produces a larger image with a size roughly of 540MB.

**Dockerfile** - this image is the release image based on **microsoft/dotnet:1.0.0-core** and should be used for production. This image when built is approximately 253 MB.

### Creating the Docker images
Using the `dockerTask.sh` or `dockerTask.ps1` script, we can build or compose the image and container for the **api** application for a specific environment. Build the **debug** image by running the following command.

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

![vscode debugging icon](./media/building-net-docker-images/debugging_debugicon.png)

Then tap the play icon or F5 to generate the image and start the application within the container. The Web API will be launched using your default web browser at http://localhost:5000.

![VSCode Docker Tools Debug](./media/building-net-docker-images/docker-tools-vscode-f5.png)

You may set break points in your application, step through, etc. just as if the application was running locally on your development machine as opposed to inside the container. The benefit to debugging within the container is this is the same image that would be deployed to a production environment.

Creating the release or production image requires simply running the command from the terminal passing the `release` environment name.

```bash
./dockerTask build release
```

The command creates the image based on the smaller **microsoft/dotnet:core** base image, [EXPOSE](https://docs.docker.com/engine/reference/builder/#/expose) port 5000, sets the [ENTRYPOINT](https://docs.docker.com/engine/reference/builder/#/entrypoint) for `dotnet api.dll` and copies it to the `/app` directory. There is no debugger, SDK or `dotnet restore` resulting in a much smaller image. The image is named **api** with a `TAG` of **latest**.

```
REPOSITORY          TAG                  IMAGE ID            CREATED             SIZE
api                 debug                70e89fbc5dbe        1 hour ago        779.8 MB
api                 latest               ef17184c8de6        1 hour ago        260.7 MB
```

## Summary

Using the Docker generator to add the necessary files to our Web API application made the process simple to create the development and production versions of the images.  The tooling is cross platform by also providing a PowerShell script to accomplish the same results on Windows and Visual Studio Code integration providing step through debugging of the application within the container. By understanding the image variants and the target scenarios, you can optimize your inner-loop development process, while achieving optimized images for production deployments.  


