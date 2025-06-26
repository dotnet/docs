---
description: "Learn more about: IHostManualEvent::Set Method"
title: "IHostManualEvent::Set Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostManualEvent.Set"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostManualEvent::Set"
helpviewer_keywords: 
  - "Set method, IHostManualEvent interface [.NET Framework hosting]"
  - "IHostManualEvent::Set method [.NET Framework hosting]"
ms.assetid: e930c174-f71d-4faa-bb59-f0fb3df4d77b
topic_type: 
  - "apiref"
---
# IHostManualEvent::Set Method

Sets the current [IHostManualEvent](ihostmanualevent-interface.md) instance to a signaled state.  
  
## Syntax  
  
```cpp  
HRESULT Set ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Set` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
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
