---
title: Install .NET on RHEL - .NET
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Red Hat Enterprise Linux.
author: adegeo
ms.author: adegeo
ms.date: 01/06/2021
---

# Install the .NET SDK or the .NET Runtime on RHEL

.NET is supported on Red Hat Enterprise Linux (RHEL). This article describes how to install .NET on RHEL.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Register your Red Hat subscription

To install .NET from Red Hat on RHEL, you first need to register using the Red Hat Subscription Manager. If this hasn't been done on your system, or if you're unsure, see the [Red Hat Product Documentation for .NET](https://access.redhat.com/documentation/en-us/net/5.0).

## Supported distributions

The following table is a list of currently supported .NET releases on both RHEL 7 and RHEL 8. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of RHEL is no longer supported.

- A ✔️ indicates that the version of RHEL or .NET is still supported.
- A ❌ indicates that the version of RHEL or .NET isn't supported on that RHEL release.
- When both a version of RHEL and a version of .NET have ✔️, that OS and .NET combination is supported.

| RHEL                     | .NET Core 2.1 | .NET Core 3.1                  | .NET 5.0                   |
| ------------------------ | ------------- | ------------------------------ | -------------------------- |
| ✔️ [8](#rhel-8-)        | ✔️ 2.1        | ✔️ 3.1                         | ✔️ 5.0                    |
| ✔️ [7](#rhel-7--net-50) | ✔️ 2.1        | ✔️ [3.1](#rhel-7--net-core-31) | ✔️ [5.0](#rhel-7--net-50) |

The following versions of .NET are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## RHEL 8 ✔️

.NET is included in the AppStream repositories for RHEL 8.

[!INCLUDE [linux-dnf-install-50](includes/linux-install-50-dnf.md)]

## RHEL 7 ✔️ .NET 5.0

The following command installs the `scl-utils` package:

```bash
sudo yum install scl-utils
```

### Install the SDK

The .NET SDK allows you to develop apps with .NET . If you install the .NET SDK, you don't need to install the corresponding runtime. To install .NET SDK, run the following commands:

```bash
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install rh-dotnet50 -y
scl enable rh-dotnet50 bash
```

Red Hat does not recommend permanently enabling `rh-dotnet50` because it may affect other programs. If you want to enable `rh-dotnet` permanently, add the following line to your _~/.bashrc_ file.

```bash
source scl_source enable rh-dotnet50
```

### Install the runtime

The .NET Runtime allows you to run apps that were made with .NET that didn't include the runtime. The commands below install the ASP.NET Core Runtime, which is the most compatible runtime for .NET Core. In your terminal, run the following commands.

```bash
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install rh-dotnet50-aspnetcore-runtime-5.0 -y
scl enable rh-dotnet50 bash
```

Red Hat does not recommend permanently enabling `rh-dotnet50` because it may affect other programs. If you want to enable `rh-dotnet50` permanently, add the following line to your _~/.bashrc_ file.

```bash
source scl_source enable rh-dotnet50
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Runtime that doesn't include ASP.NET Core support: replace `rh-dotnet50-aspnetcore-runtime-5.0` in the commands above with `rh-dotnet50-dotnet-runtime-5.0`.

## RHEL 7 ✔️ .NET Core 3.1

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

The following command installs the `scl-utils` package:

```bash
sudo yum install scl-utils
```

### Install the SDK

.NET Core SDK allows you to develop apps with .NET Core. If you install .NET Core SDK, you don't need to install the corresponding runtime. To install .NET Core SDK, run the following commands:

```bash
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install rh-dotnet31 -y
scl enable rh-dotnet31 bash
```

Red Hat does not recommend permanently enabling `rh-dotnet31` because it may affect other programs. For example, `rh-dotnet31` includes a version of `libcurl` that differs from the base RHEL version. This may lead to issues in programs that do not expect a different version of `libcurl`. If you want to enable `rh-dotnet` permanently, add the following line to your _~/.bashrc_ file.

```bash
source scl_source enable rh-dotnet31
```

### Install the runtime

The .NET Core Runtime allows you to run apps that were made with .NET Core that didn't include the runtime. The commands below install the ASP.NET Core Runtime, which is the most compatible runtime for .NET Core. In your terminal, run the following commands.

```bash
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install rh-dotnet31-aspnetcore-runtime-3.1 -y
scl enable rh-dotnet31 bash
```

Red Hat does not recommend permanently enabling `rh-dotnet31` because it may affect other programs. For example, `rh-dotnet31` includes a version of `libcurl` that differs from the base RHEL version. This may lead to issues in programs that do not expect a different version of `libcurl`. If you want to enable `rh-dotnet31` permanently, add the following line to your _~/.bashrc_ file.

```bash
source scl_source enable rh-dotnet31
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Core Runtime that doesn't include ASP.NET Core support: replace `rh-dotnet31-aspnetcore-runtime-3.1` in the commands above with `rh-dotnet31-dotnet-runtime-3.1`.

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
