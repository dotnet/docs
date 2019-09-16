---
title: "ICorDebugFunction::GetModule Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunction.GetModule"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::GetModule"
helpviewer_keywords: 
  - "ICorDebugFunction::GetModule method [.NET Framework debugging]"
  - "GetModule method, ICorDebugFunction interface [.NET Framework debugging]"
ms.assetid: 5031a5d3-2564-412a-9007-e36d4631308a
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugFunction::GetModule Method
Gets the module in which this function is defined.  
  
## Syntax  
  
```cpp  
HRESULT GetModule (  
    [out] ICorDebugModule **ppModule  
);  
```  
  
## Parameters  
 `ppModule`  
 [out] A pointer to the address of an ICorDebugModule object that represents the module in which this function is defined.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
