---
description: "Learn more about: IHostGCManager::ThreadIsBlockingForSuspension Method"
title: "IHostGCManager::ThreadIsBlockingForSuspension Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostGCManager.ThreadIsBlockingForSuspension"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostGCManager::ThreadIsBlockingForSuspension"
helpviewer_keywords: 
  - "IHostGCManager::ThreadIsBlockingForSuspension method [.NET Framework hosting]"
  - "ThreadIsBlockingForSuspension method [.NET Framework hosting]"
ms.assetid: 2657d45d-26d2-4d0a-8473-32b652e3321d
topic_type: 
  - "apiref"
---
# IHostGCManager::ThreadIsBlockingForSuspension Method

Notifies the host that the thread from which the method call was made is about to block for a garbage collection.  
  
## Syntax  
  
```cpp  
HRESULT ThreadIsBlockingForSuspension ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`ThreadIsBlockingForSuspension` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR typically calls the `ThreadIsBlockForSuspension` method in preparation for a garbage collection, to give the host an opportunity to reschedule the thread for unmanaged tasks.  
  
> [!IMPORTANT]
> The host can reschedule tasks only after a call to `ThreadIsBlockingForSuspension`. After the runtime calls [SuspensionStarting](ihostgcmanager-suspensionstarting-method.md), the host must not reschedule a task.  
  
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
- [IHostGCManager Interface](ihostgcmanager-interface.md)
