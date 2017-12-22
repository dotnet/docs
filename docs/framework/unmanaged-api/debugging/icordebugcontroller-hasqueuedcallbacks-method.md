---
title: "ICorDebugController::HasQueuedCallbacks Method"
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
  - "ICorDebugController.HasQueuedCallbacks"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController::HasQueuedCallbacks"
helpviewer_keywords: 
  - "HasQueuedCallbacks method [.NET Framework debugging]"
  - "ICorDebugController::HasQueuedCallbacks method [.NET Framework debugging]"
ms.assetid: 0d6a1cd9-370b-4462-adbf-e3980e897ea7
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugController::HasQueuedCallbacks Method
Gets a value that indicates whether any managed callbacks are currently queued for the specified thread.  
  
## Syntax  
  
```  
HRESULT HasQueuedCallbacks (  
    [in] ICorDebugThread *pThread,  
    [out] BOOL           *pbQueued  
);  
```  
  
#### Parameters  
 `pThread`  
 [in] A pointer to an "ICorDebugThread" object that represents the thread.  
  
 `pbQueued`  
 [out] A pointer to a value that is `true` if any managed callbacks are currently queued for the specified thread; otherwise, `false`.  
  
 If null is specified for the `pThread` parameter, `HasQueuedCallbacks` will return `true` if there are currently managed callbacks queued for any thread.  
  
## Remarks  
 Callbacks will be dispatched one at a time, each time [ICorDebugController::Continue](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-continue-method.md) is called. The debugger can check this flag if it wants to report multiple debugging events that occur simultaneously.  
  
 When debugging events are queued, they have already occurred, so the debugger must drain the entire queue to be sure of the state of the debuggee. (Call `ICorDebugController::Continue` to drain the queue.) For example, if the queue contains two debugging events on thread *X*, and the debugger suspends thread *X* after the first debugging event and then calls `ICorDebugController::Continue`, the second debugging event for thread *X* will be dispatched although the thread has been suspended.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
