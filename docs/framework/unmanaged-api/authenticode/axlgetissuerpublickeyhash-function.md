---
title: "_AxlGetIssuerPublicKeyHash Function"
ms.date: "03/30/2017"
api_name: 
  - "_AxlGetIssuerPublicKeyHash"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: fb626b41-b888-4625-84c3-2c02b5e3866f
author: "rpetrusha"
ms.author: "ronpet"
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
 [in] The CSP public key blob. See the [CRYPTOAPI_BLOB](/windows/desktop/api/dpapi/ns-dpapi-_cryptoapi_blob) structure.  
  
 `ppwszPublicKeyHash`  
 [out] A pointer to WCHAR * to receive the hex-encoded public key token.  
  
## Return Value  
 `S_OK` if the function succeeds; otherwise `S_FALSE`.  
  
## See also
- [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
