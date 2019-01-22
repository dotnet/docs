---
title: "ICorRuntimeHost::LocksHeldByLogicalThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.LocksHeldByLogicalThread"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::LocksHeldByLogicalThread"
helpviewer_keywords: 
  - "ICorRuntimeHost::LocksHeldByLogicalThread method [.NET Framework hosting]"
  - "LocksHeldByLogicalThread method [.NET Framework hosting]"
ms.assetid: c3601255-d894-4d7c-b1df-c31334551700
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorRuntimeHost::LocksHeldByLogicalThread Method
Retrieves the number of locks that current thread holds.  
  
 This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT LocksHeldByLogicalThread(  
    [out] DWORD *pCount  
);  
```  
  
#### Parameters  
 `pCount`  
 [out] A pointer to the number of locks that the current thread holds.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also
 [ICorRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md)
