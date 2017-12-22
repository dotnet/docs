---
title: "ISymUnmanagedScope::GetLocals Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedScope::GetLocals Method
Gets the local variables defined within this scope.  
  
## Syntax  
  
```  
HRESULT GetLocals(  
    [in]  ULONG32  cLocals,  
    [out] ULONG32  *pcLocals,  
    [out, size_is(cLocals),  
        length_is(*pcLocals)] ISymUnmanagedVariable* locals[]);  
```  
  
#### Parameters  
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
  
## See Also  
 [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)
