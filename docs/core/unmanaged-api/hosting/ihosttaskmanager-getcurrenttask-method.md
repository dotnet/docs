---
description: "Learn more about: IHostTaskManager::GetCurrentTask Method"
title: "IHostTaskManager::GetCurrentTask Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager.GetCurrentTask"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::GetCurrentTask"
helpviewer_keywords: 
  - "GetCurrentTask method, IHostTaskManager interface [.NET Framework hosting]"
  - "IHostTaskManager::GetCurrentTask method [.NET Framework hosting]"
ms.assetid: f17bca49-90bd-4dee-a5e1-b9a57ea46f85
topic_type: 
  - "apiref"
---
# IHostTaskManager::GetCurrentTask Method

Gets an interface pointer to the task that is currently executing on the operating system thread from which this call is made.  
  
## Syntax  
  
```cpp  
HRESULT GetCurrentTask (  
    [out] IHostTask **pTask  
);  
```  
  
## Parameters  

 `pTask`  
 [out] A pointer to the address of an [IHostTask](ihosttask-interface.md) instance that represents the currently executing task, or null, if no task is currently executing.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetCurrentTask` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_INVALIDOPERATION|`GetCurrentTask` was called on an operating system thread outside the control of the host.|  
  
## Remarks  

 The host can also set the `pTask` parameter to null to prevent a task that it did not initiate from entering the CLR.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
