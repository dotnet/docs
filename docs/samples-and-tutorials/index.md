---
title: Samples and tutorials
description: Information on samples and tutorials for .NET Core, ASP.NET Core, and the C# language that help you learn about .NET.
keywords: .NET, .NET Core, ASP.NET, C#, sample, tutorial
author: BillWagner
ms.author: wiwagn
ms.date: 03/31/2017
ms.topic: article
ms.prod: .net
ms.devlang: dotnet
ms.assetid: 617310e7-336b-4864-8dab-7e2021512929
---

# Samples and tutorials

The .NET documentation contains a rich set of samples and tutorials that teach you about .NET. This topic describes how to find, view, and download .NET Core, ASP.NET Core, and C# samples and tutorials. Find great resources to learn the F# programming language on the [F# Foundation's site](http://fsharp.org/learn.html). If you're interested in exploring C# using an online code editor, try these [interactive tutorials](http://go.microsoft.com/fwlink/p/?LinkId=817234).

## Viewing or downloading samples

Many topics show source code and samples that are available for viewing or download from GitHub. To view the sample, follow the sample link to the sample folder at the aspnet/Docs or dotnet/docs repository on GitHub. To obtain the code for the sample mentioned in a topic, follow these instructions:

1. Obtain the repository containing the sample code for your local system by performing one of the following procedures:
   * [Fork](https://help.github.com/articles/fork-a-repo/) the repository and [clone](https://help.github.com/articles/cloning-a-repository/) the fork to your local system. Forking and cloning permits you to make contributions to the .NET documentation by committing to your fork and creating pull requests to the docs repositories. For more information, see the [.NET Documentation Contributing Guide](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md) and the [ASP.NET Docs Contributing Guide](https://github.com/aspnet/Docs/blob/master/CONTRIBUTING.md).
   * Clone the repository locally. Note that if you clone a docs repository directly to your local system that you won't be able to make commits, so you won't be able to make documentation contributions later.
   * Download a ZIP of the repository to your local system. Un-ZIP the compressed archive.
1. Navigate within the repository to the sample's location. The relative path to the sample's location appears in the GitHub UI and in your browser's address bar when you follow the link to the sample in the topic where the sample is described.
1. If you intend to run the sample code locally and prefer to run it from a different location on your system than where you maintain your repository files, copy the sample's files and folders to your preferred location.
1. To run a sample, you have several options:
   * Use the [dotnet CLI tools](../core/tools/index.md): In a console window, navigate to the sample's folder and use dotnet CLI commands.
   * Use [Visual Studio](https://www.visualstudio.com/) or [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/): Open the sample by selecting **File > Open > Project/Solution** from the menu bar, navigate to the sample project folder, and select the project file (*.csproj* or *.fsproj*).
   * Use [Visual Studio Code](https://code.visualstudio.com/): Open the sample by selecting **File > Open Folder** from the menu bar and selecting the sample's project folder.
   * Use a different IDE that supports .NET Core projects.

## .NET Core

### Samples

**[Unit Testing in .NET Core using dotnet test](../core/testing/unit-testing-with-dotnet-test.md)**

This guide shows you how to create an ASP.NET Core web app and associated unit tests. It starts by creating a simple web service app and then adds tests. It continues with creating more tests to guide implementing new features. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/core/getting-started/unit-testing-using-dotnet-test) is available in the dotnet/docs repository on GitHub.

### Tutorials

**[Writing .NET Core console apps using the CLI tools: A step-by-step guide](../core/tutorials/using-with-xplat-cli.md)**

This guide shows you how to use the .NET Core CLI tooling to build cross-platform console apps. It starts with a basic console app and eventually spans multiple projects, including testing. You add features step-by-step, building your knowledge as you go. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/core/console-apps) is available in the dotnet/docs repository on GitHub.

**[Writing Libraries with Cross Platform Tools](../core/tutorials/libraries.md)**

This sample covers how to write libraries for .NET using cross-platform CLI tools. These tools provide an efficient and low-level experience that works across any supported operating system. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/framework/libraries/frameworks-library) is available in the dotnet/docs repository on GitHub.

## ASP.NET Core

The [ASP.NET Core tutorials](https://docs.microsoft.com/aspnet/core/tutorials/) include step-by-step guides and sample code for:

* Building web apps
* Building web APIs
* Working with data
* Authentication and authorization
* Client-side development
* Testing
* Publishing and deployment

## C# language

### Samples

**[Iterators](../csharp/iterators.md)**

This sample demonstrates the syntax and features for creating and consuming C# iterators. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/iterators) is available in the dotnet/docs repository on GitHub.

**[Indexers](../csharp/indexers.md)**

This sample demonstrates the syntax and features for C# indexers. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/indexers) is available in the dotnet/docs repository on GitHub.

**[Delegates and Events](../csharp/delegates-events.md)**

This sample demonstrates the syntax and features for C# delegates and events. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/delegates-and-events) is available in the dotnet/docs repository on GitHub. A [second sample](https://github.com/dotnet/docs/tree/master/samples/csharp/events) focused on events is also in the same repository.

**[Expression Trees](../csharp/expression-trees.md)**

This sample demonstrates many of the problems that can be solved by using Expression Trees. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/expression-trees) is available in the dotnet/docs repository on GitHub.

**LINQ Samples**

This series of samples demonstrate many of the features of Language Integrated Query (LINQ). The [completed sample](https://github.com/dotnet/docs/tree/master/samples/core/linq/csharp) is available in the dotnet/docs repository on GitHub.

### Tutorials

**[Console Application](../csharp/tutorials/console-teleprompter.md)**

This tutorial demonstrates Console I/O, the structure of a console app, and the basics of the Task-based asynchronous programming model. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/console-teleprompter) is available in the dotnet/docs repository on GitHub.

**[REST Client](../csharp/tutorials/console-webapiclient.md)**

This tutorial demonstrates web communications, JSON serialization, and Object Oriented features of the C# language. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/console-webapiclient) is available in the dotnet/docs repository on GitHub.

**[Working with LINQ](../csharp/tutorials/working-with-linq.md)**

This tutorial demonstrates many of the features of LINQ and the language elements that support it. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/console-linq) is available in the dotnet/docs repository on GitHub.

**[Microservices hosted in Docker](../csharp/tutorials/microservices.md)**

This tutorial demonstrates building an ASP.NET Core microservice and hosting it in Docker. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/WeatherMicroservice) is available in the dotnet/docs repository on GitHub.

**[Getting started with .NET Core on macOS using Visual Studio for Mac](../core/tutorials/using-on-mac-vs.md)**

This tutorial shows you how to build a simple .NET Core console app using Visual Studio for Mac.

**[Building a complete .NET Core solution on macOS using Visual Studio for Mac](../core/tutorials/using-on-mac-vs-full-solution.md)**

This tutorial shows you how to build a complete .NET Core solution that includes a reusable library and unit testing.

## Deploying to containers

**[Running ASP.NET MVC Applications in Windows Docker Containers](../framework/docker/aspnetmvc.md)**

This tutorial demonstrates how to deploy an existing ASP.NET MVC app in a Windows Docker Container. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator) is available in the dotnet/docs repository on GitHub.

**[Running .NET Framework Console Applications in Windows Containers](../framework/docker/console.md)**

This tutorial demonstrates how to deploy an existing console app in a Windows container. The [completed sample](https://github.com/dotnet/docs/tree/master/samples/framework/docker/ConsoleRandomAnswerGenerator) is available in the dotnet/docs repository on GitHub.
