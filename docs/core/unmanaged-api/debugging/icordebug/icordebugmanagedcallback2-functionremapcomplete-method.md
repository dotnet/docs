---
description: "Learn more about: ICorDebugManagedCallback2::FunctionRemapComplete Method"
title: "ICorDebugManagedCallback2::FunctionRemapComplete Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback2.FunctionRemapComplete"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback2::FunctionRemapComplete"
helpviewer_keywords:
  - "FunctionRemapComplete method [.NET debugging]"
  - "ICorDebugManagedCallback2::FunctionRemapComplete method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback2::FunctionRemapComplete Method

Notifies the debugger that code execution has switched to a new version of an edited function.

## Syntax

```cpp
HRESULT FunctionRemapComplete (
    [in] ICorDebugAppDomain   *pAppDomain,
    [in] ICorDebugThread      *pThread,
    [in] ICorDebugFunction    *pFunction
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the edited function.

 `pThread`
 [in] A pointer to an ICorDebugThread object that represents the thread on which the remap breakpoint was encountered.

 `pFunction`
 [in] A pointer to an ICorDebugFunction object that represents the version of the function currently running on the thread.

## Remarks

This callback gives the debugger an opportunity to recreate any steppers that previously existed.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
