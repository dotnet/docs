---
title: "ICorThreadpool::CorUnregisterWait Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorThreadpool.CorUnregisterWait"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorUnregisterWait"
helpviewer_keywords: 
  - "CorUnregisterWait method [.NET Framework hosting]"
  - "ICorThreadpool::CorUnregisterWait method [.NET Framework hosting]"
ms.assetid: 42c933f1-30a8-4011-bdea-e117f3c3265e
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorThreadpool::CorUnregisterWait Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorUnregisterWait (  
    [in] HANDLE hWaitObject,  
    [in] HANDLE CompletionEvent,  
    [out] BOOL* result  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)
