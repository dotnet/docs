---
title: Install .NET on Linux distributions
description: Learn about how to install .NET on Linux. .NET is not only available at package.microsoft.com, but also the official package archives for various Linux distributions.
author: adegeo
ms.author: adegeo
ms.date: 03/25/2022
---

# Install .NET on Linux

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

This article details how to install .NET on various Linux distributions, manually and via a package manager. Typically, stable .NET versions are available in a package manager, and Preview versions are not.

See Linux support information for in-support .NET versions:

- [.NET Core 3.1](https://github.com/dotnet/core/blob/main/release-notes/3.1/3.1-supported-os.md#linux)
- [.NET 6](https://github.com/dotnet/core/blob/main/release-notes/6.0/supported-os.md#linux)

## Manual installation

You can install .NET manually in the following ways:

- [Download tarballs](https://dotnet.microsoft.com/download/dotnet)
- [Scripted install](linux-scripted-manual.md#scripted-install)
- [Manual binary extraction](linux-scripted-manual.md#manual-install)

You may need to install [.NET dependencies](https://github.com/dotnet/core/blob/main/release-notes/6.0/linux-packages.md) if you install .NET manually.

## Official package archives

.NET is available in the [official package archives](https://pkgs.org/search/?q=dotnet) for various Linux distributions, including the following ones.

- [Arch Linux](https://archlinux.org/packages/?q=dotnet)
- [Arch Linux User Repository](https://aur.archlinux.org/packages?K=dotnet)
- [Fedora](https://packages.fedoraproject.org/search?query=dotnet)
- [Red Hat Enterprise Linux](https://access.redhat.com/documentation/en-us/net/6.0)

.NET may or may not be supported by Microsoft as published in the official package archives. See Linux support information above. You can still [open issues at dotnet/core](https://github.com/dotnet/core/issues) if you run into problems.

## Microsoft packages

.NET is also available via [packages.microsoft.com](https://packages.microsoft.com/).

- [CentOS](linux-centos.md)
- [Debian](linux-debian.md)
- [Fedora](linux-fedora.md)
- [openSUSE](linux-opensuse.md)
- [SLES](linux-sles.md)
- [Ubuntu](linux-ubuntu.md)

These packages are supported by Microsoft.

You are encouraged to install .NET from the official distribution archive if it is available, even if it is also available at packages.microsoft.com for your distribution.

## Other distributions

Installation information is also provided for other distributions.

- [Alpine](linux-alpine.md)
- [Containers](/dotnet/core/docker/introduction#net-core-images)
- [Snap](linux-snap.md)

## Next steps

- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-linux).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).
