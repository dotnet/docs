---
description: "Learn more about: ICorDebugVariableHomeEnum Interface"
title: "ICorDebugVariableHomeEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugVariableHomeEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHomeEnum"
helpviewer_keywords: 
  - "ICorDebugVariableHomeEnum interface [.NET Framework debugging]"
ms.assetid: c312ae6d-c8dc-48d6-9f1e-ead515c88fdf
topic_type: 
  - "apiref"
---
# ICorDebugVariableHomeEnum Interface

Provides an enumerator to the local variables and arguments in a function.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](icordebugvariablehomeenum-next-method.md)|Gets the specified number of [ICorDebugVariableHome](icordebugvariablehome-interface.md) instances that contain information about the local variables and arguments in a function.|  
  
## Remarks  

 The `ICorDebugVariableHomeEnum` interface implements the ICorDebugEnum interface.  
  
 An `ICorDebugVariableHomeEnum` instance is populated with [ICorDebugVariableHome](icordebugvariablehome-interface.md) instances by calling the [ICorDebugCode4::EnumerateVariableHomes](icordebugcode4-enumeratevariablehomes-method.md) method. Each [ICorDebugVariableHome](icordebugvariablehome-interface.md) instance in the collection represents a local variable or argument in a function. The  [ICorDebugVariableHome](icordebugvariablehome-interface.md) objects in the collection can be enumerated by calling the [ICorDebugVariableHomeEnum::Next](icordebugvariablehomeenum-next-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
