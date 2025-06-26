---
description: "Learn more about: ICorConfiguration::SetDebuggerThreadControl Method"
title: "ICorConfiguration::SetDebuggerThreadControl Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorConfiguration.SetDebuggerThreadControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetDebuggerThreadControl"
helpviewer_keywords: 
  - "SetDebuggerThreadControl method [.NET Framework hosting]"
  - "ICorConfiguration::SetDebuggerThreadControl method [.NET Framework hosting]"
ms.assetid: 1ded7639-dacb-4db1-961c-d1ceaec01959
topic_type: 
  - "apiref"
---
# ICorConfiguration::SetDebuggerThreadControl Method

Sets the callback interface that the debugging services will call as common language runtime (CLR) threads are blocked and unblocked for debugging.  
  
## Syntax  
  
```cpp  
HRESULT SetDebuggerThreadControl (  
    [in] IDebuggerThreadControl* pDebuggerThreadControl  
);  
```  
  
## Parameters  

 `pDebuggerThreadControl`  
 [in] A pointer to an [IDebuggerThreadControl](idebuggerthreadcontrol-interface.md) object that notifies the host about the blocking and unblocking of threads by the debugging services.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorConfiguration Interface](icorconfiguration-interface.md)
