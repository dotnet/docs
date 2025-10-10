---
description: "Learn more about: ICorDebugController::Continue Method"
title: "ICorDebugController::Continue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugController.Continue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugController::Continue"
helpviewer_keywords:
  - "Continue method [.NET debugging]"
  - "ICorDebugController::Continue method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugController::Continue Method

Resumes execution of managed threads after a call to [Stop Method](icordebugcontroller-stop-method.md).

## Syntax

```cpp
HRESULT Continue (
    [in] BOOL fIsOutOfBand
);
```

## Parameters

`fIsOutOfBand`
[in] Set to `true` if continuing from an out-of-band event; otherwise, set to `false`.

## Remarks

`Continue` continues the process after a call to the `ICorDebugController::Stop` method.

When doing mixed-mode debugging, do not call `Continue` on the Win32 event thread unless you are continuing from an out-of-band event.

An *in-band event* is either a managed event or a normal unmanaged event during which the debugger supports interaction with the managed state of the process. In this case, the debugger receives the [ICorDebugUnmanagedCallback::DebugEvent](icordebugunmanagedcallback-debugevent-method.md) callback with its `fOutOfBand` parameter set to `false`.

An *out-of-band event* is an unmanaged event during which interaction with the managed state of the process is impossible while the process is stopped due to the event. In this case, the debugger receives the `ICorDebugUnmanagedCallback::DebugEvent` callback with its `fOutOfBand` parameter set to `true`.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 1.0
