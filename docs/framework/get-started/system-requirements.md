---
title: ".NET Framework system requirements"
description: "Find out what are the hardware, operating system and software requirements to install .NET Framework 4.5 and later versions."
ms.custom: "updateeachrelease"
ms.date: "02/02/2018"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "software requirements"
  - ".NET Framework, system requirements"
  - "system requirements"
  - "operating systems supported"
  - "hardware requirements"
ms.assetid: 298275e2-da1d-4618-9f74-6a3567832350
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# .NET Framework system requirements

The tables in this topic provide the hardware, operating system, and software requirements for the following .NET Framework versions:

* .NET Framework 4.5 and its point releases (4.5.1 and 4.5.2).
* .NET Framework 4.6 and its point releases (4.6.1 and 4.6.2).
* .NET Framework 4.7 and its point release (4.7.1).

Development environments that enable you to develop apps for the .NET Framework have a separate set of requirements.

[!INCLUDE[net-framework-4-versions](../../../includes/net-framework-4x-versions.md)]

For download information and links, see [Install the .NET Framework for developers](../../../docs/framework/install/guide-for-developers.md).

For information on the support lifecycle of .NET Framework versions, see [Microsoft Support Lifecycle](https://support.microsoft.com/en-us/lifecycle/search?sort=PN&alpha=Microsoft%20.NET%20Framework&Filter=FilterNO).

## Hardware requirements

|                          |        |
| ------------------------ | ------ |
| **Processor**            | 1 GHz  |
| **RAM**                  | 512 MB |
| **Disk space (minimum)** |        |
| 32-bit                   | 4.5 GB |
| 64-bit                   | 4.5 GB |

## Installation requirements

The .NET Framework requires administrator privileges for installation. If you don't have administrator rights to the computer where you'd like to install the .NET Framework, contact your network administrator.

## Supported client operating systems

| Operating system | Supported editions | Preinstalled with the OS | Installable separately |
| ---------------- | ------------------ | ------------------------ | ---------------------- |
| Windows 10 Fall Creators Update | 32-bit and 64-bit | .NET Framework 4.7.1 | |
| Windows 10 Creators Update | 32-bit and 64-bit | .NET Framework 4.7 | .NET Framework 4.7.1 | 
| Windows 10 Anniversary Update | 32-bit and 64-bit | [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]|.NET Framework 4.7<br/><br/>.NET Framework 4.7.1 |
| Windows 10 November Update | 32-bit and 64-bit | .NET Framework 4.6.1 | .NET Framework 4.6.2 |
| Windows 10 | 32-bit and 64-bit | .NET Framework 4.6 | .NET Framework 4.6.1 <br/><br/> .NET Framework 4.6.2 |
| [!INCLUDE[win81](../../../includes/win81-md.md)] | 32-bit, 64-bit, and ARM | [!INCLUDE[net_v451](../../../includes/net-v451-md.md)] | [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]<br /><br /> [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]<br /><br /> [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1 |
| [!INCLUDE[win8](../../../includes/win8-md.md)] | 32-bit, 64-bit, and ARM | [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] | [!INCLUDE[net_v451](../../../includes/net-v451-md.md)]<br /><br /> [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]<br /><br /> [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] |
| Windows 7 SP1|32-bit and 64-bit | -- | .NET Framework 4<br /><br /> [!INCLUDE[net_v45](../../../includes/net-v45-md.md)]<br /><br /> [!INCLUDE[net_v451](../../../includes/net-v451-md.md)]<br /><br /> [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]<br /><br /> [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]<br /><br /> [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1|
| Windows Vista SP2|32-bit and 64-bit | -- | .NET Framework 4<br /><br /> [!INCLUDE[net_v45](../../../includes/net-v45-md.md)]<br /><br /> [!INCLUDE[net_v451](../../../includes/net-v451-md.md)]<br /><br /> [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] |
| Windows XP |32-bit and 64-bit | -- | .NET Framework 4 |

 **Notes:**

- On Windows 7 systems, the .NET Framework requires Windows 7 SP1. If you're on Windows 7 and haven't yet installed Service Pack 1, you need to do so before installing the .NET Framework.

- The [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] is supported on the Windows Preinstallation Environment (Windows PE). Not all features are supported on Windows PE.

- The .NET Framework 4 also supports the IA64 platform.

- For all platforms, we recommend that you upgrade to the latest Windows Service Pack and install critical updates available from the [Windows Update website](http://go.microsoft.com/fwlink/?LinkId=168461) to ensure the best compatibility and security.

- On 64-bit operating systems, the .NET Framework supports both WOW64 (32-bit processing on a 64-bit machine) and native 64-bit processing.

## Supported server operating systems

| Operating system | Supported editions | Preinstalled with the OS | Installable separately |
| ---------------- | ------------------ | ------------------------ | ---------------------- |
| Windows Server, version 1709 | 64-bit | .NET Framework 4.7.1 | -- |
| Windows Server 2016 | 64-bit | [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] | .NET Framework 4.7<br/><br/> .NET Framework 4.7.1 |
| Windows Server 2012 R2 | 64-bit | [!INCLUDE[net_v451](../../../includes/net-v451-md.md)] | [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]<br /><br /> [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]<br /><br /> [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]<br /><br />.NET Framework 4.7<br/><br/> .NET Framework 4.7.1 |
| Windows Server 2012 (64-bit edition) | 64-bit| [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] | [!INCLUDE[net_v451](../../../includes/net-v451-md.md)]<br /><br /> [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]<br /><br /> [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]<br /><br /> [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1 |
| Windows Server 2008 R2 SP1|64-bit | -- | .NET Framework 4<br /><br /> [!INCLUDE[net_v45](../../../includes/net-v45-md.md)]<br /><br /> [!INCLUDE[net_v451](../../../includes/net-v451-md.md)]<br /><br /> [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]<br /><br /> [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]<br /><br /> [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]<br /><br />.NET Framework 4.7<br/><br/>.NET Framework 4.7.1 |
| Windows Server 2008 SP2|32-bit and 64-bit | -- | .NET Framework 4<br /><br /> [!INCLUDE[net_v45](../../../includes/net-v45-md.md)]<br /><br /> [!INCLUDE[net_v451](../../../includes/net-v451-md.md)]<br /><br /> [!INCLUDE[net_v452](../../../includes/net-v452-md.md)]<br /><br /> [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] |

 **Notes:**

- [!INCLUDE[winserver8](../../../includes/winserver8-md.md)] includes the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], so you don't have to install it separately. Similarly, [!INCLUDE[winblue_server_2](../../../includes/winblue-server-2-md.md)] includes the [!INCLUDE[net_v451](../../../includes/net-v451-md.md)].

- The .NET Framework has limited support for the Server Core Role with Windows Server 2008 R2 SP1 or later. See [Server Core .NET Functionality](https://msdn.microsoft.com/library/ee391632.aspx) for a list of unsupported APIs.

- The .NET Framework isn't supported on Windows Server 2008 R2 for Itanium-Based Systems.

- On Windows Server 2008 SP2, the .NET Framework is not supported in the Server Core Role.

- For all platforms, we recommend that you upgrade to the latest Windows Service Pack and critical updates available from the [Windows Update website](http://go.microsoft.com/fwlink/?LinkId=168461) to ensure the best compatibility and security. Installation of the latest Windows Service Pack may be required on some operating systems.

- On 64-bit operating systems, the .NET Framework supports both WOW64 (32-bit processing on a 64-bit machine) and native 64-bit processing.

## See also

[Installation Guide](../../../docs/framework/install/index.md)   
[Getting Started](../../../docs/framework/get-started/index.md)   
[Troubleshoot blocked .NET Framework installations and uninstallations](../../../docs/framework/install/troubleshoot-blocked-installations-and-uninstallations.md)
