---
title: .NET Core Pre-Requisites
description: .NET Core Pre-Requisites
keywords: .NET, .NET Core
author: billwagner
manager: wpickett
ms.date: 07/27/16
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
---

# Pre-Requisites for Windows Development

.NET Core development on Windows with Visual Studio requires:

* A supported version of the Windows client or operating system.
* Visual Studio 2015 Update 3.3 or later
* NuGet Manager extension for Visual Studio
* .NET Core Tooling Preview 2

## Checking your Operating System

Check the [.NET Core Release Notes](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0.md) for a list of supported Windows client and server operating systems.

## Visual Studio Update 3.3

If you don't have Visual Studio already, you can download [Visual Studio Community 2015](https://www.visualstudio.com/downloads/download-visual-studio-vs) for free. 

Verify that you're running [Visual Studio 2015 Update 3.3](https://www.visualstudio.com/news/releasenotes/vs2015-update3-vs):

* On the **Help** menu, choose **About Microsoft Visual Studio**.
* In the About Microsoft Visual Studio dialog, the version number should be 14.0.25424.00 or higher, and include "Update 3".
* If you have Update 3, you can update to 3.3 via in-product notification, or by downloading the update [directly](https://msdn.microsoft.com/en-us/library/mt752379.aspx).
* If you don't have Update 3, it's available from [the Visual Studio website](https://www.visualstudio.com/en-us/news/releasenotes/vs2015-update3-vs). Installing Update 3 will auto-update to 3.3 upon install.
* You can read more about the changes in Update 3.3 in the [release notes](https://www.visualstudio.com/en-us/news/releasenotes/vs2015-update3-vs).

## NuGet Manager extension for Visual Studio

NuGet is the package manager for the Microsoft development platform including .NET Core. When you use NuGet to install a package, it copies the library files to your solution and automatically updates your project (add references, change config files, etc.). Download and install it from the [NuGet website](https://dist.nuget.org/visualstudio-2015-vsix/v3.5.0-beta/NuGet.Tools.vsix).

## .NET Core Tooling Preview 2 for Visual Studio 2015

Download and install the [.NET Core Tooling Preview 2 for Visual Studio 2015](https://go.microsoft.com/fwlink/?LinkId=817245). 

This installs templates and other tools for Visual Studio 2015, as well as .NET Core 1.0 itself.

> note: If you already have Update 3.3, you may be blocked from installing due to a reported issue. To workaround it, add `SKIP_VSU_CHECK=1` to the command line when you run the installer.

