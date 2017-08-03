---
title: What's new in .NET Core 2.0
description: A description of the new feature found in .NET Core 2.0.
keywords: .NET, .NET Core
author: rpetrusha
ms.author: ronpet
ms.date: 08/07/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
---
# What's new in .NET Core 2.0

.NET Core 2.0 includes enhancements and new features in the following areas:

- [Tooling](#tooling)
- [Language support](#language-support)
- [Platform improvements](#platform-improvements)
- [API changes](#api-changes)
- [Visual Studio integration](#visual-studio-integration)
- [Documentation improvements](#documentation-improvements) 

## Tooling

**`dotnet restore` runs implicitly**

In previous versions of the .NET Core, you had to run the [dotnet restore](../tools/dotnet-restore.md) command to download dependencies immediately after you created a new project with the [dotnet new](../tools/dotnet-new) command, as well as whenever you added a new dependency to your project. In .NET Core 2.0, `dotnet restore` runs implicitly when the `dotnet new` command executes, as well as if dependencies need to be updated when the `run`, `build`, and `publish` commands execute.

## Language support

In addition to supporting C# and F#, .NET Core 2.0 also supports Visual Basic.

**Visual Basic**

With version 2.0, .NET Core now supports Visual Basic 2017. For example, to create a simple Visual Basic "hello world" application, do the following from the command line:

1. Open a console window, create a directory for your project and make it the current directory.

1. Enter the command `dotnet new console -lang vb`.

   This creates a project file with a `.csproj` file extension, along with a Visual Basic source code file named `program.vb`. This file contains the source code to write the string "Hello World!" to the console window.
  
1.  Enter the command `dotnet run`. The [.NET Core CLI tools](../tools/) automatically compile and execute the application, which displays the message "Hello World!" in the console window.

Visual Studio Preview 15.3 also includes templates for Visual Basic that let you create .NET Core console apps, class libraries, unit test projects, and xUnit test projects.

**Support for C# 7.1**

.NET Core 2.0 supports C# 7.1, which adds a number of new features, including:

- The `Main` method, the application entry point, can be marked with the [async](../../csharp/language-reference/keywords/async.md) keyword.
- Inferred tuple names.
- Default expressions.
- Pattern matching with generics. 

<!-- For more information see [link to C# what's new](url). -->

## Platform improvements

.NET Core 2.0 includes a number of features that make it easier and less cumbersome to install .NET Core and to use it on supported operating systems.

**.NET Core for Linux is a single implementation**

.NET Core 2.0 offers a single Linux implementation that works on multiple Linux distributions. .NET Core 1.x required that yu download a distribution-specific Linux implementation.

You can also develop apps that target Linux as a single operating system. .NET Core 1.x required that you target each Linux distribution separately. 

**Support for the Apple cryptographic libraries**

.NET Core 1.x on macOS required the OpenSSL toolkit's cryptographic library. .NET Core 2.0 uses the Apple cryptographic libraries and does not require OpenSSL. 

## API changes and library support

**Support for the .NET Standard 2.0**

The .NET Standard defines a versioned set of APIs that must be available on .NET implementations that comply with that version of the standard. The .NET Standard is targeted at library developers and aims to guarantee the functionality that is available to a library that targets a versionof the .NET Standard on each .NET implementation. .NET Core 1.x supports the .NET Standard version 1.6; .NET Core 2.0 supports the latest version, .NET Standard 2.0.  See [.NET Standard](../standard/net-standard.md) for more information on the .NET Standard.

The .NET Standard 2.0 includes over 20,000 more APIs than were available in the .NET Standard 1.6. Much of this expanded surface area results from incorporating APIs that are common to the .NET Framework and Xamarin into .NET Standard.

.NET Standard 2.0 class libraries also can reference .NET Framework class libraries, provided that they call APIs that are present in the .NET Standard 2.0. No recompilation of the .NET Framework libraries is required.

**Expanded surface area**

The total number of APIs available on .NET Core 2.0 has more than doubled in comparison with .NET Core 1.1. 

**Support for .NET Framework libraries**

.NET Core code can reference existing .NET Framework libraries, including existing NuGet packages. Note that the libraries must use APIs that are found in .NET Standard.

## Visual Studio integration

Visual Studio 2017 Preview 15.3 and in some cases Visual Studio for Mac offer a number of significant enhancements for .NET Core developers.

**Retargeting to .NET Core 2.0**

If the .NET Core 2.0 SDK is installed, projects that target .NET Core 1.x can be retargeted to .NET Core 2.0. To do this, you open the **Application** tab of the project's properties dialog and change the **Target framework** value to **.NET Core 2.0**. You can also change it by editing your project file and changing the value of the `<TargetFrame>` element from 1.x to 2.0:

```xml
<PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
 </PropertyGroup>
```

**Live Unit Testing support for .NET Core**

Whenever you modify your code, Live Unit Testing automatically runs any affected unit tests in the background and displays the results and code coverage live in the Visual Studio environment. .NET Core 2.0 now supports Live Unit Testing. Previously, Live Unit Testing was available only for .NET Framework applications. 

For more information, see [Live Unit Testing with Visual Studio 2017](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing) and the [Live Unit Testing FAQ](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing-faq).

**Better support for multiple target frameworks**

If you are building a project for multiple target frameworks, you can now select the target platform from the top-level menu. In the following figure, a project named SCD1 targets 64-bit Mac OS X 10.11 (`osx.10.11-x64`) and 64-bit Windows 10/Windows Server 2016 (`win10-x64`). You can select the target framework before selecting the project button, in this case to run a debug build.

![Selecting the target framework when building a project](multitarget.png) 

**Side-by-side support for .NET Core SDKs**

You can now install the .NET Core SDK independently of Visual Studio. This makes it possible for a single version of Visual Studio to build projects that target different versions of .NET Core. Before Visual Studio 2017 Preview 15.3, Visual Studio and the .NET Core SDK were tightly coupled; a particular version of the SDK accompanied a particular version of Visual Studio.

## Documentation improvements

**.NET Core 2.0 and .NET Standard 2.0 API documentation**

API documentation for [.NET Core 2.0](https://docs.microsoft.com/en-us/dotnet/api/?view=netcore-2.0) and [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/api/?view=netstandard-2.0) is available from **docs.microsoft.com**.

**.NET Application Architecture**

[.NET Application Architecture](https://www.microsoft.com/net/learn/architecture) gives you access to a set of eBooks that provide guidance, best practices, and sample applications when using .NET to build:

- Microservices and Docker containers.
- Web applications with ASP.NET.
- Mobile applications with Xamarin.
- Applications that are deployed to the Cloud with Azure.

 



