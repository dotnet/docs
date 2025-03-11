---
title: Install .NET on Linux distributions
description: Learn about how .NET is available on Linux. .NET can be installed through a package manager, a snap package, or manually.
author: adegeo
ms.author: adegeo
ms.custom: updateeachrelease, linux-related-content
ms.date: 11/04/2024
---

# Install .NET on Linux

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

This article describes how .NET is available on various Linux distributions. .NET can be installed by a package manager, snap, or manually. .NET is also available as a [container image](../docker/introduction.md#net-images).

## Packages

Packages are available for the following Linux distributions:

- Azure Linux
- [Debian](linux-debian.md)
- [openSUSE Leap](linux-opensuse.md)
- [SUSE Enterprise Linux](linux-sles.md)

Packages are published in the Microsoft package repository at <https://packages.microsoft.com/>. Distributions are selected per the policy defined at [dotnet/core #9556](https://github.com/dotnet/core/discussions/9556).

The following Linux distributions publish their own .NET packages:

- [Alpine](linux-alpine.md)
- [CentOS Stream](linux-rhel.md#centos-stream-9)
- [Fedora](linux-fedora.md)
- [Red Hat Enterprise Linux (RHEL)](linux-rhel.md)
- [Ubuntu](linux-ubuntu.md)

## Snap

.NET SDK snap packages are provided by and maintained by Canonical. Snaps are a great alternative to the package manager built into your Linux distribution.

- [Install .NET Runtime with Snap](linux-snap-runtime.md)
- [Install .NET SDK with Snap](linux-snap-sdk.md)

## Manual installation

You can install .NET manually in the following ways:

- [Manual install](linux-scripted-manual.md#manual-install)
- [Scripted install](linux-scripted-manual.md#scripted-install)

You might need to install [.NET dependencies](https://github.com/dotnet/core/blob/main/release-notes/8.0/linux-packages.md) if you install .NET manually.

## Additional sources

.NET is also available from other sources. The packages and containers use a name similar to one of the following names:

- aspnet-runtime
- dotnet-runtime
- dotnet-sdk
- dotnet

### Package managers

- <https://formulae.brew.sh/cask/dotnet>
- <https://formulae.brew.sh/cask/dotnet-sdk>
- <https://ports.macports.org/port/dotnet-cli>
- <https://search.nixos.org/packages?query=dotnet>
- <https://archlinux.org>
- <https://aur.archlinux.org>

### Containers

- <https://containers.dev/features>
- <https://images.chainguard.dev>
