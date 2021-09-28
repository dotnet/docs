---
description: "Learn more about: ICorDebugBreakpoint::IsActive Method"
title: "ICorDebugBreakpoint::IsActive Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugBreakpoint.IsActive"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBreakpoint::IsActive"
helpviewer_keywords: 
  - "ICorDebugBreakpoint::IsActive method [.NET Framework debugging]"
  - "IsActive method, ICorDebugBreakpoint interface [.NET Framework debugging]"
ms.assetid: 06e583d6-d88a-4ff5-bb95-5c48618a461c
topic_type: 
  - "apiref"
---
# ICorDebugBreakpoint::IsActive Method

Gets a value that indicates whether this `ICorDebugBreakpoint` is active.  
  
## Syntax  
  
```cpp  
HRESULT IsActive (  
    [out] BOOL *pbActive  
);  
```  
  
## Parameters  

 `pbActive`  
 [out] `true` if this breakpoint is active; otherwise, `false`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
