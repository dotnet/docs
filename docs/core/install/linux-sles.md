---
title: Install .NET on SUSE Enterprise Linux
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on SUSE Enterprise Linux (SLES).
author: adegeo
ms.author: adegeo
ms.date: 11/11/2024
ms.custom: linux-related-content
---

# Install the .NET SDK or the .NET Runtime on SLES

.NET is supported on SUSE Enterprise Linux (SLES). This article describes how to install .NET on SLES.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

## Supported distributions

The following table is a list of currently supported .NET releases on SLES 15. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of SLES is no longer supported.

| SLES   | .NET     |
|--------|----------|
| 15.6   | 9.0, 8.0 |
| 15.5   | 9.0, 8.0 |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## SLES 15

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/sles/15/packages-microsoft-prod.rpm
```

Currently, the SLES 15 Microsoft repository setup package installs the *microsoft-prod.repo* file to the wrong directory, preventing zypper from finding the .NET packages. To fix this problem, create a symlink in the correct directory.

```bash
sudo ln -s /etc/yum.repos.d/microsoft-prod.repo /etc/zypp/repos.d/microsoft-prod.repo
```

[!INCLUDE [linux-zyp-install-90](includes/linux-install-90-zyp.md)]

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

If the target runtime environment's OpenSSL version is 1.1 or newer, you'll need to install `compat-openssl10`.

Dependencies can be installed with the `zypper install` command. The following snippet demonstrates installing the `krb5` library:

```bash
sudo zypper install krb5
```

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/main/Documentation/self-contained-linux-apps.md).

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
