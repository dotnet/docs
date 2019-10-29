---
title: "ICorThreadpool::CorDeleteTimer Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorThreadpool.CorDeleteTimer"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDeleteTimer"
helpviewer_keywords: 
  - "ICorThreadpool::CorDeleteTimer method [.NET Framework hosting]"
  - "CorDeleteTimer method [.NET Framework hosting]"
ms.assetid: 74847c35-7ca1-466a-b750-b25e7b03d100
topic_type: 
  - "apiref"
---
# ICorThreadpool::CorDeleteTimer Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT CorDeleteTimer (  
    [in]  HANDLE Timer,  
    [in]  HANDLE CompletionEvent,  
    [out] BOOL*  result  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)
