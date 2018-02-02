---
title: "loaderLock MDA"
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
  - "deadlocks [.NET Framework]"
  - "LoaderLock MDA"
  - "MDAs (managed debugging assistants), loader locks"
  - "managed debugging assistants (MDAs), loader locks"
  - "operating system loader locks"
  - "loader locks"
  - "locks, threads"
ms.assetid: 8c10fa02-1b9c-4be5-ab03-451d943ac1ee
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# loaderLock MDA
The `loaderLock` managed debugging assistant (MDA) detects attempts to execute managed code on a thread that holds the Microsoft Windows operating system loader lock.  Any such execution is illegal because it can lead to deadlocks and to use of DLLs before they have been initialized by the operating system's loader.  
  
## Symptoms  
 The most common failure when executing code inside the operating system's loader lock is that threads will deadlock when attempting to call other Win32 functions that also require the loader lock.  Examples of such functions are `LoadLibrary`, `GetProcAddress`, `FreeLibrary`, and `GetModuleHandle`.  The application might not directly call these functions; the common language runtime (CLR) might call these functions as the result of a higher level call like <xref:System.Reflection.Assembly.Load%2A> or the first call to a platform invoke method.  
  
 Deadlocks can also occur if a thread is waiting for another thread to start or finish.  When a thread starts or finishes executing, it must acquire the operating system's loader lock to deliver events to affected DLLs.  
  
 Finally, there are cases where calls into DLLs can occur before those DLLs have been properly initialized by the operating system's loader.  Unlike the deadlock failures, which can be diagnosed by examining the stacks of all the threads involved in the deadlock, it is very difficult to diagnose the use of uninitialized DLLs without using this MDA.  
  
## Cause  
 Mixed managed/unmanaged C++ assemblies built for .NET Framework versions 1.0 or 1.1 generally attempt to execute managed code inside the loader lock unless special care has been taken, for example, linking with **/NOENTRY**.
  
 Mixed managed/unmanaged C++ assemblies built for .NET Framework version 2.0 are less susceptible to these problems, having the same reduced risk as applications using unmanaged DLLs that violate the operating system's rules.  For example, if an unmanaged DLL's `DllMain` entry point calls `CoCreateInstance` to obtain a managed object that has been exposed to COM, the result is an attempt to execute managed code inside the loader lock. For more information about loader lock issues in the .NET Framework version 2.0 and later, see [Initialization of Mixed Assemblies](/cpp/dotnet/initialization-of-mixed-assemblies).  
  
## Resolution  
 In Visual C++ .NET 2002 and Visual C++ .NET 2003, DLLs compiled with the `/clr` compiler option could non-deterministically deadlock when loaded; this issue was called the mixed DLL loading or loader lock issue. In Visual C++ 2005 and later, almost all non-determinism has been removed from the mixed DLL loading process. However, there are a few remaining scenarios for which loader lock can (deterministically) occur. For a detailed account of the causes and resolutions for the remaining loader lock issues, see [Initialization of Mixed Assemblies](/cpp/dotnet/initialization-of-mixed-assemblies). If that topic does not identify your loader lock problem, you have to examine the thread's stack to determine why the loader lock is occurring and how to correct the problem. Look at the stack trace for the thread that has activated this MDA.  The thread is attempting to illegally call into managed code while holding the operating system's loader lock.  You will probably see a DLL's `DllMain` or equivalent entry point on the stack.  The operating system's rules for what you can legally do from inside such an entry point are quite limited.  These rules preclude any managed execution.  
  
## Effect on the Runtime  
 Typically, several threads inside the process will deadlock.  One of those threads is likely to be a thread responsible for performing a garbage collection, so this deadlock can have a major impact on the entire process.  Furthermore, it will prevent any additional operations that require the operating system's loader lock, like loading and unloading assemblies or DLLs and starting or stopping threads.  
  
 In some unusual cases, it is also possible for access violations or similar problems to be triggered in DLLs which are called before they have been initialized.  
  
## Output  
 This MDA reports that an illegal managed execution is being attempted.  You need to examine the thread's stack to determine why the loader lock is occurring and how to correct the problem.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <loaderLock/>  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
