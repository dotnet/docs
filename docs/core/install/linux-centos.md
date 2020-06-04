---
title: Install .NET Core on CentOS - .NET Core
description: Demonstrates the various ways to install .NET Core SDK and .NET Core Runtime on CentOS.
author: thraka
ms.author: adegeo
ms.date: 06/01/2020
---

# Install .NET Core SDK and .NET Core Runtime on CentOS

.NET Core is supported on CentOS. This article describes how to install .NET Core on CentOS.

## Supported distributions

The following is a list of currently supported .NET Core releases on both CentOS 7 and CentOS 8. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of CentOS is no longer supported.

For the best compatibility, choose a long-term release (LTS) version of .NET Core.

| .NET Core   |
|-------------|
| 2.1 (LTS)   |
| 3.1 (LTS)   |
| 5.0 Preview |

The following table is a list of .NET Core versions which are no longer supported. The downloads for these still remain:

| .NET Core |
|-----------|
| 3.0       |
| 2.2       |
| 2.0       |

## Dependencies

CentOS distributions require the following libraries installed:

- lttng-ust
- libcurl
- openssl-libs
- krb5-libs
- libicu
- zlib
- libunwind
- libuuid

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md).

For .NET Core apps that use the *System.Drawing.Common* assembly, you'll also need the following dependency:

- libgdiplus (version 6.0.1 or later)

> [!WARNING]
> Most versions of CentOS use an earlier version of *libgdiplus*. You can install a recent version
> of *libgdiplus* by adding the Mono repository to your system. For more information,
> see <https://www.mono-project.com/download/stable/>.

## CentOS 7 ✔️

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
```

[!INCLUDE [linux-yum-install-31](includes/linux-install-31-yum.md)]

## CentOS 8 ✔️

The packages for .NET Core doesn't require that you prepare the machine like with the CentOS 7 releases. Run the commands below to install .NET Core.

[!INCLUDE [linux-dnf-install-31](includes/linux-install-31-dnf.md)]

## Snap

[!INCLUDE [linux-install-snap](includes/linux-install-snap.md)]

## Scripted install

[!INCLUDE [linux-install-scripted](includes/linux-install-scripted.md)]

## Manual install

[!INCLUDE [linux-install-manual](includes/linux-install-manual.md)]

## Next steps

- [Tutorial: Create a console application with .NET Core using Visual Studio Code](../tutorials/with-visual-studio-code.md)
