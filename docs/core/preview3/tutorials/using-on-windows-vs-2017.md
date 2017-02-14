---
title: Getting started with .NET Core on Windows, using Visual Studio 2017 | Microsoft Docs
description: Getting started with .NET Core on Windows, using Visual Studio 2017
keywords: .NET, .NET Core
author: bleroy
ms.author: mairaw
ms.date: 01/18/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 613c65d0-f773-41b8-ba0e-83f6a82a0b30
---

# Getting started with .NET Core on Windows, using Visual Studio 2017 (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the Visual Studio 2015 - .NET Core Tools Preview 2 version,
> see the [Getting started with .NET Core on Windows, using Visual Studio 2015](../../tutorials/using-on-windows.md) topic.

Visual Studio 2017 provides a full-featured development environment for developing .NET Core applications. The procedures in this document describe the steps necessary to build a very simple console application, using Visual Studio and .NET Core.

## Prerequisites

Follow the instructions on [our prerequisites page](../windows-prerequisites.md) to update your environment.

## Getting Started

The following steps will set up Visual Studio 2017 for .NET Core console application development:

1. Open Visual Studio, and on the **File** menu, choose **New**, **Project**.

2. In the **New Project** dialog, in the **Templates** list, expand the **Visual C#** node and choose **.NET Core**. You should see five project templates for **Console App (.NET Core)**, **Class Library (.NET Standard)**, **xUnit Test Project (.NET Core)**, **Class Library (.NET Core)**, and **ASP.NET Core Web Application (.NET Core)**. Choose **Console App (.NET Core)**, type a name for your project, pick a location, then click OK.

  ![New project: console app](media/new-project-console-app.png)

3. The resulting project has a single C# file that will output "Hello World" to the console.

  ![The console app project](media/console-app-solution.png)

You may run this application in debug mode using F5, or in release mode using CTRL+F5. You may also set breakpoints to interrupt execution and inspect variables, or start writing more interesting code.

Happy coding!

## Next Steps

After this simple introduction, you're probably wondering how to build more advanced solutions, with reusable libraries and tests. The [Building a complete .NET Core solution on Windows, using Visual Studio 2017](using-on-windows-vs-2017-full-solution.md) topic will show you how to do that.
