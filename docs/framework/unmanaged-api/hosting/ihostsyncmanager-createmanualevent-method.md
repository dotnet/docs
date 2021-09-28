---
description: "Learn more about: IHostSyncManager::CreateManualEvent Method"
title: "IHostSyncManager::CreateManualEvent Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSyncManager.CreateManualEvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSyncManager::CreateManualEvent"
helpviewer_keywords: 
  - "CreateManualEvent method [.NET Framework hosting]"
  - "IHostSyncManager::CreateManualEvent method [.NET Framework hosting]"
ms.assetid: 68661fbd-09cf-46dc-890b-e694f8a3880a
topic_type: 
  - "apiref"
---
# IHostSyncManager::CreateManualEvent Method

Creates a manual-reset event object.  
  
## Syntax  
  
```cpp  
HRESULT CreateManualEvent (  
    [in]  BOOL bInitialState,  
    [out] IHostManualEvent **ppEvent  
);  
```  
  
## Parameters  

 `bInitialState`  
 [in] `true`, if the object is signaled; otherwise, `false`.  
  
 `ppEvent`  
 [out] A pointer to the address of an [IHostManualEvent](ihostmanualevent-interface.md) instance, or null if the event could not be created.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`CreateManualEvent` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to create the requested event object.|  
  
## Remarks  

 `CreateManualEvent` creates an `IHostManualEvent`, a manual-reset event object that requires a call to the [IHostManualEvent::Reset](ihostmanualevent-reset-method.md) method to set it to a non-signaled state. `CreateManualEvent` mirrors the Win32 `CreateEvent` function with a value of `true` specified for the `bManualReset` parameter.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostManualEvent Interface](ihostmanualevent-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
