---
description: "Learn more about: ICorDebugController::SetAllThreadsDebugState Method"
title: "ICorDebugController::SetAllThreadsDebugState Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugController.SetAllThreadsDebugState"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugController::SetAllThreadsDebugState"
helpviewer_keywords:
  - "SetAllThreadsDebugState method [.NET debugging]"
  - "ICorDebugController::SetAllThreadsDebugState method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugController::SetAllThreadsDebugState Method

Sets the debug state of all managed threads in the process.

## Syntax

```cpp
HRESULT SetAllThreadsDebugState (
    [in] CorDebugThreadState  state,
    [in] ICorDebugThread      *pExceptThisThread
);
```

## Parameters

 `state`
 [in] A value of the "CorDebugThreadState" enumeration that specifies the state of the thread for debugging.

 `pExceptThisThread`
 [in] A pointer to an "ICorDebugThread" object that represents a thread to be exempted from the debug state setting. If this value is null, no thread is exempted.

## Remarks

The `SetAllThreadsDebugState` method may affect threads that are not visible via [EnumerateThreads Method](icordebugcontroller-enumeratethreads-method.md), so threads that were suspended with the `SetAllThreadsDebugState` method will need to be resumed with the `SetAllThreadsDebugState` method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
