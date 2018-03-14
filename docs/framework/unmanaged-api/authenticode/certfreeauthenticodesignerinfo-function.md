---
title: "CertFreeAuthenticodeSignerInfo Function"
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
  - "CertFreeAuthenticodeSignerInfo"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: 8029633c-b6e4-4665-a7c2-89607c3247ef
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CertFreeAuthenticodeSignerInfo Function
Frees resources allocated for the [AXL_AUTHENTICODE_SIGNER_INFO](../../../../docs/framework/unmanaged-api/authenticode/axl-authenticode-signer-info-structure.md) structure.  
  
## Syntax  
  
```  
HRESULT CertFreeAuthenticodeSignerInfo (  
    [in, out]  PAXL_AUTHENTICODE_SIGNER_INFO   pSignerInfo);  
```  
  
#### Parameters  
 `pSignerInfo`  
 [in, out] Signer information to be released. See the [AXL_AUTHENTICODE_SIGNER_INFO](../../../../docs/framework/unmanaged-api/authenticode/axl-authenticode-signer-info-structure.md) structure.  
  
## Return Value  
 `S_OK` if the function succeeds. Otherwise, returns an error code.  
  
## See Also  
 [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
