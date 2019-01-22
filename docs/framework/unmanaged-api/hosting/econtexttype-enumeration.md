---
title: "EContextType Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "EContextType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EContextType"
helpviewer_keywords: 
  - "EContextType enumeration [.NET Framework hosting]"
ms.assetid: 92b926a9-b87e-408a-9036-df7b752c9492
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# EContextType Enumeration
Describes the security context of the currently executing thread.  
  
## Syntax  
  
```  
typedef enum {  
    eCurrentContext    = 0x00,  
    eRestrictedContext = 0x01  
} EContextType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eCurrentContext`|Indicates the context on the current thread at the time the common language runtime (CLR) calls the [IHostSecurityManager::GetSecurityContext](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-getsecuritycontext-method.md) method, or the context requested by the CLR in a call to the [IHostSecurityManager::SetSecurityContext](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-setsecuritycontext-method.md) method.|  
|`eRestrictedContext`|Indicates a context over which the host has lower privileges, such as the garbage collector, or class or module constructors.|  
  
## Remarks  
 The CLR supplies one of the `EContextType` values as a parameter value in calls to the `IHostSecurityManager::GetSecurityContext` and `IHostSecurityManager::SetSecurityContext` methods.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [IHostSecurityContext Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritycontext-interface.md)  
 [IHostSecurityManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-interface.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
