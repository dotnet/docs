---
description: "Learn more about: ICLRTask::Abort Method"
title: "ICLRTask::Abort Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask.Abort"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask::Abort"
helpviewer_keywords: 
  - "ICLRTask::Abort method [.NET Framework hosting]"
  - "Abort method, ICLRTask interface [.NET Framework hosting]"
ms.assetid: b3594b5f-2e41-4e36-9096-3586276a138c
topic_type: 
  - "apiref"
---
# ICLRTask::Abort Method

Requests that the common language runtime (CLR) abort the task that the current [ICLRTask](iclrtask-interface.md) instance represents.  
  
## Syntax  
  
```cpp  
HRESULT Abort ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Abort` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR raises a <xref:System.Threading.ThreadAbortException> when the host calls `Abort`. It returns immediately after the exception information is initialized, without waiting for user code, such as finalizers or exception handling mechanisms, to execute. Calls to `Abort` thus return quickly.  
  
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
