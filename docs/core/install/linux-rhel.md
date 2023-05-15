---
title: Install .NET on RHEL and CentOS Stream
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Red Hat Enterprise Linux.
author: adegeo
ms.author: adegeo
ms.date: 05/05/2023
---

# Install the .NET SDK or the .NET Runtime on RHEL and CentOS Stream

.NET is supported on Red Hat Enterprise Linux (RHEL). This article describes how to install .NET on RHEL and CentOS Stream.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Register your Red Hat subscription

To install .NET from Red Hat on RHEL, you first need to register using the Red Hat Subscription Manager. If this hasn't been done on your system, or if you're unsure, see the [Red Hat Product Documentation for .NET](https://access.redhat.com/documentation/en-us/net/6.0).

> [!IMPORTANT]
> This doesn't apply to CentOS Stream.

## Supported distributions

The following table is a list of currently supported .NET releases on both RHEL and CentOS Stream. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the Linux distribution is no longer supported.

| Distribution           | .NET      |
| ---------------------- | --------- |
| RHEL 9 (9.1)           | 7, 6      |
| RHEL 8 (8.7)           | 7, 6      |
| RHEL 7                 | 6         |
| CentOS Stream 9        | 7, 6      |
| CentOS Stream 8        | 7, 6      |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## RHEL 9

.NET is included in the AppStream repositories for RHEL 9.

[!INCLUDE [linux-dnf-install-70](includes/linux-install-70-dnf.md)]

## RHEL 8

.NET is included in the AppStream repositories for RHEL 8.

[!INCLUDE [linux-dnf-install-70](includes/linux-install-70-dnf.md)]

## RHEL 7 ❌ .NET 7

.NET 7 isn't officially supported on RHEL 7. To install .NET 7, see [Install .NET on Linux by using an install script or by extracting binaries](linux-scripted-manual.md).

## RHEL 7 ✔️ .NET 6

The following command installs the `scl-utils` package:

```bash
sudo yum install scl-utils
```

### Install the SDK

The .NET SDK allows you to develop apps with .NET. If you install the .NET SDK, you don't need to install the corresponding runtime. To install .NET SDK, run the following commands:

```bash
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install rh-dotnet60 -y
scl enable rh-dotnet60 bash
```

Red Hat does not recommend permanently enabling `rh-dotnet60` because it may affect other programs. If you want to enable `rh-dotnet` permanently, add the following line to your _~/.bashrc_ file.

```bash
source scl_source enable rh-dotnet60
```

### Install the runtime

The .NET Runtime allows you to run apps that were made with .NET that didn't include the runtime. The commands below install the ASP.NET Core Runtime, which is the most compatible runtime for .NET Core. In your terminal, run the following commands.

```bash
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install rh-dotnet60-aspnetcore-runtime-6.0 -y
scl enable rh-dotnet60 bash
```

Red Hat does not recommend permanently enabling `rh-dotnet60` because it may affect other programs. If you want to enable `rh-dotnet60` permanently, add the following line to your _~/.bashrc_ file.

```bash
source scl_source enable rh-dotnet60
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Runtime that doesn't include ASP.NET Core support: replace `rh-dotnet60-aspnetcore-runtime-6.0` in the preceding command with `rh-dotnet60-dotnet-runtime-6.0`.

## CentOS Stream 9 ✔️

.NET is included in the AppStream repositories for CentOS Stream 9.

[!INCLUDE [linux-dnf-install-70](includes/linux-install-70-dnf.md)]

## CentOS Stream 8 ✔️

.NET is included in the AppStream repositories for CentOS Stream 8.

[!INCLUDE [linux-dnf-install-70](includes/linux-install-70-dnf.md)]

## Dependencies

[!INCLUDE [linux-rpm-install-dependencies](includes/linux-rpm-install-dependencies.md)]

## How to install other versions

Consult the [Red Hat documentation for .NET](https://access.redhat.com/documentation/en-us/net/5.0) on the steps required to install other releases of .NET.

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET or .NET Core.

### Errors related to missing `fxr`, `libhostfxr.so`, or `FrameworkList.xml`

For more information about solving these problems, see [Troubleshoot `fxr`, `libhostfxr.so`, and `FrameworkList.xml` errors](linux-package-mixup.md).

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
