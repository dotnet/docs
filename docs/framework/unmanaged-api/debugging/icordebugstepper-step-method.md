---
description: "Learn more about: ICorDebugStepper::Step Method"
title: "ICorDebugStepper::Step Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugStepper.Step"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper::Step"
helpviewer_keywords: 
  - "Step method, ICorDebugStepper interface [.NET Framework debugging]"
  - "ICorDebugStepper::Step method [.NET Framework debugging]"
ms.assetid: 38c1940b-ada1-40ba-8295-4c0833744e1e
topic_type: 
  - "apiref"
---
# ICorDebugStepper::Step Method

Causes this ICorDebugStepper to single-step through its containing thread, and optionally, to continue single-stepping through functions that are called within the thread.  
  
## Syntax  
  
```cpp  
HRESULT Step (  
    [in] BOOL   bStepIn  
);  
```  
  
## Parameters  

 `bStepIn`  
 [in] Set to `true` to step into a function that is called within the thread. Set to `false` to step over the function.  
  
## Remarks  

 The step completes when the common language runtime performs the next managed instruction in this stepper's frame. If `Step` is called on a stepper, which is not in managed code, the step will complete when the next managed code instruction is executed by the thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
