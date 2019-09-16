---
title: "ISymUnmanagedMethod::GetParameters Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedMethod.GetParameters"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetParameters"
helpviewer_keywords: 
  - "ISymUnmanagedMethod::GetParameters method [.NET Framework debugging]"
  - "GetParameters method [.NET Framework debugging]"
ms.assetid: 3a8074f1-facc-4a3f-bb9b-d6574fc2fc74
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedMethod::GetParameters Method
Gets the parameters for this method. The parameters are returned in the order in which they are defined within the method's signature.  
  
## Syntax  
  
```cpp  
HRESULT GetParameters(  
    [in]  ULONG32  cParams,  
    [out] ULONG32  *pcParams,  
    [out, size_is(cParams),  
        length_is(*pcParams)] ISymUnmanagedVariable*  params[]);  
```  
  
## Parameters  
 `cParams`  
 [in] The size of the `params` array.  
  
 `pcParams`  
 [in] A pointer to a `ULONG32` that receives the size of the buffer that is required to contain the parameters.  
  
 `params`  
 [out] A pointer to the buffer that receives the parameters.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
