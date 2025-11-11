---
title: Install .NET on Ubuntu
description: Demonstrates the various ways to install .NET SDK and .NET Runtime on Ubuntu. .NET is usually installed through APT.
author: adegeo
ms.author: adegeo
ms.date: 11/07/2025
ms.custom: updateeachrelease, linux-related-content
zone_pivot_groups: ubuntu-install-set-one
---

# Install .NET SDK or .NET Runtime on Ubuntu

This article discusses how to install .NET on Ubuntu.

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

[!INCLUDE [linux-intro-sdk-vs-runtime](includes/linux-intro-sdk-vs-runtime.md)]

[!INCLUDE [linux-install-package-manager-x64-vs-arm-ubuntu](includes/linux-install-package-manager-x64-vs-arm-ubuntu.md)]

<!--
===== Ubuntu 25.10
-->

::: zone pivot="os-linux-ubuntu-2510"

## Ubuntu 25.10

[!INCLUDE [linux-ubuntu-package-feed-only](includes/linux-ubuntu-package-feed-only.md)]

The following versions of .NET are supported or available for Ubuntu 25.10:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|-----------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 10.0, 9.0, 8.0          | 9.0, 8.0                             | None                                                                                                |None                                                                                         |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 10](#tab/dotnet10)

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

[!INCLUDE [linux-apt-install-100](includes/linux-install-100-apt.md)]

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu76
- libssl3t64
- libstdc++6
- tzdata
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

::: zone-end

<!--
===== Ubuntu 25.04
-->

::: zone pivot="os-linux-ubuntu-2504"

## Ubuntu 25.04

[!INCLUDE [linux-ubuntu-package-feed-only](includes/linux-ubuntu-package-feed-only.md)]

The following versions of .NET are supported or available for Ubuntu 25.04:

| Supported .NET versions | Available in<br>built-in Ubuntu feed | [Available in<br>backports<br>Ubuntu feed](linux-ubuntu-decision.md#ubuntu-net-backports-package-repository) | [Available in<br>Microsoft feed](linux-ubuntu-decision.md#register-the-microsoft-package-repository) |
|-------------------------|--------------------------------------|-----------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| 10.0, 9.0, 8.0          | 9.0, 8.0                             | None                                                                                                |None                                                                                         |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 10](#tab/dotnet10)

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

[!INCLUDE [linux-apt-install-100](includes/linux-install-100-apt.md)]

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu76
- libssl3t64
- libstdc++6
- tzdata
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
| 10.0, 9.0, 8.0          | 8.0                                  | 9.0, 7.0, 6.0                                                                                       |None                                                                                         |

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 10](#tab/dotnet10)

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

[!INCLUDE [linux-ubuntu-register-backports](includes/linux-ubuntu-register-backports.md)]

[!INCLUDE [linux-apt-install-100](includes/linux-install-100-apt.md)]

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-ubuntu-register-backports](includes/linux-ubuntu-register-backports.md)]

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu74
- libssl3t64
- libstdc++6
- tzdata
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
| 10.0, 9.0, 8.0          | 8.0, 7.0, 6.0                        | 9.0                                                                                                      | 8.0, 7.0, 6.0, 3.1                |

[!INCLUDE [linux-ubuntu-feed-sdk-note](includes/linux-ubuntu-feed-sdk-note.md)]

When an [Ubuntu version](https://wiki.ubuntu.com/Releases) falls out of support, .NET is no longer supported with that version.

# [.NET 10](#tab/dotnet10)

[!INCLUDE [linux-release-wait](includes/linux-release-wait.md)]

[!INCLUDE [linux-ubuntu-register-backports](includes/linux-ubuntu-register-backports.md)]

[!INCLUDE [linux-apt-install-100](includes/linux-install-100-apt.md)]

# [.NET 9](#tab/dotnet9)

[!INCLUDE [linux-ubuntu-register-backports](includes/linux-ubuntu-register-backports.md)]

[!INCLUDE [linux-apt-install-90](includes/linux-install-90-apt.md)]

# [.NET 8](#tab/dotnet8)

[!INCLUDE [linux-apt-install-80](includes/linux-install-80-apt.md)]

---

## Dependencies

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- ca-certificates
- libc6
- libgcc-s1
- libgssapi-krb5-2
- libicu70
- libssl3
- libstdc++6
- tzdata
- zlib1g

[!INCLUDE [linux-ubuntu-deps-example](includes/linux-ubuntu-deps-example.md)]

::: zone-end

<!--
===== All versions
-->

::: zone pivot="os-linux-ubuntu-2504,os-linux-ubuntu-2404,os-linux-ubuntu-2204"

## Unsupported versions

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## How to install other versions

.NET package names are standardized across all Linux distributions. The following table lists the packages:

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

::: zone-end

## Next steps

- [.NET CLI overview](../tools/index.md)
- [How to enable TAB completion for the .NET CLI.](../tools/enable-tab-autocomplete.md)
- [Tutorial: Create a console application with .NET SDK using Visual Studio Code.](../tutorials/with-visual-studio-code.md)
