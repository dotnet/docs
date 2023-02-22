---
title: .NET and Ubuntu overview
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu.
author: adegeo
ms.author: adegeo
ms.date: 02/17/2023
---

# Install the .NET SDK or the .NET Runtime on Ubuntu

.NET is supported on Ubuntu. This article describes how to install .NET on Ubuntu. When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Ubuntu they're supported on.

| Ubuntu               | Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](#register-the-microsoft-package-repository) |
|----------------------|-------------------------|-----------------------------|---------------------------------------------------------------------------|
| [22.10](linux-ubuntu-2210)       | 7.0, 6.0  | 7.0, 6.0 | 7.0, 6.0, 3.1                                                             |
| [22.04 (LTS)](linux-ubuntu-2204) | 7.0, 6.0  | 6.0      | 7.0, 6.0, 5.0, 3.1                                                        |
| [20.04 (LTS)](linux-ubuntu-2004) | 7.0, 6.0  | None     | 7.0. 6.0, 5.0, 3.1, 2.1                                                   |
| [18.04 (LTS)](linux-ubuntu-1804) | 7.0, 6.0  | None     | 7.0. 6.0, 5.0, 3.1, 2.2, 2.1                                              |
| [16.04 (LTS)](linux-ubuntu-1604) | 6.0       | None     | 6.0, 5.0, 3.1, 3.0, 2.2, 2.1, 2.0                                         |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Deciding how to install .NET

Because .NET is available in the Ubuntu feed, but not every version of .NET nor every version of Ubuntu supports the feed for .NET, you may find that you need to use the Microsoft package repository. It's recommended that you avoid using both feeds for .NET, as this leads to problems when apps try to resolve a specific version of .NET.

I want to install .NET because...

- **I want to run a .NET app in a container, cloud, or continuous-integration scenario, and...**

  - **I'm using Ubuntu 22.10, and I only need .NET 6.0 or .NET 7.0:**

    Install .NET through the Ubuntu feed. For more information, see [Install the .NET SDK or the .NET Runtime on Ubuntu](linux-ubuntu-2204.md).

  - **I'm using Ubuntu 22.04, and I only need .NET 6.0:**

    Install .NET through the Ubuntu feed. For more information, see [Install the .NET SDK or the .NET Runtime on Ubuntu](linux-ubuntu-2204.md)

  - **I'm using a different Ubuntu version or I need an out-of-support .NET version:**

    [Register and install with the Microsoft package repository.](#register-the-microsoft-package-repository)

- **I want to create a .NET app:**

  [Register and install with the Microsoft package repository.](#register-the-microsoft-package-repository)

- **I want to install a preview version:**

  [Register and install with the Microsoft package repository.](#register-the-microsoft-package-repository)

## Register the Microsoft package repository

Based on your version of Ubuntu, the Microsoft package repository contains all versions of .NET that were previously, or currently are, supported. For more information, see [Supported distributions](#supported-distributions). If you want to install a version of .NET that is either unsupported or not available in the Ubuntu feed, you must either use the Microsoft package repository or [install manually](linux-scripted-manual.md).

> [!IMPORTANT]
> Package manager installs are only supported on the **x64** architecture. Other architectures, such as **Arm**, must install .NET by some other means such as with [Snap](../linux-snap.md), an [installer script](../linux-scripted-manual.md#scripted-install), or through a [manual binary installation](../linux-scripted-manual.md#manual-install).

Preview releases are also available in the Microsoft package repository. For more information, see [Install preview versions](#install-preview-versions).

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
# Get Ubuntu version
declare repo_version=$(lsb_release -r -s)

# Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb

# Clean up
rm packages-microsoft-prod.deb

# Update packages
sudo apt update
```

## Install .NET

After you've [registered the Microsoft package repository](#register-the-microsoft-package-repository), you can install .NET through the package manager with the `apt install` command. Use the name of the package you want to install, as a parameter to that command. For example, to install .NET SDK 7.0, use the command `apt install dotnet-sdk-7.0`. The following table lists the currently supported .NET packages:

|| Product      | Type    | Package                  |
|---------|--------------|---------|--------------------------|
| **7.0**    | ASP.NET Core | Runtime | `aspnetcore-runtime-7.0` |
| **7.0**    | .NET         | Runtime | `dotnet-runtime-7.0`     |
| **7.0**    | .NET         | SDK     | `dotnet-sdk-7.0`         |
| **6.0**    | ASP.NET Core | Runtime | `aspnetcore-runtime-6.0` |
| **6.0**    | .NET         | Runtime | `dotnet-runtime-6.0`     |
| **6.0**    | .NET         | SDK     | `dotnet-sdk-6.0`         |

If you want to install an unsupported version of .NET, check the [Supported distributions](#supported-distributions) section to make sure that the specific version of .NET is available in the version of Ubuntu you're using. Then, substitute the version of .NET you want to install. For example, to install ASP.NET Core 2.1, use the package name `aspnetcore-runtime-2.1`.

## Uninstall .NET

TODO

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Use APT to update .NET

When a new patch release is available for .NET, you can simply upgrade it through APT with the following commands:

```bash
sudo apt-get update
sudo apt-get upgrade
```

If you've upgraded your Linux distribution since installing .NET, you may need to reconfigure the Microsoft package repository. Run the installation instructions for your current distribution version to upgrade to the appropriate package repository for .NET updates.

## Troubleshooting

Starting with Ubuntu 22.04 you may run into a situation where it seems only a piece of .NET is available. For example, when you've installed the runtime and the SDK, but when running `dotnet --info` the SDK isn't listed. This can be related to using two different package sources. The official Ubuntu 22.04 and Ubuntu 22.10 package feeds include .NET, but you may have also installed .NET from the Microsoft feeds. For more information about how to fix this problem, see [Troubleshoot .NET errors related to missing files on Linux](linux-package-mixup.md).

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
