---
title: Install .NET on Ubuntu 16.04
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu 16.04.
author: adegeo
ms.author: adegeo
ms.date: 03/01/2023
ms.custom: linux-related-content
---

# Install .NET SDK or .NET Runtime on Ubuntu 16.04

This article discusses how to install .NET on Ubuntu 16.04; Only .NET 6 is supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported versions

The following versions of .NET are supported or available for Ubuntu 16.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 6.0                     | None                     | 6.0, 5.0, 3.1, 3.0, 2.2, 2.1, 2.0 |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Add the Microsoft package repository

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshooting

If you run into issues installing or even running .NET, see [Troubleshooting](linux-ubuntu.md#troubleshooting).

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu55
- libssl1.0.0
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
