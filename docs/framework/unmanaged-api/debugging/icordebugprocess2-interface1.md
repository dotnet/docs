---
description: "Learn more about: ICorDebugProcess2 Interface"
title: "ICorDebugProcess2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess2"
helpviewer_keywords: 
  - "ICorDebugProcess2 interface [.NET Framework debugging]"
ms.assetid: 73332138-5fea-441f-b893-61af87d45a42
topic_type: 
  - "apiref"
---
# ICorDebugProcess2 Interface

A logical extension of the ICorDebugProcess interface, which represents a process running managed code.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ClearUnmanagedBreakpoint Method](icordebugprocess2-clearunmanagedbreakpoint-method.md)|Removes a breakpoint at the specified offset that was set by an earlier call to `ICorDebugProcess2::SetUnmanagedBreakpoint`.|  
|[GetDesiredNGENCompilerFlags Method](icordebugprocess2-getdesiredngencompilerflags-method.md)|Gets the flags that must be set for the common language runtime (CLR) to load the image into the process referenced by this `ICorDebugProcess2`.|  
|[GetReferenceValueFromGCHandle Method](icordebugprocess2-getreferencevaluefromgchandle-method.md)|Gets a reference pointer to the specified managed object that has a garbage collection handle.|  
|[GetThreadForTaskID Method](icordebugprocess2-getthreadfortaskid-method.md)|Gets the thread upon which the task with the specified identifier is executing.|  
|[GetVersion Method](icordebugprocess2-getversion-method.md)|Gets the version of the CLR upon which the process being debugged is running.|  
|[SetDesiredNGENCompilerFlags Method](icordebugprocess2-setdesiredngencompilerflags-method.md)|Sets the flags that are required for the just-in-time (JIT) compiler to load an image into the process being debugged.|  
|[SetUnmanagedBreakpoint Method](icordebugprocess2-setunmanagedbreakpoint-method.md)|Sets an unmanaged breakpoint at the specified native image offset.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
