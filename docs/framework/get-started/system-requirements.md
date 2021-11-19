---
title: ".NET Framework system requirements"
description: "Find out about the hardware, operating system, and software requirements to install .NET Framework 4.5 and later versions."
ms.date: 08/27/2021
helpviewer_keywords:
  - "software requirements"
  - ".NET Framework, system requirements"
  - "system requirements"
  - "operating systems supported"
  - "hardware requirements"
ms.topic: reference
---
# .NET Framework system requirements

The tables in this article provide the hardware, operating system, and software requirements for the following .NET Framework versions:

- .NET Framework 4.5 and its point releases (4.5.1 and 4.5.2).
- .NET Framework 4.6 and its point releases (4.6.1 and 4.6.2).
- .NET Framework 4.7 and its point releases (4.7.1 and 4.7.2).
- .NET Framework 4.8

For information on .NET Framework versions earlier than .NET Framework 4.5, see [.NET Framework versions and dependencies](../migration-guide/versions-and-dependencies.md).

Development environments that enable you to develop apps for .NET Framework have a separate set of requirements.

[!INCLUDE[net-framework-4-versions](../../../includes/net-framework-4x-versions.md)]

For download information and links, see [Install the .NET Framework for developers](../install/guide-for-developers.md).

For information on the support lifecycle of .NET Framework versions, see [Microsoft Support Lifecycle](https://support.microsoft.com/lifecycle/search?sort=PN&alpha=Microsoft%20.NET%20Framework&Filter=FilterNO).

## Hardware requirements

|                                 | Requirement |
|---------------------------------|-------------|
| **Processor**                   | 1 GHz       |
| **RAM**                         | 512 MB      |
| **Minimum disk space (32-bit)** | 4.5 GB      |
| **Minimum disk space (64-bit)** | 4.5 GB      |

## Installation requirements

.NET Framework requires administrator privileges for installation. If you don't have administrator rights to the computer where you'd like to install .NET Framework, contact your network administrator.

## Supported client operating systems

| Operating system | Supported editions | Preinstalled with the OS | Installable separately |
| ---------------- | ------------------ | ------------------------ | ---------------------- |
| Windows 11<br/> (version 21H2) | 64-bit | .NET Framework 4.8 | -- |
| Windows 10 May 2021 Update<br/> (version 21H1) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 October 2020 Update<br/> (version 20H2) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 May 2020 Update<br/> (version 2004) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 November 2019 Update<br/> (version 1909) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 May 2019 Update<br/> (version 1903) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 October 2018 Update<br/> (version 1809) | 32-bit and 64-bit | .NET Framework 4.7.2 | .NET Framework 4.8 |
| Windows 10 April 2018 Update<br/> (version 1803) | 32-bit and 64-bit | .NET Framework 4.7.2 |.NET Framework 4.8|
| Windows 10 Fall Creators Update<br/> (version 1709) | 32-bit and 64-bit | .NET Framework 4.7.1 | .NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows 10 Creators Update<br/> (version 1703) | 32-bit and 64-bit | .NET Framework 4.7 | .NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows 10 Anniversary Update<br/> (version 1607) | 32-bit and 64-bit | .NET Framework 4.6.2 |.NET Framework 4.7<br/><br/>.NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8  |
| Windows 10 November Update<br/> (version 1511) | 32-bit and 64-bit | .NET Framework 4.6.1 | .NET Framework 4.6.2 |
| Windows 10<br/> (version 1507) | 32-bit and 64-bit | .NET Framework 4.6 | .NET Framework 4.6.1 <br/><br/> .NET Framework 4.6.2 |
| Windows 8.1 | 32-bit, 64-bit, and ARM | .NET Framework 4.5.1 | .NET Framework 4.5.2<br /><br /> .NET Framework 4.6<br /><br /> .NET Framework 4.6.1<br /><br /> .NET Framework 4.6.2<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows 8 | 32-bit, 64-bit, and ARM | .NET Framework 4.5 | .NET Framework 4.5.1<br /><br />.NET Framework 4.5.2<br /><br /> .NET Framework 4.6<br /><br /> .NET Framework 4.6.1 |
| Windows 7 SP1|32-bit and 64-bit | -- | .NET Framework 4<br /><br /> .NET Framework 4.5<br /><br /> .NET Framework 4.5.1<br /><br /> .NET Framework 4.5.2<br /><br /> .NET Framework 4.6<br /><br /> .NET Framework 4.6.1<br /><br /> .NET Framework 4.6.2<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows Vista SP2|32-bit and 64-bit | -- | .NET Framework 4<br /><br /> .NET Framework 4.5<br /><br /> .NET Framework 4.5.1<br /><br /> .NET Framework 4.5.2<br /><br /> .NET Framework 4.6 |
| Windows XP |32-bit and 64-bit | -- | .NET Framework 4 |

**Notes:**

- On Windows 7 systems, .NET Framework requires Windows 7 SP1. If you're on Windows 7 and haven't yet installed Service Pack 1, you need to do so before installing the .NET Framework.

- .NET Framework 4.5 is supported on the Windows Preinstallation Environment (Windows PE). Not all features are supported on Windows PE.

- .NET Framework 4 also supports the IA64 platform.

- For all platforms, we recommend that you upgrade to the latest Windows Service Pack and install critical updates available from [Windows Update](https://support.microsoft.com/help/12373/windows-update-faq) to ensure the best compatibility and security.

- On 64-bit operating systems, .NET Framework supports both WOW64 (32-bit processing on a 64-bit machine) and native 64-bit processing.

## Supported server operating systems

| Operating system | Supported editions | Preinstalled with the OS | Installable separately |
| ---------------- | ------------------ | ------------------------ | ---------------------- |
| Windows Server 2022 | 64-bit | .NET Framework 4.8   | -- |
| Windows Server 2019 | 64-bit | .NET Framework 4.7.2 | .NET Framework 4.8 |
| Windows Server, version 1809 | 64-bit | .NET Framework 4.7.2 | .NET Framework 4.8 |
| Windows Server, version 1803 | 64-bit | .NET Framework 4.7.2 | .NET Framework 4.8 |
| Windows Server, version 1709 | 64-bit | .NET Framework 4.7.1 | .NET Framework 4.7.2|
| Windows Server 2016 | 64-bit | .NET Framework 4.6.2 | .NET Framework 4.7<br/><br/> .NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows Server 2012 R2 | 64-bit | .NET Framework 4.5.1 | .NET Framework 4.5.2<br /><br /> .NET Framework 4.6<br /><br /> .NET Framework 4.6.1<br /><br /> .NET Framework 4.6.2<br /><br />.NET Framework 4.7<br/><br/> .NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows Server 2012 (64-bit edition) | 64-bit| .NET Framework 4.5 | .NET Framework 4.5.1<br /><br /> .NET Framework 4.5.2<br /><br /> .NET Framework 4.6<br /><br /> .NET Framework 4.6.1<br /><br /> .NET Framework 4.6.2<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows Server 2008 R2 SP1|64-bit | -- | .NET Framework 4<br /><br /> .NET Framework 4.5<br /><br /> .NET Framework 4.5.1<br /><br /> .NET Framework 4.5.2<br /><br /> .NET Framework 4.6<br /><br /> .NET Framework 4.6.1<br /><br /> .NET Framework 4.6.2<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows Server 2008 SP2|32-bit and 64-bit | -- | .NET Framework 4<br /><br /> .NET Framework 4.5<br /><br /> .NET Framework 4.5.1<br /><br /> .NET Framework 4.5.2<br /><br /> .NET Framework 4.6<br /><br /> .NET Framework 4.6.2 |

**Notes:**

- Windows Server 2012 includes .NET Framework 4.5, so you don't have to install it separately. Similarly, Windows Server 2012 R2 includes .NET Framework 4.5.1.

- .NET Framework has limited support for the Server Core Role with Windows Server 2008 R2 SP1 or later. See [Server Core .NET Functionality](/previous-versions//dd745015(v=vs.85)) for a list of unsupported APIs.

- .NET Framework isn't supported on Windows Server 2008 R2 for Itanium-Based Systems.

- On Windows Server 2008 SP2, .NET Framework is not supported in the Server Core Role.

- For all platforms, we recommend that you upgrade to the latest Windows Service Pack and critical updates available from [Windows Update](https://support.microsoft.com/help/12373/windows-update-faq) to ensure the best compatibility and security. Installation of the latest Windows Service Pack may be required on some operating systems.

- On 64-bit operating systems, .NET Framework supports both WOW64 (32-bit processing on a 64-bit machine) and native 64-bit processing.

## See also

- [Installation Guide](../install/index.md)
- [Getting Started](index.md)
- [Troubleshoot blocked .NET Framework installations and uninstallations](../install/troubleshoot-blocked-installations-and-uninstallations.md)
