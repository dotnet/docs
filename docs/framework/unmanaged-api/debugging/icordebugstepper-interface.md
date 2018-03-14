---
title: "ICorDebugStepper Interface1"
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
  - "ICorDebugStepper"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper"
helpviewer_keywords: 
  - "ICorDebugStepper interface [.NET Framework debugging]"
ms.assetid: ed8364eb-f01b-46f6-b5e3-5dda9cae2dfe
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStepper Interface1
Represents a step in code execution that is performed by a debugger, serves as an identifier between the issuance and completion of a command, and provides a way to cancel a step.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Deactivate Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-deactivate-method.md)|Causes this `ICorDebugStepper` to cancel the last step command it received.|  
|[IsActive Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-isactive-method.md)|Gets a value that indicates whether this `ICorDebugStepper` is currently executing a step.|  
|[SetInterceptMask Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-setinterceptmask-method.md)|Sets a CorDebugIntercept value that specifies the types of code that are stepped into.|  
|[SetRangeIL Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-setrangeil-method.md)|Sets a value that indicates whether calls to [ICorDebugStepper::StepRange](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-steprange-method.md) pass argument values relative to the native code or to Microsoft intermediate language (MSIL) code of the method that is being stepped through.|  
|[SetUnmappedStopMask Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-setunmappedstopmask-method.md)|Sets a CorDebugUnmappedStop value that specifies the type of unmapped code in which execution will halt.|  
|[Step Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-step-method.md)|Causes this `ICorDebugStepper` to single-step through its containing thread, and optionally, to continue single-stepping through functions that are called within the thread.|  
|[StepOut Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-stepout-method.md)|Causes this `ICorDebugStepper` to single-step through its containing thread, and to complete when the current frame returns control to the calling frame.|  
|[StepRange Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-steprange-method.md)|Causes this `ICorDebugStepper` to single-step through its containing thread, and to return when it reaches code beyond the last of the specified ranges.|  
  
## Remarks  
 The `ICorDebugStepper` interface serves the following purposes:  
  
-   It acts as an identifier between a step command that is issued and the completion of that command.  
  
-   It provides a central interface to encapsulate all the stepping that can be performed.  
  
-   It provides a way to prematurely cancel a stepping operation.  
  
 There can be more than one stepper per thread. For example, a breakpoint may be hit while stepping over a function, and the user may wish to start a new stepping operation inside that function. It is up to the debugger to determine how to handle this situation. The debugger may want to cancel the original stepping operation or nest the two operations. The `ICorDebugStepper` interface supports both choices.  
  
 A stepper may migrate between threads if the common language runtime (CLR) makes a cross-threaded, marshaled call.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
