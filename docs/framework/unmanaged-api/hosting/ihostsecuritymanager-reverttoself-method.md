---
title: "IHostSecurityManager::RevertToSelf Method"
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
  - "IHostSecurityManager.RevertToSelf"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityManager::RevertToSelf"
helpviewer_keywords: 
  - "RevertToSelf method [.NET Framework hosting]"
  - "IHostSecurityManager::RevertToSelf method [.NET Framework hosting]"
ms.assetid: 189f28f8-f9a1-4192-aedc-91084e4f8b99
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostSecurityManager::RevertToSelf Method
Terminates impersonation of the current user identity and returns the original thread token.  
  
## Syntax  
  
```  
HRESULT RevertToSelf ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`RevertToSelf` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 `RevertToSelf` is called to return to the original thread token, after an earlier call to the [ImpersonateLoggedOnUser](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-impersonateloggedonuser-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostSecurityContext Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritycontext-interface.md)  
 [IHostSecurityManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-interface.md)  
 [ImpersonateLoggedOnUser Method](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-impersonateloggedonuser-method.md)
