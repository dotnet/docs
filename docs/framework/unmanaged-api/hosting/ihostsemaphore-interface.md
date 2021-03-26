---
description: "Learn more about: IHostSemaphore Interface"
title: "IHostSemaphore Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostSemaphore"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSemaphore"
helpviewer_keywords: 
  - "IHostSemaphore interface [.NET Framework hosting]"
ms.assetid: c0765321-656c-441e-bab5-58176292be1e
topic_type: 
  - "apiref"
---
# IHostSemaphore Interface

Represents the host's implementation of a semaphore for threading.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ReleaseSemaphore Method](ihostsemaphore-releasesemaphore-method.md)|Increases the count of the current `IHostSemaphore` instance by the specified amount.|  
|[Wait Method](ihostsemaphore-wait-method.md)|Causes the current `IHostSemaphore` instance to wait until it is owned or the specified amount of time elapses.|  
  
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
- [Hosting Interfaces](hosting-interfaces.md)
