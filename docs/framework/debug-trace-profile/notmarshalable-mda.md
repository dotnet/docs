---
title: "notMarshalable MDA"
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
  - "managed debugging assistants (MDAs), interface pointer not marshalable"
  - "interface pointer not marshalable MDA"
  - "MDAs (managed debugging assistants), interface pointer not marshalable"
  - "marshaling, run-time errors"
  - "managed debugging assistants (MDAs), marshaling"
  - "marshalable interface pointers"
  - "MDAs (managed debugging assistants), marshaling"
  - "notMarshalable MDA"
ms.assetid: 96e7b2c1-843f-4d64-b519-740c3a18b50a
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# notMarshalable MDA
The `notMarshalable` managed debugging assistant (MDA) is activated when the common language runtime (CLR) encounters a COM interface pointer without a valid registered proxy/stub or an incorrect `IMarshal` interface implementation while attempting to marshal the interface across contexts.  
  
## Symptoms  
 Calls are not serviced, or calls occur in the wrong context for COM interface pointers.  
  
## Cause  
 No valid registered proxy/stub or an incorrect `IMarshal` while attempting to marshal the interface across contexts.  
  
## Resolution  
 Make sure you have a proxy stub registered and that the `IMarshal` implementation is valid.  
  
## Effect on the Runtime  
 This MDA has no effect on the runtime.  
  
## Output  
 A message describing the problem.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <notMarshalable/>  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
