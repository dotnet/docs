---
title: "ISymUnmanagedConstant::GetName Method"
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
  - "ISymUnmanagedConstant.GetName"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedConstant::GetName"
helpviewer_keywords: 
  - "ISymUnmanagedConstant::GetName method [.NET Framework debugging]"
  - "GetName method, ISymUnmanagedConstant interface [.NET Framework debugging]"
ms.assetid: cbaca4e1-4473-459b-ba34-f1f59ce7c0ba
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedConstant::GetName Method
Gets the name of the constant.  
  
## Syntax  
  
```  
HRESULT GetName(  
    [in]  ULONG32  cchName,  
    [out] ULONG32  *pcchName,  
    [out, size_is(cchName),  
        length_is(*pcchName)] WCHAR szName[]);  
```  
  
#### Parameters  
 `cchName`  
 [in] The length of the buffer that the `szName` parameter points to.  
  
 `pcchName`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the name, including the null termination.  
  
 `szName`  
 [out] The buffer that stores the name.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedConstant Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-interface.md)  
 [GetSignature Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-getsignature-method.md)  
 [GetValue Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-getvalue-method.md)
