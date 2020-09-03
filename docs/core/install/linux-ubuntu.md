---
title: Install .NET Core on Ubuntu - .NET Core
description: Demonstrates the various ways to install .NET Core SDK and .NET Core Runtime on Ubuntu.
author: adegeo
ms.author: adegeo
ms.date: 06/04/2020
---

# Install .NET Core SDK or .NET Core Runtime on Ubuntu

.NET Core is supported on Ubuntu. This article describes how to install .NET Core on Ubuntu. When an Ubuntu version falls out of support, .NET Core is no longer supported with that version. However, these instructions may help you to get .NET Core running on those versions, even though it isn't supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET Core releases and the versions of Ubuntu they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Ubuntu reaches end-of-life](https://wiki.ubuntu.com/Releases).

- A ✔️ indicates that the version of Ubuntu or .NET Core is still supported.
- A ❌ indicates that the version of Ubuntu or .NET Core isn't supported on that Ubuntu release.
- When both a version of Ubuntu and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| Ubuntu                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|--------------------------|---------------|---------------|----------------|
| ✔️ [20.04 (LTS)](#2004-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [19.10](#1910-)       | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [19.04](#1904-)       | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 Preview |
| ❌ [18.10](#1810-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ✔️ [18.04 (LTS)](#1804-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ [17.10](#1710-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ❌ [17.04](#1704-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ❌ [16.10](#1610-)       | ❌ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |
| ✔️ [16.04 (LTS)](#1604-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

The following versions of .NET Core are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## 20.04 ✔️

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-31](includes/linux-install-31-apt.md)]

## 19.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-31](includes/linux-install-31-apt.md)]

## 19.04 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-31](includes/linux-install-31-apt.md)]

## 18.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/18.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 18.04 ✔️

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-31](includes/linux-install-31-apt.md)]

## 17.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/17.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 17.04 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/17.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 16.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/16.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 16.04 ✔️

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-31](includes/linux-install-31-apt.md)]

## APT update SDK or runtime

When a new patch release is available for .NET Core, you can simply upgrade it through APT with the following commands:

```bash
sudo apt-get update
sudo apt-get upgrade
```

## APT troubleshooting

This section provides information on common errors you may get while using APT to install .NET Core.

### Unable to locate \\ Some packages could not be installed

[!INCLUDE [package-manager-failed-to-find-deb](includes/package-manager-failed-to-find-deb.md)]

```bash
sudo apt-get install -y gpg
wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
wget https://packages.microsoft.com/config/ubuntu/{os-version}/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y {dotnet-package}
```

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-deb](includes/package-manager-failed-to-fetch-deb.md)]

## Snap

[!INCLUDE [linux-install-snap](includes/linux-install-snap.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET Core or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu52 (for 14.x)
- libicu55 (for 16.x)
- libicu60 (for 18.x)
- libicu66 (for 20.x)
- libssl1.0.0 (for 14.x, 16.x)
- libssl1.1 (for 18.x, 20.x)
- libstdc++6
- zlib1g

For .NET Core apps that use the *System.Drawing.Common* assembly, you also need the following dependency:

- libgdiplus (version 6.0.1 or later)

  > [!WARNING]
  > You can install a recent version of *libgdiplus* by adding the Mono repository to your system. For more information, see <https://www.mono-project.com/download/stable/>.

## Scripted install

[!INCLUDE [linux-install-scripted](includes/linux-install-scripted.md)]

## Manual install

[!INCLUDE [linux-install-manual](includes/linux-install-manual.md)]

## Next steps

- [Tutorial: Create a console application with .NET Core SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
