---
title: "ICorDebugController::Stop Method"
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
  - "ICorDebugController.Stop"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController::Stop"
helpviewer_keywords: 
  - "Stop method, ICorDebugController interface [.NET Framework debugging]"
  - "ICorDebugController::Stop method [.NET Framework debugging]"
ms.assetid: c34e79be-a7fb-479e-8dec-d126a4c330e5
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugController::Stop Method
Performs a cooperative stop on all threads that are running managed code in the process.  
  
## Syntax  
  
```  
HRESULT Stop (  
    [in] DWORD dwTimeoutIgnored  
);  
```  
  
#### Parameters  
 `dwTimeoutIgnored`  
 Not used.  
  
## Remarks  
 `Stop` performs a cooperative stop on all threads running managed code in the process. During a managed-only debugging session, unmanaged threads may continue to run (but will be blocked when trying to call managed code). During an interop debugging session, unmanaged threads will also be stopped. The `dwTimeoutIgnored` value is currently ignored and treated as INFINITE (-1). If the cooperative stop fails due to a deadlock, all threads are suspended and E_TIMEOUT is returned.  
  
> [!NOTE]
>  `Stop` is the only synchronous method in the debugging API. When `Stop` returns S_OK, the process is stopped. No callback is given to notify listeners of the stop. The debugger must call [ICorDebugController::Continue](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-continue-method.md) to allow the process to resume.  
  
 The debugger maintains a stop counter. When the counter goes to zero, the controller is resumed. Each call to `Stop` or each dispatched callback increments the counter. Each call to `ICorDebugController::Continue` decrements the counter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
