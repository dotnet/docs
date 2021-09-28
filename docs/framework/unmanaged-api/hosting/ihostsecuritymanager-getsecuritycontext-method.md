---
description: "Learn more about: IHostSecurityManager::GetSecurityContext Method"
title: "IHostSecurityManager::GetSecurityContext Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostSecurityManager.GetSecurityContext"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityManager::GetSecurityContext"
helpviewer_keywords: 
  - "GetSecurityContext method [.NET Framework hosting]"
  - "IHostSecurityManager::GetSecurityContext method [.NET Framework hosting]"
ms.assetid: 958970d6-f6a2-4b84-b32a-f555cbaf8f61
topic_type: 
  - "apiref"
---
# IHostSecurityManager::GetSecurityContext Method

Gets the requested [IHostSecurityContext](ihostsecuritycontext-interface.md) from the host.  
  
## Syntax  
  
```cpp
HRESULT GetSecurityContext (  
    [in]  EContextType eContextType,
    [out] IHostSecurityContext** ppSecurityContext  
);  
```  
  
## Parameters  

 `eContextType`  
 [in] One of the [EContextType](econtexttype-enumeration.md) values, indicating what type of security context to return.  
  
 `ppSecurityContext`  
 [out] The address of an interface pointer to the `IHostSecurityContext` of `eContextType`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetSecurityContext` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 A host can control all code access to thread tokens by both the CLR and user code. It can also ensure that complete security context information is passed across asynchronous operations or code points with restricted code access. `IHostSecurityContext` encapsulates this security context information, which is opaque to the CLR. The CLR captures this information and moves it across thread pool worker item dispatch, finalizer execution, and module and class construction.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EContextType Enumeration](econtexttype-enumeration.md)
- [IHostSecurityContext Interface](ihostsecuritycontext-interface.md)
- [IHostSecurityManager Interface](ihostsecuritymanager-interface.md)
