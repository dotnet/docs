---
title: "Enabling JIT-Attach Debugging"
description: Enable just-in time (JIT) attach debugging to attach a debugger to a process when you encounter errors. It can be triggered by certain methods or functions.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "JIT-attach debugging"
  - "debugging [.NET Framework], JIT-attach debugging"
ms.assetid: f91fc5f7-de5a-4f23-b6ac-f450e63c662e
---
# Enabling JIT-Attach Debugging

JIT-attach debugging is the phrase used to describe attaching a debugger to a process when you encounter errors, or it can be triggered by specific methods or functions.  
  
 JIT-attach debugging is used under the following fault conditions:  
  
- Unhandled exceptions (in both native and managed code).  
  
- <xref:System.Environment.FailFast%2A?displayProperty=nameWithType> method or [RaiseFailFastException](/windows/win32/api/errhandlingapi/nf-errhandlingapi-raisefailfastexception) function (Windows 7 family).  
  
- Runtime fatal errors.  
  
 JIT-attach debugging is also triggered by calls to the following methods and functions:  
  
- <xref:System.Diagnostics.Debugger.Launch%2A?displayProperty=nameWithType> method.  
  
- <xref:System.Diagnostics.Debugger.Break%2A?displayProperty=nameWithType> method.  
  
- [DebugBreak](/windows/win32/api/debugapi/nf-debugapi-debugbreak) function (Win32).  
  
 Before the .NET Framework 4, the .NET Framework provided separate registry keys to control the behavior of native and managed debuggers. Starting with the .NET Framework 4, control is consolidated under a single registry key: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\Current Version\AeDebug. The values you can set for that key determine whether a debugger is invoked, and, if so, whether it is invoked with a dialog box that requires user interaction. For information about setting this registry key, see [Configuring Automatic Debugging](/windows/win32/debug/configuring-automatic-debugging).  
  
## See also

- [Debugging, Tracing, and Profiling](index.md)
- [Making an Image Easier to Debug](making-an-image-easier-to-debug.md)
