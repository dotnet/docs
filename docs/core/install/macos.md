---
title: Install .NET on macOS
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on macOS.
author: adegeo
ms.author: adegeo
ms.date: 05/14/2024
ms.custom: linux-related-content
---

# Install .NET on macOS

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

In this article, you learn how to install .NET on macOS. .NET is made up of the runtime and the SDK. The runtime is used to run a .NET app and might or might not be included with the app. The SDK is used to create .NET apps and libraries. The .NET runtime is always installed with the SDK.

The latest version of .NET is 8.

> [!div class="button"]
> [Download .NET](https://dotnet.microsoft.com/download/dotnet)

## Supported releases

There are two types of supported releases: Long Term Support (LTS) releases and Standard Term Support (STS) releases. The quality of all releases is the same. The only difference is the length of support. LTS releases get free support and patches for three years. STS releases get free support and patches for 18 months. For more information, see [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

The following table is a list of currently supported .NET releases and the versions of macOS they're supported on:

| Operating System       | .NET 8 (LTS) | .NET 6 (LTS) |
|------------------------|--------------|--------------|
| macOS 14.0 "Sonoma"    | ✔️ 8.0       | ✔️ 6.0        |
| macOS 13.0 "Ventura"   | ✔️ 8.0       | ✔️ 6.0        |
| macOS 12.0 "Monterey"  | ✔️ 8.0       | ✔️ 6.0        |
| macOS 11.0 "Big Sur"   | ❌           | ✔️ 6.0        |
| macOS 10.15 "Catalina" | ❌           | ✔️ 6.0        |

For a full list of .NET versions and their support life cycle, see [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## Unsupported releases

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

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

## Notarization

Beginning with macOS Catalina (version 10.15), all software built after June 1, 2019 that's distributed with Developer ID must be notarized. This requirement applies to the .NET runtime, .NET SDK, and software created with .NET.

The runtime and SDK installers for .NET have been notarized since February 18, 2020. Prior released versions aren't notarized. If you run a non-notarized app, you'll see an error similar to the following image:

![macOS Catalina notarization alert](media/dependencies/macos-notarized-pkg-warning.png)

For more information about how enforced-notarization affects .NET (and your .NET apps), see [Working with macOS Catalina Notarization](macos-notarization-issues.md).

## libgdiplus

.NET applications that use the *System.Drawing.Common* assembly require libgdiplus to be installed.

An easy way to obtain libgdiplus is by using the [Homebrew ("brew")](https://brew.sh/) package manager for macOS. After installing *brew*, install libgdiplus by executing the following commands at a Terminal (command) prompt:

```console
brew update
brew install mono-libgdiplus
```

## Automated install

macOS has standalone installers that can be used to install .NET:

- ✔️ [.NET 8 downloads](https://dotnet.microsoft.com/download/dotnet/8.0)
- ✔️ [.NET 6 downloads](https://dotnet.microsoft.com/download/dotnet/6.0)

## Manual install

<!-- Note, this content is taken from linux-scripted-manual.md but changed for macOS. Any fixes should be applied there too, though content may be different -->

As an alternative to the macOS installers for .NET, you can download and manually install the SDK and runtime. Manual installation is usually performed as part of continuous integration testing. For a developer or user, it's generally better to use an [installer](https://dotnet.microsoft.com/download/dotnet).

Download a **binary** release for either the SDK or the runtime from one of the following sites. The .NET SDK includes the corresponding runtime:

- ✔️ [.NET 8 downloads](https://dotnet.microsoft.com/download/dotnet/8.0)
- ✔️ [.NET 6 downloads](https://dotnet.microsoft.com/download/dotnet/6.0)
- [All .NET downloads](https://dotnet.microsoft.com/download/dotnet)

Extract the downloaded file and use the `export` command to set `DOTNET_ROOT` to the extracted folder's location and then ensure .NET is in PATH. Exporting `DOTNET_ROOT` makes the .NET CLI commands available in the terminal. For more information about .NET environment variables, see [.NET SDK and CLI environment variables](../tools/dotnet-environment-variables.md#net-sdk-and-cli-environment-variables).

Different versions of .NET can be extracted to the same folder, which coexist side-by-side.

### Example

The following commands use Bash to set the environment variable `DOTNET_ROOT` to the current working directory followed by `.dotnet`. That directory is created if it doesn't exist. The `DOTNET_FILE` environment variable is the filename of the .NET binary release you want to install. This file is extracted to the `DOTNET_ROOT` directory. Both the `DOTNET_ROOT` directory and its `tools` subdirectory are added to the `PATH` environment variable.

> [!IMPORTANT]
> If you run these commands, remember to change the `DOTNET_FILE` value to the name of the .NET binary you downloaded.

```bash
DOTNET_FILE=dotnet-sdk-8.0.100-osx-x64.tar.gz
export DOTNET_ROOT=$(pwd)/.dotnet

mkdir -p "$DOTNET_ROOT" && tar zxf "$DOTNET_FILE" -C "$DOTNET_ROOT"

export PATH=$PATH:$DOTNET_ROOT
```

You can install more than one version of .NET in the same folder.

You can also install .NET to the home directory identified by the `HOME` variable or `~` path:

```bash
export DOTNET_ROOT=$HOME/.dotnet
```

## Verify downloaded binaries

[!INCLUDE [verify-download-intro](includes/verify-download-intro.md)]

[!INCLUDE [verify-download-macos-linux](includes/verify-download-macos-linux.md)]

## Set environment variables system-wide

If you used the instructions in the [Manual install example](#example) section, the variables set only apply to your current terminal session. Add them to your shell profile. There are many different shells available for macOS and each has a different profile. For example:

- **Bash Shell**: *~/.profile*, */etc/profile*
- **Korn Shell**: *~/.kshrc* or *.profile*
- **Z Shell**: *~/.zshrc* or *.zprofile*

Set the following two environment variables in your shell profile:

- `DOTNET_ROOT`

  This variable is set to the folder .NET was installed to, such as `$HOME/.dotnet`:

  ```bash
  export DOTNET_ROOT=$HOME/.dotnet
  ```

- `PATH`

  This variable should include both the `DOTNET_ROOT` folder and the `DOTNET_ROOT/tools` folder:

  ```bash
  export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
  ```

## Arm-based Macs

The following sections describe things you should consider when installing .NET on an Arm-based Mac.

<!-- This section is mirrored in the windows.md file. Changes here should be applied there -->

### What's supported

The following table describes which versions of .NET are supported on an Arm-based Mac:

| .NET Version | SDK | Runtime | [Path conflict](#path-conflicts) |
|--------------|-----|---------|----------------------------------|
| 8            | Yes | Yes     | No                               |
| 8            | Yes | Yes     | No                               |
| 6            | Yes | Yes     | No                               |
| 6            | Yes | Yes     | No                               |

The x64 and Arm64 versions of the .NET SDK exist independently from each other. If a new version is released, each install needs to be upgraded.

### Path differences

On an Arm-based Mac, all Arm64 versions of .NET are installed to the normal _/usr/local/share/dotnet/_ folder. However, when you install the **x64** version of .NET SDK, it's installed to the _/usr/local/share/dotnet/x64/dotnet/_ folder.

### Path conflicts

The **x64** .NET SDK installs to its own directory, as described in the previous section. This allows the Arm64 and x64 versions of the .NET SDK to exist on the same machine. However, any **x64** SDK prior to .NET 6 isn't supported and installs to the same location as the Arm64 version, the _/usr/local/share/dotnet/_ folder. If you want to install an unsupported x64 SDK, you need to first uninstall the Arm64 version. The opposite is also true, you need to uninstall the unsupported x64 SDK to install the Arm64 version.

### Path variables

Environment variables that add .NET to system path, such as the `PATH` variable, might need to be changed if you have both the x64 and Arm64 versions of the .NET 6 SDK installed. Additionally, some tools rely on the `DOTNET_ROOT` environment variable, which would also need to be updated to point to the appropriate .NET 6 SDK installation folder.

## Install with Visual Studio for Mac

Visual Studio for Mac installs the .NET SDK when the **.NET** workload is selected. To get started with .NET development on macOS, see [Install Visual Studio 2022 for Mac](/visualstudio/mac/installation).

> [!IMPORTANT]
> Visual Studio for Mac is being retired. For more information, see [What's happening to Visual Studio for Mac?](/visualstudio/mac/what-happened-to-vs-for-mac?view=vsmac-2022&preserve-view=true).

| .NET SDK version      | Visual Studio version                                                               |
| --------------------- | ----------------------------------------------------------------------------------- |
| 8.0                   | Visual Studio 2022 for Mac 17.6.1 or higher. (Available as a preview feature only.) |
| 6.0                   | Visual Studio 2022 for Mac 17.0 or higher.                                          |

:::image type="content" source="media/install-sdk/mac-install-selection.png" alt-text="macOS Visual Studio 2022 for Mac with the .NET workload selected." lightbox="media/install-sdk/mac-install-selection.png":::

[!INCLUDE [](~/includes/vs-mac-eol.md)]

## Install alongside Visual Studio Code

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. Visual Studio Code is available for Windows, macOS, and Linux.

While Visual Studio Code doesn't come with an automated .NET installer like Visual Studio does, adding .NET support is simple.

01. [Download and install Visual Studio Code](https://code.visualstudio.com/Download).
01. [Download and install the .NET SDK](https://dotnet.microsoft.com/download/dotnet).
01. [Install the C# extension from the Visual Studio Code marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

## Install with bash automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the runtime. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET 8. You can choose a specific release by specifying the `channel` switch. Include the `runtime` switch to install a runtime. Otherwise, the script installs the SDK.

The following command installs the ASP.NET Core runtime for maximum compatibility. The ASP.NET Core runtime also includes the standard .NET runtime.

```bash
./dotnet-install.sh --channel 8.0 --runtime aspnetcore
```

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

## Docker

Containers provide a lightweight way to isolate your application from the rest of the host system. Containers on the same machine share just the kernel and use resources given to your application.

.NET can run in a Docker container. Official .NET Docker images are published to the Microsoft Container Registry (MCR) and are discoverable at the [Microsoft .NET Docker Hub repository](https://hub.docker.com/_/microsoft-dotnet/).

Microsoft provides images that are tailored for specific scenarios. Each repository contains images for different combinations of the .NET (SDK or Runtime) and OS that you can use. For example, the [ASP.NET Core repository](https://hub.docker.com/_/microsoft-dotnet-aspnet) provides images that are built for running ASP.NET Core apps in production.

For more information about using .NET in a Docker container, see [Introduction to .NET and Docker](../docker/introduction.md) and [Samples](https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md).

## Next steps

- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-macos).
- [Working with macOS Catalina notarization](macos-notarization-issues.md).
- [Tutorial: Get started on macOS](../tutorials/with-visual-studio-mac.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).
