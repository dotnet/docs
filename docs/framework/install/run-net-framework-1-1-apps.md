---
title: "Run .NET Framework 1.1 apps on Windows 8, 8.1, 10, or Windows 11"
description: "Describes how to accommodate apps that require .NET Framework 1.1, which is no longer supported on many versions of the Windows operating system."
ms.date: 10/06/2021
helpviewer_keywords: 
  - "Windows 8, running .NET Framework 1.1 apps"
  - ".NET Framework 1.1, running on Windows 8"
ms.assetid: fb14e195-fea5-4561-b9a8-60a67283edb9
---

# Run .NET Framework 1.1 apps on Windows 8, Windows 8.1, Windows 10, or Windows 11

.NET Framework 1.1 is not supported on the Windows 8, Windows 8.1, Windows Server 2012, Windows Server 2012 R2, Windows 10, or Windows 11 operating systems. In some cases, .NET Framework 1.1 is required for an app to run. In those cases, contact your independent software vendor (ISV) to have the app upgraded to run on .NET Framework 3.5 SP1 or a later version. For more information, see [Migrating from .NET Framework 1.1](../migration-guide/migrating-from-the-net-framework-1-1.md).

## Install .NET Framework 1.1 from a CD or download center

It isn't possible to manually install .NET Framework 1.1 on Windows 8, Windows 8.1, Windows Server 2012, Windows Server 2012 R2, Windows 10, or Windows 11 from a CD or download center. It's no longer supported. If you try to install the package, the following error message is displayed: "Setup cannot continue because this version of the .NET Framework is incompatible with a previously installed one." To solve this problem, install [.NET Framework 3.5 SP1](https://www.microsoft.com/download/details.aspx?id=22). This version includes .NET Framework 2.0 (the release that follows .NET Framework 1.1), which is supported on Windows 8, Windows 8.1, Windows 10, and Windows 11. You should always try to install the app first to determine if it will automatically be updated to a later version of .NET Framework. If it doesn't, contact your ISV for an app update.

## See also

- [Migrating from the .NET Framework 1.1](../migration-guide/migrating-from-the-net-framework-1-1.md)
- [Install the .NET Framework 3.5 on Windows 11, Windows 10, Windows 8.1, and Windows 8](../install/dotnet-35-windows.md)
