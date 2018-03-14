---
title: "IHostAutoEvent Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostAutoEvent Interface
Provides a representation of the host's implementation of an auto-reset event.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Set Method](../../../../docs/framework/unmanaged-api/hosting/ihostautoevent-set-method.md)|Sets the current `IHostAutoEvent` instance to a signaled state.|  
|[Wait Method](../../../../docs/framework/unmanaged-api/hosting/ihostautoevent-wait-method.md)|Causes the current `IHostAutoEvent` instance to wait until the event is owned or a specified amount of time elapses.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-interface.md)  
 [IHostManualEvent Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmanualevent-interface.md)  
 [IHostSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
