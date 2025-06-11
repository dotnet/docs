---
title: .NET and Ubuntu overview
description: Learn about the ways you can install .NET on Ubuntu, either from the built-in package feed, the .NET backports repository, or the Microsoft repository.
author: adegeo
ms.author: adegeo
ms.date: 03/27/2025
ms.custom: updateeachrelease, linux-related-content
---

# Install .NET on Ubuntu decision guide

This article helps you decide how install .NET on Ubuntu. Starting with Ubuntu 22.04, most supported versions of .NET are available in the built-in Ubuntu feed. The Ubuntu .NET backports package repository contains the remaining supported .NET versions.

Canonical has taken over publishing .NET on Ubuntu. Starting with Ubuntu 22.04, Microsoft no longer distributes .NET for Ubuntu to the Microsoft package repository.

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Ubuntu they're supported on. Each link goes to the specific Ubuntu version page with instructions on how to install .NET for that version of Ubuntu.

<!-- This table is replicated in each individual Ubuntu article, but with only that specific version row listed. Make sure to update those tables. -->

| Ubuntu                                                             | Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>.NET backports<br>Ubuntu feed](#register-the-ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](#register-the-microsoft-package-repository) |
|--------------------------------------------------------------------|-------------------------|--------------------------------------|--------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------|
| [24.10](linux-ubuntu-install.md?pivots=os-linux-ubuntu-2410)       | 9.0, 8.0                | 9.0, 8.0                             | None                                                                                                   | None                                                                         |
| [24.04 (LTS)](linux-ubuntu-install.md?pivots=os-linux-ubuntu-2404) | 9.0, 8.0                | 8.0                                  | 9.0, 7.0, 6.0                                                                                          | None                                                                         |
| [22.04 (LTS)](linux-ubuntu-install.md?pivots=os-linux-ubuntu-2204) | 9.0, 8.0                | 8.0, 7.0, 6.0                        | 9.0                                                                                                    | 8.0, 7.0, 6.0, 3.1                                                           |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) reaches the end of its support period, .NET is no longer supported with that particular Ubuntu version.

Canonical supports .NET versions in the built-in Ubuntu feed for the lifetime of that Ubuntu version, even beyond the Microsoft-provided support lifetime and provides best-effort support for .NET versions in the .NET backports package repository, which does not extend beyond the Microsoft-provided support lifetime.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Considerations when upgrading Ubuntu

Upgrading Ubuntu to 22.04 or later? Consider uninstalling .NET first.

If you used a package manager to install .NET from the Microsoft package repository, you'll end up with a package mix-up problem after upgrading Ubuntu. Now that Canonical publishes .NET to the package feeds for Ubuntu 22.04 (and later versions), the package manager won't know about the previously installed .NET version. The packages can't be upgraded to the latest .NET. First, uninstall them, then reinstall them from the [Ubuntu package repository].

## Decide how to install .NET

When your version of Ubuntu supports .NET through the built-in or .NET backports Ubuntu feed, support for those builds of .NET is provided by Canonical and the builds might be optimized for different workloads. Microsoft provides support for packages in the Microsoft package repository feed.

> [!WARNING]
> It's recommended that you choose between either Ubuntu or Microsoft feeds to source .NET packages. Don't mix .NET packages from multiple package repositories, as this leads to problems when apps try to resolve a specific version of .NET.

| Method | Pros | Cons |
|--------|------|------|
| [Package manager<br>(built-in<br>Ubuntu feed)](#supported-distributions) | <ul><li>Usually the latest version is available.</li><li>Patches are available right way.</li><li>Dependencies are included.</li><li>Easy removal.</li><li>Available .NET versions are supported for the support period of the particular Ubuntu version.</li><li>Support for the IBM System Z platform for .NET 8 on Ubuntu 24.04.</li></ul> | <ul><li>Not available for Ubuntu 16.04, 18.04, 20.04.</li><li>.NET versions available vary by Ubuntu version.</li><li>Preview releases aren't available.</li></ul> |
| [Package manager<br>(.NET backports<br>Ubuntu feed)](#register-the-ubuntu-net-backports-package-repository) | <ul><li>Contains any supported version, which is not contained in the built-in Ubuntu feed.</li><li>Patches are available right way.</li><li>Dependencies are included.</li><li>Easy removal.</li><li>Compatible with built-in Ubuntu feed.</li></ul> | <ul><li>Not available for Ubuntu 16.04, 18.04, 20.04.</li><li>Requires registering the Ubuntu .NET backports package repository.</li><li>Preview releases aren't available.</li></ul> |
| [Package manager<br>(Microsoft feed)](#register-the-microsoft-package-repository) | <ul><li>Supported versions always available.</li><li>Patches are available right way.</li><li>Dependencies are included.</li><li>Easy removal.</li></ul> | <ul><li>Not available for Ubuntu 24.04+.</li><li>Requires registering the Microsoft package repository.</li><li>Preview releases aren't available.</li><li>Only supports x64 Ubuntu.</li></ul> |
| [Script \ Manual extraction](linux-scripted-manual.md) | <ul><li>Control where .NET is installed.</li><li>Preview releases are available.</li></ul> | <ul><li>Manually install updates.</li><li>Manually install dependencies.</li><li>Manual removal.</li></ul> |

Use the following sections to determine how you should install .NET:

- [I'm using Ubuntu 22.04 or later, and I only need .NET](#im-using-ubuntu-2204-or-later-and-i-only-need-net)
- [I'm using a version of Ubuntu prior to 22.04](#im-using-a-version-of-ubuntu-prior-to-2204)
- [I'm using other Microsoft packages, such as `powershell`, `mdatp`, or `mssql`](#im-using-other-microsoft-packages-such-as-powershell-mdatp-or-mssql)
- [I want to create a .NET app](#i-want-to-create-a-net-app)
- [I want to run a .NET app in a container, cloud, or continuous-integration scenario](#i-want-to-run-a-net-app-in-a-container-cloud-or-continuous-integration-scenario)
- [My Ubuntu distribution doesn't include the .NET version I want, or I need an out-of-support .NET version](#my-ubuntu-distribution-doesnt-include-the-net-version-i-want-or-i-need-an-out-of-support-net-version)
- [I want to install a preview version](#i-want-to-install-a-preview-version)
- [I don't want to use APT](#i-dont-want-to-use-apt)
- [I'm using an Arm-based CPU](#im-using-an-arm-based-cpu)
- [I'm using the IBM System Z platform](#im-using-the-ibm-system-z-platform)

### I'm using Ubuntu 22.04 or later, and I only need .NET

If you don't need other Microsoft packages, such as `powershell`, `mdatp`, or `mssql`, install .NET through the Ubuntu feed. For more information, see the following pages:

- [Install .NET on Ubuntu 24.10](linux-ubuntu-install.md?pivots=os-linux-ubuntu-2410).
- [Install .NET on Ubuntu 24.04](linux-ubuntu-install.md?pivots=os-linux-ubuntu-2404).
- [Install .NET on Ubuntu 22.04](linux-ubuntu-install.md?pivots=os-linux-ubuntu-2204).

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

If you're going to install the Microsoft repository to use other Microsoft packages, such as `powershell`, `mdatp`, or `mssql`, you need to deprioritize the .NET packages provided by the Microsoft repository. For instructions on how to deprioritize the packages, see [My Linux distribution provides .NET packages, and I want to use them](linux-package-mixup.md?pivots=os-linux-ubuntu#my-linux-distribution-provides-net-packages-and-i-want-to-use-them).

### I'm using a version of Ubuntu prior to 22.04

Use the instructions in the version-specific section of [Install .NET SDK or .NET Runtime on Ubuntu](linux-ubuntu-install.md?pivots=os-linux-ubuntu-other).

Review the [Supported distributions](#supported-distributions) section for more information about what versions of .NET are supported for your version of Ubuntu. If you're installing a version that isn't supported, see [Register the Microsoft package repository](#register-the-microsoft-package-repository).

### I'm using other Microsoft packages, such as `powershell`, `mdatp`, or `mssql`

If your Ubuntu version supports .NET through an Ubuntu feeds, you must decide which feed should install .NET. The [Supported distributions](#supported-distributions) section provides a table that lists which versions of .NET are available in the package feeds.

If you want to source the .NET packages from an Ubuntu feed, you need to deprioritize the .NET packages provided by the Microsoft repository. For instructions on how to deprioritize the packages, see [My Linux distribution provides .NET packages, and I want to use them](linux-package-mixup.md?pivots=os-linux-ubuntu#my-linux-distribution-provides-net-packages-and-i-want-to-use-them).

### I want to create a .NET app

Use the same package sources for the SDK as you use for the runtime. It is recommended that you install .NET through an Ubuntu feed. If, however you want to install .NET from another source (for example, the [Microsoft package repository](#register-the-microsoft-package-repository) to access higher SDK feature bands), you should uninstall .NET, configure your package manager to ignore .NET packages from the Ubuntu feed and reinstall it from the other source.

Review the other suggestions in the [Decide how to install .NET](#decide-how-to-install-net) section.

### I want to run a .NET app in a container, cloud, or continuous-integration scenario

If your Ubuntu version provides the .NET version you require, install it from an Ubuntu feed. Otherwise, [register the Microsoft package repository](#register-the-microsoft-package-repository) and install .NET from that repository. Review the information in the [Supported distributions](#supported-distributions) section.

If the version of .NET you want isn't available, try using the [dotnet-install script](linux-scripted-manual.md#scripted-install).

### My Ubuntu distribution doesn't include the .NET version I want, or I need an out-of-support .NET version

We recommend you use APT and the Microsoft package repository. For more information, see the [Register and install with the Microsoft package repository](#register-the-microsoft-package-repository) section.

### I want to install a preview version

Use one of the following ways to install .NET:

- [Install .NET with `install-dotnet` script.](linux-scripted-manual.md#scripted-install)
- [Manually install .NET](linux-scripted-manual.md#manual-install)

### I don't want to use APT

If you want an automated installation, use the [Linux installation script](linux-scripted-manual.md#scripted-install).

If you want full control over the .NET installation experience, download a tarball and manually install .NET. For more information, see [Manual install](linux-scripted-manual.md#manual-install).

### I'm using an Arm-based CPU

If your Ubuntu version provides the .NET version you require, install it from the built-in feed. Review the information in the [Supported distributions](#supported-distributions) section.

If the version of .NET you want isn't available, try using one of the following ways to install .NET:

- [Install .NET with `install-dotnet` script.](linux-scripted-manual.md#scripted-install)
- [Manually install .NET](linux-scripted-manual.md#manual-install)

### I'm using the IBM System Z platform

Starting with .NET 8 on Ubuntu 24.04, Canonical supports .NET for the IBM System Z platform. Canonical works on extending the support to other .NET and Ubuntu versions.

Install .NET through the built-in Ubuntu feed. For more information, see the following page:

- [Install .NET 9 on Ubuntu 24.10](linux-ubuntu-install.md?pivots=os-linux-ubuntu-2410&tabs=dotnet9).

## Register a package repository

Depending on your version of Ubuntu, you might need to register either the Ubuntu backports or the Microsoft package repository.

> [!IMPORTANT]
> Make sure you consider the information in the [Decide how to install .NET section](#decide-how-to-install-net).

- [Register the Ubuntu .NET backports package repository](#ubuntu-net-backports-package-repository)
- [Register the Microsoft package repository](#register-the-microsoft-package-repository)

### Ubuntu .NET backports package repository

The Ubuntu .NET backports package repository provides versions of .NET that aren't available in the built-in Ubuntu feed. Canonical maintains the packages contained in this package repository and provides best-effort support, which does not extend beyond the Microsoft-provided support lifetime or the support period of the particular Ubuntu version.

This package repository is supported on Ubuntu 24.04 LTS (Noble Numbat) and Ubuntu 22.04 LTS (Jammy Jellyfish). The [Supported distributions section](#supported-distributions) provides a table that lists which versions of .NET are available in the package feed. For more information, see [Ubuntu .NET backports package repository](https://launchpad.net/~dotnet/+archive/ubuntu/backports).

To add this package repository, run the following commands:

```bash
sudo add-apt-repository ppa:dotnet/backports
sudo apt update
```

#### Register the Ubuntu .NET backports package repository

Open a terminal and run the following command:

```bash
sudo add-apt-repository ppa:dotnet/backports
```

> [!NOTE]
> The Ubuntu .NET backports package repository is compatible with the built-in Ubuntu feed. Therefore you do not need to configure your package manager to ignore .NET packages in the built-in Ubuntu feed.

#### Unregister the Ubuntu .NET backports package repository

If you no longer want to consume packages from the Ubuntu .NET backports package repository you can unregister it. Open a terminal and run the following command:

```bash
sudo add-apt-repository --remove ppa:dotnet/backports
```

> [!IMPORTANT]
> Unregistering the Ubuntu .NET backports package repository does not uninstall any packages.

#### add-apt-repository command not found

The [`add-apt-repository(1)`](https://manpages.ubuntu.com/manpages/noble/en/man1/add-apt-repository.1.html) utility is pre-installed on most Ubuntu installations.

If you receive an error message that the `add-apt-repository` command was not found, you have to install the `software-properties-common` package, which provides this command. Open a terminal and run the following commands:

```bash
sudo apt update
sudo apt install software-properties-common
```

### Register the Microsoft package repository

> [!IMPORTANT]
> This only applies to Ubuntu versions prior to 24.04. Starting with Ubuntu 24.04, Microsoft no longer publishes packages to the Microsoft package repository. Use the  [supported distributions table](#supported-distributions) to determine the best way to install .NET.

The Microsoft package repository contains all versions of .NET that were previously, or are currently, [supported with your version of Ubuntu](#supported-distributions). If your version of Ubuntu provides .NET packages, you'll need to deprioritize the Ubuntu packages and use the Microsoft repository. For instructions on how to deprioritize the packages, see [I need a version of .NET that isn't provided by my Linux distribution](linux-package-mixup.md?pivots=os-linux-ubuntu#i-need-a-version-of-net-that-isnt-provided-by-my-linux-distribution).

> [!IMPORTANT]
> The Microsoft package repository only supports .NET packages that target the **x64** architecture. Other architectures, such as **Arm**, must install .NET by some other means, such as with the [installer script](linux-scripted-manual.md#scripted-install) or by [manual installation](linux-scripted-manual.md#manual-install).

Preview releases are **not** available in the Microsoft package repository. For more information, see [Install preview versions](#install-preview-versions).

> [!CAUTION]
> We recommend that you only use one repository to manage all of your .NET installs. If you've previously installed .NET with the Ubuntu repository, you must clean the system of .NET packages and configure APT to ignore the Ubuntu feeds. For more information about how to do this, see [I need a version of .NET that isn't provided by my Linux distribution](linux-package-mixup.md?pivots=os-linux-ubuntu#i-need-a-version-of-net-that-isnt-provided-by-my-linux-distribution).

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
# Get OS version info which adds the $ID and $VERSION_ID variables
source /etc/os-release

# Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/$ID/$VERSION_ID/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb

# Clean up
rm packages-microsoft-prod.deb

# Update packages
sudo apt update
```

> [!TIP]
> The previous script was written for Ubuntu and might not work if you're using a derived distribution, such as Linux Mint. It's likely that the `$ID` and `$VERSION_ID` variables won't be assigned the correct values, making the URI for the `wget` command invalid. The `$ID` corresponds to the distribution (for example, `ubuntu`), while `$VERSION_ID` maps to the specific version of Ubuntu you want to get packages for, such as 22.04 or 23.10.
>
> For example, on Ubuntu 22.04 `$ID` would be `ubuntu` and `$VERSION_ID` would be `22.04`. The URL would look like:
> `https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb`.
>
> You can use a web browser and navigate to <https://packages.microsoft.com/config/ubuntu/> to see which versions of Ubuntu are available to use as the `$repo_version` value.

## Install, uninstall, or update .NET

The following sections describe how to manage .NET through the package manager.

### Install .NET

Install .NET through the package manager with the `sudo apt install <package-name>` command. Replace `<package-name>` with the name of the .NET package you want to install. For example, to install .NET SDK 9.0, use the command `sudo apt install dotnet-sdk-9.0`. The following table lists the currently supported .NET packages (which [might vary by your Ubuntu version](#supported-distributions)):

|| Product      | Type    | Package                  |
|---------|--------------|---------|--------------------------|
| **9.0**    | ASP.NET Core | Runtime | `aspnetcore-runtime-9.0` |
| **9.0**    | .NET         | Runtime | `dotnet-runtime-9.0`     |
| **9.0**    | .NET         | SDK     | `dotnet-sdk-9.0`         |
| **8.0**    | ASP.NET Core | Runtime | `aspnetcore-runtime-8.0` |
| **8.0**    | .NET         | Runtime | `dotnet-runtime-8.0`     |
| **8.0**    | .NET         | SDK     | `dotnet-sdk-8.0`         |

> [!TIP]
> If you're not creating .NET apps, install the ASP.NET Core runtime as it includes the .NET runtime and also supports ASP.NET Core apps.

Some environment variables affect how .NET is run after it's installed. For more information, see [.NET SDK and CLI environment variables](../tools/dotnet-environment-variables.md#net-sdk-and-cli-environment-variables).

### Uninstall .NET

If you installed .NET through a package manager, uninstall in the same way with the `apt-get remove` command:

```bash
sudo apt-get remove dotnet-sdk-6.0
```

For more information, see [Uninstall .NET](remove-runtime-sdk-versions.md?pivots=os-linux#uninstall-net).

### Update .NET

If you installed .NET through a package manager, you can upgrade the package with the `apt upgrade` command. For example, the following commands upgrade the `dotnet-sdk-9.0` package with the latest version:

```bash
sudo apt update
sudo apt upgrade dotnet-sdk-9.0
```

> [!TIP]
> If you've upgraded your Linux distribution since installing .NET, you may need to reconfigure the Microsoft package repository. Run the installation instructions for your current distribution version to upgrade to the appropriate package repository for .NET updates.

## Manage preview versions

The following sections describe how to install and uninstall preview releases of .NET.

### Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

### Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Troubleshooting

Starting with Ubuntu 22.04, you might run into a situation where it seems only a piece of .NET is available. For example, you've installed the runtime and the SDK, but when you run `dotnet --info` only the runtime is listed. This situation can be related to using two different package sources. The built-in Ubuntu 22.04 and Ubuntu 22.10 package feeds include some versions of .NET, but not all, and you might have also installed .NET from the Microsoft feeds. For more information about how to fix this problem, see [Troubleshoot .NET errors related to missing files on Linux](linux-package-mixup.md?pivots=os-linux-ubuntu#solutions).

### APT problems

This section provides information on common errors you might get while using APT to install .NET.

#### Unable to find package

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

#### Unable to locate \\ Some packages could not be installed

> [!NOTE]
> This information only applies when .NET is installed from the Microsoft package feed.

[!INCLUDE [package-manager-failed-to-find-deb-intro](includes/package-manager-failed-to-find-deb-intro.md)]

If you're using Ubuntu 23.10 or later, try the following commands:

[!INCLUDE [package-manager-failed-to-find-deb-new](includes/package-manager-failed-to-find-deb-new.md)]

If you're using an Ubuntu version prior to 23.10, try the following commands:

[!INCLUDE [package-manager-failed-to-find-deb-classic](includes/package-manager-failed-to-find-deb-classic.md)]

#### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-deb](includes/package-manager-failed-to-fetch-deb.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you must install these dependencies to run your app:

- ca-certificates
- libc6
- libgcc1 (for 16.x and 18.x)
- libgcc-s1 (for 20.x or later)
- libgssapi-krb5-2
- libicu55 (for 16.x)
- libicu60 (for 18.x)
- libicu66 (for 20.x)
- libicu70 (for 22.04)
- libicu72 (for 23.10)
- libicu74 (for 24.04 or later)
- liblttng-ust1 (for 22.x or later)
- libssl1.0.0 (for 16.x)
- libssl1.1 (for 18.x, 20.x)
- libssl3 (for 22.x or later)
- libstdc++6
- libunwind8 (for 22.x or later)
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable Tab completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
