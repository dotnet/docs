---
title: Install .NET on Ubuntu 22.10
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu 22.10.
author: adegeo
ms.author: adegeo
ms.date: 05/24/2023
---

# Install .NET SDK or .NET Runtime on Ubuntu 22.10

This article discusses how to install .NET on Ubuntu 22.10; .NET 6 and .NET 7 are both supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

.NET is available in the Ubuntu package manager feeds, as well as the Microsoft package repository. However, you should only use one or the other to install .NET. If you want to use the Microsoft package repository, see [How to register the Microsoft package repository](linux-ubuntu.md#register-the-microsoft-package-repository).

> [!WARNING]
> Don't use both repositories to manage .NET. If you've previously installed .NET from the Ubuntu feed or the Microsoft feed, you'll run into issues using the other feed. .NET is installed to different locations and is resolved differently for both package feeds. It's recommended that you uninstall previously installed versions of .NET and then install with the Microsoft package repository. For more information, see [How to register the Microsoft package repository](linux-ubuntu.md#register-the-microsoft-package-repository).

## Supported versions

The following versions of .NET are supported or available for Ubuntu 22.10:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 7.0, 6.0                | 7.0, 6.0                 | 7.0, 6.0, 3.1                     |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install .NET

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

## How to install other versions

.NET package names are standardized across all Linux distributions. The following table lists the packages:

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

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

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
