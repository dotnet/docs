---
title: "ISymUnmanagedWriter5 Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 15b8526e-4f5d-475c-a1e3-d8b2d145c879
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter5 Interface
ISymUnmanagedWriter5 interface.  
  
## Syntax  
  
```idl  
[object,uuid(DCF7780D-BDE9-45DF-ACFE-21731A32000C),pointer_default(unique)]interface ISymUnmanagedWriter5 : ISymUnmanagedWriter4  
```  
  
## Methods  
 This interface contains the following methods:  
  
|Method|Description|  
|------------|-----------------|  
|[CloseMapTokensToSourceSpans Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-closemaptokenstosourcespans-method.md)|Close the special custom data section for token-to- source span mapping information. After it is closed, no more mapping information can be added.|  
|[MapTokenToSourceSpan Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-maptokentosourcespan-method.md)|Maps the given metadata token to the given source line span in the specified source file.<br /><br /> Must be called between calls to [OpenMapTokensToSourceSpans Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-openmaptokenstosourcespans-method.md) and [CloseMapTokensToSourceSpans Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-closemaptokenstosourcespans-method.md).|  
|[OpenMapTokensToSourceSpans Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-openmaptokenstosourcespans-method.md)|Open a special custom data section to emit token-to- source span mapping information into. Opening this section when a method is already open, or vice versa, is an error.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [Diagnostics Symbol Store Interfaces](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-interfaces.md)  
 [ISymUnmanagedWriter4 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter4-interface.md)
