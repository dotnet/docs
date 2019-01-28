---
title: "ISymUnmanagedReader::GetVariables Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetVariables"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetVariables"
helpviewer_keywords: 
  - "ISymUnmanagedReader::GetVariables method [.NET Framework debugging]"
  - "GetVariables method, ISymUnmanagedReader interface [.NET Framework debugging]"
ms.assetid: 16dc49cb-2c60-4ac8-9c35-020e9afba3f8
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedReader::GetVariables Method
Returns a non-local variable, given its parent and name.  
  
## Syntax  
  
```  
HRESULT GetVariables (  
    [in]  mdToken  parent,  
    [in]  ULONG32  cVars,  
    [out] ULONG32  *pcVars,  
    [out, size_is (cVars),  
        length_is (*pcVars)] ISymUnmanagedVariable *pVars[]);  
```  
  
#### Parameters  
 `parent`  
 [in] The parent of the variable.  
  
 `cVars`  
 [in] The size of the `pVars` array.  
  
 `pcVars`  
 [out] A pointer to the variable that receives the number of variables returned in `pVars`.  
  
 `pVars`  
 [out] A pointer to the variable that receives the variables.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also
- [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
