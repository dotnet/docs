---
description: "Learn more about: IHostSecurityContext::Capture Method"
title: "IHostSecurityContext::Capture Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSecurityContext.Capture"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityContext::Capture"
helpviewer_keywords: 
  - "Capture method [.NET Framework hosting]"
  - "IHostSecurityContext::Capture method [.NET Framework hosting]"
ms.assetid: ae0836d0-1170-4494-bac5-d0e809df51a2
topic_type: 
  - "apiref"
---
# IHostSecurityContext::Capture Method

Gets a clone of the [IHostSecurityContext](ihostsecuritycontext-interface.md) instance returned from a call to [IHostSecurityManager::GetSecurityContext](ihostsecuritymanager-getsecuritycontext-method.md).  
  
## Syntax  
  
```cpp
HRESULT Capture (  
    [out] IHostSecurityContext** ppClonedContext  
);  
```  
  
## Parameters  

 `ppClonedContext`  
 [out] A pointer to the address of a clone of the `IHostSecurityContext` object to be captured.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Capture` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The interface pointer returned from `Capture` is a clone of the captured context. When this information is moved across an asynchronous code point, its lifetime is separated from that of the pointer against which the call was made. The original pointer can therefore be released.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostSecurityContext Interface](ihostsecuritycontext-interface.md)
- [IHostSecurityManager Interface](ihostsecuritymanager-interface.md)
