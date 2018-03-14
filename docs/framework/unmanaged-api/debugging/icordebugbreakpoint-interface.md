---
title: "ICorDebugBreakpoint Interface1"
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
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugBreakpoint Interface1
Represents a breakpoint in a function, or a watch point on a value.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Activate Method](../../../../docs/framework/unmanaged-api/debugging/icordebugbreakpoint-activate-method.md)|Sets the active state of this `ICorDebugBreakpoint`.|  
|[IsActive Method](../../../../docs/framework/unmanaged-api/debugging/icordebugbreakpoint-isactive-method.md)|Gets a value that indicates whether this `ICorDebugBreakpoint` is active.|  
  
## Remarks  
 Breakpoints do not directly support conditional expressions. If such functionality is desired, a debugger must implement it on top of `ICorDebugBreakpoint`.  
  
 The ICorDebugFunctionBreakpoint interface extends `ICorDebugBreakpoint` to support breakpoints within functions.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
