---
title: Install .NET Core SDK on Windows, Linux, and macOS - .NET Core
description: Learn how to install .NET Core on Windows, Linux, and macOS. Discover the dependencies required to develop .NET Core apps.
author: adegeo
ms.author: adegeo
ms.date: 05/04/2020
ms.custom: "updateeachrelease"
zone_pivot_groups: operating-systems-set-one
---

# Install the .NET Core SDK

In this article, you'll learn how to install the .NET Core SDK. The .NET Core SDK is used to create .NET Core apps and libraries. The .NET Core runtime is always installed with the SDK.

::: zone pivot="os-windows"

## Install with an installer

Windows has standalone installers that can be used to install the .NET Core 3.1 SDK:

- [x64 (64-bit) CPUs](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [x86 (32-bit) CPUs](https://dotnet.microsoft.com/download/dotnet-core/3.1)

::: zone-end

::: zone pivot="os-macos"

## Install with an installer

macOS has standalone installers that can be used to install the .NET Core 3.1 SDK:

- [x64 (64-bit) CPUs](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Download and manually install

As an alternative to the macOS installers for .NET Core, you can download and manually install the SDK.

To extract the SDK and make the .NET Core CLI commands available at the terminal, first [download](#all-net-core-downloads) a .NET Core binary release. Then, open a terminal and run the following commands. It's assumed the runtime is downloaded to the `~/Downloads/dotnet-sdk.pkg` file.

```bash
mkdir -p $HOME/dotnet
sudo installer -pkg ~/Downloads/dotnet-sdk.pkg -target $HOME/dotnet
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

::: zone-end

::: zone pivot="os-linux"

## Install on Linux

This article will be removed soon. It is currently replaced by [Install .NET Core on Linux](linux.md).

::: zone-end

::: zone pivot="os-windows"

## Install with Visual Studio

If you're using Visual Studio to develop .NET Core apps, the following table describes the minimum required version of Visual Studio based on the target .NET Core SDK version.

| .NET Core SDK version | Visual Studio version                      |
| --------------------- | ------------------------------------------ |
| 3.1                   | Visual Studio 2019 version 16.4 or higher. |
| 3.0                   | Visual Studio 2019 version 16.3 or higher. |
| 2.2                   | Visual Studio 2017 version 15.9 or higher. |
| 2.1                   | Visual Studio 2017 version 15.7 or higher. |

If you already have Visual Studio installed, you can check your version with the following steps.

01. Open Visual Studio.
01. Select **Help** > **About Microsoft Visual Studio**.
01. Read the version number from the **About** dialog.

Visual Studio can install the latest .NET Core SDK and runtime.

- [Download Visual Studio](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2019).

### Select a workload

When installing or modifying Visual Studio, select one or more of the following workloads, depending on the kind of application you're building:

- The **.NET Core cross-platform development** workload in the **Other Toolsets** section.
- The **ASP.NET and web development** workload in the **Web & Cloud** section.
- The **Azure development** workload in the **Web & Cloud** section.
- The **.NET desktop development** workload in the **Desktop & Mobile** section.

[![Windows Visual Studio 2019 with .NET Core workload](media/install-sdk/windows-install-visual-studio-2019.png)](media/install-sdk/windows-install-visual-studio-2019.png#lightbox)

## Download and manually install

To extract the runtime and make the .NET Core CLI commands available at the terminal, first [download](#all-net-core-downloads) a .NET Core binary release. Then, create a directory to install to, for example `%USERPROFILE%\dotnet`. Finally, extract the downloaded zip file into that directory.

By default, .NET Core CLI commands and apps won't use .NET Core installed in this way and you must explicitly choose to use it. To do so, change the environment variables with which an application is started:

```console
set DOTNET_ROOT=%USERPROFILE%\dotnet
set PATH=%USERPROFILE%\dotnet;%PATH%
```

This approach lets you install multiple versions into separate locations, then explicitly choose which install location an application should use by running the application with environment variables pointing at that location.

Even when these environment variables are set, .NET Core still considers the default global install location when selecting the best framework for running the application. The default is typically `C:\Program Files\dotnet`, which the installers use. You can instruct the runtime to only use the custom install location by setting this environment variable as well:

```console
set DOTNET_MULTILEVEL_LOOKUP=0
```

::: zone-end

::: zone pivot="os-macos"

## Install with Visual Studio for Mac

Visual Studio for Mac installs the .NET Core SDK when the **.NET Core** workload is selected. To get started with .NET Core development on macOS, see [Install Visual Studio 2019 for Mac](/visualstudio/mac/installation). For the latest release, .NET Core 3.1, you must use the Visual Studio for Mac 8.4 Preview.

[![macOS Visual Studio 2019 for Mac with .NET Core workload feature](media/install-sdk/mac-install-selection.png)](media/install-sdk/mac-install-selection.png#lightbox)

::: zone-end

::: zone pivot="os-windows,os-macos"

## Install alongside Visual Studio Code

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. Visual Studio Code is available for Windows, macOS, and Linux.

While Visual Studio Code doesn't come with an automated .NET Core installer like Visual Studio does, adding .NET Core support is simple.

01. [Download and install Visual Studio Code](https://code.visualstudio.com/Download).
01. [Download and install the .NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core).
01. [Install the C# extension from the Visual Studio Code marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

::: zone-end

::: zone pivot="os-windows"

## Install with PowerShell automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the SDK. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. To install the current release of .NET Core, run the script with the following switch.

```powershell
dotnet-install.ps1 -Channel Current
```

::: zone-end

::: zone pivot="os-macos"

## Install with bash automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the SDK. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. To install the current release of .NET Core, run the script with the following switch.

```bash
./dotnet-install.sh -c Current
```

::: zone-end

## All .NET Core downloads

You can download and install .NET Core directly with one of the following links:

- [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [.NET Core 3.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.0)
- [.NET Core 2.2 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1)

## Docker

Containers provide a lightweight way to isolate your application from the rest of the host system. Containers on the same machine share just the kernel and use resources given to your application.

.NET Core can run in a Docker container. Official .NET Core Docker images are published to the Microsoft Container Registry (MCR) and are discoverable at the [Microsoft .NET Core Docker Hub repository](https://hub.docker.com/_/microsoft-dotnet-core/). Each repository contains images for different combinations of the .NET (SDK or Runtime) and OS that you can use.

Microsoft provides images that are tailored for specific scenarios. For example, the [ASP.NET Core repository](https://hub.docker.com/_/microsoft-dotnet-core-aspnet/) provides images that are built for running ASP.NET Core apps in production.

For more information about using .NET Core in a Docker container, see [Introduction to .NET and Docker](../docker/introduction.md) and [Samples](https://github.com/dotnet/dotnet-docker/blob/master/samples/README.md).

## Next steps

::: zone pivot="os-windows"

- [Tutorial: Hello World tutorial](../tutorials/with-visual-studio.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET Core app](../docker/build-container.md).

::: zone-end

::: zone pivot="os-macos"

- [Working with macOS Catalina notarization](macos-notarization-issues.md).
- [Tutorial: Get started on macOS](../tutorials/using-on-mac-vs.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET Core app](../docker/build-container.md).

::: zone-end

::: zone pivot="os-linux"

- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET Core app](../docker/build-container.md).

::: zone-end
