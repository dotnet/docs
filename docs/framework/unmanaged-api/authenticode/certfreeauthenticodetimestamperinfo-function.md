---
title: "CertFreeAuthenticodeTimestamperInfo Function"
ms.date: "03/30/2017"
api_name: 
  - "CertFreeAuthenticodeTimestamperInfo"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: 3eb14c49-68c2-4516-ac89-e5bd7473831c
author: "rpetrusha"
ms.author: "ronpet"
---
# CertFreeAuthenticodeTimestamperInfo Function
Frees resources allocated for the [AXL_AUTHENTICODE_TIMESTAMPER_INFO](../../../../docs/framework/unmanaged-api/authenticode/axl-authenticode-timestamper-info-structure.md) structure.  
  
## Syntax  
  
```  
HRESULT CertFreeAuthenticodeTimestamperInfo (  
    [in, out]  PAXL_AUTHENTICODE_TIMESTAMPER_INFO   pTimestamperInfo  
);  
```  
  
#### Parameters  
 `pTimestamperInfo`  
 [in, out] The time stamper information to be released. See the [AXL_AUTHENTICODE_TIMESTAMPER_INFO](../../../../docs/framework/unmanaged-api/authenticode/axl-authenticode-timestamper-info-structure.md) structure.  
  
## Return Value  
 `S_OK` if the function succeeds. Otherwise, returns an error code.  
  
## See also
 [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
