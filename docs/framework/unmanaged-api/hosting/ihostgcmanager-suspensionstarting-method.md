---
description: "Learn more about: IHostGCManager::SuspensionStarting Method"
title: "IHostGCManager::SuspensionStarting Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostGCManager.SuspensionStarting"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostGCManager::SuspensionStarting"
helpviewer_keywords: 
  - "SuspensionStarting method, IHostGCManager interface [.NET Framework hosting]"
  - "IHostGCManager::SuspensionStarting method [.NET Framework hosting]"
ms.assetid: c381f524-94cf-4fa2-9298-50f847a03431
topic_type: 
  - "apiref"
---
# IHostGCManager::SuspensionStarting Method

Notifies the host that the common language runtime (CLR) is suspending execution of tasks, to perform a garbage collection.  
  
## Syntax  
  
```cpp  
HRESULT SuspensionStarting ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SuspensionStarting` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR calls `SuspensionStarting` to inform the host that garbage collection is occurring.  
  
> [!IMPORTANT]
> Do not reschedule this task. The host must reschedule a task when [ThreadIsBlockingForSuspension](ihostgcmanager-threadisblockingforsuspension-method.md) is called.  
  
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
