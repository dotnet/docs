---
title: "Enabling JIT-Attach Debugging"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "JIT-attach debugging"
  - "debugging [.NET Framework], JIT-attach debugging"
ms.assetid: f91fc5f7-de5a-4f23-b6ac-f450e63c662e
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Enabling JIT-Attach Debugging
JIT-attach debugging is the phrase used to describe attaching a debugger to a process when you encounter errors, or it can be triggered by specific methods or functions.  
  
 JIT-attach debugging is used under the following fault conditions:  
  
-   Unhandled exceptions (in both native and managed code).  
  
-   <xref:System.Environment.FailFast%2A?displayProperty=nameWithType> method or [RaiseFailFastException](http://go.microsoft.com/fwlink/?LinkId=182107) function (Windows 7 family).  
  
-   Runtime fatal errors.  
  
 JIT-attach debugging is also triggered by calls to the following methods and functions:  
  
-   <xref:System.Diagnostics.Debugger.Launch%2A?displayProperty=nameWithType> method.  
  
-   <xref:System.Diagnostics.Debugger.Break%2A?displayProperty=nameWithType> method.  
  
-   [DebugBreak](http://go.microsoft.com/fwlink/?LinkId=182106) function (Win32).  
  
 Before the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the .NET Framework provided separate registry keys to control the behavior of native and managed debuggers. Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], control is consolidated under a single registry key: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\Current Version\AeDebug. The values you can set for that key determine whether a debugger is invoked, and, if so, whether it is invoked with a dialog box that requires user interaction. For information about setting this registry key, see [Configuring Automatic Debugging](http://go.microsoft.com/fwlink/?LinkId=181767).  
  
## See Also  
 [Debugging, Tracing, and Profiling](../../../docs/framework/debug-trace-profile/index.md)  
 [Making an Image Easier to Debug](../../../docs/framework/debug-trace-profile/making-an-image-easier-to-debug.md)  
 [Enabling Profiling](http://msdn.microsoft.com/library/3b669676-f0e0-4ebf-8674-68986dd2020d)
