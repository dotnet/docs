---
title: Install .NET on Fedora
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Fedora.
author: adegeo
ms.author: adegeo
ms.date: 03/21/2022
---

# Install the .NET SDK or the .NET Runtime on Fedora

.NET is supported on Fedora and this article describes how to install .NET on Fedora. When a Fedora version falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

For more information on installing .NET without a package manager, see one of the following articles:

- [Install the .NET SDK or the .NET Runtime with Snap.](linux-snap.md)
- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)

## Install .NET 6

[!INCLUDE [linux-dnf-install-60](includes/linux-install-60-dnf.md)]

## Install .NET 5

[!INCLUDE [linux-dnf-install-50](includes/linux-install-50-dnf.md)]

## Install .NET Core 3.1

[!INCLUDE [linux-dnf-install-31](includes/linux-install-31-dnf.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

- A ✔️ indicates that the version of Fedora or .NET is still supported.
- A ❌ indicates that the version of Fedora or .NET isn't supported on that Fedora release.
- When both a version of Fedora and a version of .NET have ✔️, that OS and .NET combination is supported.

| .NET Version  | Fedora 35 ✔️ | 34 ✔️ | 33 ❌ | 32 ❌ | 31 ❌ | 30 ❌ | 29 ❌ | 28 ❌ | 27 ❌ |
| ------------  | ---------:    | --:   | --:   | --:    | --:   | --:    | --:   | --:   | --:    |
| .NET 6        | ✔️           | ✔️    | ❌    | ❌    | ❌    |❌      |❌    |❌     |❌     |
| .NET 5        | ✔️           | ✔️    | ✔️    | ✔️    | ❌    |❌      |❌    |❌     |❌     |
| .NET Core 3.1 | ✔️           | ✔️    | ✔️    | ✔️    | ✔️    |✔️      |✔️    |❌     |❌     |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

## Install using the repositories from Microsoft

> [!IMPORTANT] Older versions of Fedora don't contain .NET Core in the default package repositories, and newer versions of Fedora don't contain older versions of .NET Core. This section covers the instalation via Microsoft's repositories, which are available for [Fedora 26 and above](https://packages.microsoft.com/config/fedora). However, you can also install .NET with [snap](linux-snap.md), or through the [_dotnet-install.sh_ script](linux-scripted-manual.md#scripted-install).

01. First, add the Microsoft signing key to your list of trusted keys.

    ```bash
    sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
    ```

02. Next, add the Microsoft package repository. The URL of the repository depends on the version of Fedora running on your system, which is represented by the placeholder `{fedora-version-id}`:

    ```
    https://packages.microsoft.com/config/fedora/{fedora-version-id}/prod.repo
    ```

    The command below adds the repository automatically for any supported version of Fedora:

    ```bash
    sudo wget -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/$(. /etc/os-release && echo $VERSION_ID)/prod.repo
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
