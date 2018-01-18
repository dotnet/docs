---
title: "_AxlGetIssuerPublicKeyHash Function"
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
  - "_AxlGetIssuerPublicKeyHash"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: fb626b41-b888-4625-84c3-2c02b5e3866f
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _AxlGetIssuerPublicKeyHash Function
Retrieves the SHA-1 hash of the public key associated with the private key that is used to sign the specified certificate.  
  
## Syntax  
  
```  
HRESULT _AxlGetIssuerPublicKeyHash (  
    [in]  IN PCRYPT_DATA_BLOB   pChainContext,  
    [out] LPWSTR                *ppwszPublicKeyHash  
);  
```  
  
#### Parameters  
 `pChainContext`  
 [in] The CSP public key blob. See the [CRYPTOAPI_BLOB](http://msdn.microsoft.com/library/windows/desktop/aa380238.aspx) structure.  
  
 `ppwszPublicKeyHash`  
 [out] A pointer to WCHAR * to receive the hex-encoded public key token.  
  
## Return Value  
 `S_OK` if the function succeeds; otherwise `S_FALSE`.  
  
## See Also  
 [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
