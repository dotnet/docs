---
description: "Learn more about: IHostTaskManager::EndThreadAffinity Method"
title: "IHostTaskManager::EndThreadAffinity Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager.EndThreadAffinity"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::EndThreadAffinity"
helpviewer_keywords: 
  - "EndThreadAffinity method [.NET Framework hosting]"
  - "IHostTaskManager::EndThreadAffinity method [.NET Framework hosting]"
ms.assetid: 7738a904-0cd7-4fde-a3eb-2323a5533157
topic_type: 
  - "apiref"
---
# IHostTaskManager::EndThreadAffinity Method

Notifies the host that managed code is exiting the period in which the current task must not be moved to another operating system thread, following an earlier call to [IHostTaskManager::BeginThreadAffinity](ihosttaskmanager-beginthreadaffinity-method.md).  
  
## Syntax  
  
```cpp  
HRESULT EndThreadAffinity ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`EndThreadAffinity` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_UNEXPECTED|`EndThreadAffinity` was called without an earlier corresponding call to `BeginThreadAffinity`.|  
  
## Remarks  

 The CLR makes a corresponding call to `BeginThreadAffinity` on the current task before calling `EndThreadAffinity`. In the absence of such a corresponding call, the host's implementation of [IHostTaskManager](ihosttaskmanager-interface.md) should return E_UNEXPECTED, and take no action.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- <xref:System.Threading>
- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
