---
title: "GetAppIdAuthority Function"
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
  - "GetAppIdAuthority"
api_location: 
  - "fusion.dll"
  - "clr.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetAppIdAuthority"
helpviewer_keywords: 
  - "GetAppIdAuthority function [.NET Framework fusion]"
ms.assetid: 9f968dad-0d09-47fb-bebc-94c39a0d16ad
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetAppIdAuthority Function
Gets a pointer to an [IAppIdAuthority](../../../../docs/framework/unmanaged-api/fusion/iappidauthority-interface.md) instance that manages keys for application identities and references.  
  
## Syntax  
  
```  
HRESULT GetAppIdAuthority (  
    [out] IAppIdAuthority **ppIAppIdAuthority  
 );  
```  
  
#### Parameters  
 `ppIAppIdAuthority`  
 [out] The returned `IAppIdAuthority` pointer.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAppIdAuthority Interface](../../../../docs/framework/unmanaged-api/fusion/iappidauthority-interface.md)  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)
