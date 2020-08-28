---
title: Install .NET Core on macOS
description: Learn about what versions of macOS you can install .NET Core on.
author: adegeo
ms.author: adegeo
ms.date: 06/25/2020
---

# Install .NET Core on macOS

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

In this article, you'll learn how to install .NET Core on macOS. .NET Core is made up of the runtime and the SDK. The runtime is used to run a .NET Core app and may or may not be included with the app. The SDK is used to create .NET Core apps and libraries. The .NET Core runtime is always installed with the SDK.

The latest version of .NET Core is 3.1.

> [!div class="button"]
> [Download .NET Core](https://dotnet.microsoft.com/download/dotnet-core)

## Supported releases

The following table is a list of currently supported .NET Core releases and the versions of macOS they're supported on. These versions remain supported either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

- A ✔️ indicates that the version of .NET Core is still supported.
- A ❌ indicates that the version of .NET Core isn't supported.

| Operating System          | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview |
|---------------------------|---------------|---------------|----------------|
| macOS 10.15 "Catalina"    | ✔️ 2.1 ([Release notes][release-notes-21]) | ✔️ 3.1 ([Release notes][release-notes-31]) | ✔️ 5.0 Preview ([Release notes][release-notes-50]) |
| macOS 10.14 "Mojave"      | ✔️ 2.1 ([Release notes][release-notes-21]) | ✔️ 3.1 ([Release notes][release-notes-31]) | ✔️ 5.0 Preview ([Release notes][release-notes-50]) |
| macOS 10.13 "High Sierra" | ✔️ 2.1 ([Release notes][release-notes-21]) | ✔️ 3.1 ([Release notes][release-notes-31]) | ✔️ 5.0 Preview ([Release notes][release-notes-50]) |
| macOS 10.12 "Sierra"      | ✔️ 2.1 ([Release notes][release-notes-21]) | ❌ 3.1 ([Release notes][release-notes-31]) | ❌ 5.0 Preview ([Release notes][release-notes-50]) |

## Unsupported releases

The following versions of .NET Core are ❌ no longer supported. The downloads for these still remain published:

- 3.0 ([Release notes][release-notes-30])
- 2.2 ([Release notes][release-notes-22])
- 2.0 ([Release notes][release-notes-20])

## Runtime information

The runtime is used to run apps created with .NET Core. When an app author publishes an app, they can include the runtime with their app. If they don't include the runtime, it's up to the user to install the runtime.

There are three different runtimes you can install on macOS:

*ASP.NET Core runtime*\
Runs ASP.NET Core apps. Includes the .NET Core runtime.

*.NET Core runtime*\
This runtime is the simplest runtime and doesn't include any other runtime. It's highly recommended that you install *ASP.NET Core runtime* for the best compatibility with .NET Core apps.

> [!div class="button"]
> [Download .NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core)

## SDK information

The SDK is used to build and publish .NET Core apps and libraries. Installing the SDK includes both [runtimes](#runtime-information): ASP.NET Core and .NET Core.

> [!div class="button"]
> [Download .NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core)

## Dependencies

.NET Core is supported on the following macOS releases:

> [!NOTE]
> A `+` symbol represents the minimum version.

| .NET Core Version | macOS                 | Architectures |     |
| ----------------- | --------------------- | --------------| --- |
| 3.1               | High Sierra (10.13+)  | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/3.1/3.1-supported-os.md) |
| 3.0               | High Sierra (10.13+)  | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md) |
| 2.2               | Sierra (10.12+)       | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md) |
| 2.1               | Sierra (10.12+)       | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md) |

Beginning with macOS Catalina (version 10.15), all software built after June 1, 2019 that is distributed with Developer ID, must be notarized. This requirement applies to the .NET Core runtime, .NET Core SDK, and software created with .NET Core.

The installers for .NET Core (both runtime and SDK) versions 3.1, 3.0, and 2.1, have been notarized since February 18, 2020. Prior released versions aren't notarized. If you run a non-notarized app, you'll see an error similar to the following image:

![macOS Catalina notarization alert](media/dependencies/macos-notarized-pkg-warning.png)

For more information about how enforced-notarization affects .NET Core (and your .NET Core apps), see [Working with macOS Catalina Notarization](macos-notarization-issues.md).

## libgdiplus

.NET Core applications that use the *System.Drawing.Common* assembly require libgdiplus to be installed.

An easy way to obtain libgdiplus is by using the [Homebrew ("brew")](https://brew.sh/) package manager for macOS. After installing *brew*, install libgdiplus by executing the following commands at a Terminal (command) prompt:

```console
brew update
brew install mono-libgdiplus
```

## Install with an installer

macOS has standalone installers that can be used to install the .NET Core 3.1 SDK:

- [x64 (64-bit) CPUs](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Download and manually install

<!-- Note, this content is taken from includes/linux-install-manual.md but changed for macOS. Any fixes should be applied there too, though content may be different -->

As an alternative to the macOS installers for .NET Core, you can download and manually install the SDK and runtime. Manual install is usually performed as part of continuous integration testing. For a developer or user, it's generally better to use an [installer](https://dotnet.microsoft.com/download/dotnet-core).

If you install .NET Core SDK, you don't need to install the corresponding runtime. First, download a **binary** release for either the SDK or the runtime from one of the following sites:

- ✔️ [.NET 5.0 preview downloads](https://dotnet.microsoft.com/download/dotnet/5.0)
- ✔️ [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- ✔️ [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1)
- [All .NET Core downloads](https://dotnet.microsoft.com/download/dotnet-core)

Next, extract the downloaded file and use the `export` command to set variables used by .NET Core and then ensure .NET Core is in PATH.

To extract the runtime and make the .NET Core CLI commands available at the terminal, first download a .NET Core binary release. Then, open a terminal and run the following commands from the directory where the file was saved. The archive file name may be different depending on what you downloaded.

**Use the following command to extract the runtime**:

```bash
mkdir -p "$HOME/dotnet" && tar zxf aspnetcore-runtime-3.1.5-osx-x64.tar.gz -C "$HOME/dotnet"
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

**Use the following command to extract the SDK**:

```bash
mkdir -p "$HOME/dotnet" && tar zxf dotnet-sdk-3.1.301-osx-x64.tar.gz -C "$HOME/dotnet"
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

## Install with Visual Studio for Mac

Visual Studio for Mac installs the .NET Core SDK when the **.NET Core** workload is selected. To get started with .NET Core development on macOS, see [Install Visual Studio 2019 for Mac](/visualstudio/mac/installation). For the latest release, .NET Core 3.1, you must use the Visual Studio for Mac 8.4.

[![macOS Visual Studio 2019 for Mac with .NET Core workload feature](media/install-sdk/mac-install-selection.png)](media/install-sdk/mac-install-selection.png#lightbox)

## Install alongside Visual Studio Code

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. Visual Studio Code is available for Windows, macOS, and Linux.

While Visual Studio Code doesn't come with an automated .NET Core installer like Visual Studio does, adding .NET Core support is simple.

01. [Download and install Visual Studio Code](https://code.visualstudio.com/Download).
01. [Download and install the .NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core).
01. [Install the C# extension from the Visual Studio Code marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

## Install with bash automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the runtime. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. You can choose a specific release by specifying the `current` switch. Include the `runtime` switch to install a runtime. Otherwise, the script installs the [SDK](sdk.md).

```bash
./dotnet-install.sh --channel 3.1 --runtime aspnetcore
```

> [!NOTE]
> The command above installs the ASP.NET Core runtime for maximum compatability. The ASP.NET Core runtime also includes the standard .NET Core runtime.

## Docker

Containers provide a lightweight way to isolate your application from the rest of the host system. Containers on the same machine share just the kernel and use resources given to your application.

.NET Core can run in a Docker container. Official .NET Core Docker images are published to the Microsoft Container Registry (MCR) and are discoverable at the [Microsoft .NET Core Docker Hub repository](https://hub.docker.com/_/microsoft-dotnet-core/). Each repository contains images for different combinations of the .NET (SDK or Runtime) and OS that you can use.

Microsoft provides images that are tailored for specific scenarios. For example, the [ASP.NET Core repository](https://hub.docker.com/_/microsoft-dotnet-core-aspnet/) provides images that are built for running ASP.NET Core apps in production.

For more information about using .NET Core in a Docker container, see [Introduction to .NET and Docker](../docker/introduction.md) and [Samples](https://github.com/dotnet/dotnet-docker/blob/master/samples/README.md).

## Next steps

- [How to check if .NET Core is already installed](how-to-detect-installed-versions.md?pivots=os-macos).
- [Working with macOS Catalina notarization](macos-notarization-issues.md).
- [Tutorial: Get started on macOS](../tutorials/with-visual-studio-mac.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET Core app](../docker/build-container.md).

[release-notes-21]: https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md
[release-notes-31]: https://github.com/dotnet/core/blob/master/release-notes/3.1/3.1-supported-os.md
[release-notes-50]: https://github.com/dotnet/core/blob/master/release-notes/5.0/5.0-supported-os.md
[release-notes-20]: https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md
[release-notes-22]: https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md
[release-notes-30]: https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md
