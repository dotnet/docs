---
title: .NET Core SDK and runtime dependencies - .NET Core
description: Details the operating system and CPU architecture prerequisites to install the .NET Core SDK and runtime on Windows, Linux, and macOS.
author: leecow
ms.author: leecow
ms.date: 12/04/2019
zone_pivot_groups: operating-systems-set-one
---

# .NET Core dependencies and requirements

This article details which operating systems and CPU architecture are supported by .NET Core.

## Supported operating systems

::: zone pivot="os-windows"

<!-- markdownlint-disable MD025 -->
<!-- markdownlint-disable MD024 -->

# [.NET Core 3.1](#tab/netcore31)

The following Windows versions are supported with .NET Core 3.1:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                            | Version                        | Architectures   |
| ----------------------------- | ------------------------------ | --------------- |
| Windows Client                | 7 SP1+, 8.1                    | x64, x86        |
| Windows 10 Client             | Version 1607+                  | x64, x86        |
| Windows Server                | 2012 R2+                       | x64, x86        |
| Nano Server                   | Version 1803+                  | x64, ARM32      |

For more information about .NET Core 3.1 supported operating systems, distributions, and lifecycle policy, see [.NET Core 3.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/3.1/3.1-supported-os.md).

# [.NET Core 3.0](#tab/netcore30)

The following Windows versions are supported with .NET Core 3.0:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                            | Version                        | Architectures   |
| ----------------------------- | ------------------------------ | --------------- |
| Windows Client                | 7 SP1+, 8.1                    | x64, x86        |
| Windows 10 Client             | Version 1607+                  | x64, x86        |
| Windows Server                | 2012 R2+                       | x64, x86        |
| Nano Server                   | Version 1803+                  | x64, ARM32      |

For more information about .NET Core 3.0 supported operating systems, distributions, and lifecycle policy, see [.NET Core 3.0 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md).

# [.NET Core 2.2](#tab/netcore22)

The following Windows versions are supported with .NET Core 2.2:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                            | Version                        | Architectures   |
| ----------------------------- | ------------------------------ | --------------- |
| Windows Client                | 7 SP1+, 8.1                    | x64, x86        |
| Windows 10 Client             | Version 1607+                  | x64, x86        |
| Windows Server                | 2008 R2 SP1+                   | x64, x86        |
| Nano Server                   | Version 1803+                   | x64, ARM32      |

For more information about .NET Core 2.2 supported operating systems, distributions, and lifecycle policy, see [.NET Core 2.2 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md).

# [.NET Core 2.1](#tab/netcore21)

The following Windows versions are supported with .NET Core 2.1:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                            | Version                        | Architectures   |
| ----------------------------- | ------------------------------ | --------------- |
| Windows Client                | 7 SP1+, 8.1                    | x64, x86        |
| Windows 10 Client             | Version 1607+                  | x64, x86        |
| Windows Server                | 2008 R2 SP1+                   | x64, x86        |
| Nano Server                   | Version 1803+                  | x64,            |

For more information about .NET Core 2.1 supported operating systems, distributions, and lifecycle policy, see [.NET Core 2.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md).

---

<!-- markdownlint-disable MD001 -->

### Windows 7 / Vista / 8.1 / Server 2008 R2

Additional dependencies are required if you're installing the .NET SDK or runtime on the following Windows versions:

- Windows 7 SP1
- Windows Vista SP 2
- Windows 8.1
- Windows Server 2008 R2
- Windows Server 2012 R2

Install the following:

- [Microsoft Visual C++ 2015 Redistributable Update 3](https://www.microsoft.com/download/details.aspx?id=52685).
- [KB2533623](https://support.microsoft.com/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)

The requirements above are also required if you come across one of the following errors:

> The program can't start because *api-ms-win-crt-runtime-l1-1-0.dll* is missing from your computer. Try reinstalling the program to fix this problem.
>
> \- or -
>
> The library *hostfxr.dll* was found, but loading it from *C:\\\<path_to_app>\\hostfxr.dll* failed.

::: zone-end

::: zone pivot="os-linux"

# [.NET Core 3.1](#tab/netcore31)

.NET Core 3.1 treats Linux as a single operating system. There's a single Linux build (per chip architecture) for supported Linux distributions.

.NET Core 3.1 is supported on the following Linux distributions/versions:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                             | Version               | Architectures    |
| ------------------------------ | --------------------- | ---------------- |
| Red Hat Enterprise Linux       | 6, 7, 8               | x64 |
| CentOS                         | 7+                    | x64 |
| Oracle Linux                   | 7+                    | x64 |
| Fedora                         | 29+                   | x64 |
| Debian                         | 9+                    | x64, ARM32, ARM64 |
| Ubuntu                         | 16.04+                | x64, ARM32, ARM64 |
| Linux Mint                     | 18+                   | x64 |
| openSUSE                       | 15+                   | x64 |
| SUSE Enterprise Linux (SLES)   | 12 SP2+               | x64 |
| Alpine Linux                   | 3.10+                 | x64, ARM64 |

For more information about .NET Core 3.1 supported operating systems, distributions, and lifecycle policy, see [.NET Core 3.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/3.1/3.1-supported-os.md).

For more information about how to install .NET Core 3.1 on ARM64 (kernel 4.14+), see [Installing .NET Core 3.0 on Linux ARM64](https://gist.github.com/richlander/467813274cea8abc624553ee72b28213).

> [!IMPORTANT]
> ARM64 support requires Linux kernel 4.14 or higher. Some linux distributions satisfy this requirement while others don't. For example, Ubuntu 18.04 is supported but Ubuntu 16.04 doesn't.

# [.NET Core 3.0](#tab/netcore30)

.NET Core 3.0 treats Linux as a single operating system. There's a single Linux build (per chip architecture) for supported Linux distributions.

.NET Core 3.0 is supported on the following Linux distributions/versions:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                             | Version               | Architectures    |
| ------------------------------ | --------------------- | ---------------- |
| Red Hat Enterprise Linux       | 6, 7, 8               | x64 |
| CentOS                         | 7+                    | x64 |
| Oracle Linux                   | 7+                    | x64 |
| Fedora                         | 29+                   | x64 |
| Debian                         | 9+                    | x64, ARM32, ARM64 |
| Ubuntu                         | 16.04+                | x64, ARM32, ARM64 |
| Linux Mint                     | 18+                   | x64 |
| openSUSE                       | 15+                   | x64 |
| SUSE Enterprise Linux (SLES)   | 12 SP2+               | x64 |
| Alpine Linux                   | 3.8+                  | x64, ARM64 |

For more information about .NET Core 3.0 supported operating systems, distributions, and lifecycle policy, see [.NET Core 3.0 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md).

For more information about how to install .NET Core 3.0 on ARM64, see [Installing .NET Core 3.0 on Linux ARM64](https://gist.github.com/richlander/467813274cea8abc624553ee72b28213).

# [.NET Core 2.2](#tab/netcore22)

.NET Core 2.2 treats Linux as a single operating system. There's a single Linux build (per chip architecture) for supported Linux distributions.

.NET Core 2.2 is supported on the following Linux distributions/versions:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                             |  Version                |  Architectures   |
| ------------------------------ | ----------------------- | ---------------- |
| Red Hat Enterprise Linux       |  6, 7                   | x64 |
| CentOS                         |  7                      | x64 |
| Oracle Linux                   |  7                      | x64 |
| Fedora                         |  29, 30                 | x64 |
| Debian                         |  9                      | x64, ARM32 |
| Ubuntu                         |  16.04, 18.04, 18.10, 19.04    | x64, ARM32 |
| Linux Mint                     |  17, 18                 | x64 |
| openSUSE                       |  15+                    | x64 |
| SUSE Enterprise Linux (SLES)   |  12 SP2+                | x64 |
| Alpine Linux                   |  3.8+                   | x64 |

For more information about .NET Core 2.2 supported operating systems, distributions, and lifecycle policy, see [.NET Core 2.2 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md).

# [.NET Core 2.1](#tab/netcore21)

.NET Core 2.1 treats Linux as a single operating system. There's a single Linux build (per chip architecture) for supported Linux distributions.

.NET Core 2.1 is supported on the following Linux distributions/versions:

> [!NOTE]
> A `+` symbol represents the minimum version.

| OS                             |  Version                |  Architectures   |
| ------------------------------ | ----------------------- | ---------------- |
| Red Hat Enterprise Linux       |  6, 7, 8                | x64 |
| CentOS                         |  7+                     | x64 |
| Oracle Linux                   |  7+                     | x64 |
| Fedora                         |  29+                    | x64 |
| Debian                         |  9                      | x64, ARM32 |
| Ubuntu                         |  16.04, 18.04, 19.04, 19.10    | x64, ARM32 |
| Linux Mint                     |  17+                    | x64 |
| openSUSE                       |  15+                    | x64 |
| SUSE Enterprise Linux (SLES)   |  12 SP2+                | x64 |
| Alpine Linux                   |  3.8+                   | x64 |

For more information about .NET Core 2.1 supported operating systems, distributions, and lifecycle policy, see [.NET Core 2.1 Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md).

---

## Linux distribution dependencies

Based on your linux distribution, you may need to install additional dependencies.

> [!IMPORTANT]
> The exact versions and names may vary slightly on your Linux distribution of choice.

### Ubuntu

Ubuntu distributions require the following libraries to be installed:

- liblttng-ust0
- libcurl3 (for 14.x and 16.x)
- libcurl4 (for 18.x)
- libssl1.0.0
- libkrb5-3
- zlib1g
- libicu52 (for 14.x)
- libicu55 (for 16.x)
- libicu57 (for 17.x)
- libicu60 (for 18.x)

For .NET Core apps that use the *System.Drawing.Common* assembly, you also need the following dependency:

- libgdiplus (version 6.0.1 or later)

> [!WARNING]
> Most versions of Ubuntu include an earlier version of libgdiplus. You can install a recent version
> of libgdiplus by adding the Mono repository to your system. For more information,
> see <https://www.mono-project.com/download/stable/>.

### CentOS and Fedora

CentOS distributions require the following libraries installed:

- lttng-ust
- libcurl
- openssl-libs
- krb5-libs
- libicu
- zlib

Fedora users: If your OpenSSL's version >= 1.1, you'll need to install **compat-openssl10**.

For .NET Core 2.0, the following dependencies are also required:

- libunwind
- libuuid

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md).

For .NET Core apps that use the *System.Drawing.Common* assembly, you'll also need the following dependency:

- libgdiplus (version 6.0.1 or later)

> [!WARNING]
> Most versions of CentOS and Fedora include an earlier version of libgdiplus. You can install a recent version
> of libgdiplus by adding the Mono repository to your system. For more information,
> see <https://www.mono-project.com/download/stable/>.

::: zone-end

::: zone pivot="os-macos"

.NET Core is supported on the following macOS releases:

> [!NOTE]
> A `+` symbol represents the minimum version.

| .NET Core Version | macOS                 | Architectures |     |
| ----------------- | --------------------- | --------------| --- |
| 3.1               | High Sierra (10.13+)  | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/3.1/3.1-supported-os.md) |
| 3.0               | High Sierra (10.13+)  | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/3.0/3.0-supported-os.md) |
| 2.2               | Sierra (10.12+)       | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2-supported-os.md) |
| 2.1               | Sierra (10.12+)       | x64 | [More information](https://github.com/dotnet/core/blob/master/release-notes/2.1/2.1-supported-os.md) |

## libgdiplus

.NET Core applications that use the *System.Drawing.Common* assembly require libgdiplus to be installed.

An easy way to obtain libgdiplus is by using the [Homebrew ("brew")](https://brew.sh/) package manager for macOS. After installing *brew*, install libgdiplus by executing the following commands at a Terminal (command) prompt:

```console
brew update
brew install mono-libgdiplus
```

::: zone-end

## Next steps

- To develop and run apps, install the [.NET Core SDK](sdk.md) (includes the runtime).
- To run apps others have created, install the [.NET Core runtime](runtime.md).
