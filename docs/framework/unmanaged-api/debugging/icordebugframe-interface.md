---
description: "Learn more about: ICorDebugFrame Interface"
title: "ICorDebugFrame Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFrame"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame"
helpviewer_keywords: 
  - "ICorDebugFrame interface [.NET Framework debugging]"
ms.assetid: 0c48f764-3c64-4602-b2f4-4ffc60eb2c65
topic_type: 
  - "apiref"
---
# ICorDebugFrame Interface

Represents a frame on the current stack.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateStepper Method](icordebugframe-createstepper-method.md)|Gets an ICorDebugStepper to perform stepping operations relative to this `ICorDebugFrame`.|  
|[GetCallee Method](icordebugframe-getcallee-method.md)|Gets a pointer to the `ICorDebugFrame` in the current chain that this frame called, or returns null if this is the innermost frame in the chain.|  
|[GetCaller Method](icordebugframe-getcaller-method.md)|Gets a pointer to the `ICorDebugFrame` in the current chain that called this frame, or returns null if this is the outermost frame in the chain.|  
|[GetChain Method](icordebugframe-getchain-method.md)|Gets a pointer to the ICorDebugChain this `ICorDebugFrame` is a part of.|  
|[GetCode Method](icordebugframe-getcode-method.md)|Gets a pointer to the ICorDebugCode associated with this stack frame.|  
|[GetFunction Method](icordebugframe-getfunction-method.md)|Gets a pointer to the ICorDebugFunction that contains the code associated with this stack frame.|  
|[GetFunctionToken Method](icordebugframe-getfunctiontoken-method.md)|Gets the metadata token for the function that contains the code associated with this stack frame.|  
|[GetStackRange Method](icordebugframe-getstackrange-method.md)|Gets the absolute address range of the stack frame represented by this `ICorDebugFrame`.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
