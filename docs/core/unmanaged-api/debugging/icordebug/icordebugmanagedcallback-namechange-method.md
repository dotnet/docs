---
description: "Learn more about: ICorDebugManagedCallback::NameChange Method"
title: "ICorDebugManagedCallback::NameChange Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.NameChange"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::NameChange"
helpviewer_keywords:
  - "ICorDebugManagedCallback::NameChange method [.NET debugging]"
  - "NameChange method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::NameChange Method

Notifies the debugger that the name of either an application domain or a thread has changed.

## Syntax

```cpp
HRESULT NameChange (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugThread    *pThread
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that either had a name change or that contains the thread that had a name change.

 `pThread`
 [in] A pointer to an ICorDebugThread object that represents the thread that had a name change.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
