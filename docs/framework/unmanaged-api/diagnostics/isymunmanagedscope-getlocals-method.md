---
description: "Learn more about: ISymUnmanagedScope::GetLocals Method"
title: "ISymUnmanagedScope::GetLocals Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope.GetLocals"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetLocals"
helpviewer_keywords: 
  - "GetLocals method [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetLocals method [.NET Framework debugging]"
ms.assetid: 17c45f15-8c44-44da-b070-f902077b36e4
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope::GetLocals Method

Gets the local variables defined within this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetLocals(  
    [in]  ULONG32  cLocals,  
    [out] ULONG32  *pcLocals,  
    [out, size_is(cLocals),  
        length_is(*pcLocals)] ISymUnmanagedVariable* locals[]);  
```  
  
## Parameters  

 `cLocals`  
 [in] A `ULONG32` that indicates the size of the `locals` array.  
  
 `pcLocals`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the local variables.  
  
 `locals`  
 [out] The array that receives the local variables.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope Interface](isymunmanagedscope-interface.md)
