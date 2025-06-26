---
description: "Learn more about: ICorThreadpool::CorBindIoCompletionCallback Method"
title: "ICorThreadpool::CorBindIoCompletionCallback Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorThreadpool.CorBindIoCompletionCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorBindIoCompletionCallback"
helpviewer_keywords: 
  - "CorBindIoCompletionCallback method [.NET Framework hosting]"
  - "ICorThreadpool::CorBindIoCompletionCallback method [.NET Framework hosting]"
ms.assetid: 2b159225-f09c-42f1-aa7c-44087e121249
topic_type: 
  - "apiref"
---
# ICorThreadpool::CorBindIoCompletionCallback Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT CorBindIoCompletionCallback (  
    [in] HANDLE                          fileHandle,  
    [in] LPOVERLAPPED_COMPLETION_ROUTINE callback  
);  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorThreadpool Interface](icorthreadpool-interface.md)
