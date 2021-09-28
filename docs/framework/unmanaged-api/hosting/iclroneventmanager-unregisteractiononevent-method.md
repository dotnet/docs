---
description: "Learn more about: ICLROnEventManager::UnregisterActionOnEvent Method"
title: "ICLROnEventManager::UnregisterActionOnEvent Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLROnEventManager.UnregisterActionOnEvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLROnEventManager::UnregisterActionOnEvent"
helpviewer_keywords: 
  - "UnRegisterActionOnEvent method [.NET Framework hosting]"
  - "ICLROnEventManager::UnRegisterActionOnEvent method [.NET Framework hosting]"
ms.assetid: 4c02ec37-cdf0-46b2-890e-235092741236
topic_type: 
  - "apiref"
---
# ICLROnEventManager::UnregisterActionOnEvent Method

Unregisters a previously registered callback pointer for the specified event.  
  
## Syntax  
  
```cpp  
HRESULT UnregisterActionOnEvent (  
    [in] EClrEvent event,  
    [in] IActionOnCLREvent *pAction  
);  
```  
  
## Parameters  

 `event`  
 [in] One of the [EClrEvent](eclrevent-enumeration.md) values, indicating the event for which to unregister the callback pointer described by `pAction`.  
  
 `pAction`  
 [in] A pointer to an [IActionOnCLREvent](iactiononclrevent-interface.md) object that was passed as a parameter to the [RegisterActionOnEvent](iclroneventmanager-registeractiononevent-method.md) method.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`UnregisterActionOnEvent` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrEvent Enumeration](eclrevent-enumeration.md)
- [IActionOnCLREvent Interface](iactiononclrevent-interface.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLROnEventManager Interface](iclroneventmanager-interface.md)
