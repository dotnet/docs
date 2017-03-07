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

`dotnet-install.ps1` | `dotnet-install.sh` - script used to install the Command Line Interface (CLI) tools and the shared runtime

## Synopsis
Windows:

`dotnet-install.ps1 [-Channel] [-Version]
    [-InstallDir] [-Debug] [-NoPath] 
    [-SharedRuntime]`

macOS/Linux:

`dotnet-install.sh [--channel] [--version]
    [--install-dir] [--debug] [--no-path] 
    [--shared-runtime]`

## Description

The `dotnet-install` scripts are used to perform a non-admin install of the CLI toolchain and the shared runtime. You can download the scripts from our [CLI GitHub repo](https://github.com/dotnet/cli/tree/rel/1.0.0-preview2/scripts/obtain). 

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

Which version of CLI to install; you need to specify the version as 3-part version (for example, 1.0.0-13232). If omitted, it will default to the first [global.json](global-json.md) that contains the `version` property; if that is not present, it will use Latest. 	

`-InstallDir [DIR]`

Path to install to. The directory is created if it doesn't exist. The default value is *%LocalAppData%\.dotnet*.

`-Debug`

`true` to indicate that larger packages containing debugging symbols should be used; otherwise, `false`. The default value is `false`.

`-NoPath`

`true` to indicate that the prefix/installdir are not exported to the path for the current session; otherwise, `false`. 
The default value is `false`, that is, the PATH is modified. 
This makes the CLI tools available immediately after install. 

`-SharedRuntime`

`true` to install just the shared runtime bits; `false` to install the entire SDK. The default value is `false`.

### Bash (macOS/Linux)
`--channel [CHANNEL]`

Which channel (for example "future", "preview", "production") to install from. The default value is "Production".

`--version [VERSION]`

Which version of CLI to install; you need to specify the version as 3-part version (for example, 1.0.0-13232). If omitted, it will default to the first [global.json](global-json.md) that contains the `version` property; if that is not present, it will use Latest. 	

`--install-dir [DIR]`

Path to where to install. The directory is created if it doesn't exist. The default value is `$HOME/.dotnet`.

`--debug`

`true` to indicate that larger packages containing debugging symbols should be used; otherwise, `false`. The default value is `false`.

`--no-path`

`true` to indicate that the prefix/installdir are not exported to the path for the current session; otherwise, `false`. 
The default value is `false`, that is, the PATH is modified. 
This makes the CLI tools available immediately after install.  

`--shared-runtime`

`true` to install just the shared runtime bits; `false` to install the entire SDK. The default value is `false`.

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
