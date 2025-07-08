---
description: "Learn more about: ICorDebugManagedCallback2 Interface"
title: "ICorDebugManagedCallback2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback2"
helpviewer_keywords:
  - "ICorDebugManagedCallback2 interface [.NET Framework debugging]"
ms.assetid: cf7b7cfa-1c4b-4d8c-be70-4f9ed15a788b
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback2 Interface

Provides methods to support debugger exception handling and managed debugging assistants (MDAs). `ICorDebugManagedCallback2` is a logical extension of the [ICorDebugManagedCallback](icordebugmanagedcallback-interface.md) interface.

## Methods

|Method|Description|
|------------|-----------------|
|[ChangeConnection Method](icordebugmanagedcallback2-changeconnection-method.md)|Notifies the debugger that the set of tasks associated with the specified connection has changed.|
|[CreateConnection Method](icordebugmanagedcallback2-createconnection-method.md)|Notifies the debugger that a new connection has been created.|
|[DestroyConnection Method](icordebugmanagedcallback2-destroyconnection-method.md)|Notifies the debugger that the specified connection has been terminated.|
|[Exception Method](icordebugmanagedcallback2-exception-method.md)|Notifies the debugger that a search for an exception handler has started.|
|[ExceptionUnwind Method](icordebugmanagedcallback2-exceptionunwind-method.md)|Provides a status notification during the exception unwinding process.|
|[FunctionRemapComplete Method](icordebugmanagedcallback2-functionremapcomplete-method.md)|Notifies the debugger that code execution has switched to a new version of an edited function.|
|[FunctionRemapOpportunity Method](icordebugmanagedcallback2-functionremapopportunity-method.md)|Notifies the debugger that code execution has reached a sequence point in an older version of an edited function.|
|[MDANotification Method](icordebugmanagedcallback2-mdanotification-method.md)|Provides notification that code execution has encountered a managed debugging assistant (MDA) message.|

## Remarks

 The `ICorDebugManagedCallback2` interface extends the `ICorDebugManagedCallback` interface to handle new debug events introduced in .NET Framework version 2.0.

 A debugger must implement `ICorDebugManagedCallback2` if it is debugging .NET Framework 2.0 applications. An instance of `ICorDebugManagedCallback` or `ICorDebugManagedCallback2` is passed as the callback object to [ICorDebug::SetManagedHandler](icordebug-setmanagedhandler-method.md).

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [Diagnosing Errors with Managed Debugging Assistants](../../debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
