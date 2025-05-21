---
title: Install .NET on openSUSE Leap
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on openSUSE Leap.
author: adegeo
ms.author: adegeo
ms.date: 11/01/2024
ms.custom: linux-related-content
ms.topic: install-set-up-deploy
---

# Install the .NET SDK or the .NET Runtime on openSUSE Leap

.NET is supported on openSUSE Leap. This article describes how to install .NET on openSUSE Leap.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

## Supported distributions

The following table is a list of currently supported .NET releases on openSUSE Leap 15. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of openSUSE Leap is no longer supported.

| openSUSE Leap | .NET     |
|---------------|----------|
| 15.6          | 9.0, 8.0 |
| 15.5          | 9.0, 8.0 |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Install preview versions

[!INCLUDE [preview installs don't support package managers](./includes/linux-install-previews.md)]

## Remove preview versions

[!INCLUDE [package-manager uninstall notice](./includes/linux-uninstall-preview-info.md)]

## openSUSE Leap 15

[!INCLUDE [linux-prep-intro-generic](includes/linux-prep-intro-generic.md)]

```bash
sudo zypper install libicu
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
wget https://packages.microsoft.com/config/opensuse/15/prod.repo
sudo mv prod.repo /etc/zypp/repos.d/microsoft-prod.repo
sudo chown root:root /etc/zypp/repos.d/microsoft-prod.repo
```

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-zyp-install-90](includes/linux-install-90-zyp.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-zyp-install-80](includes/linux-install-80-zyp.md)]

---

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET.

### Unable to find package

[!INCLUDE [linux-install-package-manager-x64-vs-arm](includes/linux-install-package-manager-x64-vs-arm.md)]

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- krb5
- libicu
- libopenssl1_0_0

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
