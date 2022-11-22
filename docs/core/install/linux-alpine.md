---
title: Install .NET on Alpine
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Alpine.
author: adegeo
ms.author: adegeo
ms.date: 11/22/2022
---

# Install the .NET SDK or the .NET Runtime on Alpine

.NET is supported on Alpine and this article describes how to install .NET on Alpine. When an Alpine version falls out of support, .NET is no longer supported with that version.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

The Alpine package manager supports installing some versions of .NET. If the .NET package is unavailable, you'll need to install .NET in one of the following alternative ways:

- [Install with Snap.](linux-snap.md)
- [Use the .NET install script.](linux-scripted-manual.md#scripted-install)
- [Download and install .NET manually.](linux-scripted-manual.md#manual-install)

## Install .NET 7

[!INCLUDE [linux-apk-install-70](includes/linux-install-70-apk.md)]

## Install .NET 6

[!INCLUDE [linux-apk-install-60](includes/linux-install-60-apk.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://alpinelinux.org/releases/).

| Alpine | .NET      |
|--------|-----------|
| 3.17   | 7, 6      |
| 3.16   | 7, 6, 3.1 |
| 3.15   | 7, 6, 3.1 |
| 3.14   | 6, 3.1    |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Supported architectures

| Architecture     | .NET 6  | .NET 7  |
|------------------|---------|---------|
| x86_64           | ✔️ 3.16 | ✔️ 3.17 |
| x86              | ❌      | ❌      |
| aarch64          | ✔️ 3.16 | ✔️ 3.17 |
| armv7            | ✔️ 3.16 | ✔️ 3.17 |
| armhf            | ❌      | ❌      |
| s390x            | ✔️ 3.17 | ❌      |
| ppc64le          | ❌      | ❌      |
| riscv64          | ❌      | ❌      |

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

.NET on Alpine Linux requires the following dependencies installed:

- icu-libs
- krb5-libs
- libgcc
- libgdiplus (if the .NET app requires the *System.Drawing.Common* assembly)
- libintl
- libssl1.1 (Alpine v3.9 or greater)
- libssl1.0 (Alpine v3.8 or lower)
- libstdc++
- zlib

To install the needed requirements, run the following command:

```bash
apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
```

To install **libgdiplus**, you may need to specify a repository:

```bash
apk add libgdiplus --repository https://dl-3.alpinelinux.org/alpine/edge/testing/
```

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
