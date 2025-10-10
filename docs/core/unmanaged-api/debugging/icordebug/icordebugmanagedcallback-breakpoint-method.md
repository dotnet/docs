---
description: "Learn more about: ICorDebugManagedCallback::Breakpoint Method"
title: "ICorDebugManagedCallback::Breakpoint Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.Breakpoint"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::Breakpoint"
helpviewer_keywords:
  - "ICorDebugManagedCallback::Breakpoint method [.NET debugging]"
  - "Breakpoint method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::Breakpoint Method

Notifies the debugger when a breakpoint is encountered.

## Syntax

```cpp
HRESULT Breakpoint (
    [in] ICorDebugAppDomain  *pAppDomain,
    [in] ICorDebugThread     *pThread,
    [in] ICorDebugBreakpoint *pBreakpoint
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the breakpoint.

 `pThread`
 [in] A pointer to an ICorDebugThread object that represents the thread that contains the breakpoint.

 `pBreakpoint`
 [in] A pointer to an ICorDebugBreakpoint object that represents the breakpoint.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
