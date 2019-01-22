---
title: "ICorThreadpool::CorQueueUserWorkItem Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorThreadpool.CorQueueUserWorkItem"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorQueueUserWorkItem"
helpviewer_keywords: 
  - "ICorThreadpool::CorQueueUserWorkItem method [.NET Framework hosting]"
  - "CorQueueUserWorkItem method [.NET Framework hosting]"
ms.assetid: 29ac7898-a7c7-433e-8f79-cd5237e0bab8
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorThreadpool::CorQueueUserWorkItem Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorQueueUserWorkItem (  
    [in] LPTHREAD_START_ROUTINE Function,  
    [in] PVOID                  Context,  
    [in] BOOL                   executeOnlyOnce,  
    [out] BOOL*                 result  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)
