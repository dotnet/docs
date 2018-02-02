---
title: "dirtyCastAndCallOnInterface MDA"
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
  - "managed debugging assistants (MDAs), early bound calls AutoDispatch"
  - "dispatch-only mode"
  - "dirtyCastAndCallOnInterface"
  - "early-bound managed classes"
  - "early bound calls on AutoDispatch"
  - "MDAs (managed debugging assistants), early bound calls AutoDispatch"
  - "EarlyBoundCallOnAutorDispatchClassInteface MDA"
ms.assetid: aa388ed3-7e3d-48ea-a0b5-c47ae19cec38
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# dirtyCastAndCallOnInterface MDA
The `dirtyCastAndCallOnInterface` managed debugging assistant (MDA) is activated when an early-bound call through a vtable is attempted on a class interface that has been marked late-bound only.  
  
## Symptoms  
 An application throws an access violation or has unexpected behavior when placing an early-bound call via COM into the CLR.  
  
## Cause  
 Code is attempting an early-bound call through a vtable via a class interface that is late-bound only. Note that by default class interfaces are identified as being late-bound only. They can also be identified as late-bound with the <xref:System.Runtime.InteropServices.ClassInterfaceAttribute> attribute with an <xref:System.Runtime.InteropServices.ClassInterfaceType.AutoDispatch> value (`[ClassInterface(ClassInterfaceType.AutoDispatch)]`).  
  
## Resolution  
 The recommended resolution is to define an explicit interface for use by COM and have the COM clients call through this interface instead of through the automatically generated class interface. Alternatively, the call from COM can be transformed into a late-bound call via `IDispatch`.  
  
 Finally, it is possible to identify the class as <xref:System.Runtime.InteropServices.ClassInterfaceType.AutoDual> (`[ClassInterface(ClassInterfaceType.AutoDual)]`) to allow early bound calls to be placed from COM; however, using <xref:System.Runtime.InteropServices.ClassInterfaceType.AutoDual> is strongly discouraged because of the versioning limitations described in <xref:System.Runtime.InteropServices.ClassInterfaceAttribute>.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR. It only reports data about early-bound calls on late-bound interfaces.  
  
## Output  
 The name of the method or name of the field being accessed early-bound.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <dirtyCastAndCallOnInterface />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.ClassInterfaceAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
