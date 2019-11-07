---
title: Install .NET Core SDK on Windows, Linux, and macOS
description: Learn how to install for .NET Core on Windows, Linux, and macOS. Discover the dependencies required to develop .NET Core apps.
author: leecow
ms.author: leecow
ms.date: 10/30/2019
zone_pivot_groups: operating-systems-set-one
---

## Install the .NET Core SDK

In this article you'll learn how to download and install the .NET Core SDK. The .NET Core SDK is used to create create .NET Core apps and libraries. The .NET Core runtime is always installed with the SDK.

Here are links to the .NET Core downloads page by version:

- [.NET Core 3.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.0).
- [.NET Core 2.2 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.2).
- [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1).

## Install with an IDE

When you install a supported IDE, you can also install .NET Core. By keeping the IDE up-to-date, you'll receive the latest supported .NET Core SDK.

::: zone pivot="os-windows"

- Download [Visual Studio](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2019)\
For more information, see [Visual Studio](#visual-studio).

- Download [Visual Studio Code](https://code.visualstudio.com/)\
For more information, see [Install with Visual Studio Code](#install-with-visual-studio-code).

::: zone-end

::: zone pivot="os-linux"

- Download [Visual Studio Code](https://code.visualstudio.com/)\
For more information, see [Install with Visual Studio Code](#install-with-visual-studio-code).

::: zone-end

::: zone pivot="os-macos"

- Download [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link)\
For more information, see [Install with Visual Studio for Mac](#install-with-visual-studio-for-mac).

- Download [Visual Studio Code](https://code.visualstudio.com/)\
For more information, see [Install with Visual Studio Code](#install-with-visual-studio-code).

::: zone-end

## Install with an installer

Both Windows and macOS have standalone installers which can be used to install the .NET Core SDK.

- Windows [x64 CPUs](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-3.0.100-windows-x64-installer) | [x32 CPUs](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-3.0.100-windows-x86-installer)
- macOS [x64 CPUs](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-3.0.100-macos-x64-installer)

::: zone pivot="os-linux"

## Install with a package manager

If you want to install .NET Core, either SDK or runtime, use the [Linux Package Manager](linux-package-manager-rhel7.md) page.

::: zone-end

::: zone pivot="os-windows"

## Visual Studio

If you're using Visual Studio to develop .NET Core apps, the following table describes the minimum required version of Visual Studio based on the target .NET Core runtime.

| .NET Core SDK version | Visual Studio version                      |
| --------------------- | ------------------------------------------ |
| 3.0                   | Visual Studio 2019 version 16.3 or higher. |
| 2.2                   | Visual Studio 2017 version 15.9 or higher. |
| 2.1                   | Visual Studio 2017 version 15.7 or higher. |

If you already have Visual Studio installed, you can check your version with the following steps.

01. Open Visual Studio.
01. Select the **Help** menu > **About Microsoft Visual Studio**.
01. Read the version number from the **About** dialog.

### Download

Visual Studio installs the latest .NET Core SDK and runtime, so you can target your app to run on the .NET Core runtime version of your choice.

- [Download Visual Studio](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2019).

Selecting any of the managed workloads for **Web**, **Desktop**, or **Azure development**, will install the .NET Core SDK development tools and runtime. Specifically choosing the **.NET Core** workload also installs .NET Core.

[![Windows Visual Studio 2019 with .NET Core workload](media/install-sdk/windows-install-visual-studio-2019.png)](media/install-sdk/windows-install-visual-studio-2019.png#lightbox)

After you've installed Visual Studio, create your first app by following the [C# Hello World tutorial](../tutorials/with-visual-studio.md) or the [Visual Basic Hello World tutorial](../tutorials/vb-with-visual-studio.md).

::: zone-end

::: zone pivot="os-macos"

## Install with Visual Studio for Mac

Visual Studio for Mac installs the .NET Core SDK when the **.NET Core workload** is selected. To get started with .NET Core development on macOS, see [Install Visual Studio 2019 for Mac](https://docs.microsoft.com/visualstudio/mac/installation?view=vsmac-2019).

[![macOS Visual Studio 2019 for Mac with .NET Core workload feature](media/install-sdk/mac-install-selection.png)](media/install-sdk/mac-install-selection.png#lightbox)

After you've installed Visual Studio for Mac, create your first app by following the [Get started on macOS](../tutorials/using-on-mac-vs.md) tutorial.

::: zone-end

## Install with Visual Studio Code

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. VS Code is available for Windows, macOS, and Linux.

While VS Code doesn't come with .NET Core support, adding .NET Core support is simple.

01. [Download and install Visual Studio Code](https://code.visualstudio.com/Download).
01. [Download and install the .NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0).
01. [Install the C# extension from the VS Code marketplace](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).

After you've installed .NET Core support for VS Code, create your first app by following the [Using .NET Core in Visual Studio Code](https://code.visualstudio.com/docs/languages/dotnet) tutorial.

::: zone pivot="os-windows"

## Install with PowerShell automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for a non-admin install of the CLI toolchain and the shared runtime. You can download the script from [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest "LTS" version, which is currently .NET Core 2.1. To install the current release of .NET Core (3.0), run the script with the following switch:

```powershell
dotnet-install.ps1 -Channel 3.0
```

The installer PowerShell script is used in automation scenarios and non-admin installations.

::: zone-end

::: zone pivot="os-linux,os-macos"

## Install with bash automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for a non-admin install of the CLI toolchain and the shared runtime. You can download the script from [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest "LTS" version, which is currently .NET Core 2.1. To install the current release of .NET Core, which is 3.0, run the script with the following switch:

```bash
./dotnet-install.sh -c Current
```

The installer bash script is used in automation scenarios and non-admin installations.

::: zone-end

## Docker

TODO

## Next steps

TODO