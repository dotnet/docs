---
description: "Learn more about: ICorDebugFunctionBreakpoint::GetFunction Method"
title: "ICorDebugFunctionBreakpoint::GetFunction Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunctionBreakpoint.GetFunction"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunctionBreakpoint::GetFunction"
helpviewer_keywords: 
  - "ICorDebugFunctionBreakpoint::GetFunction method [.NET Framework debugging]"
  - "GetFunction method, ICorDebugFunctionBreakpoint interface [.NET Framework debugging]"
ms.assetid: 2a62dae5-dd8a-4696-b817-0e1e586c24a0
topic_type: 
  - "apiref"
---
# ICorDebugFunctionBreakpoint::GetFunction Method

Gets an interface pointer to an ICorDebugFunction that references the function in which the breakpoint is set.  
  
## Syntax  
  
```cpp  
HRESULT GetFunction (  
    [out] ICorDebugFunction  **ppFunction  
);  
```  
  
## Parameters  

 `ppFunction`  
 [out] A pointer to the address of the function in which the breakpoint is set.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
