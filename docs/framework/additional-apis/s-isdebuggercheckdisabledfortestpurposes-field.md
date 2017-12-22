---
title: "s_isDebuggerCheckDisabledForTestPurposes Field"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
api_name: 
  - "System.Windows.Diagnostics.VisualDiagnostics.s_isDebuggerCheckDisabledForTestPurposes"
api_location: 
  - "PresentationCore.dll"
api_type: 
  - "Assembly"
ms.assetid: 9033a513-c255-4f31-b6d7-09b8d8c50e2d
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
robots: noindex,nofollow
ms.workload: 
  - dotnet
---

# s_isDebuggerCheckDisabledForTestPurposes Field

This private field in the `System.Windows.Diagnostics.VisualDiagnostics` class is used by Visual Studio to determine whether an internal check for an active debugger will be performed.

## Syntax
  
```csharp  
private static bool s_isDebuggerCheckDisabledForTestPurposes
```
  
> [!WARNING]
>  API's in the `System.Windows.Diagnostics.VisualDiagnostics` class are only available when an application is running under a debugger. Set `s_isDebuggerCheckDisabledForTestPurposes` to `true` to access the APIs outside of a debugger.  
>   
>  Microsoft does not support the use of this field in a production application under any circumstance.  

## Requirements

**Namespace:** <xref:System.Windows.Diagnostics>

**Assembly:** PresentationCore (in PresentationCore.dll)

**.NET Framework versions:** Available since 4.6.
