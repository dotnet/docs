---
title: Install .NET on Ubuntu 22.04
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu 22.04.
author: adegeo
ms.author: adegeo
ms.date: 03/01/2023
---

# Install .NET SDK or .NET Runtime on Ubuntu 22.04

This article discusses how to install .NET on Ubuntu 22.04; .NET 6 and .NET 7 are supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

.NET is available in the Ubuntu package manager feeds, as well as the Microsoft package repository. However, you should only one use or the other to install .NET. If you want to use the Microsoft package repository, see [How to register the Microsoft package repository](linux-ubuntu.md#register-the-microsoft-package-repository).

## Supported versions

The following versions of .NET are supported or available for Ubuntu 22.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 7.0, 6.0                | 6.0                      | 7.0, 6.0, 3.1                     |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install .NET 7

.NET 7 packages aren't available in the Ubuntu package manager feeds. You must use the Microsoft package repository.

> [!WARNING]
> If you've previously installed .NET 6 from the Ubuntu feed, you'll run into issues installing .NET 7 from the Microsoft package repository. .NET is installed to different locations and is resolved differently for both package feeds. It's recommended that you uninstall .NET 6 and then install with the Microsoft package repository.
>
> For more information about how to clean your system and install .NET 7, see [I need a version of .NET that isn't provided by my Linux distribution](linux-package-mixup.md#i-need-a-version-of-net-that-isnt-provided-by-my-linux-distribution?pivots=os-linux-ubuntu).

## Install .NET 6

This section describes how to install .NET 6.

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
