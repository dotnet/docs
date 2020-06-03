---
title: .NET Core and Linux package managers
description: Learn about what Linux distributions support installing .NET Core on Linux through a package manager.
author: thraka
ms.author: adegeo
ms.date: 06/01/2020
---

# .NET Core and Linux package managers

.NET Core is available on different Linux distributions. Most Linux platforms and distributions have a major release each year, and most provide a package manager that is used to install .NET Core. This article describes what is currently supported and which package manager is used.

The rest of this article is a breakdown of each major Linux distribution that .NET Core supports. All .NET Core releases remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the Linux distribution reaches end-of-life.

For the best compatibility, choose a long-term release (LTS) version.

## Ubuntu

Ubuntu uses APT (Advanced Package Tool) as a package manager.

The following is a list of currently supported .NET Core releases and the versions of Ubuntu they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Ubuntu reaches end-of-life](https://wiki.ubuntu.com/Releases).

For the best compatibility, choose a long-term release (LTS) version of both Ubuntu and .NET Core.

| .NET Core   | Ubuntu version                                           |
|-------------|----------------------------------------------------------|
| 2.1 (LTS)   | **[16.04 (LTS)](linux-ubuntu.md#1604-)**, **[18.04 (LTS)](linux-ubuntu.md#1804-)**, **[20.04 (LTS)](linux-ubuntu.md#2004-)**, [19.10](linux-ubuntu.md#1910-) |
| 3.1 (LTS)   | **[16.04 (LTS)](linux-ubuntu.md#1604-)**, **[18.04 (LTS)](linux-ubuntu.md#1804-)**, **[20.04 (LTS)](linux-ubuntu.md#2004-)**, [19.10](linux-ubuntu.md#1910-) |
| 5.0 Preview | **[16.04 (LTS)](linux-ubuntu.md#1604-)**, **[18.04 (LTS)](linux-ubuntu.md#1804-)**, **[20.04 (LTS)](linux-ubuntu.md#2004-)**, [19.10](linux-ubuntu.md#1910-) |

For more information, see [Install .NET Core on Ubuntu](linux-ubuntu.md).

### Unsupported releases

The following table is a list of .NET Core versions which are ❌ no longer supported. The downloads for these still remain. The Ubuntu version listed is the *last* LTS release they were supported on:

| .NET Core | Ubuntu version (LTS) |
|-----------|----------------------|
| 3.0       | 16.04, 18.04         |
| 2.2       | 16.04, 18.04         |
| 2.0       | 14.04, 16.04, 18.04  |

For more information, see [Install .NET Core on Ubuntu](linux-ubuntu.md).

## CentOS

CentOS 7 uses Yum as a package manager and CentOS 8 uses DNF.

The following is a list of currently supported .NET Core releases on both CentOS 7 and CentOS 8. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of CentOS is no longer supported.

For the best compatibility, choose a long-term release (LTS) version of .NET Core.

| .NET Core   |
|-------------|
| 2.1 (LTS)   |
| 3.1 (LTS)   |
| 5.0 Preview |

For more information, see [Install .NET Core on CentOS](linux-centos.md).

### Unsupported releases

The following table is a list of .NET Core versions which are ❌ no longer supported. The downloads for these still remain. The Ubuntu version listed is the *last* LTS release they were supported on:

| .NET Core |
|-----------|
| 3.0       |
| 2.2       |
| 2.0       |

For more information, see [Install .NET Core on CentOS](linux-centos.md).

## Debian

todo

## Fedora

todo

## OpenSUSE

todo

## Redhat

todo

## SLES

todo

## See also

todo
