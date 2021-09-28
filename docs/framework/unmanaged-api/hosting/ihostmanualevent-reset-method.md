---
description: "Learn more about: IHostManualEvent::Reset Method"
title: "IHostManualEvent::Reset Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostManualEvent.Reset"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostManualEvent::Reset"
helpviewer_keywords: 
  - "Reset method, IHostManualEvent interface [.NET Framework hosting]"
  - "IHostManualEvent::Reset method [.NET Framework hosting]"
ms.assetid: 0d101168-b5e3-49ce-90c7-85cf2db83c4c
topic_type: 
  - "apiref"
---
# IHostManualEvent::Reset Method

Resets the current [IHostManualEvent](ihostmanualevent-interface.md) instance to a non-signaled state.  
  
## Syntax  
  
```cpp  
HRESULT Reset ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Reset` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](ihostautoevent-interface.md)
- [IHostManualEvent Interface](ihostmanualevent-interface.md)
- [IHostSemaphore Interface](ihostsemaphore-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
