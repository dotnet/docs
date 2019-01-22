---
title: "ISymUnmanagedMethod::GetScopeFromOffset Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedMethod.GetScopeFromOffset"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetScopeFromOffset"
helpviewer_keywords: 
  - "GetScopeFromOffset method [.NET Framework debugging]"
  - "ISymUnmanagedMethod::GetScopeFromOffset method [.NET Framework debugging]"
ms.assetid: d14cf210-81f8-46e1-8b19-6ddec0ba8b11
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedMethod::GetScopeFromOffset Method
Gets the most enclosing lexical scope within this method that encloses the given offset. This can be used to start local variable searches.  
  
## Syntax  
  
```  
HRESULT GetScopeFromOffset(  
    [in]  ULONG32 offset,  
    [out, retval] ISymUnmanagedScope**  pRetVal);  
```  
  
#### Parameters  
 `offset`  
 [in] A `ULONG` that contains the offset.  
  
 `pRetVal`  
 [out] A pointer that is set to the returned [ISymUnmanagedScope](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md) interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also
 [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
