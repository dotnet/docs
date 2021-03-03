---
description: "Learn more about: IGCHost2 Interface"
title: "IGCHost2 Interface"
ms.date: "03/30/2017"
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
---
# IGCHost2 Interface

Provides methods for obtaining information about the garbage collection system and for controlling some aspects of garbage collection.  
  
> [!NOTE]
> For new development, we recommend that you use the [ICLRGCManager2](iclrgcmanager2-interface.md) interface instead.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetGCStartupLimitsEx Method](igchost2-setgcstartuplimitsex-method.md)|Sets the segment size and the maximum size for generation 0. Enables generation 0 and segment sizes larger than `DWORD`.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
- [CLR Hosting Interfaces](clr-hosting-interfaces.md)
- [CorRuntimeHost Coclass](corruntimehost-coclass.md)
