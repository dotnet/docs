---
title: "ISymUnmanagedWriter5::OpenMapTokensToSourceSpans Method"
ms.date: "03/30/2017"
ms.assetid: 93ad2517-b0dc-464c-8688-a58a30eda18d
author: "rpetrusha"
ms.author: "ronpet"
---
# ISymUnmanagedWriter5::OpenMapTokensToSourceSpans Method
Open a special custom data section to emit token-to-source span mapping information into. Opening this section when a method is already open, or vice versa, is an error.  
  
## Syntax  
  
```idl  
HRESULT OpenMapTokensToSourceSpans();  
```  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter5 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-interface.md)
