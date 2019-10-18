---
title: "ISymUnmanagedWriter5::CloseMapTokensToSourceSpans Method"
ms.date: "03/30/2017"
ms.assetid: f8a0c0a2-a11d-436c-aa85-bc110215cfd6
author: "rpetrusha"
ms.author: "ronpet"
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
  
## See also

- [ISymUnmanagedWriter5 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-interface.md)
