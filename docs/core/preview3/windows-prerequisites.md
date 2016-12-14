---
title: .NET Core Prerequisites (Preview 3 Tooling)
description: .NET Core Prerequisites (Preview 3 Tooling)
keywords: .NET, .NET Core
author: billwagner
ms.author: wiwagn
ms.date: 09/15/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
---

# Prerequisites for Windows development (Preview 3 Tooling)

.NET Core development on Windows with Visual Studio requires:

* A supported version of the Windows client or operating system.
* Visual Studio 2017 RC or later
* .NET Core Tooling Preview 3

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

You may develop .NET Core apps with any editor using the .NET Core command-line tools, but if you want to use Visual Studio and the Preview 3 of the .NET Core tooling, you need Visual Studio 2017 RC or later. You can download [Visual Studio Community 2017 RC](https://www.visualstudio.com/vs/visual-studio-2017-rc/) for free. 

Verify that you're running Visual Studio 2017 RC:

* On the **Help** menu, choose **About Microsoft Visual Studio**.
* In the **About Microsoft Visual Studio** dialog, the version number should be 15.0.25831.1 or higher.

You can read more about the changes in Visual Studio 2017 RC in the [release notes](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes).

Make sure you installed the ".NET Core and Docker (Preview)" workload during setup. If you didn't, it's possible to run the setup again and select it.
