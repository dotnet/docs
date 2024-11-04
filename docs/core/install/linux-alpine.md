---
title: Install .NET on Alpine
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Alpine.
author: adegeo
ms.author: adegeo
ms.date: 11/01/2024
ms.custom: linux-related-content
---

# Install the .NET SDK or the .NET Runtime on Alpine

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

.NET is supported on Alpine and this article describes how to install .NET on Alpine. When an Alpine version falls out of support, .NET is no longer supported with that version.

If you're using Docker, consider using [official .NET Docker images](../docker/introduction.md#net-images) instead of installing .NET yourself.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Install .NET

[!INCLUDE [linux-apk-install-80](includes/linux-install-80-apk.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://alpinelinux.org/releases/).

| Alpine | Supported Version | Available in Package Manager |
|--------|-------------------|------------------------------|
| 3.20   | 8.0, 6.0          | 8.0, 6.0                     |
| 3.19   | 8.0, 6.0          | 7.0, 6.0                     |
| 3.18   | 8.0, 6.0          | 7.0, 6.0                     |
| 3.17   | 8.0, 6.0          | 7.0, 6.0                     |

> [!IMPORTANT]
> Alpine 3.17 reaches end-of-life on November 22, 2024.

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Supported architectures

The following table is a list of currently supported .NET releases and the architecture of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the architecture of [Alpine is supported#](https://alpinelinux.org/releases/). Note that only `x86_64`, `armv7`, `aarch64` is officially supported by Microsoft. Other architectures are supported by the distribution maintainers, and can be installed using the `apk` package manager.

| Architecture     | .NET 6           | .NET 8  |
|------------------|------------------|---------|
| x86_64           | 3.17, 3.18, 3.19, 3.20 | 3.17, 3.18, 3.19, 3.20 |
| x86              | None             | None       |
| aarch64          | 3.17, 3.18, 3.19, 3.20 | 3.17, 3.18, 3.19, 3.20 |
| armv7            | 3.17, 3.18, 3.19, 3.20 | 3.17, 3.18, 3.19, 3.20 |
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

### 3.18+

- ca-certificates-bundle
- libgcc
- libssl3
- libstdc++
- zlib
- libgdiplus (if the .NET app requires the *System.Drawing.Common* assembly)

### 3.15 - 3.17

- icu-libs
- krb5-libs
- libgcc
- libintl
- libssl3
- libstdc++
- zlib
- libgdiplus (if the .NET app requires the *System.Drawing.Common* assembly)

Use the `apk add` command to install the dependencies.

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

To install `libgdiplus`, run:

```bash
apk add libgdiplus
```

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
