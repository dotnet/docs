---
description: "Learn more about: ICorDebugController Interface"
title: "ICorDebugController Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugController"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController"
helpviewer_keywords: 
  - "ICorDebugController interface [.NET Framework debugging]"
ms.assetid: dbb1c4dc-269a-459b-ab1d-6c70788782ce
topic_type: 
  - "apiref"
---
# ICorDebugController Interface

Represents a scope, either a <xref:System.Diagnostics.Process> or an <xref:System.AppDomain>, in which code execution context can be controlled.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`ICorDebugController::CanCommitChanges`|This method is obsolete.|  
|`ICorDebugController::CommitChanges`|This method is obsolete.|  
|[Continue Method](icordebugcontroller-continue-method.md)|Resumes execution of managed threads after a call to [ICorDebugController::Stop](icordebugcontroller-stop-method.md).|  
|[Detach Method](icordebugcontroller-detach-method.md)|Detaches the debugger from the process or application domain.|  
|[EnumerateThreads Method](icordebugcontroller-enumeratethreads-method.md)|Gets an enumerator for the active managed threads in the process.|  
|[HasQueuedCallbacks Method](icordebugcontroller-hasqueuedcallbacks-method.md)|Gets a value that indicates whether any managed callbacks are currently queued for the specified thread.|  
|[IsRunning Method](icordebugcontroller-isrunning-method.md)|Gets a value that indicates whether the threads in the process are currently running freely.|  
|[SetAllThreadsDebugState Method](icordebugcontroller-setallthreadsdebugstate-method.md)|Sets the debug state of all managed threads in the process.|  
|[Stop Method](icordebugcontroller-stop-method.md)|Performs a cooperative stop on all threads that are running managed code in the process.|  
|[Terminate Method](icordebugcontroller-terminate-method.md)|Terminates the process with the specified exit code.|  
  
## Remarks  

 If `ICorDebugController` is controlling a process, the scope includes all threads of the process. If `ICorDebugController` is controlling an application domain, the scope includes only the threads of that particular application domain.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
