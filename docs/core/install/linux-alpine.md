---
title: Install .NET Core on Alpine - .NET Core
description: Demonstrates the various ways to install .NET Core SDK and .NET Core Runtime on Alpine.
author: adegeo
ms.author: adegeo
ms.date: 06/04/2020
---

# Install .NET Core SDK or .NET Core Runtime on Alpine

This article describes how to install .NET Core on Alpine. When a Alpine version falls out of support, .NET Core is no longer supported with that version. However, these instructions may help you to get .NET Core running on those versions, even though it isn't supported.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

There are no installers for Alpine. You must either use the [install script](#scripted-install) or follow the [manual install](#manual-install) instructions.

## Supported distributions

The following table is a list of currently supported .NET Core releases and the versions of Alpine they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Alpine reaches end-of-life](https://wiki.alpinelinux.org/wiki/Alpine_Linux:Releases).

- A ✔️ indicates that the version of Alpine or .NET Core is still supported.
- A ❌ indicates that the version of Alpine or .NET Core isn't supported on that Alpine release.
- When both a version of Alpine and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| Alpine                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview |
|--------------------------|---------------|---------------|----------------|
| ✔️ 3.12  | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ 3.11  | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ 3.10  | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ 3.9   | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ❌ 3.8   | ✔️ 2.1        | ❌ 3.1        | ❌ 5.0 Preview |

The following versions of .NET Core are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

## Dependencies

.NET Core on Alpine Linux requires the following dependencies installed:

- icu-libs
- krb5-libs
- libgcc
- libintl
- libssl1.1 (Alpine v3.9 or greater)
- libssl1.0 (Alpine v3.8 or lower)
- libstdc++
- zlib

## Scripted install

[!INCLUDE [linux-install-scripted](includes/linux-install-scripted.md)]

## Manual install

[!INCLUDE [linux-install-manual](includes/linux-install-manual.md)]

## Next steps

- [Tutorial: Create a console application with .NET Core SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
