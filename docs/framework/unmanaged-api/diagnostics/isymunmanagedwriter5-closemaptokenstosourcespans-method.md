---
title: "ISymUnmanagedWriter5::CloseMapTokensToSourceSpans Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: f8a0c0a2-a11d-436c-aa85-bc110215cfd6
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter5::CloseMapTokensToSourceSpans Method
Close the special custom data section for token-to-source span mapping information. After it is closed, no more mapping information can be added.  
  
## Syntax  
  
```idl  
HRESULT CloseMapTokensToSourceSpans();  
```  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter5 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-interface.md)
