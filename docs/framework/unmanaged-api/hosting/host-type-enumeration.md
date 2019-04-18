---
title: "HOST_TYPE Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "HOST_TYPE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "HOST_TYPE"
helpviewer_keywords: 
  - "HOST_TYPE enumeration [.NET Framework hosting]"
ms.assetid: 51f848be-84c5-4036-9839-c762c576bbf5
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# HOST_TYPE Enumeration
Contains values that specify the type of host that is launching an application.  
  
## Syntax  
  
```  
typedef enum {  
    HOST_TYPE_DEFAULT     = 0x0,  
    HOST_TYPE_APPLAUNCH   = 0x1,  
    HOST_TYPE_CORFLAG     = 0x2  
} HOST_TYPE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`HOST_TYPE_APPLAUNCH`|Launch the application from AppLaunch.exe.<br /><br /> Use this value for partially-trusted applications.|  
|`HOST_TYPE_CORFLAG`|Launch the application directly. That is, launch the application from its own .exe file.<br /><br /> Use this value for fully-trusted applications.|  
|`HOST_TYPE_DEFAULT`|Same as HOST_TYPE_APPLAUNCH.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
