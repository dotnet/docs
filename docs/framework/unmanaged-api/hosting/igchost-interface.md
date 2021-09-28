---
description: "Learn more about: IGCHost Interface"
title: "IGCHost Interface"
ms.date: "03/30/2017"
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
---
# IGCHost Interface

Provides methods for obtaining information about the garbage collection system and for controlling some aspects of garbage collection.  
  
> [!NOTE]
> Starting with the .NET Framework 4.5, you can use the [IGCHost2::SetGCStartupLimitsEx](igchost2-setgcstartuplimitsex-method.md) method to set the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0 to values greater than the `DWORD` limit that is imposed by the [SetGCStartupLimits](igchost-setgcstartuplimits-method.md) method.  
  
> [!NOTE]
> This interface is for expert usage only. It can affect the performance of an application if used improperly.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Collect Method](igchost-collect-method.md)|Forces a collection to occur for the given generation, regardless of the state of the current garbage collection.|  
|[GetStats Method](igchost-getstats-method.md)|Gets the statistics for the current state of the garbage collection system.|  
|[GetThreadStats Method](igchost-getthreadstats-method.md)|Gets the per-thread statistics for garbage collection.|  
|[SetGCStartupLimits Method](igchost-setgcstartuplimits-method.md)|Sets the segment size and the maximum size for generation 0.|  
|[SetVirtualMemLimit Method](igchost-setvirtualmemlimit-method.md)|Sets the maximum size of the runtime's virtual memory.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
- [CorRuntimeHost Coclass](corruntimehost-coclass.md)
