---
title: Install .NET on Linux distributions
description: Learn about how .NET is available on Linux. .NET can be installed through a package manager, a snap package, or manually.
author: adegeo
ms.author: adegeo
ms.custom: updateeachrelease, linux-related-content
ms.date: 12/15/2023
---

# Install .NET on Linux

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

This article describes how .NET is available on various Linux distributions. .NET can be installed by a package manager, snap, or manually. .NET is also available as a [container image](../docker/introduction.md#net-images).

## Packages

.NET is available in [official package archives](https://github.com/dotnet/core/blob/main/linux.md) for various Linux distributions and [packages.microsoft.com](https://packages.microsoft.com/).

- [Alpine](linux-alpine.md)
- [CentOS](linux-centos.md)
- [Debian](linux-debian.md)
- [Fedora](linux-fedora.md)
- [openSUSE](linux-opensuse.md)
- [SLES](linux-sles.md)
- [Ubuntu](linux-ubuntu.md)

.NET is [supported by Microsoft](https://github.com/dotnet/core/blob/main/microsoft-support.md) when downloaded from a Microsoft source. Best effort support is offered from Microsoft when downloaded from elsewhere. You can open issues at [dotnet/core](https://github.com/dotnet/core) if you run into problems.

## Snap

.NET SDK snap packages are provided by and maintained by Canonical. Snaps are a great alternative to the package manager built into your Linux distribution.

- [Install .NET Runtime with Snap](linux-snap-runtime.md)
- [Install .NET SDK with Snap](linux-snap-sdk.md)

## Manual installation

You can install .NET manually in the following ways:

- [Manual install](linux-scripted-manual.md#manual-install)
- [Scripted install](linux-scripted-manual.md#scripted-install)

You may need to install [.NET dependencies](https://github.com/dotnet/core/blob/main/release-notes/8.0/linux-packages.md) if you install .NET manually.
