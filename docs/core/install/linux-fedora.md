---
title: Install .NET on Fedora
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Fedora.
author: adegeo
ms.author: adegeo
ms.date: 11/01/2024
ms.custom: linux-related-content
---

# Install the .NET SDK or the .NET Runtime on Fedora

.NET is supported on Fedora and this article describes how to install .NET on Fedora. When a Fedora version falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

For more information on installing .NET without a package manager, see one of the following articles:

- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

| Fedora | .NET       |
|--------|------------|
| 41     | 9.0, 8.0   |
| 40     | 9.0, 8.0, 6.0   |
| 39     | 8.0, 6.0 |

> [!IMPORTANT]
> Fedora 39 reaches end-of-life on November 12, 2024.
>
> .NET 9 is currently in preview.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install .NET 8

[!INCLUDE [linux-dnf-install-80](includes/linux-install-80-dnf.md)]

## Install .NET 6

[!INCLUDE [linux-dnf-install-60](includes/linux-install-60-dnf.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

## Install on older distributions

Older versions of Fedora don't contain .NET in the default package repositories. You can install .NET with the [_dotnet-install.sh_ script](linux-scripted-manual.md#scripted-install), or use Microsoft's repository to install .NET:

01. First, add the Microsoft signing key to your list of trusted keys.

    ```bash
    sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
    ```

01. Next, add the Microsoft package repository. The source of the repository is based on your version of Fedora.

    | Fedora Version | Package repository |
    | -------------- | ------- |
    | 36             | `https://packages.microsoft.com/config/fedora/36/prod.repo` |
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

01. Use the `sudo dnf install` command to install a .NET package.

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

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
