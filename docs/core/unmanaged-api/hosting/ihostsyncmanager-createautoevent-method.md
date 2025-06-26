---
description: "Learn more about: IHostSyncManager::CreateAutoEvent Method"
title: "IHostSyncManager::CreateAutoEvent Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSyncManager.CreateAutoEvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSyncManager::CreateAutoEvent"
helpviewer_keywords: 
  - "IHostSyncManager::CreateAutoEvent method [.NET Framework hosting]"
  - "CreateAutoEvent method [.NET Framework hosting]"
ms.assetid: 3153643e-cf5c-4b44-8e0e-c2b22cb08208
topic_type: 
  - "apiref"
---
# IHostSyncManager::CreateAutoEvent Method

Creates an auto-reset event object.  
  
## Syntax  
  
```cpp  
HRESULT CreateAutoEvent (  
    [out] IHostAutoEvent **ppEvent  
);  
```  
  
## Parameters  

 `ppEvent`  
 [out] A pointer to the address of an [IHostAutoEvent](ihostautoevent-interface.md) instance implemented by the host, or null if the event object could not be created.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`CreateAutoEvent` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to create the requested event object.|  
  
## Remarks  

 `CreateAutoEvent` creates an auto-event object whose state is automatically changed to non-signaled after the waiting thread has been released. This method mirrors the Win32 `CreateEvent` function with a value of `false` specified for the `bManualReset` parameter  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](ihostautoevent-interface.md)
- [IHostControl Interface](ihostcontrol-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
