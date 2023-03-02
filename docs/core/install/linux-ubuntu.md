---
title: .NET and Ubuntu overview
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu.
author: adegeo
ms.author: adegeo
ms.date: 02/17/2023
---

# Install the .NET SDK or the .NET Runtime on Ubuntu

This article describes how to install .NET on Ubuntu. For each version of Ubuntu, the Microsoft package repository contains every version of .NET that is currently, or was previously, supported. Some versions of Ubuntu contain .NET in the Ubuntu package feed. For more information about available versions, see the [Supported distributions](#supported-distributions) section.

> [!WARNING]
> It's recommended that you avoid using both feeds for .NET, as this leads to problems when apps try to resolve a specific version of .NET. Mixing the package feeds for .NET is an advanced scenario, and is covered in [Troubleshoot .NET errors related to missing files on Linux - Solutions](linux-package-mixup.md).

| Method | Pros | Cons |
|--------|------|------|
| [Package manager<br>(Microsoft feed)*](#register-the-microsoft-package-repository) | <ul><li>Supported versions always available.</li><li>Preview releases are available.</li><li>Patches are available right way.</li><li>Dependencies are included.</li><li>Easy removal.</li></ul> | <ul><li>Requires registering the Microsoft package repository.</li><li>Only supports x64 Ubuntu.</li></ul> |
| [Package manager<br>(Ubuntu feed)](#supported-distributions) | <ul><li>Usually the latest version is available.</li><li>Patches are available right way.</li><li>Dependencies are included.</li><li>Easy removal.</li></ul> | <ul><li>.NET versions available vary by Ubuntu version.</li><li>Preview releases aren't available.</li><li>Only supports x64 Ubuntu.</li></ul> |
| [Snap](../linux-snap.md) | <ul><li>Dependencies are included.</li><li>All supported CPU architectures available.</li><li>Easy to update to the latest patch version.</li><li>Easy removal.</li></ul> | <ul><li>Cumbersome to install and enable multiple runtimes.</li></ul> |
| [Script \ Manual extraction](linux-scripted-manual.md) | <ul><li>Control where .NET is installed.</li></ul> | <ul><li>Manually install updates.</li><li>Manually install dependencies.</li><li>Manual removal.</li></ul> |

\* This is the recommended installation method for end-users and developers.

## Decide how to install .NET

I want to install .NET because...

- **I want to create a .NET app:**

  We recommend you use APT and the Microsoft package repository. For more information, see the [Register and install with the Microsoft package repository](#register-the-microsoft-package-repository) section.

- **I want to run a .NET app in a container, cloud, or continuous-integration scenario:**

  If your Ubuntu version provides the .NET version you require, install it from the built-in feed. Otherwise, [register the Microsoft package repository](#register-the-microsoft-package-repository) and install .NET from that repository. Review the information in the [supported distributions](#supported-distributions) section.

  If the version of .NET you want isn't available, try using [dotnet-install script](linux-scripted-manual.md#scripted-install) or a [Snap](../linux-snap.md) package.

- **I want to run a .NET app, and...**

  - **I'm using Ubuntu 22.10, and I only need .NET 6.0 or .NET 7.0:**

    Install .NET through the Ubuntu feed. For more information, see [Install .NET on Ubuntu 22.04](linux-ubuntu-2204.md) and [Install .NET on Ubuntu 22.10](linux-ubuntu-2210.md).

  - **I'm using Ubuntu 22.04, and I only need .NET 6.0:**

    Install .NET through the Ubuntu feed. For more information, see [Install .NET on Ubuntu 22.04](linux-ubuntu-2204.md).

  - **I'm using Ubuntu 22.04, and I need .NET 7.0:**

    We recommend you use APT and the Microsoft package repository. For more information, see the [Register and install with the Microsoft package repository](#register-the-microsoft-package-repository) section.

  - **I'm using a different Ubuntu version or I need an out-of-support .NET version:**

    We recommend you use APT and the Microsoft package repository. For more information, see the [Register and install with the Microsoft package repository](#register-the-microsoft-package-repository) section.

- **I want to install a preview version:**

  We recommend you use APT and the Microsoft package repository. For more information, see the [Register and install with the Microsoft package repository](#register-the-microsoft-package-repository) section.

- **I don't want to use APT:**

  - **I want an automated install:**

    There are two ways to install .NET, use the [Snap packages](linux-snap.md#install-the-net-sdk-or-the-net-runtime-with-snap) or use the [Linux installation script](linux-scripted-manual.md#scripted-install).

  - **I want full control:**

    Download a tarball and manually install .NET. For more information, see [Manual install](linux-scripted-manual.md#manual-install).

- **I'm using an Arm-based CPU:**

  Use one of the following ways to install .NET:

  - [Install .NET with Snap.](../linux-snap.md)
  - [Install .NET with `install-dotnet` script.](../linux-scripted-manual.md#scripted-install)
  - [Manually install .NET](../linux-scripted-manual.md#manual-install)

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Ubuntu they're supported on. Each link goes to the specific Ubuntu version page with specific instructions on how to install .NET for that version of Ubuntu.

<!-- This table is replicated in each individual Ubuntu article, but with only that specific version row listed. Make sure to update those tables. -->

| Ubuntu                              | Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](#register-the-microsoft-package-repository) |
|-------------------------------------|-------------------------|--------------------------|-----------------------------------|
| [22.10](linux-ubuntu-2210.md)       | 7.0, 6.0                | 7.0, 6.0                 | 7.0, 6.0, 3.1                     |
| [22.04 (LTS)](linux-ubuntu-2204.md) | 7.0, 6.0                | 6.0                      | 7.0, 6.0, 3.1                     |
| [20.04 (LTS)](linux-ubuntu-2004.md) | 7.0, 6.0                | None                     | 7.0. 6.0, 5.0, 3.1, 2.1           |
| [18.04 (LTS)](linux-ubuntu-1804.md) | 7.0, 6.0                | None                     | 7.0. 6.0, 5.0, 3.1, 2.2, 2.1      |
| [16.04 (LTS)](linux-ubuntu-1604.md) | 6.0                     | None                     | 6.0, 5.0, 3.1, 3.0, 2.2, 2.1, 2.0 |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Register the Microsoft package repository

The Microsoft package repository contains all versions of .NET that were previously, or currently are, [supported with your version of Ubuntu](#supported-distributions). If the version of .NET you want to install is either unsupported or not available in the Ubuntu feed, use the Microsoft package repository or [install manually](linux-scripted-manual.md).

> [!IMPORTANT]
> Package manager installs are only supported on the **x64** architecture. Other architectures, such as **Arm**, must install .NET by some other means such as with [Snap](../linux-snap.md), an [installer script](../linux-scripted-manual.md#scripted-install), or through a [manual binary installation](../linux-scripted-manual.md#manual-install).

Preview releases are also available in the Microsoft package repository. For more information, see [Install preview versions](#install-preview-versions).

> [!CAUTION]
> We recommend that you only use one repository to manage all of your .NET installs. If you've previously installed .NET with the Ubuntu repository, remove those packages, add the Microsoft package repository, and then install .NET.

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
# Get Ubuntu version
declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi)

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

After you've [registered the Microsoft package repository](#register-the-microsoft-package-repository), or if your version of Ubuntu's default feed supports the .NET package, you can install .NET through the package manager with the `apt install <package-name>` command. Replace `<package-name>` with the name of the .NET package you want to install. For example, to install .NET SDK 7.0, use the command `apt install dotnet-sdk-7.0`. The following table lists the currently supported .NET packages:

|| Product      | Type    | Package                  |
|---------|--------------|---------|--------------------------|
| **7.0**    | ASP.NET Core | Runtime | `aspnetcore-runtime-7.0` |
| **7.0**    | .NET         | Runtime | `dotnet-runtime-7.0`     |
| **7.0**    | .NET         | SDK     | `dotnet-sdk-7.0`         |
| **6.0**    | ASP.NET Core | Runtime | `aspnetcore-runtime-6.0` |
| **6.0**    | .NET         | Runtime | `dotnet-runtime-6.0`     |
| **6.0**    | .NET         | SDK     | `dotnet-sdk-6.0`         |

If you want to install an unsupported version of .NET, check the [Supported distributions](#supported-distributions) section to see if that version of .NET is available. Then, substitute the **version** of .NET you want to install. For example, to install ASP.NET Core 2.1, use the package name `aspnetcore-runtime-2.1`.

> [!TIP]
> If you're not creating .NET apps, install the ASP.NET Core runtime as it includes the .NET runtime as well.

## Uninstall .NET

If you installed .NET through a package manager, uninstall in the same way with the `apt-get remove` command:

```bash
sudo apt-get remove dotnet-sdk-6.0
```

For more information, see [Uninstall .NET](remove-runtime-sdk-versions.md?pivots=os-linux#uninstall-net).

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Use APT to update .NET

If you installed .NET through a package manager, you can upgrade it with the following commands:

```bash
sudo apt-get update
sudo apt-get upgrade
```

> [!TIP]
> If you've upgraded your Linux distribution since installing .NET, you may need to reconfigure the Microsoft package repository. Run the installation instructions for your current distribution version to upgrade to the appropriate package repository for .NET updates.

## Troubleshooting

Starting with Ubuntu 22.04 you may run into a situation where it seems only a piece of .NET is available. For example, when you've installed the runtime and the SDK, but when running `dotnet --info` only the runtime is listed. This can be related to using two different package sources. The built-in Ubuntu 22.04 and Ubuntu 22.10 package feeds include some versions of .NET, but not all, but you may have also installed .NET from the Microsoft feeds. For more information about how to fix this problem, see [Troubleshoot .NET errors related to missing files on Linux](linux-package-mixup.md).

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

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you must install these dependencies to run your app:

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
