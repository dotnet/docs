---
title: Install .NET on Alpine
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Alpine.
author: adegeo
ms.author: adegeo
ms.date: 10/16/2023
---

# Install the .NET SDK or the .NET Runtime on Alpine

.NET is supported on Alpine and this article describes how to install .NET on Alpine. When an Alpine version falls out of support, .NET is no longer supported with that version.

If you're using Docker, consider using [official .NET Docker images](../docker/introduction.md#net-images) instead of installing .NET yourself.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

The Alpine package manager supports installing some versions of .NET. If the .NET package is unavailable, you'll need to install .NET in one of the following alternative ways:

- [Use the .NET install script.](linux-scripted-manual.md#scripted-install)
- [Download and install .NET manually.](linux-scripted-manual.md#manual-install)

## Install .NET 7

[!INCLUDE [linux-apk-install-70](includes/linux-install-70-apk.md)]

## Install .NET 6

[!INCLUDE [linux-apk-install-60](includes/linux-install-60-apk.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://alpinelinux.org/releases/).

| Alpine | Supported Version  | Available in Package Manager |
|--------|--------------------| -----------------------------|
| 3.18   | .NET 7.0, .NET 6.0 | .NET 7.0, .NET 6.0 |
| 3.17   | .NET 7.0, .NET 6.0 | .NET 7.0, .NET 6.0 |
| 3.16   | .NET 7.0, .NET 6.0 | .NET 6.0 |
| 3.15   | .NET 7.0, .NET 6.0 | None |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Supported architectures

The following table is a list of currently supported .NET releases and the architecture of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the architecture of [Alpine is supported#](https://alpinelinux.org/releases/). Note that only `x86_64`, `armv7`, `aarch64` is officially supported by Microsoft. Other architectures are supported by the distribution maintainers, and can be installed using the `apk` package manager.

| Architecture     | .NET 6           | .NET 7  |
|------------------|------------------|---------|
| x86_64           | 3.16, 3.17, 3.18 | 3.17, 3.18 |
| x86              | None             | None       |
| aarch64          | 3.16, 3.17, 3.18 | 3.17, 3.18 |
| armv7            | 3.16, 3.17, 3.18 | 3.17, 3.18 |
| armhf            | None             | None |
| s390x            | 3.17             | 3.17 |
| ppc64le          | None             | None |
| riscv64          | None             | None |

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- icu-libs
- krb5-libs
- libgcc
- libgdiplus (if the .NET app requires the *System.Drawing.Common* assembly)
- libintl
- libssl1.1
- libstdc++
- zlib

To install the needed requirements, run the following command:

```bash
apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
```

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

To install libgdiplus on Alpine 3.16 or newer, run:

```bash
apk add libgdiplus
```

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
