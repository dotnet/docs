---
description: "Learn more about: IHostTaskManager::SetUILocale Method"
title: "IHostTaskManager::SetUILocale Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager.SetUILocale"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::SetUILocale"
helpviewer_keywords: 
  - "SetUILocale method, IHostTaskManager interface [.NET Framework hosting]"
  - "IHostTaskManager::SetUILocale method [.NET Framework hosting]"
ms.assetid: d0c87a9c-ea81-4237-a16b-c22b36ec9dc8
topic_type: 
  - "apiref"
---
# IHostTaskManager::SetUILocale Method

Notifies the host that the common language runtime (CLR) has changed the user interface (UI) locale, or culture, on the currently executing task.  
  
## Syntax  
  
```cpp  
HRESULT SetUILocale (  
    [in] LCID lcid  
);  
```  
  
## Parameters  

 `lcid`  
 [in] The locale identifier value that maps to the newly assigned geographical culture and language.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetUILocale` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_NOTIMPL|The host does not allow managed user code to change the UI culture.|  
  
## Remarks  

 The runtime calls `SetUILocale` when the value of the <xref:System.Threading.Thread.CurrentUICulture%2A?displayProperty=nameWithType> property is changed by managed code. This method provides an opportunity for the host to execute any mechanisms it might have for synchronization of locales. If a host does not allow the UI locale to be changed from managed code, or does not implement a mechanism to synchronize locales, it should return E_NOTIMPL from this method.  
  
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
- [SetLocale Method](ihosttaskmanager-setlocale-method.md)
