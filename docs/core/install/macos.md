---
title: Install .NET on macOS
description: Learn about what versions of macOS you can install .NET on.
author: adegeo
ms.author: adegeo
ms.date: 11/10/2020
---

# Install .NET on macOS

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

In this article, you'll learn how to install .NET on macOS. .NET is made up of the runtime and the SDK. The runtime is used to run a .NET app and may or may not be included with the app. The SDK is used to create .NET apps and libraries. The .NET runtime is always installed with the SDK.

The latest version of .NET is 5.0.

> [!div class="button"]
> [Download .NET Core](https://dotnet.microsoft.com/download/dotnet)

## Supported releases

The following table is a list of currently supported .NET releases and the versions of macOS they're supported on. These versions remain supported until the version of .NET reaches [end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

- A ✔️ indicates that the version of .NET Core is still supported.
- A ❌ indicates that the version of .NET Core isn't supported.

| Operating System          | .NET Core 2.1 | .NET Core 3.1 | .NET 5.0 |
|---------------------------|---------------|---------------|----------------|
| macOS 11.0 "Big Sur"        | ✔️ 2.1 ([Release notes][release-notes-21]) | ✔️ 3.1 ([Release notes][release-notes-31]) | ✔️ 5.0 ([Release notes][release-notes-50]) |
| macOS 10.15 "Catalina"    | ✔️ 2.1 ([Release notes][release-notes-21]) | ✔️ 3.1 ([Release notes][release-notes-31]) | ✔️ 5.0 ([Release notes][release-notes-50]) |
| macOS 10.14 "Mojave"      | ✔️ 2.1 ([Release notes][release-notes-21]) | ✔️ 3.1 ([Release notes][release-notes-31]) | ✔️ 5.0 ([Release notes][release-notes-50]) |
| macOS 10.13 "High Sierra" | ✔️ 2.1 ([Release notes][release-notes-21]) | ✔️ 3.1 ([Release notes][release-notes-31]) | ✔️ 5.0 ([Release notes][release-notes-50]) |
| macOS 10.12 "Sierra"      | ✔️ 2.1 ([Release notes][release-notes-21]) | ❌ 3.1 ([Release notes][release-notes-31]) | ❌ 5.0 ([Release notes][release-notes-50]) |

## Unsupported releases

The following versions of .NET are ❌ no longer supported. The downloads for these still remain published:

- 3.0 ([Release notes][release-notes-30])
- 2.2 ([Release notes][release-notes-22])
- 2.0 ([Release notes][release-notes-20])

## Runtime information

The runtime is used to run apps created with .NET. When an app author publishes an app, they can include the runtime with their app. If they don't include the runtime, it's up to the user to install the runtime.

There are two different runtimes you can install on macOS:

- *ASP.NET Core runtime*\
  Runs ASP.NET Core apps. Includes the .NET runtime.

- *.NET runtime*\
  This runtime is the simplest runtime and doesn't include any other runtime. It's highly recommended that you install *ASP.NET Core runtime* for the best compatibility with .NET apps.

> [!div class="button"]
> [Download .NET Runtime](https://dotnet.microsoft.com/download/dotnet)

## SDK information

The SDK is used to build and publish .NET apps and libraries. Installing the SDK includes both [runtimes](#runtime-information): ASP.NET Core and .NET.

## Dependencies

.NET is supported on the following macOS releases:

> [!NOTE]
> A `+` symbol represents the minimum version.

| .NET Core Version | macOS                 | Architectures | More information    |
| ----------------- | --------------------- | --------------| --- |
| 5.0               | High Sierra (10.13+)  | x64 | [More information](https://github.com/dotnet/core/blob/main/release-notes/5.0/5.0-supported-os.md) |
| 3.1               | High Sierra (10.13+)  | x64 | [More information](https://github.com/dotnet/core/blob/main/release-notes/3.1/3.1-supported-os.md) |
| 3.0               | High Sierra (10.13+)  | x64 | [More information](https://github.com/dotnet/core/blob/main/release-notes/3.0/3.0-supported-os.md) |
| 2.2               | Sierra (10.12+)       | x64 | [More information](https://github.com/dotnet/core/blob/main/release-notes/2.2/2.2-supported-os.md) |
| 2.1               | Sierra (10.12+)       | x64 | [More information](https://github.com/dotnet/core/blob/main/release-notes/2.1/2.1-supported-os.md) |

Beginning with macOS Catalina (version 10.15), all software built after June 1, 2019 that is distributed with Developer ID, must be notarized. This requirement applies to the .NET runtime, .NET SDK, and software created with .NET.

The runtime and SDK installers for .NET 5.0 and .NET Core 3.1, 3.0, and 2.1, have been notarized since February 18, 2020. Prior released versions aren't notarized. If you run a non-notarized app, you'll see an error similar to the following image:

![macOS Catalina notarization alert](media/dependencies/macos-notarized-pkg-warning.png)

For more information about how enforced-notarization affects .NET (and your .NET apps), see [Working with macOS Catalina Notarization](macos-notarization-issues.md).

## libgdiplus

.NET applications that use the *System.Drawing.Common* assembly require libgdiplus to be installed.

An easy way to obtain libgdiplus is by using the [Homebrew ("brew")](https://brew.sh/) package manager for macOS. After installing *brew*, install libgdiplus by executing the following commands at a Terminal (command) prompt:

```console
brew update
brew install mono-libgdiplus
```

## Install with an installer

macOS has standalone installers that can be used to install the .NET 5.0 SDK:

- [x64 (64-bit) CPUs](https://dotnet.microsoft.com/download/dotnet/5.0)

## Download and manually install

<!-- Note, this content is taken from includes/linux-install-manual.md but changed for macOS. Any fixes should be applied there too, though content may be different -->

As an alternative to the macOS installers for .NET, you can download and manually install the SDK and runtime. Manual installation is usually performed as part of continuous integration testing. For a developer or user, it's generally better to use an [installer](https://dotnet.microsoft.com/download/dotnet).

First, download a **binary** release for either the SDK or the runtime from one of the following sites. If you install the .NET SDK, you will not need to install the corresponding runtime:

- ✔️ [.NET 5.0 downloads](https://dotnet.microsoft.com/download/dotnet/5.0)
- ✔️ [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet/3.1)
- ✔️ [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet/2.1)
- [All .NET Core downloads](https://dotnet.microsoft.com/download/dotnet)

Next, extract the downloaded file and use the `export` command to set `DOTNET_ROOT` to the extracted folder's location and then ensure .NET is in PATH. This should make the .NET CLI commands available at the terminal.

Alternatively, after downloading the .NET binary, the following commands may be run from the directory where the file is saved to extract the runtime. This will also make the .NET CLI commands available at the terminal and set the required environment variables. **Remember to change the `DOTNET_FILE` value to the name of the downloaded binary**:

```bash
DOTNET_FILE=dotnet-sdk-5.0.302-osx-x64.tar.gz
export DOTNET_ROOT=$(pwd)/dotnet

mkdir -p "$DOTNET_ROOT" && tar zxf "$DOTNET_FILE" -C "$DOTNET_ROOT"

export PATH=$PATH:$DOTNET_ROOT
```

> [!TIP]
> The preceding `export` commands only make the .NET CLI commands available for the terminal session in which it was run.
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

Visual Studio for Mac installs the .NET SDK when the **.NET** workload is selected. To get started with .NET development on macOS, see [Install Visual Studio 2019 for Mac](/visualstudio/mac/installation).

| .NET SDK version      | Visual Studio version                      |
| --------------------- | ------------------------------------------ |
| 5.0                   | Visual Studio 2019 for Mac version 8.8 or higher. |
| 3.1                   | Visual Studio 2019 for Mac version 8.4 or higher. |
| 2.1                   | Visual Studio 2019 for Mac version 8.0 or higher. |

[![macOS Visual Studio 2019 for Mac with .NET workload feature](media/install-sdk/mac-install-selection.png)](media/install-sdk/mac-install-selection.png#lightbox)

## Install alongside Visual Studio Code

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. Visual Studio Code is available for Windows, macOS, and Linux.

While Visual Studio Code doesn't come with an automated .NET installer like Visual Studio does, adding .NET support is simple.

01. [Download and install Visual Studio Code](https://code.visualstudio.com/Download).
01. [Download and install the .NET SDK](https://dotnet.microsoft.com/download/dotnet).
01. [Install the C# extension from the Visual Studio Code marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

## Install with bash automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the runtime. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. You can choose a specific release by specifying the `current` switch. Include the `runtime` switch to install a runtime. Otherwise, the script installs the [SDK](./windows.md).

```bash
./dotnet-install.sh --channel 5.0 --runtime aspnetcore
```

> [!NOTE]
> The previous command installs the ASP.NET Core runtime for maximum compatability. The ASP.NET Core runtime also includes the standard .NET runtime.

## Docker

Containers provide a lightweight way to isolate your application from the rest of the host system. Containers on the same machine share just the kernel and use resources given to your application.

.NET can run in a Docker container. Official .NET Docker images are published to the Microsoft Container Registry (MCR) and are discoverable at the [Microsoft .NET Core Docker Hub repository](https://hub.docker.com/_/microsoft-dotnet/). Each repository contains images for different combinations of the .NET (SDK or Runtime) and OS that you can use.

Microsoft provides images that are tailored for specific scenarios. For example, the [ASP.NET Core repository](https://hub.docker.com/_/microsoft-dotnet-aspnet) provides images that are built for running ASP.NET Core apps in production.

For more information about using .NET Core in a Docker container, see [Introduction to .NET and Docker](../docker/introduction.md) and [Samples](https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md).

## Next steps

- [How to check if .NET Core is already installed](how-to-detect-installed-versions.md?pivots=os-macos).
- [Working with macOS Catalina notarization](macos-notarization-issues.md).
- [Tutorial: Get started on macOS](../tutorials/with-visual-studio-mac.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET Core app](../docker/build-container.md).

[release-notes-21]: https://github.com/dotnet/core/blob/main/release-notes/2.1/2.1-supported-os.md
[release-notes-31]: https://github.com/dotnet/core/blob/main/release-notes/3.1/3.1-supported-os.md
[release-notes-50]: https://github.com/dotnet/core/blob/main/release-notes/5.0/5.0-supported-os.md
[release-notes-20]: https://github.com/dotnet/core/blob/main/release-notes/2.0/2.0-supported-os.md
[release-notes-22]: https://github.com/dotnet/core/blob/main/release-notes/2.2/2.2-supported-os.md
[release-notes-30]: https://github.com/dotnet/core/blob/main/release-notes/3.0/3.0-supported-os.md
