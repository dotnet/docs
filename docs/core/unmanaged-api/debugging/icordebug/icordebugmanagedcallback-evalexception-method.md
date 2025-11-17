---
description: "Learn more about: ICorDebugManagedCallback::EvalException Method"
title: "ICorDebugManagedCallback::EvalException Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.EvalException"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::EvalException"
helpviewer_keywords:
  - "EvalException method [.NET debugging]"
  - "ICorDebugManagedCallback::EvalException method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::EvalException Method

Notifies the debugger that an evaluation has terminated with an unhandled exception.

## Syntax

```cpp
HRESULT EvalException (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugThread    *pThread,
    [in] ICorDebugEval      *pEval
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain in which the evaluation terminated.

 `pThread`
 [in] A pointer to an ICorDebugThread object that represents the thread in which the evaluation terminated.

 `pEval`
 [in] A pointer to an ICorDebugEval object that represents the code that performed the evaluation.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
