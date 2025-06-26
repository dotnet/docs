---
description: "Learn more about: IHostTaskManager::BeginDelayAbort Method"
title: "IHostTaskManager::BeginDelayAbort Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager.BeginDelayAbort"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::BeginDelayAbort"
helpviewer_keywords: 
  - "BeginDelayAbort method [.NET Framework hosting]"
  - "IHostTaskManager::BeginDelayAbort method [.NET Framework hosting]"
ms.assetid: 75f42a8b-ed68-4718-a030-a179cfba7d72
topic_type: 
  - "apiref"
---
# IHostTaskManager::BeginDelayAbort Method

Notifies the host that managed code is entering a period in which the current task must not be aborted.  
  
## Syntax  
  
```cpp  
HRESULT BeginDelayAbort ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`BeginDelayAbort` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_UNEXPECTED|`BeginDelayAbort` has already been called, but the corresponding call to [EndDelayAbort](ihosttaskmanager-enddelayabort-method.md) has not yet been received.|  
  
## Remarks  

 The host must not abort the current task until `EndDelayAbort` is called. If another call to `BeginDelayAbort` is made without an intervening call to `EndDelayAbort`, the host should return E_UNEXPECTED from `BeginDelayAbort`, and should take no action.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
