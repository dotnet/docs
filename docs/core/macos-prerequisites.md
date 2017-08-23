---
title: Prerequisites for .NET Core on Mac
description: Supported macOS versions and .NET Core dependencies to develop, deploy, and run .NET Core applications on macOS machines.
keywords: .NET, .NET Core, macOS, Mac
author: guardrex
ms.author: mairaw
ms.date: 07/07/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
---

# Prerequisites for .NET Core on Mac

This article shows you the supported macOS versions and .NET Core dependencies that you need to develop, deploy, and run .NET Core applications on macOS machines. The supported OS versions and dependencies that follow apply to the three ways of developing .NET Core apps on a Mac: via the [command-line with your favorite editor](tutorials/using-with-xplat-cli.md), [Visual Studio Code](https://code.visualstudio.com/), and [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/).

## Supported macOS versions

.NET Core is supported on the following versions of macOS:

* macOS 10.12 "Sierra"
* macOS 10.11 "El Capitan" (.NET Core 1.x only)

See [Supported OS Versions](https://github.com/dotnet/core/blob/master/roadmap.md#supported-os-versions) for the complete list of supported operating systems.

## .NET Core dependencies

**.NET Core 1.x**

.NET Core 1.x requires OpenSSL when running on macOS. An easy way to obtain OpenSSL is by using the [Homebrew ("brew")](https://brew.sh/) package manager for macOS. After installing *brew*, install OpenSSL by executing the following commands at a Terminal (command) prompt:

```console
brew update
brew install openssl
mkdir -p /usr/local/lib
ln -s /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib /usr/local/lib/
ln -s /usr/local/opt/openssl/lib/libssl.1.0.0.dylib /usr/local/lib/
```

Download and install the .NET Core SDK from [.NET Downloads](https://www.microsoft.com/net/download/core). If you have problems with the installation on macOS, consult the [1.0.0 Known Issues](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0-known-issues.md) and [1.0.1 Known Issues](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.1-known-issues.md) topics.

**.NET Core 2.x**

Download and install the .NET Core SDK from [.NET Downloads](https://www.microsoft.com/net/download/core). If you have problems with the installation on macOS, consult the [Known issues](https://github.com/dotnet/core/tree/master/release-notes/2.0) topic for the version you have installed.

## Visual Studio for Mac

You can use any editor to develop .NET Core applications using the .NET Core SDK. However, if you want to develop .NET Core applications on a Mac in an integrated development environment, you can use [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/). 

.NET Core development on macOS with Visual Studio for Mac requires:

* A supported version of the macOS operating system
* OpenSSL (.NET Core 1.x only; .NET Core 2.x uses security services available natively in macOS)
* .NET Core SDK for Mac
* [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/)
