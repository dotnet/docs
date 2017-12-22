---
title: "IGCHost Interface"
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
  - "IGCHost"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IGCHost"
helpviewer_keywords: 
  - "IGCHost interface [.NET Framework hosting]"
ms.assetid: 9ad70ffd-6963-4ab2-8c84-3d86c3fb8deb
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCHost Interface
Provides methods for obtaining information about the garbage collection system and for controlling some aspects of garbage collection.  
  
> [!NOTE]
>  Starting with the [!INCLUDE[net_v45](../../../../includes/net-v45-md.md)], you can use the [IGCHost2::SetGCStartupLimitsEx](../../../../docs/framework/unmanaged-api/hosting/igchost2-setgcstartuplimitsex-method.md) method to set the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0 to values greater than the `DWORD` limit that is imposed by the [SetGCStartupLimits](../../../../docs/framework/unmanaged-api/hosting/igchost-setgcstartuplimits-method.md) method.  
  
> [!NOTE]
>  This interface is for expert usage only. It can affect the performance of an application if used improperly.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Collect Method](../../../../docs/framework/unmanaged-api/hosting/igchost-collect-method.md)|Forces a collection to occur for the given generation, regardless of the state of the current garbage collection.|  
|[GetStats Method](../../../../docs/framework/unmanaged-api/hosting/igchost-getstats-method.md)|Gets the statistics for the current state of the garbage collection system.|  
|[GetThreadStats Method](../../../../docs/framework/unmanaged-api/hosting/igchost-getthreadstats-method.md)|Gets the per-thread statistics for garbage collection.|  
|[SetGCStartupLimits Method](../../../../docs/framework/unmanaged-api/hosting/igchost-setgcstartuplimits-method.md)|Sets the segment size and the maximum size for generation 0.|  
|[SetVirtualMemLimit Method](../../../../docs/framework/unmanaged-api/hosting/igchost-setvirtualmemlimit-method.md)|Sets the maximum size of the runtime's virtual memory.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [CorRuntimeHost Coclass](../../../../docs/framework/unmanaged-api/hosting/corruntimehost-coclass.md)
