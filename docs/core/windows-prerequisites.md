---
title: .NET Core Prerequisites
description: .NET Core Prerequisites
keywords: .NET, .NET Core
author: billwagner
ms.author: wiwagn
ms.date: 09/15/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
---

# Prerequisites for Windows development

.NET Core development on Windows with Visual Studio requires:

* A supported version of the Windows client or operating system.
* Visual Studio 2015 Update 3.3 or later
* NuGet Manager extension for Visual Studio
* .NET Core Tooling Preview 2

## Supported Windows versions

.NET Core is supported by the following versions of Windows:

* Windows 7 SP1
* Windows 8.1
* Windows 10
* Windows Server 2008 R2 SP1 (Full Server or Server Core)
* Windows Server 2012 SP1 (Full Server or Server Core)
* Windows Server 2012 R2 SP1 (Full Server or Server Core)
* Windows Server 2016 (Full Server, Server Core or Nano Server)

You can see the full set of [supported operating systems](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0.md#rtm-platform-support) in the [.NET Core Release Notes](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0.md).

## .NET Core dependencies

.NET Core requires the VC++ Redistributable when running on Windows. It is installed for you by the .NET Core installer. You need to install the Visual C++ redistributable manually if you are installing .NET Core via the installer script (`dotnet-install.ps1`). 

The Visual C++ Redistributable version differs by Windows version.

* Windows 10
    * [Visual C++ Redistributable for Visual Studio 2015](https://www.microsoft.com/en-us/download/details.aspx?id=48145)
* Windows 7+ (not Windows 10)
    * Please make sure that your Windows installation is up-to-date and includes hotfix [KB2533623](https://support.microsoft.com/en-us/kb/2533623) installed through Windows Update.
    * [Universal CRT update](https://www.microsoft.com/en-us/download/details.aspx?id=48234) (you can get more info on what Universal CRT is in [this blog post](https://blogs.msdn.microsoft.com/vcblog/2015/03/03/introducing-the-universal-crt/))

## Visual Studio

You need Visual Studio 2015 to develop .NET Core apps. You can download [Visual Studio Community 2015](https://www.visualstudio.com/downloads/download-visual-studio-vs) for free. 

Verify that you're running [Visual Studio 2015 Update 3.3](https://msdn.microsoft.com/library/mt752379.aspx):

* On the **Help** menu, choose **About Microsoft Visual Studio**.
* In the **About Microsoft Visual Studio** dialog, the version number should be 14.0.25424.00 or higher, and include "Update 3".
* If you don't have Update 3, you first need to download and install [Visual Studio 2015 Update 3](https://www.visualstudio.com/news/releasenotes/vs2015-update3-vs).
* If you have Update 3 but the version number is smaller than 14.0.25424.00, you need to download and install [Visual Studio 2015 Update 3.3](https://msdn.microsoft.com/library/mt752379.aspx).

You can read more about the changes in Update 3 in the [release notes](https://www.visualstudio.com/news/releasenotes/vs2015-update3-vs).

## NuGet Manager extension for Visual Studio

NuGet is the package manager for the Microsoft development platform including .NET Core. You need [NuGet 3.5.0](https://dist.nuget.org/visualstudio-2015-vsix/v3.5.0-beta/NuGet.Tools.vsix) or higher to build .NET Core apps.

## .NET Core tools for Visual Studio 2015

Download and install the [.NET Core 1.0.1 - VS 2015 Tooling Preview 2][sdk]. 

The .NET Core Tooling package installs .NET Core, project templates and other tools for Visual Studio 2015.

> [!NOTE]
Currently, you cannot download an offline installer for [.NET Core 1.0.1 - VS 2015 Tooling Preview 2][sdk]. Instead, you have to download the [regular bootstrapper][sdk] and run it with a command-line option (such as, `/layout c:\path`) to get an offline layout. After that, it can be used as an offline installer: just run the executable from the local path. Notice that because it's a full layout, this procedure downloads all the packages for all supported languages, which is around 1 GB in size.

[sdk]: https://go.microsoft.com/fwlink/?LinkID=827546
