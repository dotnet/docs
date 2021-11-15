---
title: Install .NET on CentOS - .NET
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on CentOS.
author: adegeo
ms.author: adegeo
ms.date: 11/04/2021
---

# Install the .NET SDK or the .NET Runtime on CentOS

.NET is supported on CentOS. This article describes how to install .NET on CentOS.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET releases on both CentOS 7 and CentOS 8. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of CentOS is no longer supported.

- A ✔️ indicates that the version of CentOS or .NET is still supported.
- A ❌ indicates that the version of CentOS or .NET isn't supported on that CentOS release.
- When both a version of CentOS and a version of .NET have ✔️, that OS and .NET combination is supported.

| CentOS                   | .NET Core 3.1 | .NET 5         | .NET 6       |
|--------------------------|---------------|----------------|----------------|
| ✔️ [7](#centos-7-)       | ✔️ 3.1        | ✔️ 5.0         | ✔️ 6.0         |
| ✔️ [8](#centos-8-)\*     | ✔️ 3.1        | ✔️ 5.0         | ❌ 6.0         |

> [!WARNING]
> \*CentOS 8 will reach an early End Of Life (EOL) on December 31st, 2021. For more information, see the official [CentOS Linux EOL page](https://www.centos.org/centos-linux-eol/). Because of this, .NET 6 won't be supported on CentOS Linux 8.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## CentOS 7 ✔️

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
```

[!INCLUDE [linux-yum-install-60](includes/linux-install-60-yum.md)]

## CentOS 8 ✔️

> [!WARNING]
> \*CentOS 8 will reach an early End Of Life (EOL) on December 31st, 2021. For more information, see the official [CentOS Linux EOL page](https://www.centos.org/centos-linux-eol/). Because of this, .NET 6 won't be supported on CentOS Linux 8.

.NET 5 is available in the default package repositories for CentOS 8.

[!INCLUDE [linux-dnf-install-50](includes/linux-install-50-dnf.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET.

### Unable to find package

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

### Errors related to missing `fxr`, `libhostfxr.so`, or `FrameworkList.xml`

For more information about solving these problems, see [Troubleshoot `fxr`, `libhostfxr.so`, and `FrameworkList.xml` errors](linux-package-mixup.md).

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
