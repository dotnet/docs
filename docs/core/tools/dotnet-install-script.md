---
title: dotnet-install scripts (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: Learn about the dotnet-install scripts to install the .NET Core CLI tools and the shared runtime. 
keywords: dotnet-install, dotnet install script, dotnet-install scripts, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 07/10/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: b64e7e6f-ffb4-4fc8-b43b-5731c89479c2
---

# dotnet-install scripts (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet-install.ps1` | `dotnet-install.sh` - Script used to install the .NET Core Command-line Interface (CLI) tools and the shared runtime.

## Synopsis

Windows:

`dotnet-install.ps1 [-Architecture] [-AzureFeed] [-Channel] [-DryRun] [-InstallDir] [-NoPath] [-ProxyAddress] [-ProxyUseDefaultCredentials] [-SharedRuntime] [-UncachedFeed] [-Version]`

macOS/Linux:

`dotnet-install.sh [-arch|--architecture] [--azure-feed] [-c|--channel] [--debug-symbols] [--dry-run] [-h|--help] [-i|--install-dir] [--no-path] [--runtime-id] [--shared-runtime] [--uncached-feed] [--verbose] [-v|--version]`

## Description

The `dotnet-install` script is used to perform a non-admin install of the CLI toolchain and the shared runtime. Two scripts are available: One is a PowerShell script that works on Windows. The other script is a bash script that works on macOS/Linux. The bash script also reads PowerShell switches, so you can use PowerShell switches on macOS/Linux systems. Download the script for your platform from the [dotnet/cli GitHub repo](https://github.com/dotnet/cli/tree/release/2.0.0/scripts/obtain) (See NOTE). 

> [!NOTE>
> Install the required [dependencies](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md) before running the script.

The installation script downloads the SDK ZIP/tarball file from the CLI build outputs and installs the SDK in either the default location or in a location specified by `-InstallDir` (Windows) or `--install-dir` (macOS/Linux). If you wish to only install the shared runtime, specify the `--shared-runtime` option.

The script adds the install location to the PATH for the current session. Override the default behavior by specifying the `--no-path` option. 

Install a specific version using the `--version` option. Specify the version as a three-part version (for example, 1.0.0-13232). If omitted, it defaults to the first [global.json](global-json.md) file found in the hierarchy above the folder where the script is invoked that contains the `version` property. If that isn't present, it uses the latest version.

On macOS/Linux, obtain the SDK or shared runtime debug binaries with debug symbols by using the `--debug-symbols` option. If you fail to do this on first install and realize later that you need the debug symbols, re-run the script with the `--debug-symbols` option and the installed SDK version to obtain the debug symbols.

> [!NOTE]
> For the PowerShell (Windows) version of the script, obtaining the debug symbols using a `-DebugSymbols` switch isn't currently available but planned for a future release.

## Options

Options are different between script implementations. macOS/Linux users should refer to the [Bash (macOS/Linux) section](#bash-macoslinux), while Windows users should refer to the [PowerShell (Windows) section](#powershell-windows).

### Bash (macOS/Linux)

`dotnet-install.sh [-arch|--architecture] [--azure-feed] [-c|--channel] [--debug-symbols] [--dry-run] [-h|--help] [-i|--install-dir] [--no-path] [--runtime-id] [--shared-runtime] [--uncached-feed] [--verbose] [-v|--version]`

`-arch|--architecture <ARCHITECTURE>`

Specifies the architecture of the .NET Core binaries to install. Possible values are `auto`, `x64` and `amd64`. The default value is `auto`, which represents the currently running OS architecture.

`--azure-feed`

Indicates the URL for the Azure feed to the installer. We don't recommended that you change this value. The default is `https://dotnetcli.azureedge.net/dotnet`.

`-Channel <CHANNEL>`

Specifies the source channel for the installation. The possible values are:

- `Current` - Current release
- `LTS` - Long-Term Support channel (current supported release)
- Two-part version in X.Y format representing a specific release (for example, `2.0` or `1.0`)
- Branch name [for example, `release/2.0.0`, `release/2.0.0-preview2`, or `master` for the latest from the `master` branch ("bleeding edge" nightly releases)]

The default value is `LTS`. For more information on .NET support channels, see the [.NET Core Support Lifecycle](https://www.microsoft.com/net/core/support) topic.

`--debug-symbols`

If set, the installer includes debugging symbols in the installation.

`--dry-run`

If set, the script won't perform the installation. Instead, it displays the command-line command to use to consistently install the requested version of the CLI. For example if you specify version `latest`, it displays a link with the specific version, so you have a stable command to use in a build script. It also displays the binary's location if you prefer to install or download the binary yourself.

`-h|--help`

Shows help information.

`-i|--install-dir <DIRECTORY>`

Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\.dotnet*. Note that binaries are placed directly in the directory.

`--no-path`

If set, the prefix/installdir are not exported to the PATH for the current session. By default, the script modifies the PATH, which makes the CLI tools available immediately after install.

`--runtime-id <RUNTIME_IDENTIFIER>`

Installs the .NET tools for the given runtime.

> [!NOTE]
> For 64-bit portable Linux systems, use `linux-x64`.

`--shared-runtime`

If set, this option limits installation to the shared runtime. The entire SDK isn't installed.

`--uncached-feed <FEED>`

Allows you to change URL for the uncached feed used by the installer. It defaults to `https://dotnetcli.blob.core.windows.net/dotnet`. This parameter typically isn't changed by the user.

`-Version <VERSION>`

Represents a build version on the source channel (see the `-Channel` option). The possible values are:

- `latest` - Latest build on the channel
- `coherent` - Latest coherent build on the channel; uses the latest stable package combination
- Three-part version in X.Y.Z format representing a specific build version (for example, `1.0.x` with `x` representing the patch version; or a specific build, such as `2.0.0-preview2-006120`)

If omitted, `-Version` defaults to the first [global.json](global-json.md) that contains the `version` member. If that isn't present, `-Version` defaults to `latest`.

### PowerShell (Windows)

`dotnet-install.ps1 [-Architecture] [-AzureFeed] [-Channel] [-DryRun] [-InstallDir] [-NoPath] [-ProxyAddress] [-ProxyUseDefaultCredentials] [-SharedRuntime] [-UncachedFeed] [-Version]`

`-Architecture <ARCHITECTURE>`

Specifies the architecture of the .NET Core binaries to install. Possible values are `auto`, `x64`, and `x86`. The default value is `auto`, which represents the currently running OS architecture.

`-AzureFeed`

Indicates the URL for the Azure feed to the installer. It isn't recommended that you change this value. The default is `https://dotnetcli.azureedge.net/dotnet`.

`-Channel <CHANNEL>`

Specifies the source channel for the installation. The possible values are:

- `Current` - Current release
- `LTS` - Long-Term Support channel (current supported release)
- Two-part version in X.Y format representing a specific release (for example, `2.0` or `1.0`)
- Branch name [for example, `release/2.0.0`, `release/2.0.0-preview2`, or `master` for the latest from the `master` branch ("bleeding edge" nightly releases)]

The default value is `LTS`. For more information on .NET support channels, see the [.NET Core Support Lifecycle](https://www.microsoft.com/net/core/support) topic.

`-DryRun`

If set, the script won't perform the installation; but instead, it displays what command line to use to consistently install the currently requested version of the .NET CLI. For example if you specify version `latest`, it displays a link with the specific version, so you can use the command deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

`-InstallDir <DIRECTORY>`

Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\.dotnet*. Note that binaries are placed directly in the directory.

`-NoPath`

If set, the prefix/installdir are not exported to the path for the current session. By default, the script modifies the PATH, which makes the CLI tools available immediately after install.

`-ProxyAddress`

If set, the installer uses the proxy when making web requests.

`-ProxyUseDefaultCredentials`

Indicates that when using a proxy address to use default credentials. Defaults to `false`.

`-SharedRuntime`

If set, this option limits installation to the shared runtime. The entire SDK isn't installed.

`-UncachedFeed <FEED>`

Allows you to change URL for the uncached feed used by the installer. It defaults to `https://dotnetcli.blob.core.windows.net/dotnet`. This parameter typically isn't changed by the user.

`-Version <VERSION>`

Represents a build version on the source channel (see the `-Channel` option). The possible values are:

- `latest` - Latest build on the channel
- `coherent` - Latest coherent build on the channel; uses the latest stable package combination
- Three-part version in X.Y.Z format representing a specific build version (for example, `1.0.x` with `x` representing the patch version; or a specific build, such as `2.0.0-preview2-006120`)

If omitted, `-Version` defaults to the first [global.json](global-json.md) that contains the `version` member. If that isn't present, `-Version` defaults to `latest`.

## Examples

**Install the latest development version to the default location:**

Windows:

`./dotnet-install.ps1 -Channel Future`

macOS/Linux:

`./dotnet-install.sh --channel Future`

**Install the latest preview to the specified location:**

Windows:

`./dotnet-install.ps1 -Channel preview -InstallDir C:\cli`

macOS/Linux:

`./dotnet-install.sh --channel preview --install-dir ~/cli`

## See also

[.NET Core releases](https://github.com/dotnet/core/releases)   
[.NET Core Runtime and SDK download archive](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md)
