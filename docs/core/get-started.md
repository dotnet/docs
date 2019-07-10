---
title: Get started with .NET Core
description: Find resources to learn how to build .NET Core applications on Windows, Linux and macOS.
author: thraka
ms.author: adegeo
ms.date: 06/27/2018
---

# Get started with .NET Core

This article provides information on getting started with .NET Core. .NET Core can be installed on Windows, Linux, and macOS. You can code in your favorite text editor and produce cross-platform libraries and applications. 

If you're unsure what .NET Core is, or how it relates to other .NET technologies, start with the [What is .NET](https://www.microsoft.com/net/learn/dotnet/what-is-dotnet) overview. Put simply, .NET Core is an open-source, cross-platform implementation of .NET.

## Create an application

First, download and install the [.NET Core SDK](https://www.microsoft.com/net/download/) on your computer.

Next, open a terminal such as **PowerShell**, **Command Prompt**, or **bash**. Type the following `dotnet` commands to create and run a C# application.

```console
dotnet new console --output sample1
dotnet run --project sample1
```

You should see the following output:

```console
Hello World!
```

Congratulations! You've created a simple .NET Core application. You can also use [Visual Studio Code](tutorials/with-visual-studio-code.md), [Visual Studio](tutorials/with-visual-studio.md) (Windows only), or [Visual Studio for Mac](tutorials/using-on-mac-vs.md) (macOS only), to create a .NET Core application.

## Tutorials

You can get started developing .NET Core applications by following these step-by-step tutorials.

# [Windows](#tab/windows)

* [Build a C# "Hello World" Application with .NET Core in Visual Studio 2017.](./tutorials/with-visual-studio.md)

* [Build a C# class library with .NET Core in Visual Studio 2017.](./tutorials/library-with-visual-studio.md)

* [Build a Visual Basic "Hello World" application with .NET Core in Visual Studio 2017.](./tutorials/vb-with-visual-studio.md)

* [Build a class library with Visual Basic and .NET Core in Visual Studio 2017.](./tutorials/vb-library-with-visual-studio.md)  

* Watch a video on [how to install and use Visual Studio Code and .NET Core](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core/).

* Watch a video on [how to install and use Visual Studio 2017 and .NET Core](https://channel9.msdn.com/Blogs/dotnet/Get-Started-NET-Core-Visual-Studio-2017/).

* [Getting started with .NET Core using the command-line.](tutorials/using-with-xplat-cli.md)

See the [Prerequisites for Windows development](windows-prerequisites.md) article for a list of the supported Windows versions.

# [Linux](#tab/linux)

You can get started developing .NET Core application by following these step-by-step tutorials.

* [Getting started with .NET Core using the command-line.](tutorials/using-with-xplat-cli.md)

* Watch a video on [getting started with Visual Studio Code using C# and .NET Core on Ubuntu](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-Csharp-dotnet-Core-Ubuntu).

See the [Prerequisites for Linux development](linux-prerequisites.md) article for a list of the supported Linux distros and versions.

# [macOS](#tab/macos)

You can get started developing .NET Core application by following these step-by-step tutorials.

* Watch a video on [Getting started with Visual Studio Code using C# and .NET Core on macOS](https://channel9.msdn.com/Blogs/dotnet/Get-started-VSCode-NET-Core-Mac).

* [Getting started with .NET Core on macOS, using Visual Studio Code.](tutorials/using-on-macos.md)

* [Getting started with .NET Core using the command-line.](tutorials/using-with-xplat-cli.md)

* [Getting started with .NET Core on macOS using Visual Studio for Mac.](tutorials/using-on-mac-vs.md)

* [Build a complete .NET Core solution on macOS using Visual Studio for Mac.](tutorials/using-on-mac-vs-full-solution.md)

See the [Prerequisites for macOS development](macos-prerequisites.md) article for a list of the supported OS X / macOS versions.

---
