---
title: When to choose .NET Core for Docker containers
description: .NET Microservices Architecture for Containerized .NET Applications | When to choose .NET Core for Docker containers
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/11/2018
---
# When to choose .NET Core for Docker containers

The modularity and lightweight nature of .NET Core makes it perfect for containers. When you deploy and start a container, its image is far smaller with .NET Core than with .NET Framework. In contrast, to use .NET Framework for a container, you must base your image on the Windows Server Core image, which is a lot heavier than the Windows Nano Server or Linux images that you use for .NET Core.

Additionally, .NET Core is cross-platform, so you can deploy server apps with Linux or Windows container images. However, if you are using the traditional .NET Framework, you can only deploy images based on Windows Server Core.

The following is a more detailed explanation of why to choose .NET Core.

## Developing and deploying cross platform

Clearly, if your goal is to have an application (web app or service) that can run on multiple platforms supported by Docker (Linux and Windows), the right choice is .NET Core, because .NET Framework only supports Windows.

.NET Core also supports macOS as a development platform. However, when you deploy containers to a Docker host, that host must (currently) be based on Linux or Windows. For example, in a development environment, you could use a Linux VM running on a Mac.

[Visual Studio](https://www.visualstudio.com/vs/) provides an integrated development environment (IDE) for Windows and supports Docker development.

[Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/) is an IDE, evolution of Xamarin Studio, that runs on macOS and supports Docker-based application development. This should be the preferred choice for developers working in Mac machines who also want to use a powerful IDE.

You can also use [Visual Studio Code](https://code.visualstudio.com/) (VS Code) on macOS, Linux, and Windows. VS Code fully supports .NET Core, including IntelliSense and debugging. Because VS Code is a lightweight editor, you can use it to develop containerized apps on the Mac in conjunction with the Docker CLI and the [.NET Core command-line interface (CLI)](https://docs.microsoft.com/dotnet/core/tools/?tabs=netcore2x). You can also target .NET Core with most third-party editors like Sublime, Emacs, vi, and the open-source OmniSharp project, which also provides IntelliSense support.

In addition to the IDEs and editors, you can use the [.NET Core CLI](https://docs.microsoft.com/dotnet/core/tools/?tabs=netcore2x) tools for all supported platforms.

## Using containers for new ("green-field") projects

Containers are commonly used in conjunction with a microservices architecture, although they can also be used to containerize web apps or services that follow any architectural pattern. You can use .NET Framework on Windows Containers, but the modularity and lightweight nature of .NET Core makes it perfect for containers and microservices architectures. When you create and deploy a container, its image is far smaller with .NET Core than with .NET Framework.

## Creating and deploying microservices on containers

You could use the traditional .NET Framework for building microservices-based applications (without containers) by using plain processes. That way, because the .NET Framework is already installed and shared across processes, processes are light and fast to start. However, if you are using containers, the image for the traditional .NET Framework is also based on Windows Server Core and that makes it too heavy for a microservices-on-containers approach.

In contrast, .NET Core is the best candidate if you are embracing a microservices-oriented system that is based on containers, because .NET Core is lightweight. In addition, its related container images, either the Linux image or the Windows Nano image, are lean and small making containers light and fast to start.

A microservice is meant to be as small as possible: to be light when spinning up, to have a small footprint, to have a small Bounded Context (check DDD, [Domain-Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design)), to represent a small area of concerns, and to be able to start and stop fast. For those requirements, you will want to use small and fast-to-instantiate container images like the .NET Core container image.

A microservices architecture also allows you to mix technologies across a service boundary. This enables a gradual migration to .NET Core for new microservices that work in conjunction with other microservices or with services developed with Node.js, Python, Java, GoLang, or other technologies.

## Deploying high density in scalable systems

When your container-based system needs the best possible density, granularity, and performance, .NET Core and ASP.NET Core are your best options. ASP.NET Core is up to ten times faster than ASP.NET in the traditional .NET Framework, and it leads other popular industry technologies for microservices, such as Java servlets, Go, and Node.js.

This is especially relevant for microservices architectures, where you could have hundreds of microservices (containers) running. With ASP.NET Core images (based on the .NET Core runtime) on Linux or Windows Nano, you can run your system with a much lower number of servers or VMs, ultimately saving costs in infrastructure and hosting.

>[!div class="step-by-step"]
>[Previous](general-guidance.md)
>[Next](net-framework-container-scenarios.md)