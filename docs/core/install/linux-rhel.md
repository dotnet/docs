---
title: Install .NET on RHEL and CentOS Stream
description: Learn about which versions of .NET are supported, and how to install .NET on Red Hat Enterprise Linux and CentOS Stream.
author: adegeo
ms.author: adegeo
ms.date: 12/13/2024
ms.custom: linux-related-content
---

# Install the .NET SDK or the .NET Runtime on RHEL and CentOS Stream

.NET is supported on Red Hat Enterprise Linux (RHEL). This article describes how to install .NET on RHEL and CentOS Stream.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Register your Red Hat subscription

To install .NET from Red Hat on RHEL, you first need to register using the Red Hat Subscription Manager. If this hasn't been done on your system, or if you're unsure, see the [Red Hat Product Documentation for .NET](https://access.redhat.com/documentation/en-us/net/8.0).

> [!IMPORTANT]
> The previous statement doesn't apply to CentOS Stream.

## Supported distributions

The following table is a list of currently supported .NET releases on both RHEL and CentOS Stream. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the Linux distribution is no longer supported.

| Distribution                                                  | .NET     |
|---------------------------------------------------------------|----------|
| [RHEL 9](#rhel-9)                                             | 9.0, 8.0 |
| [RHEL 8](#rhel-8)                                             | 9.0, 8.0 |
| [CentOS Stream 9](#centos-stream-9)                           | 9.0, 8.0 |
| [CentOS Stream 8](#centos-stream-8)                           | 8.0,     |
| [CentOS Linux is no longer supported](#where-is-centos-linux) |          |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## RHEL 9

.NET is included in the [AppStream repositories](https://access.redhat.com/support/policy/updates/rhel-app-streams-life-cycle) for RHEL 9.

[!INCLUDE [linux-dnf-install-90](includes/linux-install-90-dnf.md)]

## RHEL 8

.NET is included in the [AppStream repositories](https://access.redhat.com/support/policy/updates/rhel-app-streams-life-cycle) for RHEL 8.

[!INCLUDE [linux-dnf-install-90](includes/linux-install-90-dnf.md)]

## CentOS Stream 9

.NET is included in the AppStream repositories for CentOS Stream 9.

[!INCLUDE [linux-dnf-install-90](includes/linux-install-90-dnf.md)]

## CentOS Stream 8

Use the Microsoft repository to install .NET:

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/centos/8/packages-microsoft-prod.rpm
sudo yum install dotnet-sdk-8.0
```

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

## Where is CentOS Linux

.NET is no longer supported on CentOS Linux. As of June 30th, 2024, CentOS Linux reached end-of-life. For more information, see [End dates are coming for CentOS Stream 8 and CentOS Linux 7](https://blog.centos.org/2023/04/end-dates-are-coming-for-centos-stream-8-and-centos-linux-7/).

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

## How to install other versions

Consult the [Red Hat documentation for .NET](https://access.redhat.com/documentation/en-us/net/5.0) on the steps required to install other releases of .NET.

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET or .NET Core.

### Errors related to missing `fxr`, `libhostfxr.so`, or `FrameworkList.xml`

For more information about solving these problems, see [Troubleshoot `fxr`, `libhostfxr.so`, and `FrameworkList.xml` errors](linux-package-mixup.md).

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
