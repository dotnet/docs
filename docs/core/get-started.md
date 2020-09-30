---
title: Get started with .NET
description: Create a Hello World app and find resources for learning how to build .NET applications on Windows, Linux, and macOS.
author: adegeo
ms.author: adegeo
ms.date: 09/29/2020
ms.custom: vs-dotnet
---
# Get started with .NET

This article tells you how to create and run a "Hello World!" app.

If you're unsure what .NET is, start with the [.NET introduction](introduction.md).

## Create an application

First, download and install the [.NET SDK](https://dotnet.microsoft.com/download) on your computer.

Next, open a terminal such as **PowerShell**, **Command Prompt**, or **bash**. Enter the following `dotnet` commands to create and run a C# application:

```dotnetcli
dotnet new console --output sample1
dotnet run --project sample1
```

You see the following output:

```output
Hello World!
```

Congratulations! You've created a simple .NET application.

You created two files: a code file named *Program.cs* and a project file named *sample1.csproj*:

***Program.cs***

```csharp
namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

**sample1.csproj**

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

</Project>
```

You can also use [Visual Studio Code](./tutorials/with-visual-studio-code.md), [Visual Studio](./tutorials/with-visual-studio.md) (Windows only), or [Visual Studio for Mac](tutorials/with-visual-studio-mac.md) (macOS only), to create a .NET Core application.

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

See the [.NET Core dependencies and requirements](./install/windows.md) article for a list of the supported Windows versions.

# [Linux](#tab/linux)

Get started developing .NET Core applications by following these step-by-step tutorials:

- [Tutorial: Create a .NET Core console app using Visual Studio Code](tutorials/with-visual-studio-code.md)

|   |   |
|---|---|
| ![movie camera icon for video](./media/video-icon.png "Watch a video") | Watch a video on [getting started with Visual Studio Code using C# and .NET Core on Ubuntu](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-Csharp-dotnet-Core-Ubuntu). |

See the [.NET Core dependencies and requirements](./install/linux.md) article for a list of the supported Linux distros and versions.

# [macOS](#tab/macos)

Get started developing .NET Core applications by following these step-by-step tutorials:

- [Tutorial: Create a .NET Core console application using Visual Studio Code](tutorials/with-visual-studio-code.md)
- [Tutorial: Create a .NET Core console application using Visual Studio for Mac](tutorials/with-visual-studio-mac.md)
- [Build a .NET Standard library on macOS using Visual Studio for Mac](tutorials/library-with-visual-studio-mac.md)

|   |   |
|---|---|
| ![movie camera icon for video](media/video-icon.png "Watch a video") | Watch a video on [getting started with Visual Studio Code using C# and .NET Core on macOS](https://channel9.msdn.com/Blogs/dotnet/Get-started-VSCode-NET-Core-Mac). |

See the [.NET Core dependencies and requirements](./install/macos.md) article for a list of the supported OS X / macOS versions.

---
