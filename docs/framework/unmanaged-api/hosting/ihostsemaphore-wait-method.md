---
description: "Learn more about: IHostSemaphore::Wait Method"
title: "IHostSemaphore::Wait Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSemaphore.Wait"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSemaphore::Wait"
helpviewer_keywords: 
  - "IHostSemaphore::Wait method [.NET Framework hosting]"
  - "Wait method, IHostSemaphore interface [.NET Framework hosting]"
ms.assetid: 0da962a3-ce55-44dd-ab7a-14ad7105af4a
topic_type: 
  - "apiref"
---
# IHostSemaphore::Wait Method

Causes the current [IHostSemaphore](ihostsemaphore-interface.md) instance to wait until it is owned or the specified amount of time elapses.  
  
## Syntax  
  
```cpp  
HRESULT Wait (  
    [in] DWORD dwMilliseconds,  
    [in] DWORD option  
);  
```  
  
## Parameters  

 `dwMilliseconds`  
 [in] The number of milliseconds to wait before returning, if the current `IHostSemaphore` instance is not owned.  
  
 `option`  
 [in] One of the [WAIT_OPTION](wait-option-enumeration.md) values, specifying what action the host should take if this operation blocks.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Wait` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_DEADLOCK|The host detected a deadlock during the wait interval, and chose the current `IHostSemaphore` instance as a deadlock victim.|  
  
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
