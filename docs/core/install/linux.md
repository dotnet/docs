---
title: Install .NET on Linux Distributions
description: Learn about what Linux distributions support installing .NET on Linux.
author: adegeo
ms.author: adegeo
ms.date: 11/05/2021
---

# Install .NET on Linux

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

.NET is available on different Linux distributions. Most Linux platforms and distributions have a major release each year, and most provide a package manager that is used to install .NET. This article describes what is currently supported and which package manager is used.

The rest of this article is a breakdown of each major Linux distribution that .NET supports. All .NET releases remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the Linux distribution reaches end-of-life.

For the best compatibility, choose a long-term release (LTS) version.

## Unsupported releases

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

These unsupported versions aren't detailed in the sections below and your mileage may vary if you try to install them.

## Manual installation

If you don't want to use a package manager to install .NET on Linux, you can install .NET in one of the following ways:

- [Snap package](linux-snap.md)
- [Scripted install with _install-dotnet.sh_](linux-scripted-manual.md#scripted-install)
- [Manual binary extraction](linux-scripted-manual.md#manual-install)

Be sure to check the appropriate distribution page for more information about any required dependencies that may be missing when you do a manual installation.

## Install preview versions

Preview and Release Candidate versions of .NET aren't available in package managers. You can install previews and release candidates of .NET [manually](#manual-installation).

## Alpine

The following table is a list of currently supported .NET releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://alpinelinux.org/releases/).

- A ✔️ indicates that the version of Alpine or .NET is still supported.
- A ❌ indicates that the version of Alpine or .NET isn't supported on that Alpine release.
- When both a version of Alpine and a version of .NET have ✔️, that OS and .NET combination is supported.

| Alpine  | .NET Core 3.1 | .NET 5    | .NET 6    |
|---------|---------------|-----------|-----------|
| ✔️ 3.14 | ✔️ 3.1        | ✔️ 5.0    | ✔️ 6.0    |
| ✔️ 3.13 | ✔️ 3.1        | ✔️ 5.0    | ✔️ 6.0    |
| ✔️ 3.12 | ✔️ 3.1        | ✔️ 5.0    | ✔️ 6.0    |
| ❌ 3.11 | ✔️ 3.1        | ✔️ 5.0    | ❌ 6.0    |
| ❌ 3.10 | ✔️ 3.1        | ❌ 5.0    | ❌ 6.0    |
| ❌ 3.9  | ✔️ 3.1        | ❌ 5.0    | ❌ 6.0    |
| ❌ 3.8  | ✔️ 3.1        | ❌ 5.0    | ❌ 6.0    |

For more information, see [Install .NET on Alpine](linux-alpine.md).

## CentOS

CentOS 7 uses Yum as a package manager and CentOS 8 uses DNF.

The following table is a list of currently supported .NET releases on both CentOS 7 and CentOS 8. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of CentOS is no longer supported.

- A ✔️ indicates that the version of CentOS or .NET is still supported.
- A ❌ indicates that the version of CentOS or .NET isn't supported on that CentOS release.
- When both a version of CentOS and a version of .NET have ✔️, that OS and .NET combination is supported.

| CentOS                   | .NET Core 3.1 | .NET 5         | .NET 6         |
|--------------------------|---------------|----------------|----------------|
| ✔️ [7](linux-centos.md#centos-7-)       | ✔️ 3.1        | ✔️ 5.0         | ✔️ 6.0         |
| ✔️ [8](linux-centos.md#centos-8-)\*     | ✔️ 3.1        | ✔️ 5.0         | ❌ 6.0         |

> [!WARNING]
> \*CentOS 8 will reach an early End Of Life (EOL) on December 31st, 2021. For more information, see the official [CentOS Linux EOL page](https://www.centos.org/centos-linux-eol/). Because of this, .NET 6 won't be supported on CentOS Linux 8.

For more information, see [Install .NET on CentOS](linux-centos.md).

## Debian

Debian uses APT (Advanced Package Tool) as a package manager.

The following table is a list of currently supported .NET releases and the versions of Debian they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Debian reaches end-of-life](https://wiki.debian.org/DebianReleases).

- A ✔️ indicates that the version of Debian or .NET is still supported.
- A ❌ indicates that the version of Debian or .NET isn't supported on that Debian release.
- When both a version of Debian and a version of .NET have ✔️, that OS and .NET combination is supported.

| Debian                   | .NET Core 3.1 | .NET 5   | .NET 6   |
|--------------------------|---------------|----------|----------|
| ✔️ [11](linux-debian.md#debian-11-)     | ✔️ 3.1        | ✔️ 5.0   | ✔️ 6.0   |
| ✔️ [10](linux-debian.md#debian-10-)     | ✔️ 3.1        | ✔️ 5.0   | ✔️ 6.0   |
| ✔️ [9](linux-debian.md#debian-9-)       | ✔️ 3.1        | ✔️ 5.0   | ✔️ 6.0   |
| ❌ [8](linux-debian.md#debian-8-)       | ❌ 3.1        | ❌ 5.0   | ❌ 5.0   |

For more information, see [Install .NET on Debian](linux-debian.md).

## Fedora

Fedora uses DNF as its package manager.

The following table is a list of currently supported .NET releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

- A ✔️ indicates that the version of Fedora or .NET is still supported.
- A ❌ indicates that the version of Fedora or .NET isn't supported on that Fedora release.
- When both a version of Fedora and a version of .NET have ✔️, that OS and .NET combination is supported.

| .NET Version  | Fedora 35 ✔️ | 34 ✔️ | 33 ✔️ | 32 ❌ | 31 ❌ | 30 ❌ | 29 ❌ | 28 ❌ | 27 ❌ |
| ------------  | ---------:    | --:   | --:   | --:    | --:   | --:    | --:   | --:   | --:    |
| .NET 6        | ✔️           | ✔️    | ✔️    | ❌    | ❌    |❌      |❌    |❌     |❌     |
| .NET 5        | ✔️           | ✔️    | ✔️    | ✔️    | ❌    |❌      |❌    |❌     |❌     |
| .NET Core 3.1 | ✔️           | ✔️    | ✔️    | ✔️    | ✔️    |✔️      |✔️    |❌     |❌     |

For more information, see [Install .NET on Fedora](linux-fedora.md).

## openSUSE

openSUSE uses zypper as the package manager.

The following table is a list of currently supported .NET releases on openSUSE 15. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of openSUSE is no longer supported.

- A ✔️ indicates that the version of openSUSE or .NET is still supported.
- A ❌ indicates that the version of openSUSE or .NET isn't supported on that openSUSE release.
- When both a version of openSUSE and a version of .NET have ✔️, that OS and .NET combination is supported.

| openSUSE                   | .NET Core 3.1 | .NET 5     | .NET 6         |
|----------------------------|---------------|------------|----------------|
| ✔️ [15](linux-opensuse.md#opensuse-15-)     | ✔️ 3.1        | ✔️ 5.0     | ✔️ 6.0         |

For more information, see [Install .NET on openSUSE](linux-opensuse.md).

## Red Hat

Red Hat Enterprise Linux (RHEL) uses yum (RHEL 7) and DNF (RHEL 8) as the package manager.

The following table is a list of currently supported .NET releases on both RHEL 7 and RHEL 8. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of RHEL is no longer supported.

- A ✔️ indicates that the version of RHEL or .NET is still supported.
- A ❌ indicates that the version of RHEL or .NET isn't supported on that RHEL release.
- When both a version of RHEL and a version of .NET have ✔️, that OS and .NET combination is supported.

| RHEL                                 | .NET Core 3.1                                | .NET 5                                 | .NET 6                                  |
| ------------------------------------ | -------------------------------------------- | -------------------------------------- | --------------------------------------- |
| ✔️ [8](linux-rhel.md#rhel-8-)        | ✔️ [3.1](linux-rhel.md#rhel-8-)             | ✔️ [5.0](linux-rhel.md#rhel-8-)        | ✔️ [6.0](linux-rhel.md#rhel-8-)        |
| ✔️ [7](linux-rhel.md#rhel-7--net-50) | ✔️ [3.1](linux-rhel.md#rhel-7--net-core-31) | ✔️ [5.0](linux-rhel.md#rhel-7--net-50) | ✔️ [6.0](linux-rhel.md#rhel-7--net-60) |

For more information, see [Install .NET on RHEL](linux-rhel.md).

## SLES

SLES uses zypper as the package manager.

The following table is a list of currently supported .NET releases on both SLES 12 SP2 and SLES 15. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of SLES is no longer supported.

- A ✔️ indicates that the version of SLES or .NET is still supported.
- A ❌ indicates that the version of SLES or .NET isn't supported on that SLES release.
- When both a version of SLES and a version of .NET have ✔️, that OS and .NET combination is supported.

| SLES                   | .NET Core 3.1 | .NET 5   | .NET 6   |
|------------------------|---------------|----------|----------|
| ✔️ [15](linux-sles.md#sles-15-)     | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |
| ✔️ [12 SP2](linux-sles.md#sles-12-) | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |

For more information, see [Install .NET on SLES](linux-sles.md).

## Ubuntu

Ubuntu uses APT (Advanced Package Tool) as a package manager.

The following table is a list of currently supported .NET releases and the versions of Ubuntu they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Ubuntu reaches end-of-life](https://wiki.ubuntu.com/Releases).

- A ✔️ indicates that the version of Ubuntu or .NET is still supported.
- A ❌ indicates that the version of Ubuntu or .NET isn't supported on that Ubuntu release.
- When both a version of Ubuntu and a version of .NET have ✔️, that OS and .NET combination is supported.

| Ubuntu                                   | .NET Core 3.1 | .NET 5   | .NET 6   |
|------------------------------------------|---------------|----------|----------|
| ✔️ [21.10](linux-ubuntu.md#2110-)       | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |
| ✔️ [21.04](linux-ubuntu.md#2104-)       | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |
| ❌ [20.10](linux-ubuntu.md#2010-)       | ✔️ 3.1        | ✔️ 5.0 | ❌ 6.0 |
| ✔️ [20.04 (LTS)](linux-ubuntu.md#2004-) | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |
| ❌ [19.10](linux-ubuntu.md#1910-)       | ✔️ 3.1        | ❌ 5.0 | ❌ 6.0 |
| ❌ [19.04](linux-ubuntu.md#1904-)       | ✔️ 3.1        | ❌ 5.0 | ❌ 6.0 |
| ❌ [18.10](linux-ubuntu.md#1810-)       | ❌ 3.1        | ❌ 5.0 | ❌ 6.0 |
| ✔️ [18.04 (LTS)](linux-ubuntu.md#1804-) | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |
| ❌ [17.10](linux-ubuntu.md#1710-)       | ❌ 3.1        | ❌ 5.0 | ❌ 6.0 |
| ❌ [17.04](linux-ubuntu.md#1704-)       | ❌ 3.1        | ❌ 5.0 | ❌ 6.0 |
| ❌ [16.10](linux-ubuntu.md#1610-)       | ❌ 3.1        | ❌ 5.0 | ❌ 6.0 |
| ✔️ [16.04 (LTS)](linux-ubuntu.md#1604-) | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |

For more information, see [Install .NET on Ubuntu](linux-ubuntu.md).

## Next steps

- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-linux).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).
