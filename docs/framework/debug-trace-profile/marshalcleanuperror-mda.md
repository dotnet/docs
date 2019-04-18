---
title: "marshalCleanupError MDA"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "cleanup operations"
  - "marshaling, run-time errors"
  - "managed debugging assistants (MDAs), marshaling"
  - "MDAs (managed debugging assistants), marshaling"
  - "marshaling cleanup error"
  - "MarshalCleanupError MDA"
  - "memory, cleanup errors"
ms.assetid: 2f5d9e7c-ae51-4155-a435-54347aa1f091
author: "mairaw"
ms.author: "mairaw"
---
# marshalCleanupError MDA
The `marshalCleanupError` managed debugging assistant (MDA) is activated when the common language runtime (CLR) encounters an error while attempting to clean up temporary structures and memory used for marshaling data types between native and managed code boundaries.  
  
## Symptoms  
 A memory leak occurs when making native and managed code transitions, runtime state such as thread culture is not restored, or errors occur in <xref:System.Runtime.InteropServices.SafeHandle> cleanup.  
  
## Cause  
 An unexpected error occurred while cleaning up temporary structures.  
  
## Resolution  
 Review all <xref:System.Runtime.InteropServices.SafeHandle> destructor, finalizer, and custom marshaler implementations for errors.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
 A message reporting the operation that failed during cleanup.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <marshalCleanupError />  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
