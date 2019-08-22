---
title: "ICLRGCManager::SetGCStartupLimits Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRGCManager.SetGCStartupLimits"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRGCManager::SetGCStartupLimits"
helpviewer_keywords: 
  - "SetGCStartupLimits method, ICLRGCManager interface [.NET Framework hosting]"
  - "ICLRGCManager::SetGCStartupLimits method [.NET Framework hosting]"
ms.assetid: 1c8d9959-95b5-4131-be4a-556d97774014
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICLRGCManager::SetGCStartupLimits Method
Sets the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0.  
  
> [!IMPORTANT]
>  Starting with the .NET Framework 4.5, you can set segment size and maximum generation 0 size to values greater than `DWORD` by using the [ICLRGCManager2::SetGCStartupLimitsEx](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager2-setgcstartuplimitsex-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT SetGCStartupLimits (  
    [in] DWORD SegmentSize,   
    [in] DWORD MaxGen0Size  
);  
```  
  
## Parameters  
 `SegmentSize`  
 [in] The specified size of a garbage collection segment.  
  
 The minimum segment size is 4 MB. Segments can be increased in increments of 1 MB or larger.  
  
 `MaxGen0Size`  
 [in] The specified maximum size for generation 0.  
  
 The minimum generation 0 size is 64 KB.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetGCStartupLimits` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The values that `SetGCStartupLimits` sets can be specified only once. Later calls to `SetGCStartupLimits` are ignored.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Automatic Memory Management](../../../../docs/standard/automatic-memory-management.md)
- [Garbage Collection](../../../../docs/standard/garbage-collection/index.md)
- [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)
- [ICLRGCManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-interface.md)
