---
title: "ICorDebugStepper::StepRange Method"
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
  - "ICorDebugStepper.StepRange"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper::StepRange"
helpviewer_keywords: 
  - "StepRange method [.NET Framework debugging]"
  - "ICorDebugStepper::StepRange method [.NET Framework debugging]"
ms.assetid: b9776112-6e6d-4708-892a-8873db02e16f
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStepper::StepRange Method
Causes this ICorDebugStepper to single-step through its containing thread, and to return when it reaches code beyond the last of the specified ranges.  
  
## Syntax  
  
```  
HRESULT StepRange (  
    [in] BOOL     bStepIn,  
    [in, size_is(cRangeCount)] COR_DEBUG_STEP_RANGE ranges[],  
    [in] ULONG32  cRangeCount  
);  
```  
  
#### Parameters  
 `bStepIn`  
 [in] Set to `true` to step into a function that is called within the thread. Set to `false` to step over the function.  
  
 `ranges`  
 [in] An array of COR_DEBUG_STEP_RANGE structures, each of which specifies a range.  
  
 `cRangeCount`  
 [in] The size of the `ranges` array.  
  
## Remarks  
 The `StepRange` method works like the [ICorDebugStepper::Step](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-step-method.md) method, except that it does not complete until code outside the given range is reached.  
  
 This can be more efficient than stepping one instruction at a time. Ranges are specified as a list of offset pairs from the start of the stepper's frame.  
  
 Ranges are relative to the Microsoft intermediate language (MSIL) code of a method. Call [ICorDebugStepper::SetRangeIL](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-setrangeil-method.md) with `false` to make the ranges relative to the native code of a method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
