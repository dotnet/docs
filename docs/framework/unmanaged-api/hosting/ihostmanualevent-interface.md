---
title: "IHostManualEvent Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostManualEvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostManualEvent"
helpviewer_keywords: 
  - "IHostManualEvent interface [.NET Framework hosting]"
ms.assetid: 300c2661-b7d1-4c39-b080-9ebdef0fd523
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IHostManualEvent Interface
Provides the host's implementation of a representation of a manual reset event.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Reset Method](../../../../docs/framework/unmanaged-api/hosting/ihostmanualevent-reset-method.md)|Resets the current `IHostManualEvent` instance to a non-signaled state.|  
|[Set Method](../../../../docs/framework/unmanaged-api/hosting/ihostmanualevent-set-method.md)|Sets the current `IHostManualEvent` instance to a signaled state.|  
|[Wait Method](../../../../docs/framework/unmanaged-api/hosting/ihostmanualevent-wait-method.md)|Causes the current `IHostManualEvent` instance to wait until it is owned, or a specified amount of time elapses.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](../../../../docs/framework/unmanaged-api/hosting/ihostautoevent-interface.md)
- [IHostSemaphore Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsemaphore-interface.md)
- [IHostSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-interface.md)
- [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
