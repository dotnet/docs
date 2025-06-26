---
description: "Learn more about: IHostSecurityManager::RevertToSelf Method"
title: "IHostSecurityManager::RevertToSelf Method"
ms.date: "03/30/2017"
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
---
# IHostSecurityManager::RevertToSelf Method

Terminates impersonation of the current user identity and returns the original thread token.  
  
## Syntax  
  
```cpp  
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

 `RevertToSelf` is called to return to the original thread token, after an earlier call to the [ImpersonateLoggedOnUser](ihostsecuritymanager-impersonateloggedonuser-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostSecurityContext Interface](ihostsecuritycontext-interface.md)
- [IHostSecurityManager Interface](ihostsecuritymanager-interface.md)
- [ImpersonateLoggedOnUser Method](ihostsecuritymanager-impersonateloggedonuser-method.md)
