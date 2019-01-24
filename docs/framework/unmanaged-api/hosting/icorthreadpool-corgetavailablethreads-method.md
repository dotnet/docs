---
title: "ICorThreadpool::CorGetAvailableThreads Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorThreadpool.CorGetAvailableThreads"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorGetAvailableThreads"
helpviewer_keywords: 
  - "CorGetAvailableThreads method [.NET Framework hosting]"
  - "ICorThreadpool::CorGetAvailableThreads method [.NET Framework hosting]"
ms.assetid: 0b09b750-0b86-4ba4-9621-041857cfe8ba
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorThreadpool::CorGetAvailableThreads Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorGetAvailableThreads (  
    [out] DWORD *AvailableWorkerThreads,  
    [out] DWORD *AvailableIOCompletionThreads  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)
