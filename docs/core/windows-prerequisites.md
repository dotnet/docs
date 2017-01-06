---
title: Prerequisites for .NET Core on Windows | Microsoft Docs
description: Learn what dependencies you need on your Windows machine to develop and run .NET Core applications.
keywords: .NET Core, Windows, prerequisites, dependencies, Visual Studio
author: mairaw
ms.author: mairaw
ms.date: 01/05/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
---

# Prerequisites for .NET Core on Windows

This articles shows you what dependencies you need to deploy and run .NET Core applications on Windows machines and develop using Visual Studio.

## Supported Windows versions

.NET Core is supported on the following versions of Windows:

* Windows 7 SP1
* Windows 8.1
* Windows 10
* Windows Server 2008 R2 SP1 (Full Server or Server Core)
* Windows Server 2012 SP1 (Full Server or Server Core)
* Windows Server 2012 R2 SP1 (Full Server or Server Core)
* Windows Server 2016 (Full Server, Server Core or Nano Server)

You can see the full set of [supported operating systems](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0.md#rtm-platform-support) in the [.NET Core 1.0.0 Release Notes](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0.md).

## .NET Core dependencies

.NET Core requires the Visual C++ Redistributable when running on Windows versions earlier than Windows 10 and Windows Server 2016. This dependency is automatically installed for you if you use the .NET Core installer. However, you need to manually install the [Visual C++ Redistributable for Visual Studio 2015](https://www.microsoft.com/en-us/download/details.aspx?id=48145) if you are installing .NET Core via the [installer script](https://docs.microsoft.com/en-us/dotnet/articles/core/tools/dotnet-install-script) or deploying a self-contained .NET Core application.

> [!NOTE]
> <em>For Windows 7 and Windows Server 2008 machines only:</em><br>
> Make sure that your Windows installation is up-to-date and includes hotfix [KB2533623](https://support.microsoft.com/en-us/kb/2533623) installed through Windows Update.

## Prerequisites with Visual Studio

You can use any editor of your choice to develop .NET Core applications using the .NET Core SDK. However, if you want to develop .NET Core applications on Windows using Visual Studio, there are two versions you can use:

* [Visual Studio 2015](#visual-studio-2015)
* [Visual Studio 2017 RC](#visual-studio-2017-rc)

Projects created with Visual Studio 2015 will be project.json-based by default while projects created with Visual Studio 2017 RC will always be MSBuild-based. For more information about the format changes, see [High-level overview of changes](./preview3/tools/layering.md).

### Visual Studio 2015

If you want to use Visual Studio 2015 to develop .NET Core apps, you'll need:

* Visual Studio 2015 Update 3.3 or later.

   There are different [editions](https://www.visualstudio.com/vs/compare) of Visual Studio 2015. You can download [Visual Studio Community 2015](https://www.visualstudio.com/downloads/) for free to get started. 

   To verify that you're running [Visual Studio 2015 Update 3.3](https://msdn.microsoft.com/library/mt752379.aspx), do the following:

   * On the **Help** menu, choose **About Microsoft Visual Studio**.
   * In the **About Microsoft Visual Studio** dialog, the version number should be 14.0.25424.00 or higher, and include "Update 3".
   * If you don't have Update 3, you first need to download and install [Visual Studio 2015 Update 3](https://www.visualstudio.com/news/releasenotes/vs2015-update3-vs).
   * If you have Update 3 but the version number is smaller than 14.0.25424.00, you need to download and install [Visual Studio 2015 Update 3.3](https://msdn.microsoft.com/library/mt752379.aspx).

   You can read more about the changes in Update 3 in the [release notes](https://www.visualstudio.com/news/releasenotes/vs2015-update3-vs).

* NuGet Manager extension for Visual Studio

   NuGet is the package manager for the Microsoft development platform including .NET Core. You need [NuGet 3.5.0-beta](https://dist.nuget.org/visualstudio-2015-vsix/v3.5.0-beta/NuGet.Tools.vsix) or higher to build .NET Core apps.

* .NET Core Tooling Preview 2

   Download and install the [.NET Core 1.0.1 - VS 2015 Tooling Preview 2][sdk]. 

   The .NET Core Tooling package installs .NET Core, project templates and other tools for Visual Studio 2015.

   > [!NOTE]
   > Currently, you cannot download an offline installer for [.NET Core 1.0.1 - VS 2015 Tooling Preview 2][sdk]. Instead, you have to download the [regular bootstrapper][sdk] and run it with a command-line option (such as, `/layout c:\path`) to get an offline layout. After that, it can be used as an offline installer: just run the executable from the local path. Notice that because it's a full layout, this procedure downloads all the packages for all supported languages, which is around 1 GB in size.

### Visual Studio 2017 RC

If you want to use Visual Studio 2017 RC to develop .NET Core apps, you'll need to have the latest version of Visual Studio RC installed with the ".NET Core and Docker (Preview)" workload selected. 

There are different editions of Visual Studio 2017 RC. You can download [Visual Studio Community 2017 RC](https://www.visualstudio.com/vs/visual-studio-2017-rc/#downloadvs) for free to get started.  To learn more about the Visual Studio installation process, see [Install Visual Studio 2017 RC](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio).

To verify that you're running the latest version of Visual Studio 2017 RC, do the following:

* On the **Help** menu, choose **About Microsoft Visual Studio**.
* In the **About Microsoft Visual Studio** dialog, the version number should be 15.0.26020.0 or higher.

You can read more about the changes in Visual Studio 2017 RC in the [release notes](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes).

[sdk]: https://go.microsoft.com/fwlink/?LinkID=827546
