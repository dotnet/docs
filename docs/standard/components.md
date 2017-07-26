---
title: .NET Architectural Components | Microsoft Docs
description: Describes .NET architectural components such as the .NET Standard, .NET implementations, and tooling.
>>>>>>> 75230c0be6... terminology
keywords: .NET, .NET Standard, .NET Standard, .NET Core, .NET Framework, Xamarin, MSBuild, C#, F#, VB, compilers
author: cartermp
ms.author: mairaw
ms.date: 11/16/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 2e38e9d9-8284-46ee-a15f-199adc4f26f4
---

# .NET Architectural Components

The .NET Standard is an API specification common to all implementations of .NET.  Implementations of .NET include the .NET Framework, .NET Core, and Mono for Xamarin. Each implementation of .NET includes the following components:

* One or more runtimes. Examples: CLR for .NET Framework, CoreCLR and CoreRT for .NET Core.
* A class library that implements the .NET Standard and may implement additional APIs. Examples: .NET Framework Base Class Library, .NET Core Base Class Library.
* Optionally, one or more application frameworks. Examples: ASP.NET, Windows Forms, and WPF are included in the .NET Framework.
* Optionally, development tools. Some development tools are shared among multiple implementations.

What follows is a brief explanation of the key components mentioned in this overview.  

## .NET Standard

The .NET Standard is a set of APIs which are implemented by the Base Class Library of a .NET implementation. More formally, it is a specification of .NET APIs which make up a uniform set of contracts that you compile your code against.  These contracts are implemented in each .NET implementation.  This enables portability across different .NET implementations, making it so that your code can effectively "run everywhere".

The .NET Standard is also a target framework. You can currently target .NET Standard 1.0-2.0. If your code targets a version of the .NET Standard, it is guaranteed to run on any .NET implementation which supports that version of .NET Standard.

To learn more about the .NET Standard and how to target it, see the [.NET Standard](net-standard.md) topic.

## .NET implementations

There are 3 primary .NET implementations which Microsoft actively develops and maintains: .NET Core, .NET Framework, and Mono for Xamarin.

### .NET Core

.NET Core is a cross-platform runtime optimized for server workloads.  It implements the .NET Standard, which means that any code that targets the .NET Standard can run on .NET Core.  It is the .NET implementation used by ASP.NET Core and the Universal Windows Platform (UWP).  It is modern, efficient, and designed to handle server and cloud workloads at scale.

To learn more about .NET Core, see the [.NET Core Guide](../core/index.md).

### .NET Framework

.NET Framework is the original .NET implementation that has existed since 2002.  It is the same .NET Framework that existing .NET developers have always used.  It implements the .NET Standard, which means that any code that targets the .NET Standard can run on the .NET Framework.  It contains additional Windows-specific APIs, such as APIs for Windows desktop development with Windows Forms and WPF. The .NET Framework is optimized for building Windows desktop applications.

To learn more about the .NET Framework, see the [.NET Framework Guide](../framework/index.md).

### Mono for Xamarin

Mono is the runtime used by Xamarin apps.  It implements the .NET Standard, which means that any code that targets the .NET Standard can run on Xamarin apps.  It contains additional APIs for iOS, Android, Xamarin.Forms, and Xamarin.Mac.  It is optimized for building mobile applications on iOS and Android.

To learn more about Mono, see the [Mono documentation](http://www.mono-project.com/docs/).

## .NET runtimes

A runtime is the execution environment for a managed program. The OS is part of the runtime environment but is not part of the .NET runtime. Here are some examples of .NET runtimes:
 
 - Common Language Runtime (CLR) for .NET Framework
 - Core Common Language Runtime (CoreCLR) for .NET Core
 - .NET Native for Universal Windows Platform 

## .NET tooling and common infrastructure

Some tooling for .NET is common across all implementations of .NET.  These include, but are not limited to:

- The .NET languages and their compilers
- .NET project system (sometimes known as "csproj", "vbproj", or "fsproj")
- MSBuild, the build engine used to build projects
- NuGet, Microsoft's package manager for .NET
- Open Source build orchestration tools, such as CAKE and FAKE

The main takeaway here should be that there is a vast amount of tooling and infrastructure which is common for any implementation of .NET you choose to build your apps with.

## Next Steps

To learn more, visit the following:

[.NET Standard](net-standard.md)  
[.NET Core Guide](../core/index.md)  
[.NET Framework Guide](../framework/index.md)  
[C# Guide](../csharp/index.md)  
[F# Guide](../fsharp/index.md)  
[VB.NET Guide](../visual-basic/index.md)  

