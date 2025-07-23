---
title: Install .NET on Ubuntu
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu. .NET is usually installed through APT.
author: adegeo
ms.author: adegeo
ms.date: 12/13/2024
ms.custom: linux-related-content
zone_pivot_groups: ubuntu-install-set-one
---

# Install .NET SDK or .NET Runtime on Ubuntu

This article discusses how to install .NET on Ubuntu.

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm-ubuntu](includes/linux-install-package-manager-x64-vs-arm-ubuntu.md)]

<!--
===== Ubuntu 24.10
-->

::: zone pivot="os-linux-ubuntu-2410"

## Ubuntu 24.10

[!INCLUDE [linux-ubuntu-package-feed-only](includes/linux-ubuntu-package-feed-only.md)]

The following versions of .NET are supported or available for Ubuntu 24.10:

- 9.0
- 8.0

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 6](#tab/dotnet6)

Not available.

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libicu74
- liblttng-ust1
- libssl3
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

::: zone-end

<!--
===== Ubuntu 24.04
-->

::: zone pivot="os-linux-ubuntu-2404"

## Ubuntu 24.04

[!INCLUDE [linux-ubuntu-package-feed-only](includes/linux-ubuntu-package-feed-only.md)]

The following versions of .NET are supported or available for Ubuntu 24.04:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|-----------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 9.0, 8.0                | 8.0                                  | 9.0, 7.0, 6.0                                                                                       |None                                                                                         |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-ubuntu-register-backports](includes/linux-ubuntu-register-backports.md)]

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-ubuntu-register-backports](includes/linux-ubuntu-register-backports.md)]

> [!WARNING]
> .NET 6 is no longer supported.

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libicu74
- liblttng-ust1
- libssl3
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

::: zone-end

<!--
===== Ubuntu 22.04
-->

::: zone pivot="os-linux-ubuntu-2204"

## Ubuntu 22.04

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET are supported or available for Ubuntu 22.04:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>.NET backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|----------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 9.0, 8.0                | 8.0, 7.0, 6.0                        | 9.0                                                                                                      | 8.0, 7.0, 6.0, 3.1                |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-ubuntu-register-backports](includes/linux-ubuntu-register-backports.md)]

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 6](#tab/dotnet6)

> [!WARNING]
> .NET 6 is no longer supported.

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu70
- liblttng-ust1
- libssl3
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

::: zone-end

<!--
===== All versions
-->

::: zone pivot="os-linux-ubuntu-2410,os-linux-ubuntu-2404,os-linux-ubuntu-2204"

## Unsupported versions

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## How to install other versions

.NET package names are standardized across all Linux distributions. The following table lists the packages:

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

::: zone-end

<!--
===== Other Ubuntu versions
-->

::: zone pivot="os-linux-ubuntu-other"

## Manual install

If your Ubuntu version isn't supported and the version of .NET you want to use wasn't available in a package repository, you most likely need to install .NET by manually extracting the binaries, by using the install script, or with Snap. For more information, see [Install .NET on Linux without using a package manager](linux-scripted-manual.md) and [Install .NET Runtime with Snap](linux-snap-runtime.md).

<!--
===== Ubuntu 23.10
-->

## Ubuntu 23.10

[!INCLUDE [linux-ubuntu-not-supported](includes/linux-ubuntu-not-supported.md)]

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET were supported or available for Ubuntu 23.10:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>.NET backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|----------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 8.0, 6.0                | 8.0, 7.0, 6.0                        | None                                                                                                     | 8.0, 7.0, 6.0                                                                               |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 9](#tab/dotnet9)

.NET 9 isn't supported on Ubuntu 23.10.

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

### Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu72
- liblttng-ust1
- libssl3
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

<!--
===== Ubuntu 23.04
-->

## Ubuntu 23.04

[!INCLUDE [linux-ubuntu-not-supported](includes/linux-ubuntu-not-supported.md)]

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET were supported or available for Ubuntu 23.04:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>.NET backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|----------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 8.0, 6.0                | 7.0, 6.0                             | None                                                                                                     | 8.0, 7.0, 6.0                                                                               |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

# [.NET 9](#tab/dotnet9)

.NET 9 isn't supported on Ubuntu 23.04.

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-ubuntu-80-ms](includes/linux-ubuntu-80-ms.md)]

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

### Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu72
- liblttng-ust1
- libssl3
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

<!--
===== Ubuntu 22.10
-->

## Ubuntu 22.10

[!INCLUDE [linux-ubuntu-not-supported](includes/linux-ubuntu-not-supported.md)]

[!INCLUDE [linux-ubuntu-package-feed-both](includes/linux-ubuntu-package-feed-both.md)]

The following versions of .NET are supported or available for Ubuntu 22.10:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>.NET backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|----------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 6.0                     | 7.0, 6.0                             |  None                                                                                                    | 7.0, 6.0, 3.1                                                                               |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

# [.NET 9](#tab/dotnet9)

.NET 9 isn't supported on Ubuntu 22.10.

# [.NET 8](#tab/dotnet8)

.NET 8 isn't supported on Ubuntu 22.10.

# [.NET 6](#tab/dotnet6)

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

### Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu71
- liblttng-ust1
- libssl3
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

<!--
===== Ubuntu 20.04
-->

## Ubuntu 20.04

[!INCLUDE [linux-ubuntu-package-feed-ms](includes/linux-ubuntu-package-feed-ms.md)]

The following versions of .NET are supported or available for Ubuntu 20.04:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>.NET backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|----------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 8.0                     | None                                 | None                                                                                                     | 8.0, 7.0. 6.0, 5.0, 3.1, 2.1                                                                |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

### Add the Microsoft package repository

[!INCLUDE [linux-prep-intro-apt](includes/linux-prep-intro-apt.md)]

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

# [.NET 9](#tab/dotnet9)

Because Ubuntu 20.04 reached end of life in April 2025, Microsoft doesn't support .NET 9 on Ubuntu 20.04.

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

# [.NET 6](#tab/dotnet6)

> [!WARNING]
> .NET 6 is no longer supported.

[!INCLUDE [linux-apt-install-60](includes/linux-install-60-apt.md)]

---

### Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu66
- libssl1.1
- libstdc++6
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

::: zone-end

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI.](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code.](../tutorials/with-visual-studio-code.md)
