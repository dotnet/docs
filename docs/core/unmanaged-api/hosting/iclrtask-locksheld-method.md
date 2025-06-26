---
description: "Learn more about: ICLRTask::LocksHeld Method"
title: "ICLRTask::LocksHeld Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask.LocksHeld"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask::LocksHeld"
helpviewer_keywords: 
  - "LocksHeld method [.NET Framework hosting]"
  - "ICLRTask::LocksHeld method [.NET Framework hosting]"
ms.assetid: e88a4dc3-02cc-4703-a474-292b71c40657
topic_type: 
  - "apiref"
---
# ICLRTask::LocksHeld Method

Gets the number of locks currently held on the task.  
  
## Syntax  
  
```cpp  
HRESULT LocksHeld (  
    [out] SIZE_T *pLockCount  
);  
```  
  
## Parameters  

 `pLockCount`  
 [out] The number of locks held on the task at the time of the method call.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`LocksHeld` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../../framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
