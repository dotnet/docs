---
description: "Learn more about: ICLRGCManager Interface"
title: "ICLRGCManager Interface"
ms.date: "03/30/2017"
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
---
# ICLRGCManager Interface

Provides methods that allow a host to interact with the common language runtime's garbage collection system.  
  
> [!NOTE]
> Starting with the .NET Framework 4.5, you can use the [ICLRGCManager2::SetGCStartupLimitsEx](iclrgcmanager2-setgcstartuplimitsex-method.md) method to set the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0 to values greater than the `DWORD` limit that is imposed by the [SetGCStartupLimits](iclrgcmanager-setgcstartuplimits-method.md) method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Collect Method](iclrgcmanager-collect-method.md)|Forces a garbage collection for the specified generation.|  
|[GetStats Method](iclrgcmanager-getstats-method.md)|Gets a set of current statistics about the garbage collection system.|  
|[SetGCStartupLimits Method](iclrgcmanager-setgcstartuplimits-method.md)|Sets the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0.|  
  
## Remarks  

 The common language runtime (CLR) implements its garbage collection mechanism with the managed <xref:System.GC> type. For more information about the garbage collection system, see [Garbage Collection](../../../standard/garbage-collection/index.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Automatic Memory Management](../../../standard/automatic-memory-management.md)
- [COR_GC_STATS Structure](cor-gc-stats-structure.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [CLR Hosting Interfaces](clr-hosting-interfaces.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
