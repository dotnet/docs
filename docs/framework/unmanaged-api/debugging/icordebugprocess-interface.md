---
description: "Learn more about: ICorDebugProcess Interface"
title: "ICorDebugProcess Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess"
helpviewer_keywords:
  - "ICorDebugProcess interface [.NET Framework debugging]"
ms.assetid: be86f4b5-418a-4c5c-a67c-97148c65ed8c
topic_type:
  - "apiref"
---
# ICorDebugProcess Interface

Represents a process that is executing managed code. This interface is a subclass of ICorDebugController.

## Methods

|Method|Description|
|------------|-----------------|
|[ClearCurrentException Method](icordebugprocess-clearcurrentexception-method.md)|Clears the current unmanaged exception on the given thread.|
|[EnableLogMessages Method](icordebugprocess-enablelogmessages-method.md)|Enables and disables the sending of log messages to the debugger.|
|[EnumerateAppDomains Method](icordebugprocess-enumerateappdomains-method.md)|Enumerates all of the application domains in the process.|
|[EnumerateObjects Method](icordebugprocess-enumerateobjects-method.md)|Not implemented.|
|[GetHandle Method](icordebugprocess-gethandle-method.md)|Gets a handle to the process.|
|[GetHelperThreadID Method](icordebugprocess-gethelperthreadid-method.md)|Gets the operating system (OS) thread ID for the debugger's internal helper thread.|
|[GetID Method](icordebugprocess-getid-method.md)|Gets the operating system (OS) ID of the process.|
|[GetObject Method](icordebugprocess-getobject-method.md)|Not implemented.|
|[GetThread Method](icordebugprocess-getthread-method.md)|Gets the ICorDebugThread instance that has the specified OS thread ID.|
|[GetThreadContext Method](icordebugprocess-getthreadcontext-method.md)|Gets the context for the given thread.|
|[IsOSSuspended Method](icordebugprocess-isossuspended-method.md)|Determines whether the thread has been suspended as a result of the debugger stopping the process.|
|[IsTransitionStub Method](icordebugprocess-istransitionstub-method.md)|Determines whether an address is inside a stub that will cause a transition to managed code.|
|[ModifyLogSwitch Method](icordebugprocess-modifylogswitch-method.md)|Sets the severity level of the specified log switch.|
|[ReadMemory Method](icordebugprocess-readmemory-method.md)|Reads memory from the process.|
|[SetThreadContext Method](icordebugprocess-setthreadcontext-method.md)|Sets the context for the given thread.|
|[ThreadForFiberCookie Method](icordebugprocess-threadforfibercookie-method.md)|Deprecated.|
|[WriteMemory Method](icordebugprocess-writememory-method.md)|Writes data to an area of memory in the process.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [ICorDebug Interface](icordebug-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
