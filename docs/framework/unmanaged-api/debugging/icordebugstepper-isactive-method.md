---
description: "Learn more about: ICorDebugStepper::IsActive Method"
title: "ICorDebugStepper::IsActive Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugStepper.IsActive"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper::IsActive"
helpviewer_keywords: 
  - "IsActive method, ICorDebugStepper interface [.NET Framework debugging]"
  - "ICorDebugStepper::IsActive method [.NET Framework debugging]"
ms.assetid: 8b35e7a9-b40e-40a9-8d8e-b82e823fc575
topic_type: 
  - "apiref"
---
# ICorDebugStepper::IsActive Method

Gets a value that indicates whether this ICorDebugStepper is currently executing a step.  
  
## Syntax  
  
```cpp  
HRESULT IsActive (  
    [out] BOOL   *pbActive  
);  
```  
  
## Parameters  

 `pbActive`  
 [out] Returns `true` if the stepper is currently executing a step; otherwise, returns `false`.  
  
## Remarks  

 Any step action remains active until the debugger receives a [ICorDebugManagedCallback::StepComplete](icordebugmanagedcallback-stepcomplete-method.md) call, which automatically deactivates the stepper. A stepper may also be deactivated prematurely by calling [ICorDebugStepper::Deactivate](icordebugstepper-deactivate-method.md) before the callback condition is reached.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
