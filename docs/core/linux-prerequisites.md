---
title: Prerequisites for .NET Core on Linux
description: Supported Linux versions and .NET Core dependencies to develop, deploy, and run .NET Core applications on Linux machines.
author: leecow
ms.author: leecow
ms.date: 12/14/2018
---
# Prerequisites for .NET Core on Linux

This article shows the dependencies needed to develop .NET Core applications on Linux. The supported Linux distributions/versions, and dependencies that follow apply to the two ways of developing .NET Core apps on Linux:

* [Command-line with your favorite editor](tutorials/using-with-xplat-cli.md)
* [Visual Studio Code](https://code.visualstudio.com/)

> [!NOTE]
> The .NET Core SDK package is not required for production servers/environments. Only the .NET Core runtime package is needed for apps deployed to production environments. The .NET Core runtime is deployed with apps as part of a self-contained deployment, however, it must be deployed for Framework-dependent deployed apps separately. For more information about framework-dependent and self-contained deployment types, see [.NET Core application deployment](./deploying/index.md). Also see [Self-contained Linux applications](https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md) for specific guidelines.

## Supported Linux versions

<!-- markdownlint-disable MD025 -->

# [.NET Core 2.x](#tab/netcore2x)

.NET Core 2.x treats Linux as a single operating system. There is a single Linux build (per chip architecture) for supported Linux distributions. 

For download links and more information, see [.NET Core 2.2 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.2) or [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1).

.NET Core 2.x is supported on the following Linux distributions/versions:

* Red Hat Enterprise Linux 7, 6 - 64-bit (`x86_64` or `amd64`)
* CentOS 7  - 64-bit (`x86_64` or `amd64`) 
* Oracle Linux 7 - 64-bit (`x86_64` or `amd64`) 
* Fedora 28, 27 - 64-bit (`x86_64` or `amd64`) 
* Debian 9 (64-bit, `arm32`), 8.7 or later versions - 64-bit (`x86_64` or `amd64`)
* Ubuntu 18.04 (64-bit, `arm32`), 16.04, 14.04 - 64-bit (`x86_64` or `amd64`)
* Linux Mint 18, 17 - 64-bit (`x86_64` or `amd64`)
* openSUSE 42.3 or later versions - 64-bit (`x86_64` or `amd64`)
* SUSE Enterprise Linux (SLES) 12 Service Pack 2 or later - 64-bit (`x86_64` or `amd64`)
* Alpine Linux 3.7 or later versions - 64-bit (`x86_64` or `amd64`)

See [.NET Core 2.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md) and [.NET Core 2.2 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md) for the complete list of .NET Core 2.1 and .NET Core 2.2 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

# [.NET Core 1.x](#tab/netcore1x)

For download links and more information, see [.NET Core 1.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/1.1) or [.NET Core 1.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/1.0).

.NET Core 1.x is supported on the following Linux 64-bit (`x86_64` or `amd64`) distributions/versions:

* Red Hat Enterprise Linux 7
* CentOS 7
* Oracle Linux 7
* Fedora 28 (.NET Core 1.1), 27
* Debian 8.2 or later versions
* Ubuntu 18.04 (.NET Core 1.1), 16.04, 14.04
* Linux Mint 17
* openSUSE 42.3 or later versions (.NET Core 1.1)

See [.NET Core 1.x Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0-supported-os.md) for the complete list of .NET Core 1.x supported operating systems, out of support OS versions, and lifecycle policy links.

# [.NET Core 3.0](#tab/netcore30)

.NET Core 3.0 Preview 9 treats Linux as a single operating system. There is a single Linux build (per chip architecture) for supported Linux distributions. 

For download links and more information, see [.NET Core 3.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.0).

.NET Core 3.0 Preview 9 is supported on the following Linux distributions/versions. 

OS                            | Version               | Architectures  
------------------------------|-----------------------|----------------
Red Hat Enterprise Linux      | 6                     | x64
Red Hat Enterprise Linux<br>CentOS<br>Oracle Linux  | 7                     | x64
Fedora                        | 28, 29, 30            | x64
Debian                        | 9, 10                 | x64, ARM32\*, ARM64\*
Ubuntu                        | 16.04+, 18.04+, 19.04+ | x64, ARM32\*, ARM64\*
Linux Mint                    | 18                    | x64
OpenSUSE Leap                 | 42.3+                 | x64
SUSE Enterprise Linux (SLES)  | 12 SP2+, 15           | x64
Alpine Linux                  | 3.8+                  | x64, ARM64

\* ARM32 and ARM64 support starts with Debian 9 and Ubuntu 16.04. Earlier versions of those distros are not supported on ARM chips.

See [.NET Core 3.0 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md) for the complete list of .NET Core 3.0 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

For more information about how to install .NET Core 3.0 on ARM64, see [Installing .NET Core 3.0 on Linux ARM64](https://gist.github.com/richlander/467813274cea8abc624553ee72b28213).

---

## Linux distribution dependencies

The following are intended to be examples. The exact versions and names may vary slightly on your Linux distribution of choice.

### Ubuntu

Ubuntu distributions require the following libraries installed:

* liblttng-ust0
* libcurl3 (for 14.x and 16.x)
* libcurl4 (for 18.x)
* libssl1.0.0
* libkrb5-3
* zlib1g
* libicu52 (for 14.x)
* libicu55 (for 16.x)
* libicu57 (for 17.x)
* libicu60 (for 18.x)

For versions earlier than .NET Core 2.1, following dependencies are also required:

* libunwind8
* libuuid1

### CentOS and Fedora

CentOS distributions require the following libraries installed:

* lttng-ust
* libcurl
* openssl-libs
* krb5-libs
* libicu
* zlib

Fedora users: If your openssl's version >= 1.1, you'll need to install compat-openssl10.

For versions earlier than .NET Core 2.1, following dependencies are also required:

* libunwind
* libuuid

For more information about the dependencies, see [Self-contained Linux applications](https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md).

## Installing .NET Core dependencies with the native installers

.NET Core native installers are available for supported Linux distributions/versions. The native installers require admin (sudo) access to the server. The advantage of using a native installer is that all of the .NET Core native dependencies are installed. Native installers also install the .NET Core SDK system-wide.

On Linux, there are two installer package choices:

* Using a feed-based package manager, such as apt-get for Ubuntu, or yum for CentOS/RHEL.
* Using the packages themselves, DEB or RPM.

### Scripting Installs with the .NET Core installer script

The [dotnet-install scripts](./tools/dotnet-install-script.md) are used to perform a non-admin install of the CLI toolchain and the shared runtime. You can download the script from <https://dot.net/v1/dotnet-install.sh>.

The script defaults to installing the latest "LTS" version, which is currently .NET Core 1.1. To install .NET Core 2.1, run the script with the following switch:

```bash
./dotnet-install.sh -c Current
```

The installer bash script is used in automation scenarios and non-admin installations. This script also reads PowerShell switches, so they can be used with the script on Linux/OS X systems.

## Troubleshoot

If you have problems with a .NET Core installation on a supported Linux distribution/version, consult the following topics for your installed distributions/versions:

* [.NET Core 3.0 known issues](https://github.com/dotnet/core/tree/master/release-notes/3.0)
* [.NET Core 2.2 known issues](https://github.com/dotnet/core/tree/master/release-notes/2.2)
* [.NET Core 2.1 known issues](https://github.com/dotnet/core/tree/master/release-notes/2.1)
* [.NET Core 1.1 known issues](https://github.com/dotnet/core/blob/master/release-notes/1.1)
* [.NET Core 1.0 known issues](https://github.com/dotnet/core/blob/master/release-notes/1.0)
