---
title: "disconnectedContext MDA"
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
  - "DisconnectedContext MDA"
  - "MDAs (managed debugging assistants), disconnected context"
  - "dead context"
  - "transitioning disconnected apartment or context"
  - "context disconnections"
  - "managed debugging assistants (MDAs), disconnected context"
ms.assetid: 1887d31d-7006-4491-93b3-68fd5b05f71d
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# disconnectedContext MDA
The `disconnectedContext` managed debugging assistant (MDA) is activated when the CLR attempts to transition into a disconnected apartment or context while servicing a request concerning a COM object.  
  
## Symptoms  
 Calls made on a [Runtime Callable Wrapper](../../../docs/framework/interop/runtime-callable-wrapper.md) (RCW) are delivered to the underlying COM component in the current apartment or context instead of the one in which they exist. This can cause corruption and or data loss if the COM component is not multithreaded, as in the case of single-threaded apartment (STA) components. Alternatively, if the RCW is itself a proxy, the call might result in the throwing of a <xref:System.Runtime.InteropServices.COMException> with an HRESULT of RPC_E_WRONG_THREAD.  
  
## Cause  
 The OLE apartment or context has been shut down when the CLR attempts to transition into it. This is most commonly caused by STA apartments being shut down before all the COM components owned by the apartment were completely released This can occur as a result of an explicit call from user code on an RCW or while the CLR itself is manipulating the COM component, for example when the CLR is releasing the COM component when the associated RCW has been garbage collected.  
  
## Resolution  
 To avoid this problem, ensure the thread that owns the STA does not terminate before the application has finished with all the objects that live in the apartment. The same applies to contexts; ensure contexts are not shut down before the application is completely finished with any COM components that live inside the context.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR. It only reports data about the disconnected context.  
  
## Output  
 Reports the context cookie of the disconnected apartment or context.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <disconnectedContext />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
