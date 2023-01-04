---
title: Install .NET on Linux distributions
description: Learn about how to install .NET on Linux. .NET is not only available at package.microsoft.com, but also the official package archives for various Linux distributions.
author: adegeo
ms.author: adegeo
ms.date: 11/08/2022
---

# Install .NET on Linux

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

This article details how to install .NET on various Linux distributions either manually, via a package manager, or via a [container](../docker/introduction.md#net-core-images).

## Manual installation

You can install .NET manually in the following ways:

- [Manual install](linux-scripted-manual.md#manual-install)
- [Scripted install](linux-scripted-manual.md#scripted-install)

You may need to install [.NET dependencies](https://github.com/dotnet/core/blob/main/release-notes/7.0/linux-packages.md) if you install .NET manually.

## Packages

.NET is available in [official package archives](https://github.com/dotnet/core/blob/main/linux.md) for various Linux distributions and [packages.microsoft.com](https://packages.microsoft.com/).

- [Alpine](linux-alpine.md)
- [CentOS](linux-centos.md)
- [Debian](linux-debian.md)
- [Fedora](linux-fedora.md)
- [openSUSE](linux-opensuse.md)
- [SLES](linux-sles.md)
- [Snap](linux-snap.md)
- [Ubuntu](linux-ubuntu.md)

.NET is [supported by Microsoft](https://github.com/dotnet/core/blob/main/microsoft-support.md) when downloaded from a Microsoft source. Best effort support is offered from Microsoft when downloaded from elsewhere. You can open issues at [dotnet/core](https://github.com/dotnet/core) if you run into problems.

## Next steps

- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-linux).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).
