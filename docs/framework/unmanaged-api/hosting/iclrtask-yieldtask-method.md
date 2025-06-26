---
description: "Learn more about: ICLRTask::YieldTask Method"
title: "ICLRTask::YieldTask Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask.YieldTask"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask::YieldTask"
helpviewer_keywords: 
  - "ICLRTask::YieldTask method [.NET Framework hosting]"
  - "YieldTask method [.NET Framework hosting]"
ms.assetid: b8eb4095-3a8f-4be3-9446-63e9893dce7d
topic_type: 
  - "apiref"
---
# ICLRTask::YieldTask Method

Requests that the common language runtime (CLR) put aside the task that the current [ICLRTask](iclrtask-interface.md) instance represents, and make the processor time available to other tasks.  
  
## Syntax  
  
```cpp  
HRESULT YieldTask ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`YieldTask` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 A host calls `YieldTask` to request processor resources for other tasks or processes. This method is primarily intended to allow long-running code to give up CPU time. The runtime attempts to put the task that the current `ICLRTask` instance represents in a state where it can yield processing time, but makes no guarantee of success.  
  
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
