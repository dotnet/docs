---
title: Install .NET on Alpine
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Alpine.
author: adegeo
ms.author: adegeo
ms.date: 11/07/2025
ms.custom: linux-related-content
---

# Install the .NET SDK or the .NET Runtime on Alpine

.NET is supported on Alpine and this article describes how to install .NET on Alpine. When an Alpine version falls out of support, .NET is no longer supported with that version.

If you're using Docker, consider using [official .NET Docker images](../docker/introduction.md#net-images) instead of installing .NET yourself.

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://alpinelinux.org/releases/).

| Alpine | Supported Version | Available in Package Manager |
|--------|-------------------|------------------------------|
| 3.22   | 10.0, 9.0, 8.0    | 9.0, 8.0                     |
| 3.21   | 9.0, 8.0          | 9.0, 8.0                     |
| 3.20   | 9.0, 8.0          | 8.0, 6.0                     |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install .NET

# [.NET 10](#tab/dotnet10)

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

[!INCLUDE [linux-apk-install-100](includes/linux-install-100-apk.md)]

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-apk-install-90](includes/linux-install-90-apk.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apk-install-80](includes/linux-install-80-apk.md)]

---

## Supported architectures

The following table is a list of currently supported .NET releases and the architecture of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the architecture of [Alpine is supported#](https://alpinelinux.org/releases/). Note that only `x86_64`, `armv7`, `aarch64` is officially supported by Microsoft. Other architectures are supported by the distribution maintainers, and can be installed using the `apk` package manager, if a package is available for that architecture.

| Architecture | .NET 10  | .NET 9            | .NET 8                 |
|--------------|----------|-------------------|------------------------|
| x86_64       | 3.22     | 3.20, 3.21, 3.22  | 3.20, 3.21, 3.22       |
| x86          | None     | None              | None                   |
| aarch64      | 3.22     | 3.20, 3.21, 3.22  | 3.20, 3.21, 3.22       |
| armv7        | 3.22     | 3.20, 3.21, 3.22  | 3.20, 3.21, 3.22       |
| armhf        | None     | None              | None                   |
| s390x        | None     | None              | None                   |
| ppc64le      | None     | None              | None                   |
| riscv64      | None     | None              | None                   |

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

### 3.20+

- ca-certificates
- libgcc
- libssl3
- libstdc++
- zlib (.NET 8 only)
- icu-libs and icu-data-full (unless the .NET app is running in [globalization-invariant mode](../runtime-config/globalization.md#invariant-mode))
- tzdata
- krb5

Use the `apk add` command to install the dependencies.

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
