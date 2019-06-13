---
title: "GetIdentityAuthority Function"
ms.date: "03/30/2017"
api_name: 
  - "GetIdentityAuthority"
api_location: 
  - "fusion.dll"
  - "clr.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetIdentityAuthority"
helpviewer_keywords: 
  - "GetIdentityAuthority function [.NET Framework fusion]"
ms.assetid: 843cd5ab-d2b7-4ff6-86bd-e68c7a91c098
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# GetIdentityAuthority Function
Gets a pointer to an [IIdentityAuthority](../../../../docs/framework/unmanaged-api/fusion/iidentityauthority-interface.md) instance that manages keys for code objects.  
  
## Syntax  
  
```  
HRESULT GetIdentityAuthority (  
    [out] IIdentityAuthority   **ppIIdentityAuthority  
 );  
```  
  
## Parameters  
 `ppIIdentityAuthority`  
 [out] The returned `IIdentityAuthority` pointer.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IIdentityAuthority Interface](../../../../docs/framework/unmanaged-api/fusion/iidentityauthority-interface.md)
- [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)
