---
title: "ICorDebugUnmanagedCallback::DebugEvent Method"
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
  - "ICorDebugUnmanagedCallback.DebugEvent"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugUnmanagedCallback::DebugEvent"
helpviewer_keywords: 
  - "DebugEvent method [.NET Framework debugging]"
  - "ICorDebugUnmanagedCallback::DebugEvent method [.NET Framework debugging]"
ms.assetid: be9cab04-65ec-44d5-a39a-f90709fdd043
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugUnmanagedCallback::DebugEvent Method
Notifies the debugger that a native event has been fired.  
  
## Syntax  
  
```  
HRESULT DebugEvent (  
    [in] LPDEBUG_EVENT  pDebugEvent,  
    [in] BOOL           fOutOfBand  
);  
```  
  
#### Parameters  
 `pDebugEvent`  
 [in] A pointer to the native event.  
  
 `fOutOfBand`  
 [in] `true`, if interaction with the managed process state is impossible after an unmanaged event occurs, until the debugger calls [ICorDebugController::Continue](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-continue-method.md); otherwise, `false`.  
  
## Remarks  
 If the thread being debugged is a Win32 thread, do not use any members of the Win32 debugging interface. You can call `ICorDebugController::Continue` only on a Win32 thread and only when continuing past an out-of-band event.  
  
 The `DebugEvent` callback does not follow the standard rules for callbacks. When you call `DebugEvent`, the process will be in the raw, OS-debug stopped state. The process will not be synchronized. It will automatically enter the synchronized state when necessary to satisfy requests for information about managed code, which may result in other nested `DebugEvent` callbacks.  
  
 Call [ICorDebugProcess::ClearCurrentException](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-clearcurrentexception-method.md) on the process to ignore an exception event before continuing the process. Calling this method sends DBG_CONTINUE instead of DBG_EXCEPTION_NOT_HANDLED on the continue request, and automatically clears out-of-band breakpoints and single-step exceptions. Out-of-band events can come at any time, even when the application being debugged appears stopped and when an outstanding in-band event already exists.  
  
 In the .NET Framework version 2.0, the debugger should immediately continue past an out-of-band breakpoint event. The debugger should be using the [ICorDebugProcess2::SetUnmanagedBreakpoint](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess2-setunmanagedbreakpoint-method.md) and [ICorDebugProcess2::ClearUnmanagedBreakpoint](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess2-clearunmanagedbreakpoint-method.md) methods to add and remove breakpoints. These methods will skip over any out-of-band breakpoints automatically. Thus, the only out-of-band breakpoints that get dispatched should be raw breakpoints that are already in the instruction stream, such as a call to the Win32 `DebugBreak` function. Do not try to use `ICorDebugProcess::ClearCurrentException`, [ICorDebugProcess::GetThreadContext](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-getthreadcontext-method.md), [ICorDebugProcess::SetThreadContext](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-setthreadcontext-method.md), or any other member of the [debugging API](../../../../docs/framework/unmanaged-api/debugging/index.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugUnmanagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugunmanagedcallback-interface.md)
