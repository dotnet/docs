---
title: Install for Docker - Command line
description: Install for Docker - Command line
keywords: .NET, .NET Core, C#, Getting Started, Acquisition,  Cross Platform, Docker, CLI
author: kendrahavens
ms.author: kendrahavens
ms.date: 12/19/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 
---

# Install for Docker - Command line
## 1. Install Docker
- Before you can try out the .NET Core Docker base images, you should install Docker.
- Refer to the [macOS](http://www.docker.com/products/docker#/mac), [Windows](http://www.docker.com/products/docker#/windows) or [Linux](http://www.docker.com/products/docker#/linux) getting started instructions for Docker to learn more about installing Docker.
## 2. Run the container using "dotnet" base image
- The following command will get you a running container with the toolchain, straight off of Microsoft's [Docker Hub](https://hub.docker.com/r/microsoft/dotnet/).
```
docker run -it microsoft/dotnet:latest
```
## 3. Initialize some code
- Let's initialize a sample Hello World application!
```
mkdir hwapp
cd hwapp
dotnet new
```
## 4. Run the app
- The first command will restore the packages specified in the project.json file, and the second command will run the actual sample:
```
dotnet restore
dotnet run
```
## And you're ready!
- You now have .NET core running on your machine!

## Want some tools?
- Visual Studio Code provides a lightweight code editing experience which runs everywhere (including Windows, Linux and Mac).
  ## [Download Visual Studio Code](https://code.visualstudio.com/)

If you use [Yeoman](http://yeoman.io/), then take a look at [yo docker](https://aka.ms/yodocker) to help you create, run and debug your .NET Core project inside of a Docker container.


