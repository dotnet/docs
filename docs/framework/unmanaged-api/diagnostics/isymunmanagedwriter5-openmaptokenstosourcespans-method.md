---
title: "ISymUnmanagedWriter5::OpenMapTokensToSourceSpans Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 93ad2517-b0dc-464c-8688-a58a30eda18d
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
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
  
## See Also  
 [ISymUnmanagedWriter5 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter5-interface.md)
