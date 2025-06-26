---
description: "Learn more about: IHostTask::GetPriority Method"
title: "IHostTask::GetPriority Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTask.GetPriority"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTask::GetPriority"
helpviewer_keywords: 
  - "GetPriority method [.NET Framework hosting]"
  - "IHostTask::GetPriority method [.NET Framework hosting]"
ms.assetid: 4b463cd6-77c1-4f9a-8518-346ad8fc4b70
topic_type: 
  - "apiref"
---
# IHostTask::GetPriority Method

Gets the thread priority level of the task represented by the current [IHostTask](ihosttask-interface.md) instance.  
  
## Syntax  
  
```cpp  
HRESULT GetPriority (  
    [out] int *pPriority  
);  
```  
  
## Parameters  

 `pPriority`  
 [out] A pointer to an integer that indicates the thread priority level of the task represented by the current `IHostTask` instance.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetPriority` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 Thread priority level values are defined by the Win32 `SetThreadPriority` function.  
  
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
