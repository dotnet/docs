---
title: Prerequisites for .NET Core on Windows, Linux, MacOS
description: Supported Windows, Linux, MacOS versions and .NET Core dependencies to develop, deploy, and run .NET Core applications.
author: leecow
ms.author: leecow
ms.date: 10/03/2019
zone_pivot_groups: operating-systems-set-one
---

# Prerequisites for .NET Core

This article provides information on getting started with .NET Core. .NET Core can be installed on Windows, Linux, and macOS. You can code in your favorite text editor and produce cross-platform libraries and applications.

.NET Core is made up of two components, the runtime and the SDK. The **runtime** is required to run a .NET Core application that doesn't include the runtime. The **SDK** is required to build .NET Core applications.

There are a variety of ways to develop .NET Core apps:

::: zone pivot="os-windows"

- [Command-line with your favorite editor](tutorials/using-with-xplat-cli.md)
- [Visual Studio](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2019)
- [Visual Studio Code](https://code.visualstudio.com/)

::: zone-end

::: zone pivot="os-linux"

- [Command-line with your favorite editor](tutorials/using-with-xplat-cli.md)
- [Visual Studio Code](https://code.visualstudio.com/)

::: zone-end

::: zone pivot="os-macos"

- [Command-line with your favorite editor](tutorials/using-with-xplat-cli.md)
- [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link).
- [Visual Studio Code](https://code.visualstudio.com/)

::: zone-end

The following articles have a complete list of .NET Core supported operating systems per version:

- [.NET Core 3.0](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md)
- [.NET Core 2.2](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md)
- [.NET Core 2.1](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md)

## Check what is installed

Based on your environment, the .NET Core SDK may already be installed. If you use an IDE, such as Visual Studio, Visual Studio Code, or Visual Studio for Mac, the .NET Core SDK may already be installed on your system. You can check what is installed by opening a terminal and running the `dotnet --list-sdks` command:

::: zone pivot="os-windows"

```console
dotnet --list-sdks

2.1.500 [C:\program files\dotnet\sdk]
2.1.502 [C:\program files\dotnet\sdk]
2.1.504 [C:\program files\dotnet\sdk]
2.1.600 [C:\program files\dotnet\sdk]
2.1.602 [C:\program files\dotnet\sdk]
2.2.101 [C:\program files\dotnet\sdk]
3.0.100 [C:\program files\dotnet\sdk]
```

::: zone-end

::: zone pivot="os-linux"

```bash
$ dotnet --list-sdks

2.1.500 [/home/user/dotnet/sdk]
2.1.502 [/home/user/dotnet/sdk]
2.1.504 [/home/user/dotnet/sdk]
2.1.600 [/home/user/dotnet/sdk]
2.1.602 [/home/user/dotnet/sdk]
2.2.101 [/home/user/dotnet/sdk]
3.0.100 [/home/user/dotnet/sdk]
```

::: zone-end

::: zone pivot="os-macos"

```bash
$ dotnet --list-sdks

2.1.500 [/usr/local/share/dotnet/sdk]
2.1.502 [/usr/local/share/dotnet/sdk]
2.1.504 [/usr/local/share/dotnet/sdk]
2.1.600 [/usr/local/share/dotnet/sdk]
2.1.602 [/usr/local/share/dotnet/sdk]
2.2.101 [/usr/local/share/dotnet/sdk]
3.0.100 [/usr/local/share/dotnet/sdk]
```

::: zone-end

You can also see what runtimes are installed with the command `dotnet --list-runtimes`.

## Standalone installers

You can download a standalone installer for each OS from the following links:

- [.NET Core 3.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.0).
- [.NET Core 2.2 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.2).
- [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1).

## Dependencies

Depending on the OS you're using, you may need to install additional dependencies.

::: zone pivot="os-windows"

<!-- markdownlint-disable MD025 -->

# [.NET Core 3.0](#tab/netcore30)

The following Windows operating systems are supported with .NET Core 3.0:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                            | Version                        | Architectures   |
| ----------------------------- | ------------------------------ | --------------- |
| Windows Client                | 7 SP1+, 8.1                    | x64, x86        |
| Windows 10 Client             | Version 1607+                  | x64, x86        |
| Windows Server                | 2012 R2 SP1+                   | x64, x86        |
| Nano Server                   | Version 1803+                  | x64, ARM32      |

# [.NET Core 2.2](#tab/netcore22)

The following Windows operating systems are supported with .NET Core 2.2:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                            | Version                        | Architectures   |
| ----------------------------- | ------------------------------ | --------------- |
| Windows Client                | 7 SP1+, 8.1                    | x64, x86        |
| Windows 10 Client             | Version 1607+                  | x64, x86        |
| Windows Server                | 2008 R2 SP1+                   | x64, x86        |
| Nano Server                   | Version 1709+                  | x64, ARM32      |

# [.NET Core 2.1](#tab/netcore21)

The following Windows operating systems are supported with .NET Core 2.1:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                            | Version                        | Architectures   |
| ----------------------------- | ------------------------------ | --------------- |
| Windows Client                | 7 SP1+, 8.1                    | x64, x86        |
| Windows 10 Client             | Version 1607+                  | x64, x86        |
| Windows Server                | 2008 R2 SP1+                   | x64, x86        |

---

### Windows 7 / 8.1 / Server 2008 R2

There are additional prerequisites if you're installing the .NET SDK or Runtime on the following Windows operating systems:

- Windows 7 SP1
- Windows 8.1
- Windows Server 2008 R2
- Windows Server 2012 R2

Install the following:

- [Microsoft Visual C++ 2015 Redistributable Update 3](https://www.microsoft.com/download/details.aspx?id=52685).
- [KB2533623](https://support.microsoft.com/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)

The requirements above are also required if you encounter one of the following errors:

> The program can't start because api-ms-win-crt-runtime-l1-1-0.dll is missing from your computer. Try reinstalling the program to fix this problem.
>
> \- or -
>
> The library hostfxr.dll was found, but loading it from C:\\\<path_to_app>\\hostfxr.dll failed.

### Visual Studio

If you're using Visual Studio to develop .NET Core applications, the following table describes the minimum required version of Visual Studio based on the target .NET Core runtime.

| .NET Core SDK version | Visual Studio version                      |
| --------------------- | ------------------------------------------ |
| 3.0                   | Visual Studio 2019 version 16.3 or higher. |
| 2.2                   | Visual Studio 2017 version 15.9 or higher. |
| 2.1                   | Visual Studio 2017 version 15.7 or higher. |

To verify your Visual Studio version:

01. Open Visual Studio.
01. Press the **Help** > **About Microsoft Visual Studio** menu.
01. Read the version number from the **About** dialog.

::: zone-end

::: zone pivot="os-linux"

<!-- markdownlint-disable MD025 -->

# [.NET Core 3.0](#tab/netcore30)

.NET Core 3.0 treats Linux as a single operating system. There is a single Linux build (per chip architecture) for supported Linux distributions. 

.NET Core 3.0 is supported on the following Linux distributions/versions):

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                             | Version               | Architectures    |
| ------------------------------ | --------------------- | ---------------- |
| Red Hat Enterprise Linux       | 6+, 7                 | x64 |
| Oracle Linux                   | 7                     | x64 |
| CentOS                         | 7                     | x64 |
| Fedora                         | 29+                   | x64 |
| Debian                         | 9+                    | x64, ARM32, ARM64 |
| Ubuntu                         | 16.04+                | x64, ARM32, ARM64 |
| Linux Mint                     | 18+                   | x64 |
| openSUSE                       | 15+                   | x64 |
| SUSE Enterprise Linux (SLES)   | 12 SP2+               | x64 |
| Alpine Linux                   | 3.8+                  | x64, ARM64 |

See [.NET Core 3.0 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md) for the complete list of .NET Core 3.0 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

For more information about how to install .NET Core 3.0 on ARM64, see [Installing .NET Core 3.0 on Linux ARM64](https://gist.github.com/richlander/467813274cea8abc624553ee72b28213).

# [.NET Core 2.2](#tab/netcore22)

.NET Core 2.2 treats Linux as a single operating system. There is a single Linux build (per chip architecture) for supported Linux distributions.

.NET Core 2.2 is supported on the following Linux distributions/versions:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                             |  Version                |  Architectures   |
| ------------------------------ | ----------------------- | ---------------- |
| Red Hat Enterprise Linux       |  6, 7                   | x64 |
| Oracle Linux                   |  7                      | x64 |
| CentOS                         |  7                      | x64 |
| Fedora                         |  29, 30                 | x64 |
| Debian                         |  9                      | x64, ARM32 |
| Ubuntu                         |  16.04, 18.04, 18.10    | x64, ARM32 |
| Linux Mint                     |  17, 18                 | x64 |
| openSUSE                       |  15+                    | x64 |
| SUSE Enterprise Linux (SLES)   |  12 SP2+                | x64 |
| Alpine Linux                   |  3.7+                   | x64 |

See [.NET Core 2.2 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md) for the complete list of .NET Core 2.2 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

# [.NET Core 2.1](#tab/netcore21)

.NET Core 2.1 treats Linux as a single operating system. There is a single Linux build (per chip architecture) for supported Linux distributions.

.NET Core 2.1 is supported on the following Linux distributions/versions:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                             |  Version                |  Architectures   |
| ------------------------------ | ----------------------- | ---------------- |
| Red Hat Enterprise Linux       |  6, 7, 8                | x64 |
| Oracle Linux                   |  7                      | x64 |
| CentOS                         |  7                      | x64 |
| Fedora                         |  29, 30                 | x64 |
| Debian                         |  9                      | x64, ARM32 |
| Ubuntu                         |  16.04, 18.04, 19.04    | x64, ARM32 |
| Linux Mint                     |  17, 18                 | x64 |
| openSUSE                       |  42.3+                  | x64 |
| SUSE Enterprise Linux (SLES)   |  12 SP2+                | x64 |
| Alpine Linux                   |  3.7+                   | x64 |

See [.NET Core 2.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md) for the complete list of .NET Core 2.1 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

---

::: zone-end

::: zone pivot="os-macos"

<!-- markdownlint-disable MD025 -->

# [.NET Core 3.0](#tab/netcore30)

.NET Core 3.0 is supported on **macOS High Sierra (version 10.13)** and later versions. A **x64** CPU architecture is required.

Download and install the .NET Core SDK from the [.NET Core 3.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.0) page. [.NET Core 3.0 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md) for the complete list of .NET Core 3.0 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

For a list of known issues, see [.NET Core known issues](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-known-issues.md).

# [.NET Core 2.2](#tab/netcore22)

.NET Core 2.2 is supported on **macOS Sierra (version 10.12)** and later versions. A **x64** CPU architecture is required.

Download and install the .NET Core SDK from the [.NET Core 2.2 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.2) page. [.NET Core 2.2 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md) for the complete list of .NET Core 2.2 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

For a list of known issues, see [.NET Core known issues](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-known-issues.md).

# [.NET Core 2.1](#tab/netcore21)

.NET Core 2.1 is supported on **macOS Sierra (version 10.12)** and later versions. A **x64** CPU architecture is required.

Download and install the .NET Core SDK from the [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1) page. [.NET Core 2.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md) for the complete list of .NET Core 2.1 supported operating systems, distributions and versions, out of support OS versions, and lifecycle policy links.

For a list of known issues, see [.NET Core known issues](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-known-issues.md).

---

::: zone-end

## Installing with the native installers

.NET Core native installers are available for supported Linux distributions/versions. The native installers require admin (sudo) access to the server. The advantage of using a native installer is that all of the .NET Core native dependencies are installed. Native installers also install the .NET Core SDK system-wide.

On Linux, there are two installer package choices:

* Using a feed-based package manager, such as apt-get for Ubuntu, or yum for CentOS/RHEL.
* Using the packages themselves, DEB or RPM.

## Installer script for automation

The [dotnet-install scripts](./tools/dotnet-install-script.md) are used to perform a non-admin install of the CLI toolchain and the shared runtime. You can download the script from <https://dot.net/v1/dotnet-install.sh>.

The script defaults to installing the latest "LTS" version, which is currently .NET Core 1.1. To install .NET Core 2.1, run the script with the following switch:

```bash
./dotnet-install.sh -c Current
```

The installer bash script is used in automation scenarios and non-admin installations. This script also reads PowerShell switches, so they can be used with the script on Linux/OS X systems.

::: zone pivot="os-windows"

## Install with Visual Studio

Stuff

::: zone-end

::: zone pivot="os-macos"

## Install with Visual Studio for Mac

Stuff

::: zone-end

## Install with Visual Studio Code

Stuff




<!--
::: zone pivot="os-windows"

::: zone-end

::: zone pivot="os-linux"

::: zone-end

::: zone pivot="os-macos"

::: zone-end
-->
