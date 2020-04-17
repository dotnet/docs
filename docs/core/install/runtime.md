---
title: Install .NET Core runtime on Windows, Linux, and macOS - .NET Core
description: Learn how to install .NET Core on Windows, Linux, and macOS. Discover the dependencies required to run .NET Core apps.
author: thraka
ms.author: adegeo
ms.date: 12/04/2019
ms.custom: "updateeachrelease"
zone_pivot_groups: operating-systems-set-one
---

# Install the .NET Core Runtime

In this article, you'll learn how to download and install the .NET Core runtime. The .NET Core runtime is used to run apps created with .NET Core.

::: zone pivot="os-windows"

## Install with an installer

Windows has standalone installers that can be used to install the .NET Core 3.1 runtime:

- [x64 (64-bit) CPUs](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [x86 (32-bit) CPUs](https://dotnet.microsoft.com/download/dotnet-core/3.1)

::: zone-end

::: zone pivot="os-macos"

## Install with an installer

macOS has standalone installers that can be used to install the .NET Core 3.1 runtime:

- [x64 (64-bit) CPUs](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Download and manually install

As an alternative to the macOS installers for .NET Core, you can download and manually install the runtime.

To install the runtime and enable the .NET Core CLI commands available at the terminal, first [download](#all-net-core-downloads) a .NET Core binary release. Then, open a terminal and run the following commands. It's assumed the runtime is downloaded to the `~/Downloads/dotnet-runtime.pkg` file.

```bash
mkdir -p $HOME/dotnet
sudo installer -pkg ~/Downloads/dotnet-runtime.pkg -target $HOME/dotnet
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

::: zone-end

::: zone pivot="os-linux"

## Install with a package manager

You can install the .NET Core Runtime with many of the common Linux package managers. For more information, see [Linux Package Manager - Install .NET Core](linux-package-managers.md).

Installing it with a package manager is only supported on the x64 architecture. If you're installing the .NET Core Runtime with a different architecture, such as ARM, follow the instructions on the [Download and manually install](#download-and-manually-install) section. For more information about what architectures are supported, see [.NET Core dependencies and requirements](dependencies.md).

## Download and manually install

To extract the runtime and make the .NET Core CLI commands available at the terminal, first [download](#all-net-core-downloads) a .NET Core binary release. Then, open a terminal and run the following commands.

```bash
mkdir -p $HOME/dotnet && tar zxf aspnetcore-runtime-3.1.0-linux-x64.tar.gz -C $HOME/dotnet
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

> [!TIP]
> The preceding `export` commands only make the .NET Core CLI commands available for the terminal session in which it was run.
>
> You can edit your shell profile to permanently add the commands. There are a number of different shells available for Linux and each has a different profile. For example:
>
> - **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
> - **Korn Shell**: *~/.kshrc* or *.profile*
> - **Z Shell**: *~/.zshrc* or *.zprofile*
>
> Edit the appropriate source file for your shell and add `:$HOME/dotnet` to the end of the existing `PATH` statement. If no `PATH` statement is included, add a new line with `export PATH=$PATH:$HOME/dotnet`.
>
> Also, add `export DOTNET_ROOT=$HOME/dotnet` to the end of the file.

This approach lets you install different versions into separate locations and choose explicitly which one to use by which application.

::: zone-end

::: zone pivot="os-windows"

## Install with PowerShell automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the runtime. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. You can choose a specific release by specifying the `Channel` switch. Include the `Runtime` switch to install a runtime. Otherwise, the script installs the [SDK](sdk.md).

```powershell
dotnet-install.ps1 -Channel 3.1 -Runtime aspnetcore
```

> [!NOTE]
> The command above installs the ASP.NET Core runtime for maximum compatability. The ASP.NET Core runtime also includes the standard .NET Core runtime.

## Download and manually install

To extract the runtime and make the .NET Core CLI commands available at the terminal, first [download](#all-net-core-downloads) a .NET Core binary release. Then, create a directory to install to, for example `%USERPROFILE%\dotnet`. Finally, extract the downloaded zip file into that directory.

By default, .NET Core CLI commands and apps will not use .NET Core installed in this way. You have to explicitly choose to use it. To do so, change the environment variables with which an application is started:

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

::: zone pivot="os-linux,os-macos"

## Install with bash automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the runtime. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. You can choose a specific release by specifying the `current` switch. Include the `runtime` switch to install a runtime. Otherwise, the script installs the [SDK](sdk.md).

```bash
./dotnet-install.sh --channel 3.1 --runtime aspnetcore
```

> [!NOTE]
> The command above installs the ASP.NET Core runtime for maximum compatability. The ASP.NET Core runtime also includes the standard .NET Core runtime.

::: zone-end

## All .NET Core downloads

You can download and install .NET Core directly with one of the following links:

- [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1)

## Docker

Containers provide a lightweight way to isolate your application from the rest of the host system. Containers on the same machine share just the kernel and use resources given to your application.

.NET Core can run in a Docker container. Official .NET Core Docker images are published to the Microsoft Container Registry (MCR) and are discoverable at the [Microsoft .NET Core Docker Hub repository](https://hub.docker.com/_/microsoft-dotnet-core/). Each repository contains images for different combinations of the .NET (SDK or Runtime) and OS that you can use.

Microsoft provides images that are tailored for specific scenarios. For example, the [ASP.NET Core repository](https://hub.docker.com/_/microsoft-dotnet-core-aspnet/) provides images that are built for running ASP.NET Core apps in production.

For more information about using .NET Core in a Docker container, see [Introduction to .NET and Docker](../docker/introduction.md) and [Samples](https://github.com/dotnet/dotnet-docker/blob/master/samples/README.md).

## Next steps

- [How to check if .NET Core is already installed](how-to-detect-installed-versions.md).
