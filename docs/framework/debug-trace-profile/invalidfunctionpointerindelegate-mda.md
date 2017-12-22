---
title: "invalidFunctionPointerInDelegate MDA"
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
  - "invalidFunctionPointerInDelegate MDA"
  - "managed debugging assistants (MDAs), invalid function pointer to delegates"
  - "MDAs (managed debugging assistants), invalid function pointer to delegates"
  - "function pointers, invalid"
  - "marshaling, run-time errors"
  - "managed debugging assistants (MDAs), marshaling"
  - "MDAs (managed debugging assistants), marshaling"
  - "invalid function pointers"
ms.assetid: 99ae44f1-783e-49a9-9009-24f54bbd0f09
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# invalidFunctionPointerInDelegate MDA
The `invalidFunctionPointerInDelegate` managed debugging assistant (MDA) is activated when an invalid function pointer is passed in to construct a delegate over a native function pointer.  
  
## Symptoms  
 Access violations or unexpected memory corruption when using a delegate over a function pointer.  
  
## Cause  
 An invalid function pointer was specified.  
  
## Resolution  
 Specify a valid function pointer  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
 The invalid function pointer.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidFunctionPointerInDelegate />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
