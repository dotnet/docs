---
description: "Learn more about: ICorDebugFrame::CreateStepper Method"
title: "ICorDebugFrame::CreateStepper Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFrame.CreateStepper"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::CreateStepper"
helpviewer_keywords: 
  - "ICorDebugFrame::CreateStepper method [.NET Framework debugging]"
  - "CreateStepper method, ICorDebugFrame interface [.NET Framework debugging]"
ms.assetid: 689e7f28-20c1-4d5c-9baa-17441cd63a88
topic_type: 
  - "apiref"
---
# ICorDebugFrame::CreateStepper Method

Gets a stepper that allows the debugger to perform stepping operations relative to this ICorDebugFrame.  
  
## Syntax  
  
```cpp  
HRESULT CreateStepper (  
    [out] ICorDebugStepper   **ppStepper  
);  
```  
  
## Parameters  

 `ppStepper`  
 [out] A pointer to the address of an ICorDebugStepper object that allows the debugger to perform stepping operations relative to the current frame.  
  
## Remarks  

 If the frame is not active, the stepper object will typically have to return to the frame before the step is completed.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
