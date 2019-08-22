---
title: "ICorDebugEval::GetThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEval.GetThread"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::GetThread"
helpviewer_keywords: 
  - "GetThread method, ICorDebugEval interface [.NET Framework debugging]"
  - "ICorDebugEval::GetThread method [.NET Framework debugging]"
ms.assetid: 57163b0d-c8a7-44af-9078-e7a895d29f9a
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugEval::GetThread Method
Gets the thread in which this evaluation is executing or will execute.  
  
## Syntax  
  
```cpp  
HRESULT GetThread (  
    [out] ICorDebugThread   **ppThread  
);  
```  
  
## Parameters  
 `ppThread`  
 [out] A pointer to the address of an ICorDebugThread object that represents the thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
