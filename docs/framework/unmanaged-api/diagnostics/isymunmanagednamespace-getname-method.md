---
title: "ISymUnmanagedNamespace::GetName Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedNamespace.GetName"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedNamespace::GetName"
helpviewer_keywords: 
  - "ISymUnmanagedNamespace::GetName method [.NET Framework debugging]"
  - "GetName method, ISymUnmanagedNamespace interface [.NET Framework debugging]"
ms.assetid: 657bf91d-005a-4ea4-9298-04d1291c0bc3
topic_type: 
  - "apiref"
---
# ISymUnmanagedNamespace::GetName Method
Gets the name of this namespace.  
  
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
 [in] A `ULONG32` that indicates the size of the `szName` buffer.  
  
 `pcchName`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the namespace name, including the null termination.  
  
 `szName`  
 [out] A pointer to a buffer that contains the namespace name.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedNamespace Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagednamespace-interface.md)
