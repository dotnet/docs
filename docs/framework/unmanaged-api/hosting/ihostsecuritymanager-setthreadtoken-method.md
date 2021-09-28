---
description: "Learn more about: IHostSecurityManager::SetThreadToken Method"
title: "IHostSecurityManager::SetThreadToken Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSecurityManager.SetThreadToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityManager::SetThreadToken"
helpviewer_keywords: 
  - "SetThreadToken method [.NET Framework hosting]"
  - "IHostSecurityManager::SetThreadToken method [.NET Framework hosting]"
ms.assetid: e951c345-8a86-4587-911b-a1a57bc6428a
topic_type: 
  - "apiref"
---
# IHostSecurityManager::SetThreadToken Method

Sets a handle for the currently executing thread.  
  
## Syntax  
  
```cpp  
HRESULT SetThreadToken (  
    [in] HANDLE hToken  
);  
```  
  
## Parameters  

 `hToken`  
 [in] A handle to the token to set for the currently executing thread.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetThreadToken` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 `IHostSecurityManager::SetThreadToken` behaves similarly to the corresponding Win32 function of the same name, except that the Win32 function allows the caller to pass in a handle to an arbitrary thread, while `IHostSecurityManager::SetThreadToken` can associate a token only with the currently executing thread.  
  
 The `HANDLE` type is not COM-compliant; that is, its size is specific to an operating system and it requires custom marshaling. Thus, this token is for use only within the process, between the CLR and the host.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostSecurityManager Interface](ihostsecuritymanager-interface.md)
- [IHostThreadPoolManager Interface](ihostthreadpoolmanager-interface.md)
