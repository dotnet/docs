---
description: "Learn more about: IHostGCManager::SuspensionEnding Method"
title: "IHostGCManager::SuspensionEnding Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostGCManager.SuspensionEnding"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostGCManager::SuspensionEnding"
helpviewer_keywords: 
  - "SuspensionEnding method, IHostGCManager interface [.NET Framework hosting]"
  - "IHostGCManager::SuspensionEnding method [.NET Framework hosting]"
ms.assetid: 8849a1db-17f0-44b7-880a-bd36d431eb91
topic_type: 
  - "apiref"
---
# IHostGCManager::SuspensionEnding Method

Notifies the host that the common language runtime (CLR) is resuming execution of tasks on threads that had been suspended for a garbage collection.  
  
## Syntax  
  
```cpp  
HRESULT SuspensionEnding (  
    [in] DWORD generation  
);  
```  
  
## Parameters  

 `generation`  
 [in] The garbage collection generation that is just finishing, from which the thread is resuming.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SuspensionEnding` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The CLR calls `SuspensionEnding` after it performs a garbage collection, to inform the host that the thread is resuming execution.  
  
> [!IMPORTANT]
> Do not reschedule the thread the method call was made from.  
  
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
