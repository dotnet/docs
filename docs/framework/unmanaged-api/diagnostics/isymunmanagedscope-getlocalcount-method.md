---
title: "ISymUnmanagedScope::GetLocalCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope.GetLocalCount"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetLocalCount"
helpviewer_keywords: 
  - "GetLocalCount method [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetLocalCount method [.NET Framework debugging]"
ms.assetid: 3ede8fb5-f655-4088-8e19-9c53812588a8
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedScope::GetLocalCount Method
Gets a count of the local variables defined within this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetLocalCount(  
    [out, retval] ULONG32 *pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the count of local variables.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)
