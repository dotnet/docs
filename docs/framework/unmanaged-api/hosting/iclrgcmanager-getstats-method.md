---
description: "Learn more about: ICLRGCManager::GetStats Method"
title: "ICLRGCManager::GetStats Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRGCManager.GetStats"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRGCManager::GetStats"
helpviewer_keywords: 
  - "GetStats method, ICLRGCManager interface [.NET Framework hosting]"
  - "ICLRGCManager::GetStats method [.NET Framework hosting]"
ms.assetid: ce259d1d-cd81-4490-a7a1-0d0ea0804872
topic_type: 
  - "apiref"
---
# ICLRGCManager::GetStats Method

Gets a set of current statistics about the common language runtime's garbage collection system.  
  
## Syntax  
  
```cpp  
HRESULT GetStats (  
    [in, out] COR_GC_STATS *pStats  
);  
```  
  
## Parameters  

 `pStats`  
 [in, out] A [COR_GC_STATS](cor-gc-stats-structure.md) instance that contains the requested statistics.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetStats` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR calculates and returns only those statistics that are specified by the `Flags` field of `pStats`.  
  
 Set the `Flags` field to one or more values of the [COR_GC_STAT_TYPES](cor-gc-stat-types-enumeration.md) enumeration to specify which statistics in the [COR_GC_STATS](cor-gc-stats-structure.md) structure are to be set.  
  
 An example of the usage is as follows:  
  
```cpp  
COR_GC_STATS GCStats;  
GCStats.Flags = COR_GC_COUNTS | COR_GC_MEMORYUSAGE;  
pCLRGCManager->GetStats(&GCStats);  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Automatic Memory Management](../../../standard/automatic-memory-management.md)
- [COR_GC_STATS Structure](cor-gc-stats-structure.md)
- [COR_GC_STAT_TYPES Enumeration](cor-gc-stat-types-enumeration.md)
- [Garbage Collection](../../../standard/garbage-collection/index.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRGCManager Interface](iclrgcmanager-interface.md)
- [CLR Hosting Interfaces](clr-hosting-interfaces.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
