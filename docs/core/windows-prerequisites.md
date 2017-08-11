---
title: Prerequisites for .NET Core on Windows
description: Learn what dependencies you need on your Windows machine to develop and run .NET Core applications.
keywords: .NET Core, Windows, prerequisites, dependencies, Visual Studio
author: mairaw
ms.author: mairaw
ms.date: 08/09/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
---

# Prerequisites for .NET Core on Windows

This article shows the needed dependencies to develop .NET Core applications on Windows. The supported OS versions and dependencies that follow apply to the three ways of developing .NET Core apps on Windows:

* [Command line](tutorials/using-with-xplat-cli.md)
* [Visual Studio 2017](https://www.visualstudio.com/downloads/)
* [Visual Studio Code](https://code.visualstudio.com/)

# [.NET Core 2.x](#tab/netcore2x)
**.NET Core 2.x Supported Windows Versions**

.NET Core 2.x is supported on the following versions of Windows:

* Windows 7 SP1
* Windows 8.1
* Windows 10
* Windows Server 2008 R2 SP1 (Full Server, Server Core, or Nano Server)
* Windows Server 2012 SP1 (Full Server, Server Core, or Nano Server)
* Windows Server 2012 R2 (Full Server, Server Core, or Nano Server)
* Windows Server 2016 (Full Server, Server Core, or Nano Server)

See [Supported OS Versions](https://github.com/dotnet/core/blob/master/roadmap.md#supported-os-versions) for the complete list of supported operating systems.

**.NET Core 2.x Dependencies**

.NET Core 2.x requires the Visual C++ Redistributable when running on Windows versions earlier than Windows 10 and Windows Server 2016. This dependency is automatically installed by the .NET Core 2.x installer.

[Microsoft Visual C++ 2015 Redistributable Update 3](https://www.microsoft.com/en-us/download/details.aspx?id=52685) must be manually installed when:
   * Installing .NET Core 2.x with the [installer script](./tools/dotnet-install-script.md).
   * Deploying a self-contained .NET Core 2.x application.

> [!NOTE]
> <em>For Windows 7 and Windows Server 2008 machines only:</em><br>
> Make sure that your Windows installation is up-to-date and includes hotfix [KB2533623](https://support.microsoft.com/help/2533623) installed through Windows Update.
# [.NET Core 1.x](#tab/netcore1x)
**.NET Core 1.x Supported Windows Versions**

.NET Core 1.x is supported on the following versions of Windows:

* Windows 7 SP1
* Windows 8.1
* Windows 10
* Windows Server 2008 R2 SP1 (Full Server or Server Core)
* Windows Server 2012 SP1 (Full Server or Server Core)
* Windows Server 2012 R2 (Full Server or Server Core)
* Windows Server 2016 (Full Server, Server Core, or Nano Server)

See [Supported OS Versions](https://github.com/dotnet/core/blob/master/roadmap.md#supported-os-versions) for the complete list of supported operating systems.

**.NET Core 1.x Dependencies**

.NET Core 1.x requires the Visual C++ Redistributable when running on Windows versions earlier than Windows 10 and Windows Server 2016. This dependency is automatically installed by the .NET Core 1.x installer.

[Microsoft Visual C++ 2015 Redistributable Update 3](https://www.microsoft.com/en-us/download/details.aspx?id=52685) must be manually installed when:
   * Installing .NET Core 1.x with the [installer script](./tools/dotnet-install-script.md).
   * Deploying a self-contained .NET Core 1.x application.

> [!NOTE]
> <em>For Windows 7 and Windows Server 2008 machines only:</em><br>
> Make sure that your Windows installation is up-to-date and includes hotfix [KB2533623](https://support.microsoft.com/help/2533623) installed through Windows Update.
---
## Prerequisites with Visual Studio 2017 

You can use any editor to develop .NET Core applications using the .NET Core SDK.  [Visual Studio 2017](#visual-studio-2017) provides an integrated development environment for .NET Core apps on Windows.

You can read more about the changes in Visual Studio 2017 in the [release notes](https://www.visualstudio.com/news/releasenotes/vs2017-relnotes).
# [.NET Core 2.x](#tab/netcore2x)

To develop .NET Core 2.x apps in Visual Studio 2017:

 1. [Download and install Visual Studio 2017 version 15.0.26730.0 or higher](/visualstudio/install/install-visual-studio) with the **.NET Core cross-platform development** workload (in the **Other Toolsets** section) selected.
![Screenshot of Visual Studio 2017 installation with the ".NET Core cross-platform development" workload selected](./media/windows-prerequisites/vs-15-3-workloads.jpg)
>[!TIP]
  > To verify that you're running Visual Studio 2017 version 15.0.26730.0 or higher:
>
     > * On the **Help** menu, choose **About Microsoft Visual Studio**.
     > * In the **About Microsoft Visual Studio** dialog, verify the version number.

>[!NOTE]
>After the **.NET Core cross-platform development** toolset is installed, Visual Studio 2017 uses .NET Core 1.x by default. Install the .NET Core 2.x SDK to get .NET Core 2.x support in Visual Studio 2017.

 2. Install the [.NET Core 2.x SDK](https://www.microsoft.com/net/download/core).
 3. Retarget existing or new .NET Core 1.x projects to .NET Core 2.x using the following instructions:
   * On the **Project** menu, Choose **Properties**. 
   * In the **Target framework** selection menu, set the value to **.NET Core 2.0**.

![Screenshot of Visual Studio 2017 Application Project Property with the ".NET Core 2.0" Target framework menu item selected](./media/windows-prerequisites/Targeting-dotnetCore2.png)

Once the .NET Core 2.x SDK is installed, Visual Studio 2017 uses the .NET Core SDK 2.x, and supports the following actions:

  * Open, build, and run existing .NET Core 1.x projects.
  * Retarget .NET Core 1.x projects to .NET Core 2.x, build, and run.
  * Create new .NET Core 2.x projects.

# [.NET Core 1.x](#tab/netcore1x)
To develop .NET Core 1.x apps in Visual Studio, download and install Visual Studio 2017 version 15.0.26228.4 or higher](/visualstudio/install/install-visual-studio) with the **".NET Core cross-platform development"** workload (in the **Other Toolsets** section) selected.
![Screenshot of Visual Studio 2017 installation with the ".NET Core cross-platform development" workload selected](./media/windows-prerequisites/vs_workloads.jpg)
> [!TIP]
 > To verify that you're running Visual Studio 2017 version 15.0.26228.4 or higher:
>
     > * On the **Help** menu, choose **About Microsoft Visual Studio**.
     > * In the **About Microsoft Visual Studio** dialog, verify the version number.

> [!IMPORTANT]
> It's possible to use Visual Studio 2015 for .NET Core 1.x development, but it's not recommended for the following reasons:
  > * The .NET Core tooling is a preview version, which is not supported.
  > * The projects are project.json-based, which is deprecated.
>
> For more information about the project format changes, see [High-level overview of changes](./tools/cli-msbuild-architecture.md).

---