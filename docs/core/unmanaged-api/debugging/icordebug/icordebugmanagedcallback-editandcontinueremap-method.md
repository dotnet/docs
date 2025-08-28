---
description: "Learn more about: ICorDebugManagedCallback::EditAndContinueRemap Method"
title: "ICorDebugManagedCallback::EditAndContinueRemap Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.EditAndContinueRemap"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::EditAndContinueRemap"
helpviewer_keywords:
  - "EditAndContinueRemap method [.NET debugging]"
  - "ICorDebugManagedCallback::EditAndContinueRemap method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::EditAndContinueRemap Method

This method has been deprecated. It notifies the debugger that a remap event has been sent to the integrated development environment (IDE).

## Syntax

```cpp
HRESULT EditAndContinueRemap (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugThread *pThread,
    [in] ICorDebugFunction *pFunction,
    [in] BOOL fAccurate
);
```

## Remarks

 The `EditAndContinueRemap` method is called when the execution of the code in an old version of an updated function has been attempted. The common language runtime calls the `EditAndContinueRemap` method to send a remap event to the IDE.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
