---
title: "Run .NET Framework 1.1 apps on Windows 8, Windows 8.1, or Windows 10"
ms.custom: ""
ms.date: "05/26/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows 8, running .NET Framework 1.1 apps"
  - ".NET Framework 1.1, running on Windows 8"
ms.assetid: fb14e195-fea5-4561-b9a8-60a67283edb9
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Run .NET Framework 1.1 apps on Windows 8, Windows 8.1, or Windows 10

The .NET Framework 1.1 is not supported on the [!INCLUDE[win8](../../../includes/win8-md.md)], [!INCLUDE[win81](../../../includes/win81-md.md)], [!INCLUDE[winserver8](../../../includes/winserver8-md.md)], [!INCLUDE[winblue_server_2](../../../includes/winblue-server-2-md.md)], or the Windows 10 operating systems. In some cases, the .NET Framework 1.1 is specifically identified as required for an app to run. In those cases, you should contact your independent software vendor (ISV) to have the app upgraded to run on the [!INCLUDE[net_v35SP1_short](../../../includes/net-v35sp1-short-md.md)] or later version. For additional information, see [Migrating from the .NET Framework 1.1](../../../docs/framework/migration-guide/migrating-from-the-net-framework-1-1.md).

## Install the .NET Framework 1.1 from a CD or Download Center

It isn't possible to manually install the .NET Framework 1.1 on [!INCLUDE[win8](../../../includes/win8-md.md)], [!INCLUDE[win81](../../../includes/win81-md.md)], [!INCLUDE[winserver8](../../../includes/winserver8-md.md)], [!INCLUDE[winblue_server_2](../../../includes/winblue-server-2-md.md)], or Windows 10. It is no longer supported. If you try to install the package, the following error message is displayed: "Setup cannot continue because this version of the .NET Framework is incompatible with a previously installed one." To solve this problem, install the [.NET Framework 3.5 SP1](http://www.microsoft.com/download/details.aspx?id=22). This version includes the .NET Framework 2.0 (the release that follows the .NET Framework 1.1), which is supported on [!INCLUDE[win8](../../../includes/win8-md.md)], [!INCLUDE[win81](../../../includes/win81-md.md)], and Windows 10. You should always try to install the app first to determine if it will automatically be updated to a later version of the .NET Framework. If it does not, contact your ISV for an app update.

## See also

[Migrating from the .NET Framework 1.1](../../../docs/framework/migration-guide/migrating-from-the-net-framework-1-1.md)
[Install the .NET Framework 3.5 on Windows 10, Windows 8.1, and Windows 8](../../../docs/framework/install/dotnet-35-windows-10.md)
