---
title: "ICorDebugThread::SetDebugState Method"
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
  - "ICorDebugThread.SetDebugState"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::SetDebugState"
helpviewer_keywords: 
  - "ICorDebugThread::SetDebugState method [.NET Framework debugging]"
  - "SetDebugState method [.NET Framework debugging]"
ms.assetid: 6382bdf6-d488-4952-b653-cb09b6e1c6c2
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::SetDebugState Method
Sets flags that describe the debugging state of this ICorDebugThread.  
  
## Syntax  
  
```  
HRESULT SetDebugState (  
    [in] CorDebugThreadState state  
);  
```  
  
#### Parameters  
 `state`  
 [in] A bitwise combination of CorDebugThreadState enumeration values that specify the debugging state of this thread.  
  
## Remarks  
 `SetDebugState` sets the current debug state of the thread. (The "current debug state" represents the debug state if the process were to be continued, not the actual current state.) The normal value for this is THREAD_RUNNING. Only the debugger can affect the debug state of a thread. Debug states do last across continues, so if you want to keep a thread THREAD_SUSPENDed over multiple continues, you can set it once and thereafter not have to worry about it. Suspending threads and resuming the process can cause deadlocks, though it's usually unlikely. This is an intrinsic quality of threads and processes and is by-design. A debugger can asynchronously break and resume the threads to break the deadlock. If the thread's user state includes USER_UNSAFE_POINT, then the thread may block a garbage collection (GC). This means the suspended thread has a much higher chance of causing a deadlock. This may not affect debug events already queued. Thus a debugger should drain the entire event queue (by calling [ICorDebugController::HasQueuedCallbacks](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-hasqueuedcallbacks-method.md)) before suspending or resuming threads. Else it may get events on a thread that it believes it has already suspended.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
