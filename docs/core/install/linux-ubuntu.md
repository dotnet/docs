---
title: Install .NET on Ubuntu
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu.
author: adegeo
ms.author: adegeo
ms.date: 12/21/2022
---

# Install the .NET SDK or the .NET Runtime on Ubuntu

.NET is supported on Ubuntu. This article describes how to install .NET on Ubuntu. When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Ubuntu they're supported on.

| Ubuntu                 | .NET       |
|------------------------|------------|
| [22.10](#2210)         | 7, 6       |
| [22.04 (LTS)](#2204)   | 7, 6       |
| [20.04 (LTS)](#2004)   | 7, 6       |
| [18.04 (LTS)](#1804)   | 7, 6       |
| [16.04 (LTS)](#1604)   | 6          |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

<!-- COMMENTING OUT UNTIL THE PACKAGE MANAGER FEED IS ACTUALLY READY

## 22.10

> [!WARNING]
> If you've previously installed .NET from `packages.microsoft.com`, you may run into issues swapping to the built in Ubuntu package manager feeds for .NET. For more information, see the [Troubleshoot .NET errors related to missing files on Linux](linux-package-mixup.md),

.NET 7 and .NET 6 are included in the Ubuntu 22.10 package manager feeds.

### Install the SDK

The .NET SDK allows you to develop apps with .NET. If you install the .NET SDK, you don't need to install the corresponding runtime. To install the .NET SDK, run the following commands:

```bash
sudo apt-get update && \
  sudo apt-get install -y dotnet7
```

### Install the runtime

The ASP.NET Core Runtime allows you to run apps that were made with .NET that didn't provide the runtime. The following commands install the ASP.NET Core Runtime, which is the most compatible runtime for .NET. In your terminal, run the following commands:

```bash
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-7.0
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Runtime, which doesn't include ASP.NET Core support: replace `aspnetcore-runtime-7.0` in the previous command with `dotnet-runtime-7.0`:

```bash
sudo apt-get install -y dotnet-runtime-7.0
```

-->

## 22.10

> [!IMPORTANT]
> .NET 7 isn't yet ready in the Ubuntu feed, and is only available via the Microsoft feeds. However, .NET 6 is available in the 22.10 Ubuntu feed. These instructions demonstrate how to install .NET 7 via the Microsoft package manager feed.

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/22.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

> [!NOTE]
> [Ubuntu 22.10 includes OpenSSL 3](https://discourse.ubuntu.com/t/openssl-3-0-transition-plans/24453) as the baseline version. Versions of .NET prior to .NET 6 don't support OpenSSL 3. Microsoft doesn't test or support using OpenSSL 1.x on Ubuntu 22.10. For more information, see [.NET 6 Security Improvements](https://devblogs.microsoft.com/dotnet/announcing-net-6/#security).

## 22.04

> [!WARNING]
> If you've previously installed .NET from `packages.microsoft.com`, you may run into issues swapping to the built in Ubuntu package manager feeds for .NET. For more information, see the [Advisory on installing .NET on Ubuntu](https://github.com/dotnet/core/issues/7699) and [Troubleshoot .NET package mixups](linux-package-mixup.md#whats-going-on).

.NET 6 is included in the Ubuntu 22.04 package manager feeds.

> [!IMPORTANT]
> .NET 7 **isn't** included in the Ubuntu feeds and you must use the [22.04 Microsoft package feed](#2204-microsoft-package-feed).

### Install the SDK

The .NET SDK allows you to develop apps with .NET. If you install the .NET SDK, you don't need to install the corresponding runtime. To install the .NET SDK, run the following commands:

```bash
sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-6.0
```

### Install the runtime

The ASP.NET Core Runtime allows you to run apps that were made with .NET that didn't provide the runtime. The following commands install the ASP.NET Core Runtime, which is the most compatible runtime for .NET. In your terminal, run the following commands:

```bash
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-6.0
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Runtime, which doesn't include ASP.NET Core support: replace `aspnetcore-runtime-6.0` in the previous command with `dotnet-runtime-6.0`:

```bash
sudo apt-get install -y dotnet-runtime-6.0
```

## 22.04 (Microsoft package feed)

> [!IMPORTANT]
> .NET 6 is included in the Ubuntu 22.04 package manager feeds, but .NET 7 isn't. To install .NET 7 you must use the Microsoft package feed. If you've previously installed .NET from the Ubuntu package manager feed, you may run into issues swapping to the Microsoft package manager feed for .NET. For more information, see the [Advisory on installing .NET on Ubuntu](https://github.com/dotnet/core/issues/7699) and [Troubleshoot .NET package mixups](linux-package-mixup.md#whats-going-on).

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

> [!NOTE]
> [Ubuntu 22.04 includes OpenSSL 3](https://discourse.ubuntu.com/t/openssl-3-0-transition-plans/24453) as the baseline version. Versions of .NET prior to .NET 6 don't support OpenSSL 3. Microsoft doesn't test or support using OpenSSL 1.x on Ubuntu 22.10. For more information, see [.NET 6 Security Improvements](https://devblogs.microsoft.com/dotnet/announcing-net-6/#security).

## 20.04

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

## 18.04

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

## 16.04

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Use APT to update .NET

When a new patch release is available for .NET, you can simply upgrade it through APT with the following commands:

```bash
sudo apt-get update
sudo apt-get upgrade
```

If you've upgraded your Linux distribution since installing .NET, you may need to reconfigure the Microsoft package repository. Run the installation instructions for your current distribution version to upgrade to the appropriate package repository for .NET updates.

## Troubleshooting

Starting with Ubuntu 22.04 you may run into a situation where it seems only a piece of .NET is available. For example, when you've installed the runtime and the SDK, but when running `dotnet --info` the SDK isn't listed. This can be related to using two different package sources. The official Ubuntu 22.04 and Ubuntu 22.10 package feeds include .NET, but you may have also installed .NET from the Microsoft feeds. For more information about how to fix this problem, see [Troubleshoot _fxr_, _libhostfxr.so_, and _FrameworkList.xml_ errors](linux-package-mixup.md)

### APT problems

This section provides information on common errors you may get while using APT to install .NET.

#### Unable to find package

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

#### Unable to locate \\ Some packages could not be installed

> [!NOTE]
> This information only applies when .NET is installed from the Microsoft package feed.

[!INCLUDE [package-manager-failed-to-find-deb](includes/package-manager-failed-to-find-deb.md)]

```bash
sudo apt-get install -y gpg
wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
wget https://packages.microsoft.com/config/ubuntu/{os-version}/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
sudo apt-get update && \
  sudo apt-get install -y {dotnet-package}
```

#### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-deb](includes/package-manager-failed-to-fetch-deb.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc1
- libgcc-s1 (for 22.x)
- libgssapi-krb5-2
- libicu55 (for 16.x)
- libicu60 (for 18.x)
- libicu66 (for 20.x)
- libicu70 (for 22.04)
- libicu71 (for 22.10)
- liblttng-ust1 (for 22.x)
- libssl1.0.0 (for 16.x)
- libssl1.1 (for 18.x, 20.x)
- libssl3 (for 22.x)
- libstdc++6
- libunwind8 (for 22.x)
- zlib1g

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
