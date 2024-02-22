---
title: ".NET Framework system requirements"
description: "Find out about the hardware, operating system, and software requirements to install .NET Framework 4.5 and later versions."
ms.date: 08/10/2023
helpviewer_keywords:
  - "software requirements"
  - ".NET Framework, system requirements"
  - "system requirements"
  - "operating systems supported"
  - "hardware requirements"
---
# .NET Framework system requirements

The tables in this article provide the hardware, operating system, and software requirements for the following .NET Framework versions:

- .NET Framework 4.8 and its point release (4.8.1).
- .NET Framework 4.7 and its point releases (4.7.1 and 4.7.2).

For information on .NET Framework versions earlier than .NET Framework 4.7, see [.NET Framework versions and dependencies](../migration-guide/versions-and-dependencies.md).

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
| Windows 11, 2022 Update<br/>(version 22H2) | 64-bit | .NET Framework 4.8.1 | -- |
| Windows 11 | 64-bit | .NET Framework 4.8 | .NET Framework 4.8.1 |
| Windows 10 2022 Update<br/>(version 22H2) | 32-bit and 64-bit | .NET Framework 4.8 | .NET Framework 4.8.1 |
| Windows 10 November 2021 Update<br/>(version 21H2) | 32-bit and 64-bit | .NET Framework 4.8 | .NET Framework 4.8.1 |
| Windows 10 May 2021 Update<br/>(version 21H1) | 32-bit and 64-bit | .NET Framework 4.8 | .NET Framework 4.8.1 |
| Windows 10 October 2020 Update<br/>(version 20H2) | 32-bit and 64-bit | .NET Framework 4.8 | .NET Framework 4.8.1 |
| Windows 10 May 2020 Update<br/>(version 2004) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 November 2019 Update<br/>(version 1909) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 May 2019 Update<br/>(version 1903) | 32-bit and 64-bit | .NET Framework 4.8 | -- |
| Windows 10 October 2018 Update<br/>(version 1809) | 32-bit and 64-bit | .NET Framework 4.7.2 | .NET Framework 4.8 |
| Windows 10 April 2018 Update<br/>(version 1803) | 32-bit and 64-bit | .NET Framework 4.7.2 |.NET Framework 4.8|
| Windows 10 Fall Creators Update<br/>(version 1709) | 32-bit and 64-bit | .NET Framework 4.7.1 | .NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |
| Windows 10 Creators Update<br/>(version 1703) | 32-bit and 64-bit | .NET Framework 4.7 | .NET Framework 4.7.1<br/><br/>.NET Framework 4.7.2<br/><br/>.NET Framework 4.8 |

**Notes:**

- For all platforms, we recommend that you upgrade to the latest Windows Service Pack and install critical updates available from [Windows Update](https://support.microsoft.com/help/12373/windows-update-faq) to ensure the best compatibility and security.
- On 64-bit operating systems, .NET Framework supports both WOW64 (32-bit processing on a 64-bit machine) and native 64-bit processing.

## Supported server operating systems

| Operating system             | Supported editions | Preinstalled with the OS | Installable separately |
|------------------------------|--------------------|--------------------------|------------------------|
| Windows Server 2022          | 64-bit             | .NET Framework 4.8       | .NET Framework 4.8.1   |
| Windows Server 2019          | 64-bit             | .NET Framework 4.7.2     | .NET Framework 4.8     |
| Windows Server, version 1809 | 64-bit             | .NET Framework 4.7.2     | .NET Framework 4.8     |
| Windows Server, version 1803 | 64-bit             | .NET Framework 4.7.2     | .NET Framework 4.8     |
| Windows Server, version 1709 | 64-bit             | .NET Framework 4.7.1     | .NET Framework 4.7.2   |

**Notes:**

- For all platforms, we recommend that you upgrade to the latest Windows Service Pack and critical updates available from [Windows Update](https://support.microsoft.com/help/12373/windows-update-faq) to ensure the best compatibility and security. Installation of the latest Windows Service Pack may be required on some operating systems.
- On 64-bit operating systems, .NET Framework supports both WOW64 (32-bit processing on a 64-bit machine) and native 64-bit processing.

## See also

- [Installation Guide](../install/index.md)
- [Getting Started](index.md)
- [Troubleshoot blocked .NET Framework installations and uninstallations](../install/troubleshoot-blocked-installations-and-uninstallations.md)
