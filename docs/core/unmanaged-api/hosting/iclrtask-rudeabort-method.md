---
description: "Learn more about: ICLRTask::RudeAbort Method"
title: "ICLRTask::RudeAbort Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask.RudeAbort"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask::RudeAbort"
helpviewer_keywords: 
  - "RudeAbort method, ICLRTask interface [.NET Framework hosting]"
  - "ICLRTask::RudeAbort method [.NET Framework hosting]"
ms.assetid: b5785468-fcd7-4cc3-8a5d-8796337b53fc
topic_type: 
  - "apiref"
---
# ICLRTask::RudeAbort Method

Instructs the common language runtime (CLR) to abort the task represented by the current [ICLRTask Interface](iclrtask-interface.md) instance immediately and unconditionally.  
  
## Syntax  
  
```cpp  
HRESULT RudeAbort ();
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`RudeAbort` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 A host calls `RudeAbort` to abort a task immediately. Finalizers and exception handling routines are not guaranteed to be executed.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
