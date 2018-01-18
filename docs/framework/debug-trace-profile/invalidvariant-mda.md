---
title: "invalidVariant MDA"
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
  - "MDAs (managed debugging assistants), invalid variant"
  - "VARIANT type errors"
  - "InvalidVariant MDA"
  - "invalid VARIANT types"
  - "managed debugging assistants (MDAs), invalid variant"
ms.assetid: d273e070-d1b1-4a53-a9c7-7af837b04a3d
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# invalidVariant MDA
The `invalidVariant` managed debugging assistant (MDA) is activated when an invalid `VARIANT` structure is encountered during a call from native or unmanaged code to managed code.  
  
## Symptoms  
 Unexpected behavior during a transition between native and managed code involving the marshaling of a `VARIANT` to an object.  
  
## Cause  
 Native code is passing a malformed `VARIANT` structure to managed code.  The runtime attempts to marshal this `VARIANT` to an object and activates the MDA if the `VARIANT` is not valid. Examples of invalid `VARIANT`S include a `VARIANT` with `VARTYPE` VT_EMPTY &#124; VT_BYREF or a `VARIANT` with `VARTYPE` VT_VARIANT.  
  
## Resolution  
 The native or unmanaged code passing the `VARIANT` must ensure that the `VARIANT` is correctly formed and initialized.  
  
## Effect on the Runtime  
 The MDA has no effect on the runtime's behavior.  
  
## Output  
 An MDA message indicating that the runtime detected an invalid `VARIANT` passed to managed code by an unmanaged module.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidVariant />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
