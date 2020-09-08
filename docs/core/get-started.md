---
title: Get started with .NET Core
description: Find resources to learn how to build .NET Core applications on Windows, Linux, and macOS.
author: adegeo
ms.author: adegeo
ms.date: 12/03/2019
ms.custom: vs-dotnet
---
# Get started with .NET Core

This article provides information on getting started with .NET Core. .NET Core can be installed on Windows, Linux, and macOS. You can code in your favorite text editor and produce cross-platform libraries and applications.

If you're unsure what .NET Core is or how it relates to other .NET technologies, start with the [What is .NET](https://dotnet.microsoft.com/learn/dotnet/what-is-dotnet) overview. Put simply, .NET Core is an open-source, cross-platform implementation of .NET.

## Create an application

First, download and install the [.NET Core SDK](https://dotnet.microsoft.com/download) on your computer.

Next, open a terminal such as **PowerShell**, **Command Prompt**, or **bash**. Enter the following `dotnet` commands to create and run a C# application:

```dotnetcli
dotnet new console --output sample1
dotnet run --project sample1
```

You should see the following output:

```console
Hello World!
```

Congratulations! You've created a simple .NET Core application. You can also use [Visual Studio Code](./tutorials/with-visual-studio-code.md), [Visual Studio](./tutorials/with-visual-studio.md) (Windows only), or [Visual Studio for Mac](tutorials/with-visual-studio-mac.md) (macOS only), to create a .NET Core application.

## Tutorials

Get started developing .NET Core applications by following these step-by-step tutorials:

<!-- markdownlint-disable MD025 -->

# [Windows](#tab/windows)

- [Create your first .NET Core console application in Visual Studio 2019](./tutorials/with-visual-studio.md)
- [Build a class library with .NET Standard in Visual Studio](./tutorials/library-with-visual-studio.md)
- [Tutorial: Create a .NET Core console app using Visual Studio Code](tutorials/with-visual-studio-code.md)

|   |   |
|---|---|
| ![movie camera icon for video](./media/video-icon.png "Watch a video") | Watch the [how to install and use Visual Studio Code and .NET Core](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core/) video on Channel 9. |
| ![movie camera icon for video](./media/video-icon.png "Watch a video") | Watch the [.NET Core 101](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oWoazjhXQzBKMrFuArxpW80) videos on YouTube. |

See the [.NET Core dependencies and requirements](install/dependencies.md?pivots=os-windows) article for a list of the supported Windows versions.

# [Linux](#tab/linux)

Get started developing .NET Core applications by following these step-by-step tutorials:

- [Tutorial: Create a .NET Core console app using Visual Studio Code](tutorials/with-visual-studio-code.md)

|   |   |
|---|---|
| ![movie camera icon for video](./media/video-icon.png "Watch a video") | Watch a video on [getting started with Visual Studio Code using C# and .NET Core on Ubuntu](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-Csharp-dotnet-Core-Ubuntu). |

See the [.NET Core dependencies and requirements](install/dependencies.md?pivots=os-linux) article for a list of the supported Linux distros and versions.

# [macOS](#tab/macos)

Get started developing .NET Core applications by following these step-by-step tutorials:

- [Tutorial: Create a .NET Core console application using Visual Studio Code](tutorials/with-visual-studio-code.md)
- [Tutorial: Create a .NET Core console application using Visual Studio for Mac](tutorials/with-visual-studio-mac.md)
- [Build a .NET Standard library on macOS using Visual Studio for Mac](tutorials/library-with-visual-studio-mac.md)

|   |   |
|---|---|
| ![movie camera icon for video](media/video-icon.png "Watch a video") | Watch a video on [getting started with Visual Studio Code using C# and .NET Core on macOS](https://channel9.msdn.com/Blogs/dotnet/Get-started-VSCode-NET-Core-Mac). |

See the [.NET Core dependencies and requirements](install/dependencies.md?pivots=os-macos) article for a list of the supported OS X / macOS versions.

---
