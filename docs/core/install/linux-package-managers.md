---
title: .NET Core and Linux package managers
description: Learn about what Linux distributions support installing .NET Core on Linux through a package manager.
author: thraka
ms.author: adegeo
ms.date: 05/06/2020
---

# .NET Core and Linux package managers

.NET Core is available on different Linux distributions. Most Linux platforms and distributions have a major release each year, and most provide a package manager that is used to install .NET Core. This article describes what is currently supported and which package manager is used.

The rest of this article is a breakdown of each major Linux distribution that .NET Core supports. All .NET Core releases remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the Linux distribution reaches end-of-life.

For the best compatibility, choose a long-term release (LTS) version.

## Ubuntu

Ubuntu uses APT (Advanced Package Tool) as a package manager.

The following table is a list of currently supported .NET Core releases and the versions of Ubuntu they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Ubuntu reaches end-of-life](https://wiki.ubuntu.com/Releases).

| .NET Core | Ubuntu Version (LTS) | Ubuntu non-LTS Version |
|-----------|----------------------|------------------------|
| 2.1 (LTS) | 16.04, 18.04, 20.04  | 19.10                  |
| 3.1 (LTS) | 16.04, 18.04, 20.04  | 19.10                  |

For more information about the required Linux dependencies for .NET Core, see [.NET Core dependencies and requirements](dependencies.md?tabs=netcore31&pivots=os-linux).

For more information, see [Install .NET Core with a package manager on Ubuntu](linux-package-manager-ubuntu.md).

### Unsupported releases

The following table is a list of .NET Core versions no longer supported and the last Ubuntu release they were supported with:

| .NET Core | Ubuntu Version             |
|-----------|----------------------------|
| 3.0       | 16.04, 18.04, 18.10, 19.10 |
| 2.2       | 16.04, 18.04, 18.10        |
| 2.0       | 14.04, 16.04, 18.04        |

## CentOS

todo

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
