---
description: "Learn more about: IHostAutoEvent Interface"
title: "IHostAutoEvent Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostAutoEvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostAutoEvent"
helpviewer_keywords: 
  - "IHostAutoEvent interface [.NET Framework hosting]"
ms.assetid: 6c1d15c1-a80a-4ee9-b1e4-6e859db6575a
topic_type: 
  - "apiref"
---
# IHostAutoEvent Interface

Provides a representation of the host's implementation of an auto-reset event.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Set Method](ihostautoevent-set-method.md)|Sets the current `IHostAutoEvent` instance to a signaled state.|  
|[Wait Method](ihostautoevent-wait-method.md)|Causes the current `IHostAutoEvent` instance to wait until the event is owned or a specified amount of time elapses.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostManualEvent Interface](ihostmanualevent-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
