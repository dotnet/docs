---
description: "Learn more about: ICorDebugManagedCallback::CreateThread Method"
title: "ICorDebugManagedCallback::CreateThread Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.CreateThread"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::CreateThread method"
helpviewer_keywords:
  - "ICorDebugManagedCallback::CreateThread method [.NET debugging]"
  - "CreateThread method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::CreateThread Method

Notifies the debugger that a thread has started executing managed code.

## Syntax

```cpp
HRESULT CreateThread (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugThread    *thread
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the thread.

 `thread`
 [in] A pointer to an ICorDebugThread object that represents the thread.

## Remarks

 The thread will be positioned at the first managed code instruction to be executed.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
