---
title: "ICLRGCManager Interface"
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
  - "ICLRGCManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRGCManager"
helpviewer_keywords: 
  - "ICLRGCManager interface [.NET Framework hosting]"
ms.assetid: fb511c9b-3fe4-41b0-822a-6ba4a079d1f5
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRGCManager Interface
Provides methods that allow a host to interact with the common language runtime's garbage collection system.  
  
> [!NOTE]
>  Starting with the [!INCLUDE[net_v45](../../../../includes/net-v45-md.md)], you can use the [ICLRGCManager2::SetGCStartupLimitsEx](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager2-setgcstartuplimitsex-method.md) method to set the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0 to values greater than the `DWORD` limit that is imposed by the [SetGCStartupLimits](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-setgcstartuplimits-method.md) method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Collect Method](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-collect-method.md)|Forces a garbage collection for the specified generation.|  
|[GetStats Method](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-getstats-method.md)|Gets a set of current statistics about the garbage collection system.|  
|[SetGCStartupLimits Method](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-setgcstartuplimits-method.md)|Sets the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0.|  
  
## Remarks  
 The common language runtime (CLR) implements its garbage collection mechanism with the managed <xref:System.GC> type. For more information about the garbage collection system, see [Garbage Collection](../../../../docs/standard/garbage-collection/index.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Automatic Memory Management](../../../../docs/standard/automatic-memory-management.md)  
 [COR_GC_STATS Structure](../../../../docs/framework/unmanaged-api/hosting/cor-gc-stats-structure.md)  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)  
 [CLR Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/clr-hosting-interfaces.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
