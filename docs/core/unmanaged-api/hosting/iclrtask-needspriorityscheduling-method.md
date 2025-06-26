---
description: "Learn more about: ICLRTask::NeedsPriorityScheduling Method"
title: "ICLRTask::NeedsPriorityScheduling Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask.NeedsPriorityScheduling"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask::NeedsPriorityScheduling"
helpviewer_keywords: 
  - "ICLRTask::NeedsPriorityScheduling method [.NET Framework hosting]"
  - "NeedsPriorityScheduling method [.NET Framework hosting]"
ms.assetid: 9c9db3f3-26bf-4317-88de-5eb926a22a1d
topic_type: 
  - "apiref"
---
# ICLRTask::NeedsPriorityScheduling Method

Gets a value that indicates whether the current task, which is being switched out, needs to be marked as a high priority for rescheduling.  
  
## Syntax  
  
```cpp  
HRESULT NeedsPriorityScheduling (  
    [out] BOOL *pbNeedsPriorityScheduling  
);  
```  
  
## Parameters  

 `pbNeedsPriorityRescheduling`  
 [out] `true`, if the host should attempt to reschedule the current task instance as soon as possible; otherwise, `false`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`NeedsPriorityRescheduling` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 In situations where the task is close to being collected by the garbage collector, the CLR sets the value of `pbNeedsPriorityScheduling` to `true`, indicating high-priority rescheduling. This allows the host to reschedule the task quickly, thereby minimizing the potential for delays in garbage collection, and enabling the host and the runtime to cooperate in conserving memory resources.  
  
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
