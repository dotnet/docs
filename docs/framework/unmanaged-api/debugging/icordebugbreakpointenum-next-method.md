---
description: "Learn more about: ICorDebugBreakpointEnum::Next Method"
title: "ICorDebugBreakpointEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugBreakpointEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBreakpointEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorDebugBreakpointEnum interface [.NET Framework debugging]"
  - "ICorDebugBreakpointEnum::Next method [.NET Framework debugging]"
ms.assetid: 2e6bbaea-79ba-448c-a0e3-7c90fc7c2939
topic_type: 
  - "apiref"
---
# ICorDebugBreakpointEnum::Next Method

Gets the specified number of ICorDebugBreakpoint instances from the enumeration, starting at the current position.  
  
## Syntax  
  
```cpp  
HRESULT Next (  
    [in] ULONG  celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugBreakpoint *breakpoints[],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of `ICorDebugBreakpoint` instances to be retrieved.  
  
 `breakpoints`  
 [out] An array of pointers, each of which points to an `ICorDebugBreakpoint` object that represents a breakpoint.  
  
 `pceltFetched`  
 [out] A pointer to the number of `ICorDebugBreakpoint` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
