---
description: "Learn more about: IHostAutoEvent::Set Method"
title: "IHostAutoEvent::Set Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostAutoEvent.Set"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostAutoEvent::Set"
helpviewer_keywords: 
  - "Set method, IHostAutoEvent interface [.NET Framework hosting]"
  - "IHostAutoEvent::Set method [.NET Framework hosting]"
ms.assetid: 46becf3e-bc0e-4338-85c0-9ab0df76a1d0
topic_type: 
  - "apiref"
---
# IHostAutoEvent::Set Method

Sets the current [IHostAutoEvent](ihostautoevent-interface.md) instance to a signaled state.  
  
## Syntax  
  
```cpp  
HRESULT Set ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Set` returned successfully.|  
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
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
