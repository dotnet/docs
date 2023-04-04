---
title: Install .NET on Fedora
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Fedora.
author: adegeo
ms.author: adegeo
ms.date: 12/21/2022
---

# Install the .NET SDK or the .NET Runtime on Fedora

.NET is supported on Fedora and this article describes how to install .NET on Fedora. When a Fedora version falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

For more information on installing .NET without a package manager, see one of the following articles:

- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

| Fedora | .NET      |
|--------|-----------|
| 37     | 7, 6      |
| 36     | 7, 6      |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install .NET 7

[!INCLUDE [linux-dnf-install-70](includes/linux-install-70-dnf.md)]

## Install .NET 6

[!INCLUDE [linux-dnf-install-60](includes/linux-install-60-dnf.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

## Install on older distributions

Older versions of Fedora don't contain .NET Core in the default package repositories. You can install .NET with the [_dotnet-install.sh_ script](linux-scripted-manual.md#scripted-install), or use Microsoft's repository to install .NET:

01. First, add the Microsoft signing key to your list of trusted keys.

    ```bash
    sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
    ```

02. Next, add the Microsoft package repository. The source of the repository is based on your version of Fedora.

    | Fedora Version | Package repository |
    | -------------- | ------- |
    | 35             | `https://packages.microsoft.com/config/fedora/35/prod.repo` |
    | 34             | `https://packages.microsoft.com/config/fedora/34/prod.repo` |
    | 33             | `https://packages.microsoft.com/config/fedora/33/prod.repo` |
    | 32             | `https://packages.microsoft.com/config/fedora/32/prod.repo` |
    | 31             | `https://packages.microsoft.com/config/fedora/31/prod.repo` |
    | 30             | `https://packages.microsoft.com/config/fedora/30/prod.repo` |
    | 29             | `https://packages.microsoft.com/config/fedora/29/prod.repo` |
    | 28             | `https://packages.microsoft.com/config/fedora/28/prod.repo` |
    | 27             | `https://packages.microsoft.com/config/fedora/27/prod.repo` |

    ```bash
    sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/31/prod.repo
    ```

[!INCLUDE [linux-dnf-install-70](./includes/linux-install-70-dnf.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET or .NET Core.

### Unable to find package

For more information on installing .NET without a package manager, see one of the following articles:

- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

### Errors related to missing `fxr`, `libhostfxr.so`, `FrameworkList.xml`, or `/usr/share/dotnet`

For more information about solving these problems, see [Troubleshoot `fxr`, `libhostfxr.so`, and `FrameworkList.xml` errors](linux-package-mixup.md).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
