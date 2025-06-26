---
description: "Learn more about: ICLRTaskManager::SetLocale Method"
title: "ICLRTaskManager::SetLocale Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTaskManager.SetLocale"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTaskManager::SetLocale"
helpviewer_keywords: 
  - "SetLocale method, ICLRTaskManager interface [.NET Framework hosting]"
  - "ICLRTaskManager::SetLocale method [.NET Framework hosting]"
ms.assetid: ed16bb7f-4206-43a8-b9e9-c5737b69e3af
topic_type: 
  - "apiref"
---
# ICLRTaskManager::SetLocale Method

Notifies the common language runtime (CLR) that the host has modified the value of the locale identifier (which maps to the geographical culture and language) on the currently executing task.  
  
## Syntax  
  
```cpp  
HRESULT SetLocale (  
    [in] LCID lcid  
);  
```  
  
## Parameters  

 `lcid`  
 [in] The locale identifier value that maps to the newly assigned geographical culture and language.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 `SetLocale` gives the host an opportunity to execute any mechanisms it might have for the synchronization of locales.  
  
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
