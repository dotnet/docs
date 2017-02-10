---
title: Using .NET Core SDK and tools in Continuous Integration (CI) | Microsoft Docs
description: Using .NET Core SDK and tools in Continuous Integration (CI)
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 0d6e1e34-277c-4aaf-9880-3ebf81023857
---

# Using .NET Core SDK and tools in Continuous Integration (CI) (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the .NET Core Tools Preview 2 version,
> see the [Using .NET Core SDK and tools in Continuous Integration (CI)](../../tools/using-ci-with-cli.md) topic.

## Overview
This document outlines the usage of .NET Core SDK and its tools on the build server. In general, on a CI build server, 
you want to automate the installation in some way. The automation, ideally, should not require administrative 
privileges if at all possible. 

For SaaS CI solutions, there are several options. This document will cover two very popular ones, [TravisCI](https://travis-ci.org/) and 
[AppVeyor](https://www.appveyor.com/). There are, of course, many other services out there, but the installation and 
usage mechanisms should be similar.

## Installation options for CI build servers

## Using the native installers
If using installers that require administrative privileges is not something that presents a problem, native installers for 
each platform can be used to set up the build server. This approach, especially in the case of Linux build servers, has 
one advantage which is automatic installing of dependencies needed for the SDK to run. The native installers will also 
install a system-wide version of the SDK, which may be desired; if it's not, you should look into the 
[installer script usage](#using-the-installer-script) outlined below. 

Using this approach is simple. For Linux, there is a choice of using a feed-based package manager, such as `apt-get` for 
Ubuntu or `yum` for CentOS, or using the packages themselves (that is, DEB or RPM). The former would require setting up the 
feed that contains the packages.

For Windows platforms, you can use the MSI. 

All of the binaries can be found on the [.NET Core getting started page](https://aka.ms/dotnetcoregs) which points to the 
latest stable releases. If you wish to use newer (and potentially unstable) releases or the latest, you can use the 
links from the [CLI repo](https://github.com/dotnet/cli). 

## Using the installer script
Using the installer script allows for non-administrative installation on your build server. It also allows a very easy 
automation. The script itself will download the ZIP/tarball files needed and will unpack them; it will also add the 
install location on the local machine to the PATH so that the tools become available for invocation immediately 
post-install. 

The installer script can easily be automated at the start of the build to fetch and install the needed version of the SDK. 
The "needed version" is whatever version application being built requires. You can choose the installation path so you 
can install the SDK locally and then clean up after the build completes. This brings additional encapsulation and 
atomicity to the build process. 

The installation script reference can be found in the [dotnet-install](dotnet-install-script.md) document. 

### Dealing with the dependencies
Using the installer script means that the native dependencies are not installed automatically and that you have to 
install them if the operating system you are installing on already doesn't have them. You can see the list of prerequisites 
in the [CLI repo](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md). 

## CI services setup examples
The below sections show examples of configurations using the mentioned CI SaaS offerings. 

### TravisCI

The [travis-ci](https://travis-ci.org/) can be configured to install the .NET Core SDK using the `csharp` language and the `dotnet` key.

Just use:

```yaml
dotnet: 1.0.0-preview2-003121
```

Travis can run both `osx` (OS X 10.11) and `linux` ( Ubuntu 14.04 ) job in a build matrix, see [example .travis.yml](https://github.com/dotnet/docs/blob/master/.travis.yml) 
for more information.

### AppVeyor

The [appveyor.com ci](https://www.appveyor.com/) has .NET Core SDK preview2 already installed in the build worker image `Visual Studio 2015`.

Just use:

```yaml
os: Visual Studio 2015
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