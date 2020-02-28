---
title: "ISymUnmanagedScope2::GetConstantCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope2.GetConstantCount"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope2::GetConstantCount"
helpviewer_keywords: 
  - "ISymUnmanagedScope2::GetConstantCount method [.NET Framework debugging]"
  - "GetConstantCount method [.NET Framework debugging]"
ms.assetid: 1e1f0be6-c4e8-4d6c-98cd-d5fa9f686e87
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope2::GetConstantCount Method
Gets a count of the constants defined within this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetConstantCount(  
    [out, retval] ULONG32 *pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the constants.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope2-interface.md)
