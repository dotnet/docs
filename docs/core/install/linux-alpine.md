---
title: Install .NET on Alpine - .NET
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Alpine.
author: adegeo
ms.author: adegeo
ms.date: 01/06/2021
---

# Install the .NET SDK or the .NET Runtime on Alpine

This article describes how to install .NET on Alpine. When an Alpine version falls out of support, .NET is no longer supported with that version. However, these instructions may help you to get .NET running on those versions, even though it isn't supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Install

Installers aren't available for Alpine Linux. You must install .NET in one of the following ways:

- [Snap package](linux-snap.md)
- [Scripted install with _install-dotnet.sh_](linux-scripted-manual.md#scripted-install)
- [Manual binary extraction](linux-scripted-manual.md#manual-install)

## Supported distributions

The following table is a list of currently supported .NET releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://wiki.alpinelinux.org/wiki/Alpine_Linux:Releases).

- A ✔️ indicates that the version of Alpine or .NET is still supported.
- A ❌ indicates that the version of Alpine or .NET isn't supported on that Alpine release.
- When both a version of Alpine and a version of .NET have ✔️, that OS and .NET combination is supported.

| Alpine  | .NET Core 2.1 | .NET Core 3.1 | .NET 5.0 |
|-------- |---------------|---------------|----------------|
| ✔️ 3.13 | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ✔️ 3.12 | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ✔️ 3.11 | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 |
| ✔️ 3.10 | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 |
| ❌ 3.9  | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 |
| ❌ 3.8  | ✔️ 2.1        | ✔️ 3.1        | ❌ 5.0 |

The following versions of .NET are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

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
