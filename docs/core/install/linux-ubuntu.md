---
title: Install .NET on Ubuntu - .NET
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu.
author: adegeo
ms.author: adegeo
ms.date: 01/06/2021
---

# Install the .NET SDK or the .NET Runtime on Ubuntu

.NET is supported on Ubuntu. This article describes how to install .NET on Ubuntu. When an Ubuntu version falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Ubuntu they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Ubuntu reaches end-of-life](https://wiki.ubuntu.com/Releases).

- A ✔️ indicates that the version of Ubuntu or .NET is still supported.
- A ❌ indicates that the version of Ubuntu or .NET isn't supported on that Ubuntu release.
- When both a version of Ubuntu and a version of .NET have ✔️, that OS and .NET combination is supported.

| Ubuntu                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5.0 |
|--------------------------|---------------|---------------|----------------|
| ✔️ [21.04](#2104-)       | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ❌ [20.10](#2010-)       | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ✔️ [20.04 (LTS)](#2004-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ❌ [19.10](#1910-)       | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ❌ [19.04](#1904-)       | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 |
| ❌ [18.10](#1810-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 |
| ✔️ [18.04 (LTS)](#1804-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ❌ [17.10](#1710-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 |
| ❌ [17.04](#1704-)       | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 |
| ❌ [16.10](#1610-)       | ❌ 2.1        | ❌ 3.1        | ❌ 5.0 |
| ✔️ [16.04 (LTS)](#1604-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |

The following versions of .NET are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## 21.04 ✔️

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-50](includes/linux-install-50-apt.md)]

## 20.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-50](includes/linux-install-50-apt.md)]

## 20.04 ✔️

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-50](includes/linux-install-50-apt.md)]

## 19.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-31](includes/linux-install-31-apt.md)]

## 19.04 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-31](includes/linux-install-31-apt.md)]

## 18.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/18.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 18.04 ✔️

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-50](includes/linux-install-50-apt.md)]

## 17.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/17.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 17.04 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/17.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 16.10 ❌

[!INCLUDE [linux-not-supported](includes/linux-not-supported-ubuntu.md)]

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/16.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-21](includes/linux-install-21-apt.md)]

## 16.04 ✔️

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

[!INCLUDE [linux-apt-install-50](includes/linux-install-50-apt.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Use APT to update .NET

When a new patch release is available for .NET, you can simply upgrade it through APT with the following commands:

```bash
sudo apt-get update
sudo apt-get upgrade
```

If you've upgraded your Linux distribution since installing .NET, you may need to reconfigure the Microsoft package repository. Run the installation instructions for your current distribution version to upgrade to the appropriate package repository for .NET updates.

## APT troubleshooting

This section provides information on common errors you may get while using APT to install .NET.

### Unable to find package

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

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

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

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

For .NET apps that use the *System.Drawing.Common* assembly, you also need the following dependency:

- libgdiplus (version 6.0.1 or later)

  > [!WARNING]
  > You can install a recent version of *libgdiplus* by adding the Mono repository to your system. For more information, see <https://www.mono-project.com/download/stable/>.

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
