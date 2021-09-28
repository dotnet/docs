---
title: .NET samples and tutorials
description: Information on samples and tutorials for .NET Core, ASP.NET Core, and the C# language that help you learn about .NET.
author: BillWagner
ms.author: wiwagn
ms.date: 02/01/2021
---

# .NET samples and tutorials

The .NET documentation contains a set of samples and tutorials that teach you about .NET. This article describes how to find, view, and download .NET, ASP.NET Core, and C# samples and tutorials. Find resources to learn the F# programming language on the [F# Foundation's site](https://fsharp.org/learn/). If you're interested in exploring C# using an online code editor, start with [this interactive tutorial](https://dotnet.microsoft.com/learn/dotnet/in-browser-tutorial/1) and continue with [C# interactive tutorial](../csharp/tour-of-csharp/tutorials/index.md). For instructions on how to view and download sample code, see the [Viewing and downloading samples](#view-and-download-samples) section.

## .NET

### Samples

**[Unit Testing in .NET Core using dotnet test](../core/testing/unit-testing-with-dotnet-test.md)**

This guide shows you how to create an ASP.NET Core web app and associated unit tests. It starts by creating a simple web service app and then adds tests. It continues with creating more tests to guide implementing new features. The [completed sample](https://github.com/dotnet/samples/tree/main/core/getting-started/unit-testing-using-dotnet-test) is available in the dotnet/samples repository on GitHub.

### Tutorials

**[Tutorial: Create a .NET console application using Visual Studio Code](../core/tutorials/with-visual-studio-code.md)**

This tutorial shows how to create and run a .NET console application by using Visual Studio Code and the .NET CLI. Project tasks, such as creating, compiling, and running a project are done by using the .NET CLI.

**[Tutorial: Create a .NET class library using Visual Studio Code](../core/tutorials/library-with-visual-studio-code.md)**

This tutorial shows how to write libraries for .NET using Visual Studio Code and the .NET CLI. Project tasks, such as creating, compiling, and running a project are done by using the .NET CLI.

For more .NET tutorials, see [Learn .NET and the .NET SDK tools](../core/tutorials/index.md).

## ASP.NET Core

See the [ASP.NET Core tutorials](/aspnet/core/tutorials/). Many articles in the ASP.NET Core documentation have links to samples written for them.

## C# language

### Samples

**[Iterators](../csharp/iterators.md)**

This sample demonstrates the syntax and features for creating and consuming C# iterators. The [completed sample](https://github.com/dotnet/samples/tree/main/csharp/iterators) is available in the dotnet/samples repository on GitHub.

**[Indexers](../csharp/indexers.md)**

This sample demonstrates the syntax and features for C# indexers. The [completed sample](https://github.com/dotnet/samples/tree/main/csharp/indexers) is available in the dotnet/samples repository on GitHub.

**[Delegates and Events](../csharp/delegates-overview.md)**

This sample demonstrates the syntax and features for C# delegates and events. The [completed sample](https://github.com/dotnet/samples/tree/main/csharp/delegates-and-events) is available in the dotnet/samples repository on GitHub. A [second sample](https://github.com/dotnet/samples/tree/main/csharp/events) focused on events is also in the same repository.

**[Expression Trees](../csharp/expression-trees.md)**

This sample demonstrates many of the problems that can be solved by using Expression Trees. The [completed sample](https://github.com/dotnet/samples/tree/main/csharp/expression-trees) is available in the dotnet/samples repository on GitHub.

**LINQ Samples**

This series of samples demonstrate many of the features of Language Integrated Query (LINQ). The [completed sample](https://github.com/dotnet/samples/tree/main/core/linq/csharp) is available in the dotnet/samples repository on GitHub.

**Managed COM server Sample**

The [COM server](https://github.com/dotnet/samples/tree/main/core/extensions/COMServerDemo) sample demonstrates the creation of a managed COM server and how it can be globally registered or consumed via RegFree COM.

**Microsoft Office PIA Sample**

The [ExcelDemo](https://github.com/dotnet/samples/tree/main/core/extensions/ExcelDemo) sample demonstrates the consumption of [Microsoft Office PIAs](/visualstudio/vsto/office-primary-interop-assemblies) in .NET Core.

### Tutorials

**[Console Application](../csharp/tutorials/console-teleprompter.md)**

This tutorial demonstrates Console I/O, the structure of a console app, and the basics of the task-based asynchronous programming model. The [completed sample](https://github.com/dotnet/samples/tree/main/csharp/getting-started/console-teleprompter) is available in the dotnet/samples repository on GitHub.

**[REST Client](../csharp/tutorials/console-webapiclient.md)**

This tutorial demonstrates web communications, JSON serialization, and object-oriented features of the C# language. The [completed sample](https://github.com/dotnet/samples/tree/main/csharp/getting-started/console-webapiclient) is available in the dotnet/samples repository on GitHub.

**[Working with LINQ](../csharp/tutorials/working-with-linq.md)**

This tutorial demonstrates many of the features of LINQ and the language elements that support it. The [completed sample](https://github.com/dotnet/samples/tree/main/csharp/getting-started/console-linq) is available in the dotnet/samples repository on GitHub.

**[Tutorial: Create a .NET console application using Visual Studio for Mac](../core/tutorials/with-visual-studio-mac.md)**

This tutorial shows you how to build a simple .NET console app using Visual Studio for Mac.

**[Create a .NET class library on macOS using Visual Studio for Mac](../core/tutorials/library-with-visual-studio-mac.md)**

This tutorial shows you how to build a .NET class library using Visual Studio for Mac.

**[Creating a .NET Core application that supports plugins](../core/tutorials/creating-app-with-plugin-support.md)**

This tutorial shows you how to build a simple application on .NET Core that supports a plugin architecture. The [completed sample](https://github.com/dotnet/samples/tree/main/core/extensions/AppWithPlugin) is available in the dotnet/samples repository on GitHub.

## Deploy to containers

**[Running ASP.NET MVC Applications in Windows Docker Containers](/aspnet/mvc/overview/deployment/docker-aspnetmvc)**

This tutorial demonstrates how to deploy an existing ASP.NET MVC app in a Windows Docker Container.

## View and download samples

Many topics show source code and samples that are available for viewing or download from GitHub. To view a sample, just follow the sample link. To download the code, follow these instructions:

1. Download the repository that contains the sample code by performing one of the following procedures:
   * Download a ZIP of the repository to your local system. Un-ZIP the compressed archive.
   * [Fork](https://help.github.com/articles/fork-a-repo/) the repository and [clone](https://help.github.com/articles/cloning-a-repository/) the fork to your local system. Forking and cloning permits you to make contributions to the documentation by committing changes to your fork and then creating a pull request for the official docs repository. For more information, see the [.NET Documentation Contributing Guide](/contribute/dotnet/dotnet-contribute) and the [ASP.NET Core Docs Contributing Guide](https://github.com/dotnet/AspNetCore.Docs/blob/main/CONTRIBUTING.md).
   * Clone the repository locally. If you clone a docs repository directly to your local system, you won't be able to make commits directly against the official repository, so you won't be able to make documentation contributions later. Use the fork and clone procedure previously described if you want to preserve the opportunity to contribute to the documentation later.
1. Navigate within the repository's folders to the sample's location. The relative path to the sample's location appears in your browser's address bar when you follow the link to the sample.
1. To run a sample, you have several options:
   * Use the [.NET CLI](../core/tools/index.md): In a console window, navigate to the sample's folder and use dotnet CLI commands.
   * Use [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link): Open the sample by selecting **File > Open > Project/Solution** from the menu bar, navigate to the sample project folder, and select the project file (*.csproj* or *.fsproj*).
   * Use [Visual Studio Code](https://code.visualstudio.com/): Open the sample by selecting **File > Open Folder** from the menu bar and selecting the sample's project folder.
   * Use a different IDE that supports .NET projects.
