---
title: Using .NET Core SDK and tools in Continuous Integration (CI) | Microsoft Docs
description: Using .NET Core SDK and tools in Continuous Integration (CI)
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 02/13/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 0d6e1e34-277c-4aaf-9880-3ebf81023857
---

# Using .NET Core SDK and tools in Continuous Integration (CI) (.NET Core Tools RC4)

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Overview
This document outlines the usage of .NET Core SDK and its tools on the build server. When we started building the .NET Core SDK and its command-line tools, we have envisioned the toolset being able to be used both interactivelly, by a human being sitting at a command line, as well as automatically, that is by a CI server. The commands, options, inputs and outputs would be the same and the only thing you would add on top is a way to acquire the tooling as well as choosng how to do your build.

The document will focus on various scenarios of acqusition of the tools and show the tools that we built to help with that. We will then delve into some reccomendations on how to design and structure your build scripts themselves. 

## Installation options for CI build servers

## Using the native installers
If using installers that require administrative privileges is not something that presents a problem, native installers for 
each platform can be used to set up the build server. This approach, especially in the case of Linux build servers, has 
one advantage which is automatic installing of dependencies needed for the SDK to run. The native installers will also 
install a system-wide version of the SDK, which may be desired; if it's not, you should look into the 
[installer script usage](#using-the-installer-script) outlined below. 

* They require admin (sudo) access to the build server.
* For Ubuntu, the apt-get feed allows native depencenies to be acquired at the same time the tools are acquired.

Using these is straightforward, provided that your CI server or service allows you administrative access. In the case of Windows and macOS, you can download the MSI or PKG installers respectivelly. For Ubuntu, you can use the apt-get feed as detailed on [Ubuntu acqusition steps](https://www.microsoft.com/net/core#linuxubuntu). 

All of the binaries can be found on the [.NET Core installation guide](https://aka.ms/dotnetcoregs) which points to the 
latest stable releases. If you wish to use newer (and potentially unstable) releases or the latest, you can use the 
links from the [CLI repo](https://github.com/dotnet/cli). 

For other Linux distributions, we provide `tar.gz` archives (also known as `tarballs`) so you should use the installation script. 

### Using the installer script
Using the installer script allows for non-administrative installation on your build server. It also allows for easy 
automation. The script takes care of downloading the tooling using the CDN and then extracting it into a default (or specified) location for usage. You can also specify a version of the tooling that you wish to install as well as whether you want to install the entire SDK or just the shared runtime. 

The installer script can easily be automated at the start of the build to fetch and install the needed version of the SDK. By "needed version" here we refer to whatever the version of the SDK your project(s) need to build. It is usually a good idea to decrease the amount of side-effects by using the exact version that you need. The script allows you to install the version you need in a local directory on the server, run the tools from there and then clean up (or let the CI service clean up). This brings encapsulation and isolation to the entire build process. 

The installation script reference can be found in the [dotnet-install](dotnet-install-script.md) document. 

> [!NOTE]
> Using the installer script means that the native dependencies are not installed automatically and that you have to 
> install them if the operating system you are installing on already doesn't have them. You can see the list of prerequisites 
> in the [CLI repo](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md). 

## CI setup examples
This section will cover step-by-step guides for manual setup of a CI server as well as several SaaS CI solutions. The SaaS CI solutions that are covered are [TravisCI](https://travis-ci.org/), [AppVeyor](https://www.appveyor.com/) and [Visual Studio Team Services Build](https://www.visualstudio.com/en-us/docs/build/overview). 

### Manual setup 
Each of the below different services has its own way how to create and configure a build process. However, if you use a different CI build software or have a need to do something different than what the pre-packaged support on each of the services allow you to do, you will need to do something manual. 

In general, as desrcibed in the acqusition section above, the main thing in manual setup is to acquire the needed version of the tools (or the latest) and then run the build script that you have. The build script can either be a PowerShell/bash script that orchestrates the .NET Core commands or it can be a `proj` file that outlines the build process. The [orchestration section](#orchestrating-the-build) goes into more details about these two options. 

Once you create a script that does this manual setup, a good thing is that you can also use it on your dev machine to build your code, for example. 

Let's see a relatively simple PowerShell script that does all of this. 

```powershell
$ErrorActionPreference="Stop"
$ProgressPreference="SilentlyContinue"
$LocalDotnet=""
$InstallDir = "./cli-tools"
$CliVersion = "1.0.0-rc4-004771"

if (Test-Path $InstallDir)
{
    rm -Recurse $InstallDir
}
New-Item -Type "directory" -Path $InstallDir 

Write-Host "Downloading CLI installer..."
Invoke-WebRequest -Uri "https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.ps1" -OutFile "./$InstallDir/dotnet-install.ps1"
Write-Host "Installing the CLI requested version ($CliVersion)"
& ./$InstallDir/dotnet-install.ps1 -Version $CliVersion -InstallDir $InstallDir
$LocalDotnet = "./$InstallDir/dotnet"

# Run the build process now
```

Let's dig into details of the above:

* Lines 3 to 5 set up some variables to hold data that we will need. The `$LocalDotnet` variable will hold the path to the locally installed SDK since we want to be sure that we are executing that version and not any other that could be, potentially, installed on the machine. The `$InstallDir` and `$CliVersion` variables could also come from options to the script, for example; here, for simplicity sakes, we have 
* On line 7 we test whether the local path that the `$InstallDir` variable points to exists and if it does we remove it. This is not strictly needed, but I find that it is a good way to "reset" the environment. 
* We use the `Invoke-WebRequest` cmd-let of PowerShell on line 14 to get the installation script and put it into our installation directory. 
* Line 16 shows an invocation to install the SDK of a given version (specified in `$CliVersion`) and to install it into the specified location. 
* We then put in the final path into the `$LocalDotnet` variable for further use. 

After all of this, we are ready to run our build process. For brevity, I have left out that portion of the script, but the [orchestration section](#orchestrating-the-build) goes into more details. 

A bash script that does this on UNIX machines is similarly straightforward and is given below. 

```bash
#!/bin/bash

# Parameters
INSTALLDIR="cli-tools"
CLI_VERSION="1.0.0-rc4-004771"
DOWNLOADER=$(which curl)
LOCALDOTNET=""

if [ -d $INSTALLDIR ]; then rm -rf $INSTALLDIR; fi
mkdir -p $INSTALLDIR

echo "Downloading CLI installer"
$DOWNLOADER -sSL -o "./$INSTALLDIR/dotnet-install.sh" https://raw.githubusercontent.com/dotnet/cli/rel/1.0.0/scripts/obtain/dotnet-install.sh
chmod +x "./$INSTALLDIR/dotnet-install.sh"

say "Installing the CLI requested version ($CLI_VERSION)"
"./$INSTALLDIR/dotnet-install.sh" --install-dir $INSTALLDIR --version $CLI_VERSION
if [ $? -ne 0 ]; then die "Download of $CLI_VERSION version of the CLI failed; exiting..."; fi
$LOCALDOTNET="./$INSTALLDIR/dotnet"

# Run the build process now
```

### TravisCI

The [travis-ci](https://travis-ci.org/) can be configured to install the .NET Core SDK using the `csharp` language and the `dotnet` key.

Just use:

```yaml
dotnet: 1.0.0-rc4-0044771
```

Travis can run both `osx` (OS X 10.11) and `linux` ( Ubuntu 14.04 ) job in a build matrix, see [example .travis.yml](https://github.com/dotnet/docs/blob/master/.travis.yml) 
for more information.

The MSBuild-based tools bring both the LTS and Current runtimes (1.0.x and 1.1.x) in the package, so by installing the SDK you will get everything you need to build. 

### AppVeyor

The [appveyor.com ci](https://www.appveyor.com/) has .NET Core SDK 1.0.1 already installed in the build worker image `Visual Studio 2017`.

Just use:

```yaml
os: Visual Studio 2017
```

It's possible to install a specific version of .NET Core SDK, see [example appveyor.yml](https://github.com/dotnet/docs/blob/master/appveyor.yml) 
for more info. 

In the example, the .NET Core SDK binaries are downloaded, unzipped in a subdirectory and added to `PATH` env var.

A build matrix can be added to run integration tests with multiple version of 
the .NET Core SDK.

```yaml
environment:
  matrix:
    - CLI_VERSION: 1.0.0-preview2-003121
    - CLI_VERSION: Latest

install:
  # .NET Core SDK binaries
  - ps: $url = "https://dotnetcli.blob.core.windows.net/dotnet/preview/Binaries/$($env:CLI_VERSION)/dotnet-dev-win-x64.$($env:CLI_VERSION.ToLower()).zip"
  # follow normal installation from binaries
```
