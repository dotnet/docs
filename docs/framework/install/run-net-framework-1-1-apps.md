---
title: "Run .NET Framework 1.1 apps on Windows 8, Windows 8.1, or Windows 10"
ms.date: "05/26/2017"
helpviewer_keywords: 
  - "Windows 8, running .NET Framework 1.1 apps"
  - ".NET Framework 1.1, running on Windows 8"
ms.assetid: fb14e195-fea5-4561-b9a8-60a67283edb9
---

# Run .NET Framework 1.1 apps on Windows 8, Windows 8.1, or Windows 10

The .NET Framework 1.1 is not supported on the Windows 8, Windows 8.1, Windows Server 2012, Windows Server 2012 R2, or the Windows 10 operating systems. In some cases, the .NET Framework 1.1 is specifically identified as required for an app to run. In those cases, you should contact your independent software vendor (ISV) to have the app upgraded to run on the .NET Framework 3.5 SP1 or later version. For additional information, see [Migrating from the .NET Framework 1.1](../migration-guide/migrating-from-the-net-framework-1-1.md).

## Install the .NET Framework 1.1 from a CD or Download Center

It isn't possible to manually install the .NET Framework 1.1 on Windows 8, Windows 8.1, Windows Server 2012, Windows Server 2012 R2, or Windows 10. It is no longer supported. If you try to install the package, the following error message is displayed: "Setup cannot continue because this version of the .NET Framework is incompatible with a previously installed one." To solve this problem, install the [.NET Framework 3.5 SP1](https://www.microsoft.com/download/details.aspx?id=22). This version includes the .NET Framework 2.0 (the release that follows the .NET Framework 1.1), which is supported on Windows 8, Windows 8.1, and Windows 10. You should always try to install the app first to determine if it will automatically be updated to a later version of the .NET Framework. If it does not, contact your ISV for an app update.

## See also

- [Migrating from the .NET Framework 1.1](../migration-guide/migrating-from-the-net-framework-1-1.md)
- [Install the .NET Framework 3.5 on Windows 10, Windows 8.1, and Windows 8](dotnet-35-windows-10.md)
