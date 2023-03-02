---
title: Install .NET on Ubuntu 22.04
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu 22.04.
author: adegeo
ms.author: adegeo
ms.date: 02/17/2022
---

# Install the .NET SDK or the .NET Runtime on Ubuntu

This article discusses how to install .NET on Ubuntu 22.04; .NET 6 and .NET 7 are supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

.NET is available in the Ubuntu package manager feeds, as well as the Microsoft package repository. However, you should only one use or the other to install .NET. If you want to use the Microsoft package repository, see [How to register the Microsoft package repository](linux-ubuntu.md#register-the-microsoft-package-repository).

## Install .NET 7

.NET 7 packages aren't available in the Ubuntu package manager feeds. You must use the Microsoft package repository. If you've previously installed .NET 6 with the Ubuntu feed, you'll run into a conflict trying to install .NET 7. Instead, do the following:

01. Remove the .NET packages from your system.
01. Add the Microsoft package repository.
01. Install .NET

## Install .NET 6 SDK

The only version of .NET available in the default Ubuntu package feed is .NET 6. If you want to use other .NET version in addition to .NET 6, you should install .NET 6 and any other version you want, from the Microsoft package repository.

While .NET 7 is supported on Ubuntu 22.04, it's not available in the Ubuntu package manager feeds. You can only install it through the Microsoft package repository.

> [!WARNING]
> If you've previously installed .NET 6 from the Ubuntu feed, you'll run into issues installing .NET 7 from the Microsoft package repository. .NET is installed to different locations and is resolved differently for both package feeds. It's recommended that you uninstall .NET 6 and then install with the Microsoft package repository.

For more information about installing .NET from the Microsoft package repository, see [How to register the Microsoft package repository](linux-ubuntu.md#register-the-microsoft-package-repository).

## Install .NET 6 Runtime

While .NET 6 is supported on Ubuntu 22.04, it's not available in the Ubuntu package manager feeds. You can only install it through the Microsoft package repository.

> [!WARNING]
> If you've previously installed .NET 6 from the Ubuntu feed, you'll run into issues installing .NET 7 from the Microsoft package repository. .NET is installed to different locations and is resolved differently for both package feeds. It's recommended that you uninstall .NET 6 and then install with the Microsoft package repository.

For more information about installing .NET from the Microsoft package repository, see [How to register the Microsoft package repository](linux-ubuntu.md#register-the-microsoft-package-repository).

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

## How to install other versions

Other versions of .NET aren't supported in the Ubuntu feeds. Instead, use the Microsoft package repository.

## Troubleshooting

If you run into issues installing or even running .NET, see [Troubleshooting](linux-ubuntu.md#troubleshooting).

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc1
- libgcc-s1
- libgssapi-krb5-2
- libicu71
- liblttng-ust1
- libssl3
- libstdc++6
- libunwind8
- zlib1g

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
