---
title: Install .NET Core on Linux Distributions
description: Learn about what Linux distributions support installing .NET Core on Linux.
author: adegeo
ms.author: adegeo
ms.date: 06/01/2020
---

# Install .NET Core on Linux

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

.NET Core is available on different Linux distributions. Most Linux platforms and distributions have a major release each year, and most provide a package manager that is used to install .NET Core. This article describes what is currently supported and which package manager is used.

The rest of this article is a breakdown of each major Linux distribution that .NET Core supports. All .NET Core releases remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the Linux distribution reaches end-of-life.

For the best compatibility, choose a long-term release (LTS) version.

## Unsupported releases

The following versions of .NET Core are ❌ no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

These unsupported versions aren't detailed in the sections below and your mileage may vary if you try to install them.

## Alpine

There are no installers for Alpine. You must either use the [install script](linux-alpine.md#scripted-install) or follow the [manual install](linux-alpine.md#manual-install) instructions.

The following table is a list of currently supported .NET Core releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://wiki.alpinelinux.org/wiki/Alpine_Linux:Releases).

- A ✔️ indicates that the version of Alpine or .NET Core is still supported.
- A ❌ indicates that the version of Alpine or .NET Core isn't supported on that Alpine release.
- When both a version of Alpine and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| Alpine                      | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview |
|-----------------------------|---------------|---------------|----------------|
| ✔️ [3.12](linux-alpine.md)  | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [3.11](linux-alpine.md)  | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [3.10](linux-alpine.md)  | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [3.9](linux-alpine.md)   | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [3.8](linux-alpine.md)   | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |

For more information, see [Install .NET Core on Alpine](linux-alpine.md).

## CentOS

CentOS 7 uses Yum as a package manager and CentOS 8 uses DNF.

The following table is a list of currently supported .NET Core releases on both CentOS 7 and CentOS 8. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of CentOS is no longer supported.

| CentOS                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|--------------------------|---------------|---------------|----------------|
| ✔️ [8](linux-centos.md#centos-8-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [7](linux-centos.md#centos-7-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

For more information, see [Install .NET Core on CentOS](linux-centos.md).

## Debian

Debian uses APT (Advanced Package Tool) as a package manager.

The following table is a list of currently supported .NET Core releases and the versions of Debian they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Debian reaches end-of-life](https://wiki.debian.org/DebianReleases).

- A ✔️ indicates that the version of Debian or .NET Core is still supported.
- A ❌ indicates that the version of Debian or .NET Core isn't supported on that Debian release.
- When both a version of Debian and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| Debian                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|--------------------------|---------------|---------------|----------------|
| ✔️ [10](linux-debian.md#debian-10-)     | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [9](linux-debian.md#debian-9-)       | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [8](linux-debian.md#debian-8-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |

For more information, see [Install .NET Core on Debian](linux-debian.md).

## Fedora

Fedora uses DNF as its package manager.

The following table is a list of currently supported .NET Core releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

- A ✔️ indicates that the version of Fedora or .NET Core is still supported.
- A ❌ indicates that the version of Fedora or .NET Core isn't supported on that Fedora release.
- When both a version of Fedora and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| Fedora                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|--------------------------|---------------|---------------|----------------|
| ✔️ [32](linux-fedora.md#fedora-32-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [31](linux-fedora.md#fedora-31-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [30](linux-fedora.md#fedora-30-) | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 Preview |
| ❌ [29](linux-fedora.md#fedora-29-) | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 Preview |
| ❌ [28](linux-fedora.md#fedora-28-) | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ❌ [27](linux-fedora.md#fedora-27-) | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |

For more information, see [Install .NET Core on Fedora](linux-fedora.md).

## openSUSE

openSUSE uses zypper as the package manager.

The following table is a list of currently supported .NET Core releases on openSUSE 15. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of openSUSE is no longer supported.

- A ✔️ indicates that the version of openSUSE or .NET Core is still supported.
- A ❌ indicates that the version of openSUSE or .NET Core isn't supported on that openSUSE release.
- When both a version of openSUSE and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| openSUSE                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|----------------------------|---------------|---------------|----------------|
| ✔️ [15](linux-opensuse.md#opensuse-15-)     | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

For more information, see [Install .NET Core on openSUSE](linux-opensuse.md).

## Red Hat

Red Hat Enterprise Linux (RHEL) uses yum (RHEL 7) and DNF (RHEL 8) as the package manager.

The following table is a list of currently supported .NET Core releases on both RHEL 7 and RHEL 8. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of RHEL is no longer supported.

- A ✔️ indicates that the version of RHEL or .NET Core is still supported.
- A ❌ indicates that the version of RHEL or .NET Core isn't supported on that RHEL release.
- When both a version of RHEL and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| RHEL                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|--------------------------|---------------|---------------|----------------|
| ✔️ [8](linux-rhel.md#rhel-8-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [7](linux-rhel.md#rhel-7-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

For more information, see [Install .NET Core on RHEL](linux-rhel.md).

## SLES

SLES uses zypper as the package manager.

The following table is a list of currently supported .NET Core releases on both SLES 12 SP2 and SLES 15. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of SLES is no longer supported.

- A ✔️ indicates that the version of SLES or .NET Core is still supported.
- A ❌ indicates that the version of SLES or .NET Core isn't supported on that SLES release.
- When both a version of SLES and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| SLES                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|------------------------|---------------|---------------|----------------|
| ✔️ [15](linux-sles.md#sles-15-)     | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [12 SP2](linux-sles.md#sles-12-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

For more information, see [Install .NET Core on SLES](linux-sles.md).

## Ubuntu

Ubuntu uses APT (Advanced Package Tool) as a package manager.

The following table represents the support status of Ubuntu and .NET Core.

- A ✔️ indicates that the version of Ubuntu or .NET Core is still supported.
- A ❌ indicates that the version of Ubuntu or .NET Core isn't supported on that Ubuntu release.
- When both a version of Ubuntu and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| Ubuntu                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|--------------------------|---------------|---------------|----------------|
| ✔️ [20.04 (LTS)](linux-ubuntu.md#2004-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [19.10](linux-ubuntu.md#1910-)       | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [19.04](linux-ubuntu.md#1904-)       | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 Preview |
| ❌ [18.10](linux-ubuntu.md#1810-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ✔️ [18.04 (LTS)](linux-ubuntu.md#1804-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [17.10](linux-ubuntu.md#1710-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ❌ [17.04](linux-ubuntu.md#1704-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ❌ [16.10](linux-ubuntu.md#1610-)       | ❌ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ✔️ [16.04 (LTS)](linux-ubuntu.md#1604-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

For more information, see [Install .NET Core on Ubuntu](linux-ubuntu.md).

## Next steps

- [How to check if .NET Core is already installed](how-to-detect-installed-versions.md?pivots=os-linux).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET Core app](../docker/build-container.md).
