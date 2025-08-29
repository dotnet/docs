---
description: "Learn more about: ICorDebugManagedCallback::ExitThread Method"
title: "ICorDebugManagedCallback::ExitThread Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.ExitThread"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::ExitThread"
helpviewer_keywords:
  - "ExitThread method [.NET debugging]"
  - "ICorDebugManagedCallback::ExitThread method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::ExitThread Method

Notifies the debugger that a thread that was executing managed code has exited.

## Syntax

```cpp
HRESULT ExitThread (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugThread    *thread
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the managed thread.

 `thread`
 [in] A pointer to an ICorDebugThread object that represents the managed thread.

## Remarks

Once the `ExitThread` callback is fired, the thread will no longer appear in thread enumerations.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
