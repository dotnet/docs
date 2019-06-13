---
title: "ICorThreadpool::CorRegisterWaitForSingleObject Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorThreadpool.CorRegisterWaitForSingleObject"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorRegisterWaitForSingleObject"
helpviewer_keywords: 
  - "ICorThreadpool::CorRegisterWaitForSingleObject method [.NET Framework hosting]"
  - "CorRegisterWaitForSingleObject method [.NET Framework hosting]"
ms.assetid: cade1feb-71d2-43ed-85ca-7b2e9da12994
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorThreadpool::CorRegisterWaitForSingleObject Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorRegisterWaitForSingleObject (  
    [in]  HANDLE*             phNewWaitObject,  
    [in]  HANDLE              hWaitObject,  
    [in]  WAITORTIMERCALLBACK Callback,  
    [in]  PVOID               Context,  
    [in]  ULONG               timeout,  
    [in]  BOOL                executeOnlyOnce,  
    [out] BOOL*               result  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)
