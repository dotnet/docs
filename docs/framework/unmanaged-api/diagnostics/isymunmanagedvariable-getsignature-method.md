---
title: "ISymUnmanagedVariable::GetSignature Method"
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
  - "ISymUnmanagedVariable.GetSignature"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetSignature"
helpviewer_keywords: 
  - "GetSignature method, ISymUnmanagedVariable interface [.NET Framework debugging]"
  - "ISymUnmanagedVariable::GetSignature method [.NET Framework debugging]"
ms.assetid: 78c1ba28-a410-4360-805c-23a95408964a
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedVariable::GetSignature Method
Gets the signature of this variable.  
  
## Syntax  
  
```  
HRESULT GetSignature(  
    [in]  ULONG32  cSig,  
    [out] ULONG32  *pcSig,  
    [out, size_is(cSig),  
        length_is(*pcSig)] BYTE sig[]);  
```  
  
#### Parameters  
 `cSig`  
 [in] The length of the buffer pointed to by the `sig` parameter.  
  
 `pcSig`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the signature.  
  
 `sig`  
 [out] The buffer that stores the signature.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedVariable Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-interface.md)
