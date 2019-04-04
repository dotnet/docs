---
title: "ComCallUnmarshal Coclass"
ms.date: "03/30/2017"
api_name: 
  - "ComCallUnmarshal Coclass"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ComCallUnmarshal"
helpviewer_keywords: 
  - "ComCallUnmarshal coclass [.NET Framework hosting]"
ms.assetid: 2adb5827-2268-4914-a1c6-f62b61880a45
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ComCallUnmarshal Coclass
Provides interfaces for managing the marshaling of interface pointers.  
  
## Syntax  
  
```  
coclass ComCallUnmarshal {  
    [default] interface IMarshal;  
};  
```  
  
## Interfaces  
  
|Interface|Description|  
|---------------|-----------------|  
|`IMarshal`|Provides methods for creating, initializing, and managing a proxy in a client process.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [Hosting Coclasses](../../../../docs/framework/unmanaged-api/hosting/hosting-coclasses.md)
