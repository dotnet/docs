---
description: "Learn more about: IHostSemaphore::ReleaseSemaphore Method"
title: "IHostSemaphore::ReleaseSemaphore Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSemaphore.ReleaseSemaphore"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSemaphore::ReleaseSemaphore"
helpviewer_keywords: 
  - "ReleaseSemaphore method [.NET Framework hosting]"
  - "IHostSemaphore::ReleaseSemaphore method [.NET Framework hosting]"
ms.assetid: a343d197-979a-4ac6-ab8c-cb8a05f3120e
topic_type: 
  - "apiref"
---
# IHostSemaphore::ReleaseSemaphore Method

Increases the count of the current [IHostSemaphore](ihostsemaphore-interface.md) instance by the specified amount.  
  
## Syntax  
  
```cpp  
HRESULT ReleaseSemaphore (  
    [in]  LONG  lReleaseCount,  
    [out] LONG  *lpPreviousCount  
);  
```  
  
## Parameters  

 `lReleaseCount`  
 [in] The amount by which to increase the count of the current `IHostSemaphore` instance. This amount must be greater than zero.  
  
 `lpPreviousCount`  
 [out] A pointer to the previous count, or null if the caller does not require the previous count.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ReleaseSemaphore` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR typically calls `ReleaseSemaphore` to notify the host that it has finished using a resource, passing a value of 1 for the `lReleaseCount` parameter.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](ihostautoevent-interface.md)
- [IHostManualEvent Interface](ihostmanualevent-interface.md)
- [IHostSemaphore Interface](ihostsemaphore-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
