---
title: "invalidIUnknown MDA"
description: Review the invalidIUnknown managed debugging assistant (MDA), which is activated when an invalid IUnknown pointer is passed to managed code from native code.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "MDAs (managed debugging assistants), invalid IUnknown pointer"
  - "InvalidIUnknown MDA"
  - "invalid IUnknown pointers"
  - "IUnknown pointers"
  - "managed debugging assistants (MDAs), invalid IUnknown pointer"
ms.assetid: c7924771-a16b-40fe-b337-ce51dcdf6a12
---
# invalidIUnknown MDA

The `invalidIUnknown` managed debugging assistant (MDA) is activated when an invalid `IUnknown` pointer is passed to managed code from native code. The `IUnknown` fails to return success when queried for the `IUnknown` interface.  
  
## Symptoms  

 An unexpected error occurs when marshaling a COM interface pointer during argument marshaling.  
  
## Cause  

 An incorrect `QueryInterface` implementation on the COM interface passed to the CLR.  
  
## Resolution  

 Correct the `QueryInterface` implementation.  
  
## Effect on the Runtime  

 This MDA has no effect on the CLR.  
  
## Output  

 The description of the error.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidIUnknown />  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshaling.md)
