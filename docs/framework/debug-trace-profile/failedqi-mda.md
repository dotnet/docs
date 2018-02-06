---
title: "failedQI MDA"
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
  - "failed QueryInterface"
  - "FailedQI MDA"
  - "QueryInterface call failures"
  - "MDAs (managed debugging assistants), failed QueryInterface"
  - "managed debugging assistants (MDAs), failed QueryInterface"
ms.assetid: 902dc863-34b3-477c-b433-b8a6bb6133c6
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# failedQI MDA
The `failedQI` managed debugging assistant (MDA) is activated when the runtime calls `QueryInterface` on a COM interface pointer on behalf of a runtime callable wrapper (RCW), and the `QueryInterface` call fails.  
  
## Symptoms  
 A cast on an RCW fails, or a call to COM from an RCW fails unexpectedly.  
  
## Cause  
  
-   The call is made from the wrong context.  
  
-   The registered proxy is failing the `QueryInterface` call because the call was attempted in the wrong context.  
  
-   An OLE-owned proxy returned a failure HRESULT.  
  
## Resolution  
 See the MSDN documentation on COM rules.  
  
## Effect on the Runtime  
 If a `QueryInterface` call fails, the context is switched and the `QueryInterface` call is attempted again to see if an incorrect context was at fault.  
  
## Output  
 The managed name of the interface, the GUID of the interface, and the HRESULT of the failure.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <failedQI/>  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
