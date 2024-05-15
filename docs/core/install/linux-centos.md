---
title: Install .NET on CentOS Linux
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on CentOS Linux.
author: adegeo
ms.author: adegeo
ms.date: 05/14/2024
ms.custom: linux-related-content
---

# Install the .NET SDK or the .NET Runtime on CentOS Linux

.NET is supported on CentOS Linux. This article describes how to install .NET on CentOS Linux. If you need to install .NET On CentOS Stream, see [Install the .NET SDK or the .NET Runtime on RHEL and CentOS Stream](linux-rhel.md).

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET releases on CentOS Linux 7. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of CentOS Linux is no longer supported.

| CentOS Linux | .NET |
|--------------|------|
| 7            | 6.0  |

> [!WARNING]
> CentOS Linux 8 reached an early End Of Life (EOL) on December 31st, 2021. For more information, see the official [CentOS Linux EOL page](https://www.centos.org/centos-linux-eol/). Because of this, .NET isn't supported on CentOS Linux 8.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## CentOS Linux 7

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
```

### Install the SDK

The .NET SDK allows you to develop apps with .NET. If you install the .NET SDK, you don't need to install the corresponding runtime. To install the .NET SDK, run the following command:

```bash
sudo yum install dotnet-sdk-6.0
```

### Install the runtime

The ASP.NET Core Runtime allows you to run apps that were made with .NET that didn't provide the runtime. The following command installs the ASP.NET Core Runtime, which is the most compatible runtime for .NET. In your terminal, run the following command:

```bash
sudo yum install aspnetcore-runtime-6.0
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Runtime, which doesn't include ASP.NET Core support: replace `aspnetcore-runtime-6.0` in the previous command with `dotnet-runtime-6.0`:

```bash
sudo yum install dotnet-runtime-6.0
```

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
