---
title: Install .NET on Ubuntu
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu
author: adegeo
ms.author: adegeo
ms.date: 03/19/2024
zone_pivot_groups: ubuntu-set-one
---

# Install .NET SDK or .NET Runtime on Ubuntu

This article discusses how to install .NET on Ubuntu.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm-ubuntu](includes/linux-install-package-manager-x64-vs-arm-ubuntu.md)]

::: zone pivot="os-linux-ubuntu-2310"

## Ubuntu 23.10

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET are supported or available for Ubuntu 23.10:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 8.0, 7.0, 6.0           | 8.0, 7.0, 6.0            | 8.0, 7.0, 6.0                     |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 7](#tab/dotnet7)

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu72
- liblttng-ust1
- libssl3
- libstdc++6
- libunwind8
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

::: zone-end

::: zone pivot="os-linux-ubuntu-2304"

## Ubuntu 23.04

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET are supported or available for Ubuntu 23.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 8.0, 7.0, 6.0           | 7.0, 6.0                 | 8.0, 7.0, 6.0                     |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-ubuntu-80-ms](includes/linux-ubuntu-80-ms.md)]

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 7](#tab/dotnet7)

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu72
- liblttng-ust1
- libssl3
- libstdc++6
- libunwind8
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

::: zone-end

::: zone pivot="os-linux-ubuntu-2210"

## Ubuntu 22.10

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET are supported or available for Ubuntu 22.10:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 7.0, 6.0                | 7.0, 6.0                 | 7.0, 6.0, 3.1                     |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 8](#tab/dotnet8)

.NET 8 isn't supported on Ubuntu 22.10.

# [.NET 7](#tab/dotnet7)

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu71
- liblttng-ust1
- libssl3
- libstdc++6
- libunwind8
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

::: zone-end

::: zone pivot="os-linux-ubuntu-2204"

## Ubuntu 22.04

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET are supported or available for Ubuntu 22.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 8.0, 7.0, 6.0           | 7.0, 6.0                 | 8.0, 7.0, 6.0, 3.1                |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-ubuntu-80-ms](includes/linux-ubuntu-80-ms.md)]

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 7](#tab/dotnet7)

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu70
- liblttng-ust1
- libssl3
- libstdc++6
- libunwind8
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

::: zone-end

::: zone pivot="os-linux-ubuntu-2004"

## Ubuntu 20.04

[!INCLUDE [linux-ubuntu-package-feed-ms](includes/linux-ubuntu-package-feed-ms.md)]

The following versions of .NET are supported or available for Ubuntu 20.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 8.0, 7.0, 6.0           | None                     | 8.0, 7.0. 6.0, 5.0, 3.1, 2.1      |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

## Add the Microsoft package repository

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 7](#tab/dotnet7)

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu66
- libssl1.1
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

::: zone-end

::: zone pivot="os-linux-ubuntu-1804"

## Ubuntu 18.04

[!INCLUDE [linux-ubuntu-package-feed-ms](includes/linux-ubuntu-package-feed-ms.md)]

The following versions of .NET are supported or available for Ubuntu 18.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 7.0, 6.0                | None                     | 7.0. 6.0, 5.0, 3.1, 2.2, 2.1      |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 8](#tab/dotnet8)

.NET 8 isn't supported on Ubuntu 18.04.

# [.NET 7](#tab/dotnet7)

[!INCLUDE [linux-apt-install-70](includes/linux-install-70-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu60
- libssl1.1
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

::: zone-end

::: zone pivot="os-linux-ubuntu-1604"

## Ubuntu 16.04

[!INCLUDE [linux-ubuntu-package-feed-ms](includes/linux-ubuntu-package-feed-ms.md)]

The following versions of .NET are supported or available for Ubuntu 16.04:

| Supported .NET versions | Available in Ubuntu feed | [Available in Microsoft feed](linux-ubuntu.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------|-----------------------------------|
| 6.0                     | None                     | 6.0, 5.0, 3.1, 3.0, 2.2, 2.1, 2.0 |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

## Add the Microsoft package repository

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

# [.NET 8](#tab/dotnet8)

.NET 8 isn't supported on Ubuntu 16.04.

# [.NET 7](#tab/dotnet7)

.NET 7 isn't supported on Ubuntu 16.04.

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- libc6
- libgcc1
- libgssapi-krb5-2
- libicu55
- libssl1.0.0
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

[!INCLUDE [linux-libgdiplus-general](includes/linux-libgdiplus-general.md)]

You can install a recent version of *libgdiplus* by [adding the Mono repository to your system](https://www.mono-project.com/download/stable/#download-lin-ubuntu).

::: zone-end

## Unsupported versions

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## How to install other versions

.NET package names are standardized across all Linux distributions. The following table lists the packages:

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Next steps

- [How to enable TAB completion for the .NET CLI](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code](../tutorials/with-visual-studio-code.md)
