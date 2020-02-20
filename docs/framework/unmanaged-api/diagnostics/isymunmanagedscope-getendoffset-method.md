---
title: "ISymUnmanagedScope::GetEndOffset Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope.GetEndOffset"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetEndOffset"
helpviewer_keywords: 
  - "ISymUnmanagedScope::GetEndOffset method [.NET Framework debugging]"
  - "GetEndOffset method, ISymUnmanagedScope interface [.NET Framework debugging]"
ms.assetid: 1d0b15c9-8059-435f-9fce-346a08b9bd36
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope::GetEndOffset Method
Gets the end offset for this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetEndOffset(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the end offset.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)
- [GetStartOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getstartoffset-method.md)
