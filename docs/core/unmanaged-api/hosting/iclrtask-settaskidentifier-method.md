---
description: "Learn more about: ICLRTask::SetTaskIdentifier Method"
title: "ICLRTask::SetTaskIdentifier Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask.SetTaskIdentifier"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask::SetTaskIdentifier"
helpviewer_keywords: 
  - "SetTaskIdentifier method [.NET Framework hosting]"
  - "ICLRTask::SetTaskIdentifier method [.NET Framework hosting]"
ms.assetid: bdb7f047-1e90-40fc-9e3b-d44a16509073
topic_type: 
  - "apiref"
---
# ICLRTask::SetTaskIdentifier Method

Instructs the common language runtime (CLR) to associate the specified identifier value with the task represented by the current [ICLRTask](iclrtask-interface.md) instance.  
  
## Syntax  
  
```cpp  
HRESULT SetTaskIdentifier (  
    [in] DWORD Asked  
);  
```  
  
## Parameters  

 `Asked`  
 [in] The unique identifier for the common language runtime to associate with the task represented by the current `ICLRTask` instance.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetTaskIdentifier` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The host can associate an identifier with a task to help integrate the CLR and the host in a debugging environment. The identifier has no meaning for the CLR. The CLR passes it along to a debugger application. The debugger can use this identifier to associate a CLR call stack with a host call stack, and enable their respective trace information to be unified when viewed in the debugger's user interface.  
  
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
