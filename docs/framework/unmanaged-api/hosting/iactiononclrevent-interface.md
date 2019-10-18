---
title: "IActionOnCLREvent Interface"
ms.date: "03/30/2017"
api_name: 
  - "IActionOnCLREvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IActionOnCLREvent"
helpviewer_keywords: 
  - "IActionOnCLREvent interface [.NET Framework hosting]"
ms.assetid: b5f9b41e-7301-429c-911f-21d5422292b3
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IActionOnCLREvent Interface
Provides the [IActionOnCLREvent::OnEvent](../../../../docs/framework/unmanaged-api/hosting/iactiononclrevent-onevent-method.md) method, which performs callbacks on events that have been registered by using a call to the [ICLROnEventManager::RegisterActionOnEvent](../../../../docs/framework/unmanaged-api/hosting/iclroneventmanager-registeractiononevent-method.md) method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[OnEvent Method](../../../../docs/framework/unmanaged-api/hosting/iactiononclrevent-onevent-method.md)|Performs a callback for a registered event.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrEvent Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrevent-enumeration.md)
- [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)
- [ICLROnEventManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclroneventmanager-interface.md)
- [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
