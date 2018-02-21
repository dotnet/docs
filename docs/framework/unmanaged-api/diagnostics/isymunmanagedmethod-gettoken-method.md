---
title: "ISymUnmanagedMethod::GetToken Method"
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
  - "ISymUnmanagedMethod.GetToken"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetToken"
helpviewer_keywords: 
  - "ISymUnmanagedMethod::GetToken method [.NET Framework debugging]"
  - "GetToken method, ISymUnmanagedMethod interface [.NET Framework debugging]"
ms.assetid: 4effbe95-c36e-4a45-8b2a-ee21339415fb
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedMethod::GetToken Method
Returns the metadata token for this method.  
  
## Syntax  
  
```  
HRESULT GetToken(  
   [out, retval]  mdMethodDef  *pToken);  
```  
  
#### Parameters  
 `pToken`  
 [out] A pointer to a `mdMethodDef` that receives the size, in characters, of the buffer required to contain the metadata.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
