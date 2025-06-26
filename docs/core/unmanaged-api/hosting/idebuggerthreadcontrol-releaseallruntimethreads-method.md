---
description: "Learn more about: IDebuggerThreadControl::ReleaseAllRuntimeThreads Method"
title: "IDebuggerThreadControl::ReleaseAllRuntimeThreads Method"
ms.date: "03/30/2017"
api_name: 
  - "IDebuggerThreadControl.ReleaseAllRuntimeThreads"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ReleaseAllRuntimeThreads"
helpviewer_keywords: 
  - "ReleaseAllRuntimeThreads method [.NET Framework hosting]"
  - "IDebuggerThreadControl::ReleaseAllRuntimeThreads method [.NET Framework hosting]"
ms.assetid: 1a2995ff-5f02-4b49-84dc-3a5f9cfd7d55
topic_type: 
  - "apiref"
---
# IDebuggerThreadControl::ReleaseAllRuntimeThreads Method

Notifies the host that the debugging services are about to release all threads that are blocked.  
  
## Syntax  
  
```cpp  
HRESULT ReleaseAllRuntimeThreads ( );  
```  
  
## Remarks  

 The `ReleaseAllRuntimeThreads` method will never be called on a runtime thread. If the host has a runtime thread blocked, it should release it now.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IDebuggerThreadControl Interface](idebuggerthreadcontrol-interface.md)
