---
title: "Troubleshooting the installation of the .NET Framework 3.5 on Windows 8, Windows 8.1, and Windows 10 | Microsoft Docs"
ms.custom: ""
ms.date: "04/20/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - ".NET Framework 3.5, installing on Windows 8"
  - "Windows 8, installing .NET Framework 3.5"
ms.assetid: 3eab3eb4-4573-42ac-98f8-36fb2c22c7d5
caps.latest.revision: 69
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---

# Troubleshooting the installation of the .NET Framework 3.5 on Windows 8, Windows 8.1, and Windows 10

During installation you may encounter error 0x800f0906, 0x800f0907, or 0x800f081f, in which case refer to [.NET Framework 3.5 installation error: 0x800f0906, 0x800f0907, or 0x800f081f](https://support.microsoft.com/en-us/kb/2734782). Note that these are possibly resolved by installing [security update 3005628](https://support.microsoft.com/kb/3005628).

If the installation fails or you don't have an Internet connection, it's necessary to use your Windows installation media. For details, see Method 3 for error 0x800f0906 in the [.NET Framework 3.5 installation error article](https://support.microsoft.com/en-us/kb/2734782). If you don't have installation media, see [Create Installation media for Windows 8.1](http://windows.microsoft.com/en-US/windows-8/create-reset-refresh-media?woldogcb=0).

**Important notes:**

- In general, do not uninstall any versions of the .NET Framework from your computer. Different apps depend on different versions of the framework, and multiple versions of the .NET Framework can coexist on a single computer at the same time.

- The .NET Framework 3.5 is also used by apps built for versions 2.0 and 3.0.

- Installing a Windows language pack before installing the .NET Framework 3.5 may cause the .NET Framework 3.5 installation to fail. Install the .NET Framework 3.5 before installing any Windows language packs.

- Windows CardSpace is not available with the .NET Framework 3.5 on [!INCLUDE[win8](../../../includes/win8-md.md)].

- Because of complications around how the .NET Framework 3.5 must be installed, it is unfortunately not possible to provide a separate, standalone installer that can run independently of Windows Update. If all other methods fail, you must resort to installation media as described earlier.

## See also

[Installation Guide](../../../docs/framework/get-started/index.md)
