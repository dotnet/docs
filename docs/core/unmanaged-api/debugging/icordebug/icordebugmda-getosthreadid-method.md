---
description: "Learn more about: ICorDebugMDA::GetOSThreadId Method"
title: "ICorDebugMDA::GetOSThreadId Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugMDA.GetOSThreadId"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugMDA::GetOSThreadId"
helpviewer_keywords:
  - "ICorDebugMDA::GetOSThreadId method [.NET debugging]"
  - "GetOSThreadId method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugMDA::GetOSThreadId Method

Gets the operating system (OS) thread identifier upon which the managed debugging assistant (MDA) represented by [ICorDebugMDA](icordebugmda-interface.md) is executing.

## Syntax

```cpp
HRESULT GetOSThreadId (
    [out] DWORD    *pOsTid
);
```

## Parameters

 `pOsTid`
 [out] A pointer to the OS thread identifier.

## Remarks

 The OS thread is used instead of an ICorDebugThread to allow for situations in which an MDA is fired either on a native thread or on a managed thread that has not yet entered managed code.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugMDA Interface](icordebugmda-interface.md)
- [Diagnose Errors with Managed Debugging Assistants](../../../../framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
