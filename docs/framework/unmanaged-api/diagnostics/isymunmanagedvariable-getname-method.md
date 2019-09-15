---
title: "ISymUnmanagedVariable::GetName Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedVariable.GetName"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetName"
helpviewer_keywords: 
  - "GetName method, ISymUnmanagedVariable interface [.NET Framework debugging]"
  - "ISymUnmanagedVariable::GetName method [.NET Framework debugging]"
ms.assetid: eedf1ef0-9d4a-4847-a201-4e99572dfe5e
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedVariable::GetName Method
Gets the name of this variable.  
  
## Syntax  
  
```cpp  
HRESULT GetName(  
    [in]  ULONG32  cchName,  
    [out] ULONG32  *pcchName,  
    [out, size_is(cchName),  
        length_is(*pcchName)] WCHAR szName[]);  
```  
  
## Parameters  
 `cchName`  
 [in] The length of the buffer that the `pcchName` parameter points to.  
  
 `pcchName`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the name, including the null termination.  
  
 `szName`  
 [out] The buffer that stores the name.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedVariable Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-interface.md)
