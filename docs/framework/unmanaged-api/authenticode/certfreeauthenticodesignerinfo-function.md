---
title: "CertFreeAuthenticodeSignerInfo Function"
ms.date: "03/30/2017"
api_name: 
  - "CertFreeAuthenticodeSignerInfo"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: 8029633c-b6e4-4665-a7c2-89607c3247ef
---
# CertFreeAuthenticodeSignerInfo Function
Frees resources allocated for the [AXL_AUTHENTICODE_SIGNER_INFO](axl-authenticode-signer-info-structure.md) structure.  
  
## Syntax  
  
```cpp  
HRESULT CertFreeAuthenticodeSignerInfo (  
    [in, out]  PAXL_AUTHENTICODE_SIGNER_INFO   pSignerInfo);  
```  
  
## Parameters  
 `pSignerInfo`  
 [in, out] Signer information to be released. See the [AXL_AUTHENTICODE_SIGNER_INFO](axl-authenticode-signer-info-structure.md) structure.  
  
## Return Value  
 `S_OK` if the function succeeds. Otherwise, returns an error code.  
  
## See also

- [Authenticode](index.md)
