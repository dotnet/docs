---
title: Install .NET on Debian
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Debian.
author: adegeo
ms.author: adegeo
ms.date: 11/01/2024
ms.custom: linux-related-content
---

# Install the .NET SDK or the .NET Runtime on Debian

This article describes how to install .NET on Debian. When a Debian version falls out of support, .NET is no longer supported with that version. However, these instructions may help you to get .NET running on those versions, even though it isn't supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Debian they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Debian reaches end-of-life](https://wiki.debian.org/DebianReleases).

| Debian | .NET    |
|--------|---------|
| 12     | 9, 8    |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Debian 12

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

---

## Use APT to update .NET

When a new patch release is available for .NET, you can simply upgrade it through APT with the following commands:

```bash
sudo apt-get update
sudo apt-get upgrade
```

If you've upgraded your Linux distribution since installing .NET, you may need to reconfigure the Microsoft package repository. Run the installation instructions for your current distribution version to upgrade to the appropriate package repository for .NET updates.

## Troubleshooting

This section provides information on common errors you may get while using APT to install .NET.

### Unable to find package

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

### Unable to locate \\ Some packages could not be installed

[!INCLUDE [package-manager-failed-to-find-deb-intro](includes/package-manager-failed-to-find-deb-intro.md)]

If you're using Debian 12 or later, try the following commands:

[!INCLUDE [package-manager-failed-to-find-deb-new](includes/package-manager-failed-to-find-deb-new.md)]

If you're using a Debian version prior to 12, try the following commands:

[!INCLUDE [package-manager-failed-to-find-deb-classic](includes/package-manager-failed-to-find-deb-classic.md)]

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-deb](includes/package-manager-failed-to-fetch-deb.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

### 12.x

- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu72
- libssl3
- libstdc++6
- zlib1g

### 11.x

- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu67
- libssl1.1
- libstdc++6
- zlib1g

### 10.x

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu63
- libssl1.1
- libstdc++6
- zlib1g

### Other notes

Dependencies can be installed with the `apt install` command. The following snippet demonstrates installing the `libc6` library:

```bash
sudo apt install libc6
```

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-debian).

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
