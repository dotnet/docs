---
title: "illegalPrepareConstrainedRegion MDA"
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
  - "PrepareConstrainedRegions method"
  - "managed debugging assistants (MDAs), illegal PrepareConstrainedRegions"
  - "try/catch exception handling, managed debugging assistants"
  - "IllegalPrepareConstrainedRegions MDA"
  - "MDAs (managed debugging assistants), illegal PrepareConstrainedRegions"
ms.assetid: 2f9b5031-f910-4e01-a196-f89eab313eaf
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# illegalPrepareConstrainedRegion MDA
The `illegalPrepareConstrainedRegion` managed debugging assistant (MDA) is activated when a <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A?displayProperty=nameWithType> method call does not immediately precede the `try` statement of the exception handler. This restriction is at the MSIL level, so it is permissible to have non-code-generating source between the call and the `try`, such as comments.  
  
## Symptoms  
 A constrained execution region (CER) that is never treated as such, but as a simple exception handling block (`finally` or `catch`). As a consequence, the region does not run in the event of an out-of-memory condition or a thread abort.  
  
## Cause  
 The preparation pattern for a CER is not followed correctly.  This is an error event. The <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> method call used to mark exception handlers as introducing a CER in their `catch`/`finally`/`fault`/`filter` blocks must be used immediately before the `try` statement.  
  
## Resolution  
 Ensure that the call to <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> happens immediately before the `try` statement.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
 The MDA displays the name of the method calling the <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> method, the MSIL offset, and a message indicating the call does not immediately precede the beginning of the try block.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <illegalPrepareConstrainedRegion/>  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 The following code example demonstrates the pattern that causes this MDA to be activated.  
  
```  
void MethodWithInvalidPCR()  
{  
    RuntimeHelpers.PrepareConstrainedRegions();  
    Object o = new Object();  
    try  
    {  
        …  
    }  
    finally  
    {  
        …  
    }  
}  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
