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

## Prerequisites with Visual Studio 2017

You can use any editor of your choice to develop .NET Core applications using the .NET Core SDK. However, if you want to develop .NET Core applications on Windows in an integrated development environment, you can use [Visual Studio 2017](#visual-studio-2017).

To use Visual Studio 2017 to develop .NET Core apps, you'll need to have the latest version of Visual Studio installed with the **.NET Core cross-platform development** toolset (in the **Other Toolsets** section) selected.

There are different editions of Visual Studio 2017. You can download [Visual Studio Community 2017](https://www.visualstudio.com/vs/visual-studio-2017/#downloadvs) for free to get started.  To learn more about the Visual Studio installation process, see [Install Visual Studio 2017](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio).

You can read more about the changes in Visual Studio 2017 in the [release notes](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes).

[sdk]: https://go.microsoft.com/fwlink/?LinkID=827546