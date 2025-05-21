---
title: Install .NET on Fedora
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Fedora.
author: adegeo
ms.author: adegeo
ms.date: 11/01/2024
ms.custom: linux-related-content
ms.topic: install-set-up-deploy
---

# Install the .NET SDK or the .NET Runtime on Fedora

.NET is supported on Fedora and this article describes how to install .NET on Fedora. When a Fedora version falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

For more information on installing .NET without a package manager, see one of the following articles:

- [Install the .NET SDK or the .NET Runtime with a script.](linux-scripted-manual.md#scripted-install)
- [Install the .NET SDK or the .NET Runtime manually.](linux-scripted-manual.md#manual-install)

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Fedora they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Fedora reaches end-of-life](https://fedoraproject.org/wiki/End_of_life).

| Fedora | .NET          |
|--------|---------------|
| 41     | 9.0, 8.0      |
| 40     | 9.0, 8.0      |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-dnf-install-90](includes/linux-install-90-dnf.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-dnf-install-80](includes/linux-install-80-dnf.md)]

---

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

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
