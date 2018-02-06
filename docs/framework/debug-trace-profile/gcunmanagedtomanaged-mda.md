---
title: "gcUnmanagedToManaged MDA"
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
  - "MDAs (managed debugging assistants), garbage collection"
  - "GC unmanaged to managed"
  - "transitioning threads unmanaged to managed code"
  - "GcUnmanagedToManaged MDA"
  - "threading [.NET Framework], garbage collection"
  - "managed debugging assistants (MDAs), garbage collection"
  - "threading [.NET Framework], managed debugging assistants"
  - "garbage collection, run-time errors"
  - "unmanaged to managed garbage collection"
ms.assetid: 103eb3a3-1cf0-4406-8a9a-a7798fdc22d1
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# gcUnmanagedToManaged MDA
The `gcUnmanagedToManaged` managed debugging assistant (MDA) causes a garbage collection whenever a thread transitions from unmanaged to managed code.  
  
## Symptoms  
 An application running unmanaged user components using COM and platform invoke is causing a nondeterministic access violation in the CLR.  
  
## Cause  
 If an application is running unmanaged user components, then those components might have corrupted the garbage-collected heap. This causes an access violation in the CLR when the garbage collector tries to walk the object graph.  
  
## Resolution  
 Enabling this assistant reduces the time between when the unmanaged component corrupts the garbage-collected heap and when the access violation happens by forcing a garbage collection to occur before every managed transition.  
  
## Effect on the Runtime  
 Causes a garbage collection whenever a thread transitions from unmanaged to managed code.  
  
## Output  
 This MDA produces no output.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <gcUnmanagedToManaged/>  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [gcManagedToUnmanaged](../../../docs/framework/debug-trace-profile/gcmanagedtounmanaged-mda.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
