---
description: "Learn more about: IHostTask::Join Method"
title: "IHostTask::Join Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTask.Join"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTask::Join"
helpviewer_keywords: 
  - "IHostTask::Join method [.NET Framework hosting]"
  - "Join method, IHostTask interface [.NET Framework hosting]"
ms.assetid: 2cffcc52-19e0-4ced-a440-fc7375078ac9
topic_type: 
  - "apiref"
---
# IHostTask::Join Method

Blocks the calling task until the task represented by the current [IHostTask](ihosttask-interface.md) instance completes, the specified time interval elapses, or [IHostTask::Alert](ihosttask-alert-method.md) is called.  
  
## Syntax  
  
```cpp  
HRESULT Join (  
    [in] DWORD milliseconds,  
    [in] DWORD option  
);  
```  
  
## Parameters  

 `milliseconds`  
 [in] The time interval, in milliseconds, to wait for the task to terminate. If this interval elapses before the task terminates, the calling task unblocks.  
  
 `option`  
 [in] One of the [WAIT_OPTION](wait-option-enumeration.md) values. A value of WAIT_ALERTABLE instructs the host to wake the task if `Alert` is called before `milliseconds` elapses.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Join` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it, or the current `IHostTask` instance is not associated with a task.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
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
- [WAIT_OPTION Enumeration](wait-option-enumeration.md)
