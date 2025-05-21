---
title: Install .NET Framework on Windows
description: Learn how to install .NET Framework on Windows 11, Windows 10, and Windows Server. This article also includes information about .NET Framework and unsupported versions of Windows, such as Windows 8, Windows Vista, and Windows XP.
ms.date: 02/12/2025
ms.topic: install-set-up-deploy
---
# Install .NET Framework on Windows and Windows Server

.NET Framework is included on all current versions of Windows and Windows Server. This article helps you understand which version of .NET Framework is included in Windows and Windows Server, and if an upgrade is available.

The latest version of .NET Framework is 4.8.1. This version of .NET Framework supports all .NET Framework 4 apps. For more information about a specific release of .NET Framework, see [.NET Framework versions and dependencies](versions-and-dependencies.md).

> [!NOTE]
> .NET Framework is a Windows-only technology, and is separate from .NET (formerly called .NET Core). For more information, see [Introduction to .NET](../../core/introduction.md).

## Supported versions of .NET Framework

The following versions of .NET Framework are still supported:

- [.NET Framework 4.8.1](https://dotnet.microsoft.com/download/dotnet-framework/net481)
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [.NET Framework 4.7.1](https://dotnet.microsoft.com/download/dotnet-framework/net471)
- [.NET Framework 4.7](https://dotnet.microsoft.com/download/dotnet-framework/net47)
- [.NET Framework 4.6.2](https://dotnet.microsoft.com/download/dotnet-framework/net462) (support ends January 12, 2027)
- [.NET Framework 3.5 Service Pack 1](https://dotnet.microsoft.com/download/dotnet-framework/net35-sp1) (support ends January 9, 2029)

### .NET Framework 3.5

.NET Framework 3.5 is still supported by Microsoft, even though it's an older version of .NET Framework. However, only the .NET Framework 3.5 runtime is supported, which runs apps. Developing new apps that target .NET Framework 3.5 isn't supported. This version of .NET Framework supports running apps that target versions 1.0 through 3.5, and can be installed alongside .NET Framework 4.

If you try to run an app that targets .NET Framework 1.0 through 3.5, and .NET Framework 3.5 is missing, you're prompted to install it. For more information, see [Install .NET Framework 3.5 on Windows](dotnet-35-windows.md).

### .NET Framework 4.x

All .NET Framework 4.x versions are in-place updates. Only a single 4.x version can be present on Windows. Because .NET Framework is installed as part of Windows, consider that:

- If there's a later 4.x version installed on the machine already, you can't install a previous 4.x version.
- If the OS comes preinstalled with a particular .NET Framework version, you can't install a previous 4.x version on the same machine.
- If you install a later version, you don't have to first uninstall the previous version.

## Developers and Visual Studio

Visual Studio uses .NET Framework Developer Packs to support targeting specific versions of .NET Framework 4. If you're a developer who must work on a project targeting an old version of .NET Framework 4, install the corresponding developer pack. For more information, see [Install .NET Framework for developers](guide-for-developers.md).

## Windows 11

.NET Framework 4.8 was originally included with Windows 11. Starting with Windows 11 22H2 (released September 2022), .NET Framework 4.8.1 is included.

In the following table, ❌ represents an unsupported version of Windows 11 and ✔️ represents a supported version of Windows 11. The table also describes which version of .NET Framework is included with Windows 11, and which version of .NET Framework you can upgrade to.

| Windows 11 version    | .NET Framework included | Latest .NET Framework supported |
|-----------------------|-------------------------|---------------------------------|
| ✔️ 24H2 (October 2024)   | 4.8.1                   | 4.8.1                           |
| ✔️ 23H2 (October 2023)   | 4.8.1                   | 4.8.1                           |
| ❌ 22H2 (September 2022) | 4.8.1                   | 4.8.1                           |
| ❌ 21H2 (October 2021)   | 4.8                     | 4.8.1                           |

For more information about Windows 11 end-of-support dates, see [Windows 11 Home and Pro Lifecycle](/lifecycle/products/windows-11-home-and-pro) and [Windows Lifecycle FAQ](/lifecycle/faq/windows).

### Install .NET Framework on Windows 11

If you're using Windows 11 21H2, install .NET Framework 4.8.1 by downloading and running the installer. If you're using any other version of Windows 11, the latest .NET Framework is already installed.

> [!div class="button"]
> [Download .NET Framework 4.8.1](https://dotnet.microsoft.com/download/dotnet-framework/net481)

If you need to install .NET Framework 3.5, which supports .NET Framework apps 1.0 through 3.5, refer to the [.NET Framework 3.5 section](#net-framework-35).

For more downloads, see [All downloads](#all-downloads).

## Windows 10

.NET Framework 4.6 was originally included with Windows 10. However, newer releases of Windows 10 included upgraded versions of .NET Framework.

Windows 10 22H2 is the last supported version of Windows 10. Support ends October 14, 2025. For more information about Windows 10 end-of-support dates, see [Windows 10 Home and Pro Lifecycle](/lifecycle/products/windows-10-home-and-pro) and [Windows Lifecycle FAQ](/lifecycle/faq/windows).

In the following table, ❌ represents an unsupported version of Windows 10 and ✔️ represents a supported version of Windows 10. The table also describes which version of .NET Framework is included with a particular Windows 10 version, and which version of .NET Framework you can upgrade to.

| Windows 10 version   | .NET Framework included | Latest .NET Framework supported |
|----------------------|-------------------------|---------------------------------|
| ✔️ 22H2 (October 2022)  | 4.8                     | 4.8.1                           |
| ❌ 21H2 (November 2021) | 4.8                     | 4.8.1                           |
| ❌ 21H1 (May 2021)      | 4.8                     | 4.8.1                           |
| ❌ 20H2 (October 2020)  | 4.8                     | 4.8.1                           |
| ❌ 2004 (May 2020)      | 4.8                     | 4.8                             |
| ❌ 1909 (November 2019) | 4.8                     | 4.8                             |
| ❌ 1903 (May 2019)      | 4.8                     | 4.8                             |
| ❌ 1809 (October 2018)  | 4.7.2                   | 4.8                             |
| ❌ 1803 (April 2018)    | 4.7.2                   | 4.8                             |
| ❌ 1709 (October 2017)  | 4.7.1                   | 4.8                             |
| ❌ 1703 (April 2017)    | 4.7                     | 4.8                             |
| ❌ 1607 (August 2016)   | 4.6.2                   | 4.8                             |
| ❌ 1511 (November 2015) | 4.6.1                   | 4.6.2                           |
| ❌ 1507 (July 2015)     | 4.6                     | 4.6.2                           |

### Install .NET Framework on Windows 10

The latest version of .NET Framework is 4.8.1, which can be installed on Windows 10 22H2.

> [!div class="button"]
> [Download .NET Framework 4.8.1](https://dotnet.microsoft.com/download/dotnet-framework/net481)

If you need to install .NET Framework 3.5, which supports .NET Framework apps 1.0 through 3.5, refer to the [.NET Framework 3.5 section](#net-framework-35).

For more downloads, see [All downloads](#all-downloads).

## Windows Server

Windows Server, whether it's in support or not, comes with a version of .NET Framework. Only Windows Server 2022 and Windows Server 2025 are supported, and they both support the latest version of .NET Framework. For more information about Windows Server end-of-support dates, see the following articles:

- [Windows Server 2025 Lifecycle](/lifecycle/products/windows-server-2025)
- [Windows Server 2022 Lifecycle](/lifecycle/products/windows-server-2022)
- [Windows Server 2019 Lifecycle](/lifecycle/products/windows-server-2019)
- [Product Lifecycle Search Query - Windows Server](/lifecycle/products/?products=windows&terms=Windows%20Server)
- [Windows Lifecycle FAQ](/lifecycle/faq/windows).

In the following table, ❌ represents an unsupported version of Windows Server and ✔️ represents a supported version of Windows Server. The table also describes which version of .NET Framework is included with a particular Windows Server version, and which version of .NET Framework you can upgrade to.

| Windows Server               | .NET Framework included | Latest .NET Framework supported |
|------------------------------|-------------------------|---------------------------------|
| ✔️ Windows Server 2025          | 4.8.1                   | 4.8.1                           |
| ✔️ Windows Server 2022          | 4.8                     | 4.8.1                           |
| ❌ Windows Server 2019          | 4.7.2                   | 4.8                             |
| ❌ Windows Server, version 1809 | 4.7.2                   | 4.8                             |
| ❌ Windows Server, version 1803 | 4.7.2                   | 4.8                             |
| ❌ Windows Server, version 1709 | 4.7.1                   | 4.7.2                           |
| ❌ Windows Server 2016          | 4.6.2                   | 4.8                             |
| ❌ Windows Server 2012 R2       | 4.5.1                   | 4.8                             |
| ❌ Windows Server 2012          | 4.5                     | 4.8                             |
| ❌ Windows Server 2008 R2 SP1   | 3.5                     | 4.8                             |
| ❌ Windows Server 2008 SP2      | 2.0                     | 4.6                             |
| ❌ Windows Server 2003          | 2.0                     | 4.0                             |

### Install .NET Framework on Windows Server

The latest version of .NET Framework is 4.8.1, which is already installed on Windows Server 2025 and can be installed on Windows Server 2022.

> [!div class="button"]
> [Download .NET Framework 4.8.1](https://dotnet.microsoft.com/download/dotnet-framework/net481)

If you need to install .NET Framework 3.5, which supports .NET Framework apps 1.0 through 3.5, refer to the [.NET Framework 3.5 section](#net-framework-35).

For more downloads, see [All downloads](#all-downloads).

## Windows 8.1, 8, 7, Vista, XP

The following table describes which version of .NET Framework was included with these older versions of Windows, and the last release of .NET Framework for that operating system. None of these operating systems are supported. This information is provided for historical purposes.

| Windows        | .NET Framework included | Latest .NET Framework supported |
|----------------|-------------------------|---------------------------------|
| Windows 8.1    | 4.5.1                   | 4.8                             |
| Windows 8      | 4.5                     | 4.6.1                           |
| Windows 7      | 3.5                     | 4.8                             |
| Windows Vista  | 3.0                     | 4.6                             |
| Windows XP SP3 | None                    | 4.0.3                           |
| Windows XP SP2 | None                    | 3.5                             |
| Windows XP     | None                    | 1.0                             |

### Install .NET Framework on older versions of Windows

Some downloads aren't available for these older versions of windows, and some installers might not run. For example, the latest .NET Framework 4.8 installer might not run on Windows 8.1. You might need to search the internet for older downloads as they're no longer provided by Microsoft.

For more downloads, see [All downloads](#all-downloads).

## All downloads

The following list is a link to each version of .NET Framework that can be downloaded from Microsoft.

- [.NET Framework 4.8.1](https://dotnet.microsoft.com/download/dotnet-framework/net481)
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [.NET Framework 4.7.1](https://dotnet.microsoft.com/download/dotnet-framework/net471)
- [.NET Framework 4.7](https://dotnet.microsoft.com/download/dotnet-framework/net47)
- [.NET Framework 4.6.2](https://dotnet.microsoft.com/download/dotnet-framework/net462)
- [.NET Framework 4.6.1](https://dotnet.microsoft.com/download/dotnet-framework/net461)
- [.NET Framework 4.6](https://dotnet.microsoft.com/download/dotnet-framework/net46)
- [.NET Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452)
- [.NET Framework 4.5.1](https://dotnet.microsoft.com/download/dotnet-framework/net451)
- [.NET Framework 4.5](https://dotnet.microsoft.com/download/dotnet-framework/net45)
- [.NET Framework 4.0](https://dotnet.microsoft.com/download/dotnet-framework/net40)
- [.NET Framework 3.5 Service Pack 1](https://dotnet.microsoft.com/download/dotnet-framework/net35-sp1)

Downloads of other versions of .NET Framework are no longer provided by Microsoft.

## See also

- [Install .NET Framework for developers](guide-for-developers.md)
- [How to: Determine which .NET Framework versions are installed](how-to-determine-which-versions-are-installed.md)
- [Versions and dependencies](versions-and-dependencies.md)
