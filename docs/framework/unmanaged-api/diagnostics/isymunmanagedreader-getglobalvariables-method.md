---
title: "ISymUnmanagedReader::GetGlobalVariables Method"
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
  - "ISymUnmanagedReader.GetGlobalVariables"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetGlobalVariables"
helpviewer_keywords: 
  - "GetGlobalVariables method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetGlobalVariables method [.NET Framework debugging]"
ms.assetid: a2dd5098-3e58-4be5-b7a2-e4160b3b505a
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::GetGlobalVariables Method
Returns all global variables.  
  
## Syntax  
  
```  
HRESULT GetGlobalVariables(  
    [in]  ULONG32  cVars,  
    [out] ULONG32  *pcVars,  
    [out, size_is(cVars),  
        length_is(*pcVars)] ISymUnmanagedVariable *pVars[]);  
```  
  
#### Parameters  
 `cVars`  
 [in] The length of the buffer pointed to by `pcVars`.  
  
 `pcVars`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the variables.  
  
 `pVars`  
 [out] A buffer that contains the variables.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
