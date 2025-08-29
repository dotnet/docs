---
description: "Learn more about: ICorDebugManagedCallback::BreakpointSetError Method"
title: "ICorDebugManagedCallback::BreakpointSetError Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.BreakpointSetError"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::BreakpointSetError"
helpviewer_keywords:
  - "BreakpointSetError method [.NET debugging]"
  - "ICorDebugManagedCallback::BreakpointSetError method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::BreakpointSetError Method

Notifies the debugger that the common language runtime was unable to accurately bind a breakpoint that was set before a function was just-in-time (JIT) compiled.

## Syntax

```cpp
HRESULT BreakpointSetError (
    [in] ICorDebugAppDomain  *pAppDomain,
    [in] ICorDebugThread     *pThread,
    [in] ICorDebugBreakpoint *pBreakpoint,
    [in] DWORD                dwError
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the unbound breakpoint.

 `pThread`
 [in] A pointer to an ICorDebugThread object that represents the thread that contains the unbound breakpoint.

 `pBreakpoint`
 [in] A pointer to an ICorDebugBreakpoint object that represents the unbound breakpoint.

 `dwError`
 [in] An integer that indicates the error.

## Remarks

The given breakpoint will never be hit. The debugger should deactivate and rebind it.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
