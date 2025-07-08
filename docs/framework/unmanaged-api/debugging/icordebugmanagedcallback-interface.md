---
description: "Learn more about: ICorDebugManagedCallback Interface"
title: "ICorDebugManagedCallback Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback"
helpviewer_keywords:
  - "ICorDebugManagedCallback interface [.NET Framework debugging]"
ms.assetid: b47f1d61-c7dc-4196-b926-0b08c94f7041
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback Interface

Provides methods to process debugger callbacks.

## Methods

|Method|Description|
|------------|-----------------|
|[Break Method](icordebugmanagedcallback-break-method.md)|Notifies the debugger when a <xref:System.Reflection.Emit.OpCodes.Break> instruction in the code stream is executed.|
|[Breakpoint Method](icordebugmanagedcallback-breakpoint-method.md)|Notifies the debugger when a breakpoint is encountered.|
|[BreakpointSetError Method](icordebugmanagedcallback-breakpointseterror-method.md)|Notifies the debugger that the common language runtime (CLR) was unable to accurately bind a breakpoint that was set before a function was just-in-time (JIT) compiled.|
|[ControlCTrap Method](icordebugmanagedcallback-controlctrap-method.md)|Notifies the debugger that a CTRL+C is trapped in the process being debugged.|
|[CreateAppDomain Method](icordebugmanagedcallback-createappdomain-method.md)|Notifies the debugger that an application domain has been created.|
|[CreateProcess Method](icordebugmanagedcallback-createprocess-method.md)|Notifies the debugger when a process has been attached or started for the first time.|
|[CreateThread Method](icordebugmanagedcallback-createthread-method.md)|Notifies the debugger that a thread has started executing managed code.|
|[DebuggerError Method](icordebugmanagedcallback-debuggererror-method.md)|Notifies the debugger that an error has occurred while attempting to handle an event from the CLR.|
|[EditAndContinueRemap Method](icordebugmanagedcallback-editandcontinueremap-method.md)|Deprecated. Notifies the debugger that a remap event has been sent to the IDE.|
|[EvalComplete Method](icordebugmanagedcallback-evalcomplete-method.md)|Notifies the debugger that an evaluation has been completed.|
|[EvalException Method](icordebugmanagedcallback-evalexception-method.md)|Notifies the debugger that an evaluation has been terminated with an unhandled exception.|
|[Exception Method](icordebugmanagedcallback-exception-method.md)|Notifies the debugger that an exception has been thrown from managed code.|
|[ExitAppDomain Method](icordebugmanagedcallback-exitappdomain-method.md)|Notifies the debugger that an application domain has exited.|
|[ExitProcess Method](icordebugmanagedcallback-exitprocess-method.md)|Notifies the debugger that a process has exited.|
|[ExitThread Method](icordebugmanagedcallback-exitthread-method.md)|Notifies the debugger that a thread that was executing managed code has exited.|
|[LoadAssembly Method](icordebugmanagedcallback-loadassembly-method.md)|Notifies the debugger that a CLR assembly has been successfully loaded.|
|[LoadClass Method](icordebugmanagedcallback-loadclass-method.md)|Notifies the debugger that a class has been loaded.|
|[LoadModule Method](icordebugmanagedcallback-loadmodule-method.md)|Notifies the debugger that a CLR module has been successfully loaded.|
|[LogMessage Method](icordebugmanagedcallback-logmessage-method.md)|Notifies the debugger that a CLR managed thread has called a method in the <xref:System.Diagnostics.EventLog> class to log an event.|
|[LogSwitch Method](icordebugmanagedcallback-logswitch-method.md)|Notifies the debugger that a CLR managed thread has called a method in the <xref:System.Diagnostics.Switch> class to create, modify, or delete a debugging/tracing switch.|
|[NameChange Method](icordebugmanagedcallback-namechange-method.md)|Notifies the debugger that the name of either an application domain or thread has changed.|
|[StepComplete Method](icordebugmanagedcallback-stepcomplete-method.md)|Notifies the debugger that a step has completed.|
|[UnloadAssembly Method](icordebugmanagedcallback-unloadassembly-method.md)|Notifies the debugger that a CLR assembly has been unloaded.|
|[UnloadClass Method](icordebugmanagedcallback-unloadclass-method.md)|Notifies the debugger that a class is being unloaded.|
|[UnloadModule Method](icordebugmanagedcallback-unloadmodule-method.md)|Notifies the debugger that a CLR module (DLL) has been unloaded.|
|[UpdateModuleSymbols Method](icordebugmanagedcallback-updatemodulesymbols-method.md)|Notifies the debugger that the symbols for a CLR module have changed.|

## Remarks

 All callbacks are serialized, called in the same thread, and called with the process in the synchronized state.

 Each callback implementation must call [ICorDebugController::Continue](icordebugcontroller-continue-method.md) to resume execution. If `ICorDebugController::Continue` is not called before the callback returns, the process will remain stopped and no more event callbacks will occur until `ICorDebugController::Continue` is called.

 A debugger must implement [ICorDebugManagedCallback2](icordebugmanagedcallback2-interface.md) if it is debugging .NET Framework version 2.0 applications. An instance of `ICorDebugManagedCallback` or `ICorDebugManagedCallback2` is passed as the callback object to [ICorDebug::SetManagedHandler](icordebug-setmanagedhandler-method.md).

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [ICorDebug Interface](icordebug-interface.md)
- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
