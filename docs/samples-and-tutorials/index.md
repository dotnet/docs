---
title: Samples and tutorials
description: Information on samples and tutorials for .NET Core and the C# language that help you learn about .NET.
keywords: .NET
author: BillWagner
ms.author: wiwagn
ms.date: 03/30/2017
ms.topic: article
ms.prod: .net
ms.devlang: dotnet
ms.assetid: 617310e7-336b-4864-8dab-7e2021512929
---

# Samples and tutorials

The .NET documentation contains a rich set of samples and tutorials that you can use to learn more about .NET. This topic describes samples and tutorials for .NET Core and the C# language. Find great resources to learn the F# programming language on the [F# Foundation's site](http://fsharp.org/learn.html). [Tutorials for learning ASP.NET Core](https://docs.microsoft.com/aspnet/core/tutorials/) are available. If you're interested in exploring C# using an online playground, try these [interactive tutorials](http://go.microsoft.com/fwlink/p/?LinkId=817234).

## General

### Samples

**[Unit Testing in .NET Core using dotnet test](../core/testing/unit-testing-with-dotnet-test.md)**

This guide shows how to create an ASP.NET Core web application and associated unit tests. It starts by creating a simple web service application and then adds tests. It continues with creating more tests to guide implementing new features. The [completed code](https://github.com/dotnet/docs/tree/master/samples/core/getting-started/unit-testing-using-dotnet-test) is available from GitHub.

### Tutorials

**[Writing .NET Core console apps using the CLI tools: A step-by-step guide](../core/tutorials/using-with-xplat-cli.md)**

This guide shows you how to use the .NET Core CLI tooling to build cross-platform console apps. It starts with a basic console app and eventually spans multiple projects, including testing. You add features step-by-step, building on what you've already seen and built. The [completed code](https://github.com/dotnet/docs/tree/master/samples/core/console-apps) is available from GitHub.

**[Writing Libraries with Cross Platform Tools](../core/tutorials/libraries.md)**

This sample covers how you write libraries for .NET using cross-platform CLI tools. These tools provide an efficient and low-level experience that works across any supported operating system. The [completed code](https://github.com/dotnet/docs/tree/master/samples/framework/libraries/frameworks-library) is available from GitHub.

## C# language

### Samples

**[Iterators](../csharp/iterators.md)**

This sample demonstrates the syntax and features for creating and consuming C# iterators. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/iterators) is available from GitHub.

**[Indexers](../csharp/indexers.md)**

This sample demonstrates the syntax and features for C# indexers. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/indexers) is available from GitHub.

**[Delegates and Events](../csharp/delegates-events.md)**

This sample demonstrates the syntax and features for C# delegates and events. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/delegates-and-events) is available from GitHub. A [second sample](https://github.com/dotnet/docs/tree/master/samples/csharp/events) focused on events is also in the same repository.

**[Expression Trees](../csharp/expression-trees.md)**

This sample demonstrates many of the problems that you can solve by using Expression Trees. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/expression-trees) is available from GitHub.

**LINQ Samples**

This series of samples demonstrate many of the features of Language Integrated Query (LINQ). The [completed code](https://github.com/dotnet/docs/tree/master/samples/core/linq/csharp) is available from GitHub.

### Tutorials

**[Console Application](../csharp/tutorials/console-teleprompter.md)**

This tutorial demonstrates Console I/O, the structure of a console application, and the basics of the Task-based asynchronous programming model. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/console-teleprompter) is available from GitHub.

**[REST Client](../csharp/tutorials/console-webapiclient.md)**

This tutorial demonstrates web communications, JSON serialization, and Object Oriented features in the C# language. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/console-webapiclient) is available from GitHub.

**[Working with LINQ](../csharp/tutorials/working-with-linq.md)**

This tutorial demonstrates many of the features of LINQ and the language elements that support it. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/console-linq) is available from GitHub.

**[Microservices hosted in Docker](../csharp/tutorials/microservices.md)**

This tutorial demonstrates building an ASP.NET Core microservice and hosting it in Docker. The [completed code](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/WeatherMicroservice) is available from GitHub.

**[Getting started with .NET Core on macOS using Visual Studio for Mac](../core/tutorials/using-on-mac-vs.md)**

This tutorial shows you how to build a simple .NET Core console application using Visual Studio for Mac.

**[Building a complete .NET Core solution on macOS using Visual Studio for Mac](../core/tutorials/using-on-mac-vs-full-solution.md)**

This tutorial shows you how to build a complete .NET Core solution that includes a reusable library and unit testing.

## Deploying to containers

**[Running ASP.NET MVC Applications in Windows Docker Containers](../framework/docker/aspnetmvc.md)**

This tutorial demonstrates how to deploy an existing ASP.NET MVC application in a Windows Docker Container. The [completed code](https://github.com/dotnet/docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator) is available from GitHub.

**[Running .NET Framework Console Applications in Windows Containers](../framework/docker/console.md)**

This tutorial demonstrates how to deploy an existing console application in a Windows container. The [completed code](https://github.com/dotnet/docs/tree/master/samples/framework/docker/ConsoleRandomAnswerGenerator) is available from GitHub.

## Viewing or downloading samples

Many topics show source code and samples that are available for viewing or download from GitHub. To locally view or obtain the code mentioned in a topic, follow these instructions:

1. Either fork, clone, or download a ZIP of the docs repository.
1. Navigate within the repository to the sample's location. The relative path to the sample's location appears in your browser's address bar when you follow the link to the sample in the topic.
1. If you intend to run the sample code locally and prefer to run it from a different location on your system, copy the sample's files and folders to a suitable location.
1. To run a sample, you have several options:
   * [dotnet CLI tools](../tools/index.md): Navigate to the sample's folder and use CLI commands.
   * [Visual Studio](https://www.visualstudio.com/) or [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/): Open the sample by selecting **File > Open > Project/Solution** from the menu bar, navigate to the sample project folder, and select the project's *.csproj* file.
   * [Visual Studio Code](https://code.visualstudio.com/): Open the sample by selecting **File > Open Folder** from the menu bar and selecting the sample project folder.
