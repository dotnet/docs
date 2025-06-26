---
description: "Learn more about: ICLRTask::SwitchIn Method"
title: "ICLRTask::SwitchIn Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask.SwitchIn"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask::SwitchIn"
helpviewer_keywords: 
  - "ICLRTask::SwitchIn method [.NET Framework hosting]"
  - "SwitchIn method [.NET Framework hosting]"
ms.assetid: 3d37ce20-aa65-4043-8f13-7c728b5d8a52
topic_type: 
  - "apiref"
---
# ICLRTask::SwitchIn Method

Notifies the common language runtime (CLR) that the task that the current [ICLRTask](iclrtask-interface.md) instance represents is now in an operable state.  
  
## Syntax  
  
```cpp  
HRESULT SwitchIn (  
    [in] HANDLE threadHandle  
);  
```  
  
## Parameters  

 `threadHandle`  
 [in] A handle to the physical thread on which the task represented by the current `ICLRTask` instance is executing.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SwitchIn` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_INVALIDOPERATION|`SwitchIn` was called without an earlier call to [SwitchOut Method](iclrtask-switchout-method.md).|  
  
## Remarks  

 The `threadHandle` parameter represents a handle to the operating system thread on which the task represented by the current `ICLRTask` instance has been scheduled. If impersonation has occurred on this thread, you must call [IHostSecurityManager::RevertToSelf](ihostsecuritymanager-reverttoself-method.md) before switching in the task.  
  
> [!NOTE]
> A call to `SwitchIn` without an earlier call to `SwitchOut` fails with an HRESULT value of HOST_E_INVALIDOPERATION.  
  
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
