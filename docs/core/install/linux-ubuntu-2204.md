---
title: Install .NET on Ubuntu 22.04
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu 22.04.
author: adegeo
ms.author: adegeo
ms.date: 05/24/2023
---

# Install .NET SDK or .NET Runtime on Ubuntu 22.04

This article discusses how to install .NET on Ubuntu 22.04; .NET 6 and .NET 7 are supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

.NET is available in the Ubuntu package manager feeds, as well as the Microsoft package repository. However, you should only use one or the other to install .NET. If you want to use the Microsoft package repository, see [How to register the Microsoft package repository](linux-ubuntu.md#register-the-microsoft-package-repository).

## Supported versions

The following versions of .NET are supported or available for Ubuntu 22.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 7.0, 6.0                | 7.0, 6.0                 | 7.0, 6.0, 3.1                     |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install .NET

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

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
- libicu70
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
