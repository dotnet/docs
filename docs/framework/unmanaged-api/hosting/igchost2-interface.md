---
title: "IGCHost2 Interface"
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
  - "IGCHost2"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IGCHost2"
helpviewer_keywords: 
  - "IGCHost2 interface [.NET Framework hosting]"
ms.assetid: e5323fa4-18ac-424d-859d-a65a550d08d9
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCHost2 Interface
Provides methods for obtaining information about the garbage collection system and for controlling some aspects of garbage collection.  
  
> [!NOTE]
>  For new development, we recommend that you use the [ICLRGCManager2](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager2-interface.md) interface instead.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetGCStartupLimitsEx Method](../../../../docs/framework/unmanaged-api/hosting/igchost2-setgcstartuplimitsex-method.md)|Sets the segment size and the maximum size for generation 0. Enables generation 0 and segment sizes larger than `DWORD`.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [CLR Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/clr-hosting-interfaces.md)  
 [CorRuntimeHost Coclass](../../../../docs/framework/unmanaged-api/hosting/corruntimehost-coclass.md)
