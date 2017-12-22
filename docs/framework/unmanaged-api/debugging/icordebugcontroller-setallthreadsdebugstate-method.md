---
title: "ICorDebugController::SetAllThreadsDebugState Method"
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
  - "ICorDebugController.SetAllThreadsDebugState"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController::SetAllThreadsDebugState"
helpviewer_keywords: 
  - "SetAllThreadsDebugState method [.NET Framework debugging]"
  - "ICorDebugController::SetAllThreadsDebugState method [.NET Framework debugging]"
ms.assetid: bdda4bd7-4743-4d58-a22b-8067e967db95
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugController::SetAllThreadsDebugState Method
Sets the debug state of all managed threads in the process.  
  
## Syntax  
  
```  
HRESULT SetAllThreadsDebugState (  
    [in] CorDebugThreadState  state,  
    [in] ICorDebugThread      *pExceptThisThread  
);  
```  
  
#### Parameters  
 `state`  
 [in] A value of the "CorDebugThreadState" enumeration that specifies the state of the thread for debugging.  
  
 `pExceptThisThread`  
 [in] A pointer to an "ICorDebugThread" object that represents a thread to be exempted from the debug state setting. If this value is null, no thread is exempted.  
  
## Remarks  
 The `SetAllThreadsDebugState` method may affect threads that are not visible via [EnumerateThreads Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-enumeratethreads-method.md), so threads that were suspended with the `SetAllThreadsDebugState` method will need to be resumed with the `SetAllThreadsDebugState` method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
