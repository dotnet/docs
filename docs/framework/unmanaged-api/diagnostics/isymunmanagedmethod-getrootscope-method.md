---
title: "ISymUnmanagedMethod::GetRootScope Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedMethod.GetRootScope"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetRootScope"
helpviewer_keywords: 
  - "ISymUnmanagedMethod::GetRootScope method [.NET Framework debugging]"
  - "GetRootScope method [.NET Framework debugging]"
ms.assetid: 7d58caac-2e75-4dfa-9249-32d8a624b247
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedMethod::GetRootScope Method
Gets the root lexical scope within this method. This scope encloses the entire method.  
  
## Syntax  
  
```  
HRESULT GetRootScope(  
    [out, retval] ISymUnmanagedScope** pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer that is set to the returned [ISymUnmanagedScope](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md) interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also
- [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
