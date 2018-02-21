---
title: "ICorDebugFrame Interface1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFrame Interface1
Represents a frame on the current stack.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateStepper Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-createstepper-method.md)|Gets an ICorDebugStepper to perform stepping operations relative to this `ICorDebugFrame`.|  
|[GetCallee Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getcallee-method.md)|Gets a pointer to the `ICorDebugFrame` in the current chain that this frame called, or returns null if this is the innermost frame in the chain.|  
|[GetCaller Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getcaller-method.md)|Gets a pointer to the `ICorDebugFrame` in the current chain that called this frame, or returns null if this is the outermost frame in the chain.|  
|[GetChain Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getchain-method.md)|Gets a pointer to the ICorDebugChain this `ICorDebugFrame` is a part of.|  
|[GetCode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getcode-method.md)|Gets a pointer to the ICorDebugCode associated with this stack frame.|  
|[GetFunction Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getfunction-method.md)|Gets a pointer to the ICorDebugFunction that contains the code associated with this stack frame.|  
|[GetFunctionToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getfunctiontoken-method.md)|Gets the metadata token for the function that contains the code associated with this stack frame.|  
|[GetStackRange Method](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getstackrange-method.md)|Gets the absolute address range of the stack frame represented by this `ICorDebugFrame`.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
