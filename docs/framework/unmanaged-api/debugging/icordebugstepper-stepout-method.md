---
description: "Learn more about: ICorDebugStepper::StepOut Method"
title: "ICorDebugStepper::StepOut Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugStepper.StepOut"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper::StepOut"
helpviewer_keywords: 
  - "ICorDebugStepper::StepOut method [.NET Framework debugging]"
  - "StepOut method [.NET Framework debugging]"
ms.assetid: aae0f48c-4ede-4256-9251-a7fc85a229dc
topic_type: 
  - "apiref"
---
# ICorDebugStepper::StepOut Method

Causes this ICorDebugStepper to single-step through its containing thread, and to complete when the current frame returns control to the calling frame.  
  
## Syntax  
  
```cpp  
HRESULT StepOut ();  
```  
  
## Remarks  

 A `StepOut` operation will complete after returning normally from the current frame to the calling frame.  
  
 If `StepOut` is called when in unmanaged code, the step will complete when the current frame returns to the managed code that called it.  
  
 In the .NET Framework version 2.0, do not use `StepOut` with the STOP_UNMANAGED flag set because it will fail. (Use [ICorDebugStepper::SetUnmappedStopMask](icordebugstepper-setunmappedstopmask-method.md) to set flags for stepping.) Interop debuggers must step out to native code themselves.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
