---
description: "Learn more about: ICorDebugBreakpoint Interface"
title: "ICorDebugBreakpoint Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBreakpoint"
helpviewer_keywords: 
  - "ICorDebugBreakpoint interface [.NET Framework debugging]"
ms.assetid: aa5ad3d7-e1bb-42af-99bc-471224e3bcaa
topic_type: 
  - "apiref"
---
# ICorDebugBreakpoint Interface

Represents a breakpoint in a function, or a watch point on a value.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Activate Method](icordebugbreakpoint-activate-method.md)|Sets the active state of this `ICorDebugBreakpoint`.|  
|[IsActive Method](icordebugbreakpoint-isactive-method.md)|Gets a value that indicates whether this `ICorDebugBreakpoint` is active.|  
  
## Remarks  

 Breakpoints do not directly support conditional expressions. If such functionality is desired, a debugger must implement it on top of `ICorDebugBreakpoint`.  
  
 The ICorDebugFunctionBreakpoint interface extends `ICorDebugBreakpoint` to support breakpoints within functions.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
