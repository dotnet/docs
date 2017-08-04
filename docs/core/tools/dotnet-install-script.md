---
title: dotnet-install scripts
description: Learn about the dotnet-install scripts to install the .NET Core CLI tools and the shared runtime. 
keywords: dotnet-install, dotnet-install scripts, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 07/10/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: b64e7e6f-ffb4-4fc8-b43b-5731c89479c2
---

# dotnet-install scripts reference

## Name

`dotnet-install.ps1` | `dotnet-install.sh` - Script used to install the .NET Core Command-line Interface (CLI) tools and the shared runtime.

## Synopsis

Windows:

`dotnet-install.ps1 [-Channel] [-Version] [-InstallDir] [-Architecture] [-SharedRuntime] [-DebugSymbols] [-DryRun] [-NoPath] [-AzureFeed] [-ProxyAddress]`

macOS/Linux:

`dotnet-install.sh [--channel] [--version] [--install-dir] [--architecture] [--shared-runtime] [--debug-symbols] [--dry-run] [--no-path] [--verbose] [--azure-feed] [--help]`

## Description

The `dotnet-install` scripts are used to perform a non-admin install of the CLI toolchain and the shared runtime. You can download the scripts from the [CLI GitHub repo](https://github.com/dotnet/cli/tree/rel/1.0.0/scripts/obtain). 

The main usefulness of these scripts is in automation scenarios and non-admin installations. There are two scripts: One is a PowerShell script that works on Windows. The other script is a bash script that works on Linux/OS X. Both scripts have the same behavior. The bash script also reads PowerShell switches, so you can use PowerShell switches with the script on Linux/OS X systems. 

The installation scripts download the ZIP/tarball file from the CLI build drops and proceed to install it in either the default location or in a location specified by `-InstallDir|--install-dir`. By default, the installation scripts download the SDK and install it. If you wish to only obtain the shared runtime, specify the `--shared-runtime` argument. 

By default, the script adds the install location to the $PATH for the current session. Override this default behavior by specifying the `--no-path` argument. 

Before running the script, install the required [dependencies](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md).

You can install a specific version using the `--version` argument. The version must be specified as a 3-part version (for example, 1.0.0-13232). If omitted, it defaults to the first [global.json](global-json.md) file found in the hierarchy above the folder where the script is invoked that contains the `version` property. If that isn't present, it will use the latest version.

You can also use this script to obtain the SDK or shared runtime debug binaries with debug symbols by using the `--debug` argument. If you fail to do this on first install and realize later that you need the debug symbols, you can re-run the script with the `--debug` argument and the SDK version you installed to obtain the debug symbols. 

## Options

Note: Options are different between script implementations. 

### PowerShell (Windows)

`-Channel <CHANNEL>`

Specifies the source channel for the installation. The possible values are:

- `Current` - Current release
- `LTS` - Long-Term Support channel (current supported release)
- Two-part version in X.Y format representing a specific release (for example, `2.0` or `1.0`)
- Branch name [for example, `release/2.0.0`, `release/2.0.0-preview2`, or `master` for the latest from the `master` branch ("bleeding edge" nightly releases)]

The default value is `LTS`. For more information on .NET support channels, see the [.NET Core Support Lifecycle](https://www.microsoft.com/net/core/support) topic.

`-Version <VERSION>`

Represents a build version on the source channel (see the `-Channel` option). The possible values are:

- `latest` - Latest build on the channel
- `coherent` - Latest coherent build on the channel; uses the latest stable package combination
- Three-part version in X.Y.Z format representing a specific build version (for example, `1.0.x` with `x` representing the patch version; or a specific build, such as `2.0.0-preview2-006120`)

If omitted, `-Version` defaults to the first [global.json](global-json.md) that contains the `version` member. If that isn't present, `-Version` defaults to `latest`.

`-InstallDir <DIRECTORY>`

Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\.dotnet*. Note that binaries are placed directly in the directory.

`-Architecture <ARCHITECTURE>`

Architecture of the .NET Core binaries to install. Possible values are `auto`, `x64`, and `x86`. The default value is `auto`, which represents the currently running OS architecture.

`-SharedRuntime`

If set, this switch limits installation to the shared runtime. The entire SDK isn't installed.

`-DebugSymbols` (see NOTE)

If set, the installer includes debugging symbols in the installation.

> [!NOTE]
> The `-DebugSymbols` switch is not currently avaiable but planned for a future release.

`-DryRun`

If set, the script won't perform the installation; but instead, it displays what command line to use to consistently install the currently requested version of the .NET Core CLI. For example if you specify version `latest`, it displays a link with the specific version so that this command can be used deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

`-NoPath`

If set, the prefix/installdir are not exported to the path for the current session. By default, the script will modify the PATH, which makes the CLI tools available immediately after install.

`-AzureFeed`

Specifies the URL for the Azure feed to the installer. It isn't recommended that you change this value. The default is `https://dotnetcli.azureedge.net/dotnet`.

`-ProxyAddress`

If set, the installer uses the proxy when making web requests.

### Bash (macOS/Linux)

`dotnet-install.sh [--channel] [--version] [--install-dir] [--architecture] [--shared-runtime] [--debug-symbols] [--dry-run] [--no-path] [--verbose] [--azure-feed] [--help]`

`-Channel <CHANNEL>`

Specifies the source channel for the installation. The possible values are:

- `Current` - Current release
- `LTS` - Long-Term Support channel (current supported release)
- Two-part version in X.Y format representing a specific release (for example, `2.0` or `1.0`)
- Branch name [for example, `release/2.0.0`, `release/2.0.0-preview2`, or `master` for the latest from the `master` branch ("bleeding edge" nightly releases)]

The default value is `LTS`. For more information on .NET support channels, see the [.NET Core Support Lifecycle](https://www.microsoft.com/net/core/support) topic.

`-Version <VERSION>`

Represents a build version on the source channel (see the `-Channel` option). The possible values are:

- `latest` - Latest build on the channel
- `coherent` - Latest coherent build on the channel; uses the latest stable package combination
- Three-part version in X.Y.Z format representing a specific build version (for example, `1.0.x` with `x` representing the patch version; or a specific build, such as `2.0.0-preview2-006120`)

If omitted, `-Version` defaults to the first [global.json](global-json.md) that contains the `version` member. If that isn't present, `-Version` defaults to `latest`.

`--install-dir <DIRECTORY>`

Specifies the installation path. The directory is created if it doesn't exist. The default value is `$HOME/.dotnet`.

`--architecture <ARCHITECTURE>`

Architecture of the .NET Core binaries to install. Possible values are `auto`, `x64` and `amd64`. The default value is `auto`, which represents the currently running OS architecture.

`--shared-runtime`

If set, this switch limits installation to the shared runtime. The entire SDK isn't installed.

`--debug-symbols`

If set, the installer includes debugging symbols in the installation.

> [!NOTE]
> This switch is not currently avaiable but planned for a future release.

`--dry-run`

If set, the script won't perform the installation; but instead, it displays what command line to use to consistently install the currently requested version of the .NET Core CLI. For example if you specify version `latest`, it displays a link with the specific version so that this command can be used deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

`--no-path`

If set, the prefix/installdir are not exported to the path for the current session. By default, the script will modify the PATH, which makes the CLI tools available immediately after install.

`--verbose`

Display diagnostics information.

`--azure-feed`

Specifies the URL for the Azure feed to the installer. It isn't recommended that you change this value. The default is `https://dotnetcli.azureedge.net/dotnet`.

`--help`

Prints out help for the script.

## Examples

Install the latest development version to the default location:

Windows:

`./dotnet-install.ps1 -Channel Future`

macOS/Linux:

`./dotnet-install.sh --channel Future`

Install the latest preview to the specified location:

Windows:

`./dotnet-install.ps1 -Channel preview -InstallDir C:\cli`

macOS/Linux:

`./dotnet-install.sh --channel preview --install-dir ~/cli`

## See also

[.NET Core releases](https://github.com/dotnet/core/releases)   
[.NET Core Runtime and SDK download archive](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md)
