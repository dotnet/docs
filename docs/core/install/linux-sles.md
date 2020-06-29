---
title: Install .NET Core on SLES - .NET Core
description: Demonstrates the various ways to install .NET Core SDK and .NET Core Runtime on SLES.
author: adegeo
ms.author: adegeo
ms.date: 06/04/2020
---

# Install .NET Core SDK or .NET Core Runtime on SLES

.NET Core is supported on SLES. This article describes how to install .NET Core on SLES.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Supported distributions

The following table is a list of currently supported .NET Core releases on both SLES 12 SP2 and SLES 15. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of SLES is no longer supported.

- A ✔️ indicates that the version of SLES or .NET Core is still supported.
- A ❌ indicates that the version of SLES or .NET Core isn't supported on that SLES release.
- When both a version of SLES and a version of .NET Core have ✔️, that OS and .NET combination are supported.

| SLES                   | .NET Core 2.1 | .NET Core 3.1 | .NET 5 Preview (manual install only) |
|------------------------|---------------|---------------|----------------|
| ✔️ [15](#sles-15-)     | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |
| ✔️ [12 SP2](#sles-12-) | ✔️ 2.1        | ✔️ 3.1        | ✔️ 5.0 Preview |

The following versions of .NET Core are no longer supported. The downloads for these still remain published:

- 3.0
- 2.2
- 2.0

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## SLES 15 ✔️

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/sles/15/packages-microsoft-prod.rpm
```

Currently, the SLES 15 Microsoft repository setup package installs the *microsoft-prod.repo* file to the wrong directory, preventing zypper from finding the .NET Core packages. To fix this problem, create a symlink in the correct directory.

```bash
sudo ln -s /etc/yum.repos.d/microsoft-prod.repo /etc/zypp/repos.d/microsoft-prod.repo
```

[!INCLUDE [linux-zyp-install-31](includes/linux-install-31-zyp.md)]

## SLES 12 ✔️

.NET Core requires SP2 as a minimum for the SLES 12 family.

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/sles/12/packages-microsoft-prod.rpm
```

[!INCLUDE [linux-zyp-install-31](includes/linux-install-31-zyp.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET Core.

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET Core or you publish a self-contained app, you'll need to make sure these libraries are installed:

- krb5
- libicu
- libopenssl1_1

If the target runtime environment's OpenSSL version is 1.1 or newer, you'll need to install **compat-openssl10**.

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md).

For .NET Core apps that use the *System.Drawing.Common* assembly, you'll also need the following dependency:

- [libgdiplus (version 6.0.1 or later)](https://www.mono-project.com/docs/gui/libgdiplus/)

  > [!WARNING]
  > You can install a recent version of *libgdiplus* by adding the Mono repository to your system. For more information, see <https://www.mono-project.com/download/stable/>.

## Scripted install

[!INCLUDE [linux-install-scripted](includes/linux-install-scripted.md)]

## Manual install

[!INCLUDE [linux-install-manual](includes/linux-install-manual.md)]

## Next steps

- [Tutorial: Create a console application with .NET Core SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
