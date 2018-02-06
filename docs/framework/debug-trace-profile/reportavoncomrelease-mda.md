---
title: "reportAvOnComRelease MDA"
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
  - "MDAs (managed debugging assistants), reference counting errors"
  - "exceptions, reference counting errors"
  - "ReportAvOnComRelease MDA"
  - "COM release access violations"
  - "user reference counting errors"
  - "managed debugging assistants (MDAs), reference counting errors"
  - "report access violation on Com release"
  - "reference counting errors"
ms.assetid: a2b86b63-08b2-4943-b344-3c2cf46ccd31
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# reportAvOnComRelease MDA
The `reportAvOnComRelease` managed debugging assistant (MDA) is activated when exceptions are thrown due to user reference counting errors while performing COM interop and using the <xref:System.Runtime.InteropServices.Marshal.Release%2A> or <xref:System.Runtime.InteropServices.Marshal.ReleaseComObject%2A> method combined with raw COM calls.  
  
## Symptoms  
 Access violations and memory corruption.  
  
## Cause  
 Occasionally, an exception is thrown due to user reference counting errors while performing COM interop and using the <xref:System.Runtime.InteropServices.Marshal.Release%2A> or <xref:System.Runtime.InteropServices.Marshal.ReleaseComObject%2A> method combined with raw COM calls. Normally, this exception is discarded because not doing so would cause an access violation in the CLR, bringing it down. When this assistant is enabled, such exceptions can be detected and reported instead of being simply discarded.  
  
## Resolution  
 Examine your reference counting code and search for errors as well as examining the native clients of your object for reference counting errors.  
  
## Effect on the Runtime  
 Two modes are available. If the `allowAv` attribute is `true`, the assistant prevents the runtime from discarding the access violation. If `allowAv` is `false`, which is the default, the runtime discards the access violation, but a warning message is reported to the user to indicate that an exception was thrown and discarded.  
  
## Output  
 If possible, the output contains the COM interface pointer's original vtable. Otherwise, an informational message is displayed.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <reportAvOnComRelease />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
