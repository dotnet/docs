---
title: "ISymUnmanagedScope2::GetConstants Method"
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
  - "ISymUnmanagedScope2.GetConstants"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope2::GetConstants"
helpviewer_keywords: 
  - "ISymUnmanagedScope2::GetConstants method [.NET Framework debugging]"
  - "GetConstants method [.NET Framework debugging]"
ms.assetid: f241b620-9ec5-42fd-92ef-3b22329db72a
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedScope2::GetConstants Method
Gets the local constants defined within this scope.  
  
## Syntax  
  
```  
HRESULT GetConstants(  
     [in]  ULONG32  cConstants,  
     [out] ULONG32  *pcConstants,  
     [out, size_is(cConstants),  
         length_is(*pcConstants)] ISymUnmanagedConstant*   
             constants[]);  
```  
  
#### Parameters  
 `cConstants`  
 [in] The length of the buffer that the `pcConstants` parameter points to.  
  
 `pcConstants`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the constants.  
  
 `constants`  
 [out] The buffer that stores the constants.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedScope2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope2-interface.md)
