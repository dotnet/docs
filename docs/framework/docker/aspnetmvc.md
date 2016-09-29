---
title: Running ASP.NET MVC applications in Docker
description: Learn how to take an existing ASP.NET MVC application and run it in a Windows Docker Container
keywords: .NET, .NET Server, .NET Desktop
author: dotnet-bot
manager: wpickett
ms.date: 09/28/2016
ms.topic: article
ms.prod: .net-framework-4.6
ms.technology: dotnet-mvc
ms.devlang: dotnet
ms.assetid: c9f1d52c-b4bd-4b5d-b7f9-8f9ceaf778c4
---

# Running ASP.NET MVC Applications in Windows Docker Containers

Running an existing .NET Framework based application in a Docker container
requires creating the Docker image that contains your application, and
starting one or more containers that run that image. This topic explains
the tasks you must perform to take an existing ASP.NET MVC application
and run that application in a Windows Server Core Docker container.

You'll start with an existing ASP.NET MVC application. You'll see how to
build the assets to publish using Visual Studio. You'll use the Docker tools
to build an image that contains all the services you need to run an ASP.NET
MVC application. You'll build the image that contains your application, and
runs that application when it is started. You'll see how to connect to your
application running in a Windows based Docker container.

The application you'll run in a container is a simple website that
answers questions randomly. This application
is a basic MVC application with no authentication support, or database
storage. That lets you focus on moving the web tier to a container. Later
topics show how to move and manage persistent storage in containerized
applications.

The finished application is located in the
[dotnet/core-docs repository on GitHub](https://github.com/dotnet/core-docs/tree/master/samples/framework/docker/AspNetMVCRandomAnswerGenerator).

## Define some Terms

You need to be familiar with some Docker terms before you begin working
on moving your application to a container.

> A **Docker image** is a read-only template that defines the environment
> for a running container, including the OS, system components, and application(s).

> A **Docker container** is a running instance of an image. 


.. Define Image
.. Explain where images can be built on each other
.. Define container
.. Explain multiple containers

## Publish script

## Build the images

## Start a container


## Find the IP address

## Broswe

## Closing


Coming soon!
