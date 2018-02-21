---
title: "ICorDebugStepper::SetInterceptMask Method"
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
  - "ICorDebugStepper.SetInterceptMask"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper::SetInterceptMask"
helpviewer_keywords: 
  - "SetInterceptMask method [.NET Framework debugging]"
  - "ICorDebugStepper::SetInterceptMask method [.NET Framework debugging]"
ms.assetid: 6245e2ae-5cc2-43ff-8cc1-71953d12113a
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStepper::SetInterceptMask Method
Sets a value that specifies the types of code that are stepped into.  
  
## Syntax  
  
```  
HRESULT SetInterceptMask (  
    [in] CorDebugIntercept    mask  
);  
```  
  
#### Parameters  
 `mask`  
 [in] A combination of values of the CorDebugIntercept enumeration that specifies the types of code.  
  
## Remarks  
 If the bit for an interceptor is set, the stepper will complete when the given type of intercepting code is encountered. If the bit is cleared, the intercepting code will be skipped.  
  
 The `SetInterceptMask` method may have unforeseen interactions with [ICorDebugStepper::SetUnmappedStopMask](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-setunmappedstopmask-method.md) (from the user's point of view). For example, if the only visible (that is, non-internal) portion of class initialization code lacks mapping information and STOP_NO_MAPPING_INFO isn't set (see the [ICorDebugStepper::SetUnmappedStopMask](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-setunmappedstopmask-method.md) method and the CorDebugUnmappedStop enumeration), the stepper will step over the class initialization. By default, only the INTERCEPT_NONE value of the `CorDebugIntercept` enumeration will be used.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
