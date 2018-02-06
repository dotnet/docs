---
title: "_AxlPublicKeyBlobToPublicKeyToken Function"
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
  - "_AxlPublicKeyBlobToPublicKeyToken"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: 2d92a746-d68c-4f53-a16e-727f071a2d80
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _AxlPublicKeyBlobToPublicKeyToken Function
Computes the strong name public key token from a CSP PUBLICKEYBLOB format.  
  
## Syntax  
  
```  
HRESULT _AxlPublicKeyBlobToPublicKeyToken (  
    [in]  PCCERT_CHAIN_CONTEXT   pCspPublicKeyBlob,  
    [out] LPWSTR                 *ppwszPublicKeyToken  
);  
```  
  
#### Parameters  
 `pCspPublicKeyBlob`  
 [in] The CSP public key blob.  
  
 `ppwszPublicKeyHash`  
 [out] A pointer to WCHAR * to receive the hex-encoded public key hash.  
  
## Return Value  
 `S_OK` if the function succeeds; otherwise `S_FALSE`.  
  
## See Also  
 [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
