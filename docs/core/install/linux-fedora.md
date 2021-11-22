---
title: Install .NET on Fedora - .NET
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Fedora.
author: adegeo
ms.author: adegeo
ms.date: 11/15/2021
---

# Install the .NET SDK or the .NET Runtime on Fedora

.NET is supported on Fedora and this article describes how to install .NET on Fedora. When a Fedora version falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

<!-- temporary removal so that it's not duplicating what is in the .NET 6 section
For more information on installing .NET without a package manager, see one of the following articles:

- [Install the .NET SDK or the .NET Runtime with Snap.](linux-snap.md)
- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)
-->

## Install .NET 6

The latest version of .NET that's available in the default package repositories for Fedora is .NET 5. Installing .NET 6 through the default package repositories is coming soon. For now, you'll need to install .NET 6 in one of the following ways:

- [Install the .NET SDK or the .NET Runtime with Snap.](linux-snap.md)
- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)

You can track the .NET 6 for Fedora release through [Red Hat Bugzilla bug #2021763](https://bugzilla.redhat.com/show_bug.cgi?id=2021763).

## Install .NET 5

[!INCLUDE [linux-dnf-install-50](includes/linux-install-50-dnf.md)]

## Install .NET Core 3.1

[!INCLUDE [linux-dnf-install-31](includes/linux-install-31-dnf.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

- A ✔️ indicates that the version of Fedora or .NET is still supported.
- A ❌ indicates that the version of Fedora or .NET isn't supported on that Fedora release.
- When both a version of Fedora and a version of .NET have ✔️, that OS and .NET combination is supported.

| .NET Version  | Fedora 35 ✔️ | 34 ✔️ | 33 ✔️ | 32 ❌ | 31 ❌ | 30 ❌ | 29 ❌ | 28 ❌ | 27 ❌ |
| ------------  | ---------:    | --:   | --:   | --:    | --:   | --:    | --:   | --:   | --:    |
| .NET 6        | ✔️           | ✔️    | ❌    | ❌    | ❌    |❌      |❌    |❌     |❌     |
| .NET 5        | ✔️           | ✔️    | ✔️    | ✔️    | ❌    |❌      |❌    |❌     |❌     |
| .NET Core 3.1 | ✔️           | ✔️    | ✔️    | ✔️    | ✔️    |✔️      |✔️    |❌     |❌     |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

.NET 6 is supported by Fedora, but it's not yet available in the default package manager. For more information, see the [Install .NET 6](#install-net-6) section.

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

## Install on older distributions

Older versions of Fedora don't contain .NET Core in the default package repositories. You can install .NET with [snap](linux-snap.md), through the [_dotnet-install.sh_ script](linux-scripted-manual.md#scripted-install), or use Microsoft's repository to install .NET:

01. First, add the Microsoft signing key to your list of trusted keys.

    ```bash
    sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
    ```

02. Next, add the Microsoft package repository. The source of the repository is based on your version of Fedora.

    | Fedora Version | Package repository |
    | -------------- | ------- |
    | 31             | `https://packages.microsoft.com/config/fedora/31/prod.repo` |
    | 30             | `https://packages.microsoft.com/config/fedora/30/prod.repo` |
    | 29             | `https://packages.microsoft.com/config/fedora/29/prod.repo` |
    | 28             | `https://packages.microsoft.com/config/fedora/28/prod.repo` |
    | 27             | `https://packages.microsoft.com/config/fedora/27/prod.repo` |

    ```bash
    sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/31/prod.repo
    ```

[!INCLUDE [linux-dnf-install-31](./includes/linux-install-31-dnf.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET or .NET Core.

### Unable to find package

For more information on installing .NET without a package manager, see one of the following articles:

- [Install the .NET SDK or the .NET Runtime with Snap.](linux-snap.md)
- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

### Errors related to missing `fxr`, `libhostfxr.so`, or `FrameworkList.xml`

For more information about solving these problems, see [Troubleshoot `fxr`, `libhostfxr.so`, and `FrameworkList.xml` errors](linux-package-mixup.md).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
