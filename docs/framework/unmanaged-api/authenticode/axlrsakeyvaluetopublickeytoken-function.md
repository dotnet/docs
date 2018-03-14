---
title: "_AxlRSAKeyValueToPublicKeyToken Function"
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
  - "_AxlRSAKeyValueToPublicKeyToken"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: d60f19fe-7bec-47ba-b60e-ba9ce66abf8c
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _AxlRSAKeyValueToPublicKeyToken Function
Converts a Modulus and Exponent to a strong name public key token.  
  
## Syntax  
  
```  
HRESULT _AxlRSAKeyValueToPublicKeyToken (  
    [in]  PCRYPT_DATA_BLOB pModulusBlob,  
    [in]  PCRYPT_DATA_BLOB pExponentBlob,  
    [out] LPWSTR           *ppwszPublicKeyToken  
);  
```  
  
#### Parameters  
 `pModulusBlob`  
 [in] The base64-encoded Modulus blob (from the \<Modulus> element).  See the [CRYPTOAPI_BLOB](http://msdn.microsoft.com/library/windows/desktop/aa380238.aspx) structure.  
  
 `pExponentBlob`  
 [in] The base64-encoded Exponent blob (from the \<Exponent> element). See the [CRYPTOAPI_BLOB](http://msdn.microsoft.com/library/windows/desktop/aa380238.aspx) structure.  
  
 `ppwszPublicKeyToken`  
 [out] A pointer to WCHAR * to receive the hex-encoded public key token.  
  
## Return Value  
 `S_OK` if the function succeeds. Otherwise, returns an error code.  
  
## See Also  
 [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
