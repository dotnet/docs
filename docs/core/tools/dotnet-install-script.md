---
title: dotnet-install scripts | Microsoft Docs
description: Learn about the dotnet-install scripts to install the .NET Core CLI tools and the shared runtime. 
keywords: dotnet-install, dotnet-install scripts, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: b64e7e6f-ffb4-4fc8-b43b-5731c89479c2
---

#dotnet-install scripts reference

## Name

`dotnet-install.ps1` | `dotnet-install.sh` - script used to install the .NET Core Command-line Interface (CLI) tools and the shared runtime.

## Synopsis
Windows:

```
dotnet-install.ps1 [-Channel] [-Version] [-InstallDir] [-Architecture]
    [-SharedRuntime] [-DebugSymbols] [-DryRun] [-NoPath] [-AzureFeed] [-ProxyAddress]
```

macOS/Linux:

```
dotnet-install.sh [--channel] [--version] [--install-dir] [--architecture]
    [--shared-runtime] [--debug-symbols] [--dry-run] [--no-path] [--verbose] [--azure-feed] [--help]
```

## Description
The `dotnet-install` scripts are used to perform a non-admin install of the CLI toolchain and the shared runtime. You can download the scripts from our [CLI GitHub repo](https://github.com/dotnet/cli/tree/rel/1.0.0/scripts/obtain). 

Their main use case is to help with automation scenarios and non-admin installations. There are two scripts, one for PowerShell that works on Windows and a bash script that works on Linux/OS X. They both have the same behavior. Bash script also "understands" PowerShell switches so you can use them across the board. 

Installation scripts will download the ZIP/tarball file from the CLI build drops and will proceed to install it in either the default location or in a location specified by `--install-dir`. By default, the installation script 
will download the SDK and install it; if you want to get just the shared runtime, you can specify the `--shared-runtime` argument. 

By default, the script will add the install location to the $PATH for the current session. This can be overridden if the `--no-path` argument is used. 

Before running the script, please install all the required [dependencies](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md).

You can install a specific version using the `--version` argument. The version needs to be specified as 3-part version (for example, 1.0.0-13232). If omitted, it will default to the first [global.json](global-json.md) file found in the hierarchy above the folder where the script was invoked that contains the `version` property. If that is not present, it will use Latest.

You can also use this script to get the SDK or shared runtime debug binaries with debug symbols by using the `--debug` argument. If you do not do this on first install and realize you do need debug symbols later on, you can re-run the script with this argument and the version of the bits you installed. 

## Options
Options are different between script implementations. 

### PowerShell (Windows)
`-Channel [CHANNEL]`

Which channel (for example, `future`, `preview`, `production`) to install from. The default value is `production`.

`-Version [VERSION]`

Which version of CLI to install. You need to specify the version as a 3-part version (for example, 1.0.0-13232). If omitted, it will default to the first [global.json](global-json.md) that contains the `version` property. If that is not present, it will use Latest.

`-InstallDir [DIR]`

Path to install to. The directory is created if it doesn't exist. The default value is *%LocalAppData%\.dotnet*.

`-Architecture [ARCH]`

Architecture of the .NET Core binaries to be installed. Possible values are &lt;auto&gt;, x64 and x86. The default value is &lt;auto&gt;, which represents currently running OS architecture.

`-SharedRuntime`

If set, installs just the shared runtime bits, not the entire SDK.

`-DebugSymbols`

If set, the installer will include debugging symbols in the installation.

> [!NOTE]
> This switch does not work yet.

`-DryRun`

If set, the script won't perform the installation but instead it'll display what command line to use to consistently install currently requested version of .NET CLI. 
For example, if you specify version `latest`, it will display a link with specific version, so that this command can be used deterministically in a build script.
It also displays binaries location if you prefer to install or download it yourself.

`-NoPath`

If set, the prefix/installdir are not exported to the path for the current session. 
By default, the script will modify the PATH, which makes the CLI tools available immediately after install.

`-AzureFeed`

The URL for the Azure feed to be used by this installer. Not recommended to be changed. The default is `https://dotnetcli.azureedge.net/dotnet`.

`-ProxyAddress`

If set, the installer will use the proxy when making web requests.

### Bash (macOS/Linux)

`dotnet-install.sh [--channel] [--version] [--install-dir] [--architecture]
    [--shared-runtime] [--debug-symbols] [--dry-run] [--no-path] [--verbose] [--azure-feed] [--help]
`

`--channel [CHANNEL]`

Which channel (for example "future", "dev", "production") to install from. The default value is "Production".

`--version [VERSION]`

Which version of CLI to install. You need to specify the version as a 3-part version (for example, 1.0.0-13232). If omitted, it will default to the first [global.json](global-json.md) that contains the `version` property. If that is not present, it will use Latest.

`--install-dir [DIR]`

Path to where to install. The directory is created if it doesn't exist. The default value is `$HOME/.dotnet`.

`--architecture [ARCH]`

Architecture of the .NET binaries to be installed. Possible values are &lt;auto&gt;, x64 and amd64. The default value is &lt;auto&gt;, which represents currently running OS architecture.

`--shared-runtime`

If set, installs just the shared runtime bits, not the entire SDK.

`--debug-symbols`

If set, the installer will include debugging symbols in the installation.

> [!NOTE]
> This switch does not work yet.

`--dry-run`

If set, the script won't perform the installation but instead it'll display what command line to use to consistently install currently requested version of .NET CLI. 
For example, if you specify version `latest`, it will display a link with specific version, so that this command can be used deterministically in a build script.
It also displays binaries location if you prefer to install or download it yourself.

`--no-path`

If set, the prefix/installdir are not exported to the path for the current session. 
By default, the script will modify the PATH, which makes the CLI tools available immediately after install.

`--verbose`

Display diagnostics information.

`--azure-feed`

The URL for the Azure feed to be used by this installer. Not recommended to be changed. The default is `https://dotnetcli.azureedge.net/dotnet`.

`--help`

Prints out help for the script.

## Examples

Install the dev latest version to the default location:

Windows:

`./dotnet-install.ps1 -Channel Future`

macOS/Linux:

`./dotnet-install.sh --channel Future`

Install the latest preview to the specified location:

Windows:

`./dotnet-install.ps1 -Channel preview -InstallDir C:\cli`

macOS/Linux:

`./dotnet-install.sh --channel preview --install-dir ~/cli`