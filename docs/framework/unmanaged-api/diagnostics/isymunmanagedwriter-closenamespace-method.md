---
title: "ISymUnmanagedWriter::CloseNamespace Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.CloseNamespace"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::CloseNamespace"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::CloseNamespace method [.NET Framework debugging]"
  - "CloseNamespace method [.NET Framework debugging]"
ms.assetid: 7f74d9c5-1377-4958-b842-6306d611cbd5
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::CloseNamespace Method
Closes the most recently opened namespace.  
  
## Syntax  
  
```cpp  
HRESULT CloseNamespace();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
- [OpenNamespace Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-opennamespace-method.md)
