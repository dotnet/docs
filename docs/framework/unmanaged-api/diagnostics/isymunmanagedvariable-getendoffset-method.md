---
title: "ISymUnmanagedVariable::GetEndOffset Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedVariable.GetEndOffset"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetEndOffset"
helpviewer_keywords: 
  - "ISymUnmanagedVariable::GetEndOffset method [.NET Framework debugging]"
  - "GetEndOffset method, ISymUnmanagedVariable interface [.NET Framework debugging]"
ms.assetid: e5d777c5-d450-4c0f-999c-b3953ee22cfb
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedVariable::GetEndOffset Method
Gets the end offset of this variable within its parent. If this is a local variable within a scope, the end offset will fall within the offsets defined for the scope.  
  
## Syntax  
  
```  
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

- [ISymUnmanagedVariable Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-interface.md)
- [GetStartOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getstartoffset-method.md)
