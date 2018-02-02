---
title: dotnet-install scripts
description: Learn about the dotnet-install scripts to install the .NET Core CLI tools and the shared runtime.
keywords: dotnet-install, dotnet-install scripts, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 09/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: b64e7e6f-ffb4-4fc8-b43b-5731c89479c2
ms.workload: 
  - dotnetcore
---

# dotnet-install scripts reference

## Name

`dotnet-install.ps1` | `dotnet-install.sh` - Script used to install the .NET Core CLI tools and the shared runtime.

## Synopsis

Windows:

`dotnet-install.ps1 [-Channel] [-Version] [-InstallDir] [-Architecture] [-SharedRuntime] [-DryRun] [-NoPath] [-AzureFeed] [-ProxyAddress] [--Verbose] [--Help]`

macOS/Linux:

`dotnet-install.sh [--channel] [--version] [--install-dir] [--architecture] [--shared-runtime] [--dry-run] [--no-path] [--azure-feed] [--verbose] [--help]`

## Description

The `dotnet-install` scripts are used to perform a non-admin installation of the .NET Core SDK, which includes the .NET Core CLI tools and the shared runtime.

We recommend that you use the stable version that is hosted on [.NET Core main website](https://dot.net). The direct paths to the scripts are:

* https://dot.net/v1/dotnet-install.sh (bash, UNIX)
* https://dot.net/v1/dotnet-install.ps1 (Powershell, Windows)

The main usefulness of these scripts is in automation scenarios and non-admin installations. There are two scripts: One is a PowerShell script that works on Windows. The other script is a bash script that works on Linux/macOS. Both scripts have the same behavior. The bash script also reads PowerShell switches, so you can use PowerShell switches with the script on Linux/macOS systems. 

The installation scripts download the ZIP/tarball file from the CLI build drops and proceed to install it in either the default location or in a location specified by `-InstallDir|--install-dir`. By default, the installation scripts download the SDK and install it. If you wish to only obtain the shared runtime, specify the `--shared-runtime` argument. 

By default, the script adds the install location to the $PATH for the current session. Override this default behavior by specifying the `--no-path` argument. 

Before running the script, install the required [dependencies](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md).

You can install a specific version using the `--version` argument. The version must be specified as a 3-part version (for example, 1.0.0-13232). If omitted, it uses the `latest` version.

## Options

`-Channel <CHANNEL>`

Specifies the source channel for the installation. The possible values are:

- `Current` - Current release
- `LTS` - Long-Term Support channel (current supported release)
- Two-part version in X.Y format representing a specific release (for example, `2.0` or `1.0`)
- Branch name [for example, `release/2.0.0`, `release/2.0.0-preview2`, or `master` for the latest from the `master` branch ("bleeding edge" nightly releases)]

The default value is `LTS`. For more information on .NET support channels, see the [.NET Core Support Lifecycle](https://www.microsoft.com/net/core/support) topic.

`-Version <VERSION>`

Represents a specific build version. The possible values are:

- `latest` - Latest build on the channel (used with the `-Channel` option)
- `coherent` - Latest coherent build on the channel; uses the latest stable package combination (used with Branch name `-Channel` options)
- Three-part version in X.Y.Z format representing a specific build version; supersedes the `-Channel` option. For example: `2.0.0-preview2-006120`

If omitted, `-Version` defaults to `latest`.

`-InstallDir <DIRECTORY>`

Specifies the installation path. The directory is created if it doesn't exist. The default value is *%LocalAppData%\.dotnet*. Note that binaries are placed directly in the directory.

`-Architecture <ARCHITECTURE>`

Architecture of the .NET Core binaries to install. Possible values are `auto`, `x64`, and `x86`. The default value is `auto`, which represents the currently running OS architecture.

`-SharedRuntime`

If set, this switch limits installation to the shared runtime. The entire SDK isn't installed.

`-DryRun`

If set, the script won't perform the installation; but instead, it displays what command line to use to consistently install the currently requested version of the .NET Core CLI. For example if you specify version `latest`, it displays a link with the specific version so that this command can be used deterministically in a build script. It also displays the binary's location if you prefer to install or download it yourself.

`-NoPath`

If set, the prefix/installdir are not exported to the path for the current session. By default, the script will modify the PATH, which makes the CLI tools available immediately after install.

`-AzureFeed`

Specifies the URL for the Azure feed to the installer. It isn't recommended that you change this value. The default is `https://dotnetcli.azureedge.net/dotnet`.

`-ProxyAddress`

If set, the installer uses the proxy when making web requests. (Only valid for Windows)

`--verbose`

Display diagnostics information.

`--help`

Prints out help for the script.

## Examples

Install the latest long-term supported (LTS) version to the default location:

Windows:

`./dotnet-install.ps1 -Channel LTS`

macOS/Linux:

`./dotnet-install.sh --channel LTS`

Install the latest version from 2.0 channel to the specified location:

Windows:

`./dotnet-install.ps1 -Channel 2.0 -InstallDir C:\cli`

macOS/Linux:

`./dotnet-install.sh --channel 2.0 --install-dir ~/cli`

Install the 1.1.0 version of the shared runtime:

Windows:

`./dotnet-install.ps1 -SharedRuntime -Version 1.1.0`

macOS/Linux:

`./dotnet-install.sh --shared-runtime --version 1.1.0`

Obtain script and install .NET Core CLI one-liner examples:

Windows:

`@powershell -NoProfile -ExecutionPolicy unrestricted -Command "&([scriptblock]::Create((Invoke-WebRequest -useb 'https://dot.net/v1/dotnet-install.ps1'))) <additional install-script args>"`

macOS/Linux:

`curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin <additional install-script args>`

## See also

[.NET Core releases](https://github.com/dotnet/core/releases)   
[.NET Core Runtime and SDK download archive](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md)
