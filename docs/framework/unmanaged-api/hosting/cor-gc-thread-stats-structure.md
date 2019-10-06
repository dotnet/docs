---
title: "COR_GC_THREAD_STATS Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_GC_THREAD_STATS"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_GC_THREAD_STATS"
helpviewer_keywords: 
  - "COR_GC_THREAD_STATS structure [.NET Framework hosting]"
ms.assetid: 01f9a59b-7679-4d42-9ced-4a8981625c3d
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# COR_GC_THREAD_STATS Structure
Contains per-thread statistics pertaining to garbage collection.  
  
## Syntax  
  
```cpp  
typedef struct _COR_GC_THREAD_STATS {  
    ULONGLONG  PerThreadAllocation;   
    ULONG      Flags;   
} COR_GC_THREAD_STATS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`PerThreadAllocation`|The number of bytes of memory allocated on the thread that is associated with the current `COR_GC_THREAD_STATS` instance. This number is cleared to zero each time a generation-zero garbage collection occurs.|  
|`Flags`|The number of bytes promoted to a higher generation at the most recent garbage collection.|  
  
## Remarks  
 [ICLRTask::GetMemStats](../../../../docs/framework/unmanaged-api/hosting/iclrtask-getmemstats-method.md) takes an output parameter of type `COR_GC_THREAD_STATS`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Hosting Structures](../../../../docs/framework/unmanaged-api/hosting/hosting-structures.md)
- [IHostTask Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md)
