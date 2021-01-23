---
title: Install .NET on Arch Linux - .NET
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Arch Linux.
author: josedr120
ms.author: josedr120
ms.date: 01/22/2021
---

# Install the .NET SDK or the .NET Runtime on Arch Linux

.NET is supported on Arch Linux and this article describes how to install .NET on Arch Linux. When a Arch Linux version falls out of support, .NET is no longer supported with that version.

## Install .NET 5.0

**Arch Linux**

*Note: Youll need AUR helpers to install. Ej. (yay, pacaur, trizen, etc...)\

*Note: On this guide is using yay helper. Search for your respective helper.

```bash
yay -S dotnet-sdk-bin dotnet-runtime-bin dotnet-host-bin dotnet-targeting-pack-bin
```

## Install .NET Core 3.1

The latest version of .NET available in the default package repositories for Arch Linux is .NET Core 3.1.

**Arch Linux**

```bash
sudo pacman -S dotnet-sk dotnet-runtime dotnet-host dotnet-targeting-pack
```

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Arch Linux they're supported on.

- A ✔️ indicates that the version of Arch Linux or .NET is still supported.
- A ❌ indicates that the version of Arch Linux or .NET isn't supported on that Arch Linux release.
- When both a version of Arch Linux and a version of .NET have ✔️, that OS and .NET combination is supported.

| .NET Version  | Community ✔️ | AUR ✔️
| ------------  | ---------: | --: |
| .NET 5.0      | ✔️        | ✔️ | ✔️|
| .NET Core 3.1 | ✔️        | ✔️ | ✔️|
| .NET Core 2.1 | ❌        | ✔️ | ✔️|

The following versions of .NET are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
