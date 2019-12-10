---
title: "ISymUnmanagedScope2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope2"
helpviewer_keywords: 
  - "ISymUnmanagedScope2 interface [.NET Framework debugging]"
ms.assetid: 2ed6a387-ba45-483e-9a1e-b0c69f67998b
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope2 Interface
Represents a lexical scope within a method. This interface extends the [ISymUnmanagedScope](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md) interface with methods that get information about constants defined within the scope.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetConstantCount Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope2-getconstantcount-method.md)|Gets a count of the constants defined within this scope.|  
|[GetConstants Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope2-getconstants-method.md)|Gets the local constants defined within this scope.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)
