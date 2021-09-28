---
description: "Learn more about: ISymUnmanagedNamespace::GetVariables Method"
title: "ISymUnmanagedNamespace::GetVariables Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedNamespace.GetVariables"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedNamespace::GetVariables"
helpviewer_keywords: 
  - "ISymUnmanagedNamespace::GetVariables method [.NET Framework debugging]"
  - "GetVariables method, ISymUnmanagedNamespace interface [.NET Framework debugging]"
ms.assetid: ea7c1617-f3ce-4220-8288-f2b50eaf0f0f
topic_type: 
  - "apiref"
---
# ISymUnmanagedNamespace::GetVariables Method

Returns all variables defined at global scope within this namespace.  
  
## Syntax  
  
```cpp
HRESULT GetVariables(  
    [in]  ULONG32  cVars,  
    [out] ULONG32  *pcVars,  
    [out, size_is(cVars), length_is(*pcVars)]  
        ISymUnmanagedVariable *pVars[]);  
```  
  
## Parameters  

 `cVars`  
 [in] A `ULONG32` that indicates the size of the `pVars` array.  
  
 `pcVars`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the namespaces.  
  
 `pVars`  
 [out] A pointer to a buffer that contains the namespaces.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedNamespace Interface](isymunmanagednamespace-interface.md)
