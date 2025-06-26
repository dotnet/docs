---
description: "Learn more about: ICLRGCManager2 Interface"
title: "ICLRGCManager2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRGCManager2"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRGCManager2"
helpviewer_keywords: 
  - "ICLRGCManager2 interface [.NET Framework hosting]"
ms.assetid: 4b5ffd7b-9ad7-41cd-9bba-34030ae3da7e
topic_type: 
  - "apiref"
---
# ICLRGCManager2 Interface

Provides methods that allow a host to interact with the common language runtime's garbage collection system.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetGCStartupLimitsEx Method](iclrgcmanager2-setgcstartuplimitsex-method.md)|Sets the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0. Enables generation 0 and segment sizes larger than `DWORD`.|  
  
## Remarks  

 This interface inherits from the [ICLRGCManager Interface](iclrgcmanager-interface.md).  
  
 The common language runtime (CLR) implements its garbage collection mechanism with the managed <xref:System.GC> type. For more information about the garbage collection system, see [Garbage Collection](../../../standard/garbage-collection/index.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../../framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Automatic Memory Management](../../../standard/automatic-memory-management.md)
- [COR_GC_STATS Structure](cor-gc-stats-structure.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5](clr-hosting-interfaces-added-in-the-net-framework-4-and-4-5.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
