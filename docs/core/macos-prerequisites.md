---
title: Prerequisites for .NET Core on Mac
description: Supported macOS versions and .NET Core dependencies to develop, deploy, and run .NET Core applications on macOS machines.
keywords: .NET, .NET Core, macOS, Mac
author: guardrex
ms.author: mairaw
ms.date: 09/27/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
ms.workload: 
  - dotnetcore
---

# Prerequisites for .NET Core on macOS

This article shows you the supported macOS versions and .NET Core dependencies that you need to develop, deploy, and run .NET Core applications on macOS machines. The supported OS versions and dependencies that follow apply to the three ways of developing .NET Core apps on a Mac: via the [command-line with your favorite editor](tutorials/using-with-xplat-cli.md), [Visual Studio Code](https://code.visualstudio.com/), and [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/).

## Supported macOS versions

# [.NET Core 2.x](#tab/netcore2x)

.NET Core 2.x is supported on the following versions of macOS:

* macOS 10.12 "Sierra" and later versions

See [.NET Core 2.x Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md) for the complete list of .NET Core 2.x supported operating systems, out of support OS versions, and lifecycle policy links.

# [.NET Core 1.x](#tab/netcore1x)

.NET Core 1.x is supported on the following versions of macOS:

* macOS 10.12 "Sierra"
* macOS 10.11 "El Capitan"

See [.NET Core 1.x Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0-supported-os.md) for the complete list of .NET Core 1.x supported operating systems, out of support OS versions, and lifecycle policy links.

---

## .NET Core dependencies

# [.NET Core 2.x](#tab/netcore2x)

Download and install the .NET Core SDK from [.NET Downloads](https://www.microsoft.com/net/download/core). If you have problems with the installation on macOS, consult the [Known issues](https://github.com/dotnet/core/tree/master/release-notes/2.0) topic for the version you have installed.

# [.NET Core 1.x](#tab/netcore1x)

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

---

## Increase the maximum open file limit (.NET Core versions before .NET Core SDK 2.0.2) 

In older .NET Core versions (before .NET Core SDK 2.0.2), the default open file limit on macOS may not be sufficient for some .NET Core workloads, such as restoring projects or running unit tests.

You can increase this limit by following these steps:

1. Using a text editor, create a new file _/Library/LaunchDaemons/limit.maxfiles.plist_, and save the file with this content:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN"
        "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
  <dict>
    <key>Label</key>
    <string>limit.maxfiles</string>
    <key>ProgramArguments</key>
    <array>
      <string>launchctl</string>
      <string>limit</string>
      <string>maxfiles</string>
      <string>2048</string>
      <string>4096</string>
    </array>
    <key>RunAtLoad</key>
    <true/>
    <key>ServiceIPC</key>
    <false/>
  </dict>
</plist>
```

2. In a terminal window, run the following command:

```console
echo 'ulimit -n 2048' | sudo tee -a /etc/profile
```

3. Reboot your Mac to apply these settings.

## Visual Studio for Mac

You can use any editor to develop .NET Core applications using the .NET Core SDK. However, if you want to develop .NET Core applications on a Mac in an integrated development environment, you can use [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/). 

.NET Core development on macOS with Visual Studio for Mac requires:

* A supported version of the macOS operating system
* OpenSSL (.NET Core 1.x only; .NET Core 2.x uses security services available natively in macOS)
* .NET Core SDK for Mac
* [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/)
