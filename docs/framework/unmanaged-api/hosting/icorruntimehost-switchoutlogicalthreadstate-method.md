---
title: "ICorRuntimeHost::SwitchOutLogicalThreadState Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.SwitchOutLogicalThreadState"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::SwitchOutLogicalThreadState"
helpviewer_keywords: 
  - "ICorRuntimeHost::SwitchOutLogicalThreadState method [.NET Framework hosting]"
  - "SwitchOutLogicalThreadState method [.NET Framework hosting]"
ms.assetid: e1968f0b-2675-4dc2-8507-46164e1df154
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorRuntimeHost::SwitchOutLogicalThreadState Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT SwitchOutLogicalThreadState(  
    [out] DWORD **pFiberCookie  
);  
```  
  
## Parameters  
 `pFiberCookie`  
 [out] Cookie that indicates the fiber being switched out.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Version:** 1.0, 1.1  
  
## See also

- [ICorRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md)
