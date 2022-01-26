---
title: Install .NET on SLES - .NET
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on SLES.
author: adegeo
ms.author: adegeo
ms.date: 11/04/2021
---

# Install the .NET SDK or the .NET Runtime on SLES

.NET is supported on SLES. This article describes how to install .NET on SLES.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Supported distributions

The following table is a list of currently supported .NET releases on both SLES 12 SP2 and SLES 15. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of SLES is no longer supported.

- A ✔️ indicates that the version of SLES or .NET is still supported.
- A ❌ indicates that the version of SLES or .NET isn't supported on that SLES release.
- When both a version of SLES and a version of .NET have ✔️, that OS and .NET combination is supported.

| SLES                   | .NET Core 3.1 | .NET 5   | .NET 6   |
|------------------------|---------------|----------|----------|
| ✔️ [15](#sles-15-)     | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |
| ✔️ [12 SP2](#sles-12-) | ✔️ 3.1        | ✔️ 5.0 | ✔️ 6.0 |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## SLES 15 ✔️

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/sles/15/packages-microsoft-prod.rpm
```

Currently, the SLES 15 Microsoft repository setup package installs the *microsoft-prod.repo* file to the wrong directory, preventing zypper from finding the .NET packages. To fix this problem, create a symlink in the correct directory.

```bash
sudo ln -s /etc/yum.repos.d/microsoft-prod.repo /etc/zypp/repos.d/microsoft-prod.repo
```

[!INCLUDE [linux-zyp-install-60](includes/linux-install-60-zyp.md)]

## SLES 12 ✔️

.NET requires SP2 as a minimum for the SLES 12 family.

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/sles/12/packages-microsoft-prod.rpm
```

[!INCLUDE [linux-zyp-install-60](includes/linux-install-60-zyp.md)]

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET.

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- krb5
- libicu
- libopenssl1_1

If the target runtime environment's OpenSSL version is 1.1 or newer, you'll need to install **compat-openssl10**.

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/main/Documentation/self-contained-linux-apps.md).

For .NET apps that use the *System.Drawing.Common* assembly, you'll also need the following dependency:

- [libgdiplus (version 6.0.1 or later)](https://www.mono-project.com/docs/gui/libgdiplus/)

  > [!WARNING]
  > You can install a recent version of *libgdiplus* by adding the Mono repository to your system. For more information, see <https://www.mono-project.com/download/stable/>.

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
