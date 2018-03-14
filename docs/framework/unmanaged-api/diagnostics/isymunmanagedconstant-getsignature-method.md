---
title: "ISymUnmanagedConstant::GetSignature Method"
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
  - "ISymUnmanagedConstant.GetSignature"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedConstant::GetSignature"
helpviewer_keywords: 
  - "GetSignature method, ISymUnmanagedConstant interface [.NET Framework debugging]"
  - "ISymUnmanagedConstant::GetSignature method [.NET Framework debugging]"
ms.assetid: 3eb41151-a228-43e3-ba8f-e6dd3ceb8542
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedConstant::GetSignature Method
Gets the signature of the constant.  
  
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
 [in] The length of the buffer that the `pcSig` parameter points to.  
  
 `pcSig`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the signature.  
  
 `sig`  
 [out] The buffer that stores the signature.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedConstant Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-interface.md)  
 [GetName Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-getname-method.md)  
 [GetValue Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-getvalue-method.md)
