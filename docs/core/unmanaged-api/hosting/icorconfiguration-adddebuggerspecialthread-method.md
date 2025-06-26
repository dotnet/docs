---
description: "Learn more about: ICorConfiguration::AddDebuggerSpecialThread Method"
title: "ICorConfiguration::AddDebuggerSpecialThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorConfiguration.AddDebuggerSpecialThread"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AddDebuggerSpecialThread"
helpviewer_keywords: 
  - "AddDebuggerSpecialThread method [.NET Framework hosting]"
  - "ICorConfiguration::AddDebuggerSpecialThread method [.NET Framework hosting]"
ms.assetid: 1f1e3239-438e-4be9-a3bb-7d0722d3a76d
topic_type: 
  - "apiref"
---
# ICorConfiguration::AddDebuggerSpecialThread Method

Indicates to the debugging services that a particular thread should be allowed to continue executing while the debugger has an application stopped during managed or unmanaged debugging scenarios.  
  
## Syntax  
  
```cpp  
HRESULT AddDebuggerSpecialThread (  
    [in] DWORD dwSpecialThreadId  
);  
```  
  
## Parameters  

 `dwSpecialThreadId`  
 [in] The ID of the thread that should be allowed to continue executing.  
  
## Remarks  

 The specified thread will not be allowed to run managed code or enter the runtime in any way. An example of such a thread would be an in-process thread to support legacy script debuggers.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorConfiguration Interface](icorconfiguration-interface.md)
