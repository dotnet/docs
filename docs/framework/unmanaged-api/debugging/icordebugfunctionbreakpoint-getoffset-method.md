---
description: "Learn more about: ICorDebugFunctionBreakpoint::GetOffset Method"
title: "ICorDebugFunctionBreakpoint::GetOffset Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunctionBreakpoint.GetOffset"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunctionBreakpoint::GetOffset"
helpviewer_keywords: 
  - "ICorDebugFunctionBreakpoint::GetOffset method [.NET Framework debugging]"
  - "GetOffset method, ICorDebugFunctionBreakpoint interface [.NET Framework debugging]"
ms.assetid: e619eae4-3ac3-4c37-bba4-55e59989b9cb
topic_type: 
  - "apiref"
---
# ICorDebugFunctionBreakpoint::GetOffset Method

Gets the offset of the breakpoint within the function.  
  
## Syntax  
  
```cpp  
HRESULT GetOffset (  
    [out] ULONG32  *pnOffset  
);  
```  
  
## Parameters  

 `pnOffset`  
 [out] A pointer to the offset of the breakpoint.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
