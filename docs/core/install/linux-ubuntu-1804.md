---
title: Install .NET on Ubuntu 18.04
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu 18.04.
author: adegeo
ms.author: adegeo
ms.date: 02/17/2022
---

# Install the .NET SDK or the .NET Runtime on Ubuntu

This article discusses how to install .NET on Ubuntu 18.04; .NET 6 and .NET 7 are supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Add the Microsoft package repository

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshooting

If you run into issues installing or even running .NET, see [TODO]().

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu60
- libssl1.1
- libstdc++6
- zlib1g

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
