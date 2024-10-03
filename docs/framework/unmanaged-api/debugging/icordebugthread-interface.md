---
description: "Learn more about: ICorDebugThread Interface"
title: "ICorDebugThread Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread"
helpviewer_keywords:
  - "ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: 3930fd9b-2bc3-4b72-80a0-b6eeb94d60c6
topic_type:
  - "apiref"
---
# ICorDebugThread Interface

Represents a thread in a process. The lifetime of an `ICorDebugThread` instance is the same as the lifetime of the thread it represents.

## Methods

|Method|Description|
|------------|-----------------|
|[ClearCurrentException Method](icordebugthread-clearcurrentexception-method.md)|This method is not implemented. Do not use it.|
|[CreateEval Method](icordebugthread-createeval-method.md)|Creates an ICorDebugEval object that operates on this `ICorDebugThread`.|
|[CreateStepper Method](icordebugthread-createstepper-method.md)|Creates an ICorDebugStepper object that allows stepping through the active frame in this `ICorDebugThread`.|
|[EnumerateChains Method](icordebugthread-enumeratechains-method.md)|Gets an interface pointer to an ICorDebugChainEnum enumerator that contains all the stack chains in this `ICorDebugThread`.|
|[GetActiveChain Method](icordebugthread-getactivechain-method.md)|Gets an interface pointer to the active ICorDebugChain on this `ICorDebugThread`.|
|[GetActiveFrame Method](icordebugthread-getactiveframe-method.md)|Gets an interface pointer to the active ICorDebugFrame on this `ICorDebugThread`.|
|[GetAppDomain Method](icordebugthread-getappdomain-method.md)|Gets an interface pointer to the application domain in which this `ICorDebugThread` is currently executing.|
|[GetCurrentException Method](icordebugthread-getcurrentexception-method.md)|Gets an interface pointer to an ICorDebugValue object that represents an exception currently being thrown by managed code.|
|[GetDebugState Method](icordebugthread-getdebugstate-method.md)|Gets a CorDebugThreadState value that describes the current debug state of this `ICorDebugThread`.|
|[GetHandle Method](icordebugthread-gethandle-method.md)|Gets the current handle for the active part of this `ICorDebugThread`.|
|[GetID Method](icordebugthread-getid-method.md)|Gets the current operating system identifier of the active part of this `ICorDebugThread`.|
|[GetObject Method](icordebugthread-getobject-method.md)|Gets an interface pointer to the common language runtime (CLR) thread.|
|[GetProcess Method](icordebugthread-getprocess-method.md)|Gets an interface pointer to the process of which this `ICorDebugThread` forms a part.|
|[GetRegisterSet Method](icordebugthread-getregisterset-method.md)|Gets an interface pointer to the register set associated with this `ICorDebugThread`.|
|[GetUserState Method](icordebugthread-getuserstate-method.md)|Gets a bitwise combination of CorDebugUserState values that describe the current state of this `ICorDebugThread`.|
|[SetDebugState Method](icordebugthread-setdebugstate-method.md)|Sets a bitwise combination of `CorDebugThreadState` values that describe the debugging state of this `ICorDebugThread`.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
