---
title: "ICLRMemoryNotificationCallback Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMemoryNotificationCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMemoryNotificationCallback"
helpviewer_keywords: 
  - "ICLRMemoryNotificationCallback interface [.NET Framework hosting]"
ms.assetid: 873639e2-4837-4568-83b3-4493e67e4174
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICLRMemoryNotificationCallback Interface
Allows the host to report memory pressure conditions using an approach similar to that of the Win32 `CreateMemoryResourceNotification` function.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[OnMemoryNotification Method](../../../../docs/framework/unmanaged-api/hosting/iclrmemorynotificationcallback-onmemorynotification-method.md)|Notifies the common language runtime (CLR) of the memory load on the computer.|  
  
## Remarks  
 The host uses the `ICLRMemoryNotificationCallback` interface to request that the CLR free memory resources.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
- [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
