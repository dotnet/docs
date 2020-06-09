---
title: Install .NET Core on openSUSE - .NET Core
description: Demonstrates the various ways to install .NET Core SDK and .NET Core Runtime on openSUSE.
author: thraka
ms.author: adegeo
ms.date: 06/04/2020
---

# Install .NET Core SDK or .NET Core Runtime on openSUSE

.NET Core is supported on openSUSE. This article describes how to install .NET Core on openSUSE.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET Core releases on openSUSE 15. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of openSUSE is no longer supported.

- A ✔️ indicates that the version of openSUSE or .NET Core is still supported.
- A ❌ indicates that the version of openSUSE or .NET Core isn't supported on that openSUSE release.
- When both a version of openSUSE and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| openSUSE                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|----------------------------|---------------|---------------|----------------|
| ✔️ [15](#opensuse-15-)     | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

The following versions of .NET Core are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## openSUSE 15 ✔️

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo zypper install libicu
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
wget https://packages.microsoft.com/config/opensuse/15/prod.repo
sudo mv prod.repo /etc/zypp/repos.d/microsoft-prod.repo
sudo chown root:root /etc/zypp/repos.d/microsoft-prod.repo
```

[!INCLUDE [linux-zyp-install-31](includes/linux-install-31-zyp.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET Core.

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

## Snap

[!INCLUDE [linux-install-snap](includes/linux-install-snap.md)]

## Dependencies

[!INCLUDE [linux-install-dependencies](includes/linux-install-dependencies.md)]

## Scripted install

[!INCLUDE [linux-install-scripted](includes/linux-install-scripted.md)]

## Manual install

[!INCLUDE [linux-install-manual](includes/linux-install-manual.md)]

## Next steps

- [Tutorial: Create a console application with .NET Core SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
