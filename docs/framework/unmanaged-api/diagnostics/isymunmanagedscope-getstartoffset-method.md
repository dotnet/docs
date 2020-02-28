---
title: "ISymUnmanagedScope::GetStartOffset Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope.GetStartOffset"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetStartOffset"
helpviewer_keywords: 
  - "GetStartOffset method, ISymUnmanagedScope interface [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetStartOffset method [.NET Framework debugging]"
ms.assetid: da6bbc75-94d1-4354-9722-0d455b4428fb
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope::GetStartOffset Method
Gets the start offset for this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetStartOffset(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that contains the starting offset.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)
- [GetEndOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getendoffset-method.md)
